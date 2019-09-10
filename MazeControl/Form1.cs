using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Windows;
using System.IO;
using Maze3D;
using System.Threading;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MazeControl
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource CancelSource = new CancellationTokenSource();
        
        private string _ComPort = "COM5";
        public delegate void InvokeAddDataPoint(MazeDataPoint dp);
        public delegate void InvokeDelegateNoArg();
        public delegate void InvokeDelegate(string Msg);
        public delegate Task InvokeDoorDelegate(string Msg, int Delay);
        public delegate Task InvokeLcdDelegate(string Msg, int Delay);
        public delegate void MazeDisplayInvokeDelegate(string Msg, bool Status);
        public delegate void MazeDisplayDoorDelegate(string Name);
        private MazeController Maze; 
        private string ScriptFolder = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\MazeControl";
        private string ResultsFolder = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\MazeControl\Results";
        Maze3DControl MazeDisplay;
        ScriptMachine ScriptFSM = null;
        private const string SCRIPT_TEMPLATE = "ScriptTemplate.xml";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Directory.CreateDirectory(ScriptFolder);
                Directory.CreateDirectory(ResultsFolder);
                Properties.Settings.Default.Reload();
                ComPort = Properties.Settings.Default.ComPort;
                MazeDisplay = mazeDisplayHost1.MazeDisplay;
                MazeDisplay.DoorChanged += new RoutedEventHandler(Door_DoorChanged);
                MazeDisplay.SensorChanged += new RoutedEventHandler(Sensor_SensorChanged);
                MazeDisplay.DialChanged += new RoutedEventHandler(Dial_DialChanged);
               
                ScriptEditor.ScriptFolder = ScriptFolder;
                ScriptEditor.NewScriptCreated += ScriptEditor_NewScriptCreated;
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void ScriptEditor_NewScriptCreated(object sender, string e)
        {
            controlPanel1.CurrentScript = Path.GetFileNameWithoutExtension(e);
        }

        //private void Item_CheckedChanged(object sender, EventArgs e)
        //{
        //    ToolStripMenuItem Item = (ToolStripMenuItem)sender;
        //    if (Item.Checked)
        //    {
        //        ComPort = Item.Text;
        //    }
        //}

        public void CreateMaze()
        {
            try
            {
                if (Maze == null)
                {
                    Maze = new MazeController(_ComPort, CancelSource.Token);
                    Maze.LogMessage += Maze_LogMessage;
                    //Maze.DataReceived += Maze_DataReceived;
                    Maze.SensorTriggered += Maze_SensorTriggered;
                }
                else
                {
                    Maze.ComPort = _ComPort;
                }
                Maze.Open();
                
            }
            catch(Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public string ComPort
        {
            get
            {
                return _ComPort;
            }
            set
            {
                _ComPort = value;
                CreateMaze();
            }
        }

        private void Maze_SensorTriggered(object sender, string e)
        {
            MazeDisplaySensorSafe(e, true);
            if (ScriptFSM != null)
            {
                ScriptFSM.MatchSensor(e);
            }
        }

        private void Maze_DataReceived(object sender, string e)
        {
            LogMessageSafe(e);
        }

        private void Maze_LogMessage(object sender, string e)
        {
            LogMessageSafe(e);
        }

        private void Door_DoorChanged(object sender, RoutedEventArgs e)
        {
            Maze3D.MazeDoor Door = (Maze3D.MazeDoor)e.OriginalSource;
            if (Door.IsClosed)
            {
                Maze.CloseDoor(Door.Name);
            }
            else
            {
                Maze.OpenDoor(Door.Name);
            }
            ScriptEditor.ShowDoorCommand(Door);
        }

        private void Sensor_SensorChanged(object sender, RoutedEventArgs e)
        {
            Maze3D.MazeSensor Sensor = (Maze3D.MazeSensor)e.OriginalSource;
            if(Sensor.IsTriggered)
            {
                if (ScriptFSM != null)
                {
                    ScriptFSM.MatchSensor(Sensor.Name);
                }
            }
            ScriptEditor.ShowWhen(Sensor.Name);
        }

        private void Dial_DialChanged(object sender, RoutedEventArgs e)
        {
            Maze3D.MazePumpDial Dial = (Maze3D.MazePumpDial)e.OriginalSource;
            Maze.DispenseReward(Dial.Name, 1);

            ScriptEditor.ShowReward(Dial);
        }
        private void mazeDisplay1_DoorChanged(object sender, DoorChangedEventArgs e)
        {
            if (!e.IsOpen)
            {
                Maze.CloseDoor(e.Name);
            }
            else
            {
                Maze.OpenDoor(e.Name);
            }
        }

        private void LogMessageSafe(string Msg)
        {
            SerialMonitor.BeginInvoke(new InvokeDelegate(LogMessage), new string[] { Msg });
        }

        private void LogMessage(string Msg)
        {
            SerialMonitor.AppendText(Msg + "\n");
            SerialMonitor.SelectionStart = SerialMonitor.Text.Length;
            SerialMonitor.ScrollToCaret();

        }

        private void MazeDisplaySensorSafe(string Msg, bool Status)
        {
            mazeDisplayHost1.BeginInvoke(new MazeDisplayInvokeDelegate(MazeDisplaySensor), new object[] { Msg, Status });
        }

        private void MazeDisplaySensor(string Msg, bool Status)
        {
            MazeDisplay.TriggerSensor(Msg, Status);
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            if (ScriptFSM != null)
            {
                if (ScriptFSM.Status == ScriptMachine.StatusType.Running)
                {
                    mazeRunner1.SetRunTime(ScriptFSM.RunTime);
                }
                mazeRunner1.SetStatus(ScriptFSM.Status.Label());
                if (!Queues.TestQueue.IsEmpty)
                {
                    int Val = 0;
                    if (Queues.TestQueue.TryDequeue(out Val))
                    {
                        //mazeRunner1.SetTestLabel(Val);
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (Maze != null)
            {
                Maze.Close();
                CancelSource.Cancel(true);
                
                ScriptFSM?.Reset();
                mazeRunner1.SetUpdateLcdCountdownVisibleSafe(false);
                
            }
            Properties.Settings.Default.Save();
        }

        private void LoadScript(string Filename)
        {
        }

        private void RunDoorCommands(List<ScriptDoorCommand> Cmds)
        {
            foreach (ScriptDoorCommand Cmd in Cmds)
            {
                if (Cmd.Action == ScriptDoorCommand.DoorAction.Close)
                {
                    CloseDoorSafe(Cmd.Door, Cmd.Delay);
                }
                else
                {
                    OpenDoorSafe(Cmd.Door, Cmd.Delay);
                }
            }
        }

        private void RunConditionCommands(ScriptCondition Cond)
        {
            foreach (ScriptRewardCommand Cmd in Cond.RewardCommands)
            {
                DispenseRewardSafe(Cmd.Dispenser);
                //Maze.DispenseReward(Cmd.Dispenser, Cmd.Count);
            }
        }

        private void DispenseRewardSafe(string Msg)
        {
            mazeDisplayHost1.BeginInvoke(new InvokeDelegate(DispenseReward), new object[] { Msg });
        }

        private void OpenDoorSafe(string Msg, int Delay)
        {
            mazeDisplayHost1.BeginInvoke(new InvokeDoorDelegate(OpenDoor), new object[] { Msg, Delay });
        }

        private void CloseDoorSafe(string Msg, int Delay)
        {
            mazeDisplayHost1.BeginInvoke(new InvokeDoorDelegate(CloseDoor), new object[] { Msg, Delay });
        }

        private async Task OpenDoor(string Door, int Delay)
        {
            await Task.Delay(Delay * 1000 + 500);
            MazeDisplay.OpenDoor(Door);
            Maze.OpenDoor(Door);
        }

        private async Task CloseDoor(string Door, int Delay)
        {
            await Task.Delay(Delay * 1000 + 500);
            MazeDisplay.CloseDoor(Door);
            Maze.CloseDoor(Door);
        }

        private void DispenseReward(string Tray)
        {
            MazeDisplay.DispenseReward(Tray);
            Maze.DispenseReward(Tray, 1);
        }

        private void StartScript()
        {
            ResetMaze();
            ResetResults();

            //ResetResults();
            CancelSource = new CancellationTokenSource();
            ScriptFSM = new ScriptMachine(ScriptEditor.Text, CancelSource.Token);
            //RunDoorCommands(ScriptFSM.GetCurrentCommands());

            ScriptFSM.ScriptStart += ScriptFSM_ScriptStart;
            ScriptFSM.StateChanged += ScriptFSM_StateChanged;
            ScriptFSM.StateConditionTriggered += ScriptFSM_StateConditionTriggered;
            ScriptFSM.DataPointReady += ScriptFSM_DataPointReady;

            ScriptFSM.TrialComplete += ScriptFSM_TrialComplete;
            ScriptFSM.TrialSetStart += ScriptFSM_TrialSetStart;
            ScriptFSM.TrialStart += ScriptFSM_TrialStart;

            //ScriptFSM.WaitTimerDone += ScriptFSM_WaitTimerDone;
            //ScriptFSM.WaitTimerUpdate += ScriptFSM_WaitTimerUpdate;
            ScriptFSM.TrialDelay.Started += ScriptFSM_TrialDelayStart;
            ScriptFSM.TrialDelay.Tick += ScriptFSM_TrialDelayTick;
            ScriptFSM.TrialDelay.Ended += TrialDelay_Ended;

            ScriptFSM.SessionRest.Started += SessionRest_Started;
            ScriptFSM.SessionRest.Tick += SessionRest_Tick;
            ScriptFSM.SessionRest.Ended += SessionRest_Ended;

            ScriptFSM.SessionStart += ScriptFSM_SessionStart;
            //mazeRunner1.BeginInvoke(new InvokeDelegateNoArg(ResetMazeMonitor));
            ScriptFSM.SessionSetComplete += ScriptFSM_SessionSetComplete;
            ScriptFSM.SessionSetStart += ScriptFSM_SessionSetStart;
            ScriptFSM.Run();
        }

        private void SessionRest_Ended(object sender, EventArgs e)
        {
            mazeRunner1.SetUpdateLcdCountdownVisibleSafe(false);
        }

        private void TrialDelay_Ended(object sender, EventArgs e)
        {
            mazeRunner1.SetUpdateLcdCountdownVisibleSafe(false);
        }

        private void ScriptFSM_StateConditionTriggered(object sender, ScriptStateEventArgs e)
        {
            RunConditionCommands(e.Condition);
        }

        private void ScriptFSM_SessionStart(object sender, int e)
        {
            mazeRunner1.SetSessionSafe(e);
        }

        private void ScriptFSM_SessionSetStart(object sender, int e)
        {
            mazeRunner1.SessionCount = e;
        }

        private void ScriptFSM_SessionSetComplete(object sender, EventArgs e)
        {
            SaveResults();
            controlPanel1.ResetButtonsSafe();
            System.Windows.Forms.MessageBox.Show("Session Complete!");
        }

        private void SessionRest_Tick(object sender, int e)
        {
            mazeRunner1.UpdateLcdCountdownSafe("Session Rest", e);
            mazeRunner1.SetRunTimeSafe(e);
        }

        private void SessionRest_Started(object sender, int e)
        {
            mazeRunner1.UpdateLcdCountdownSafe("Session Rest", e);
            //ResetResults();
            //throw new NotImplementedException();
        }

        private void ScriptFSM_TrialDelayTick(object sender, int e)
        {
            mazeRunner1.UpdateLcdCountdownSafe("Trial Delay", e);
            mazeRunner1.SetRunTimeSafe(e);
        }

        private void ScriptFSM_TrialDelayStart(object sender, int e)
        {
            mazeRunner1.UpdateLcdCountdownSafe("Trial Delay", e);
            mazeRunner1.SetRunTimeSafe(e);
        }

        private void ScriptFSM_WaitTimerUpdate(object sender, int e)
        {
            mazeRunner1.SetRunTimeSafe(e);
        }

        private void ScriptFSM_WaitTimerDone(object sender, EventArgs e)
        {
            ScriptTrialMachine sm = (ScriptTrialMachine)sender;
            ResetMazeSafe();
            sm.RunNextTrial();
        }

        private void ScriptFSM_TrialStart(object sender, int e)
        {
            mazeRunner1.SetTrialSafe(e);
        }

        private void ScriptFSM_TrialSetStart(object sender, int Iterations)
        {
            //ResetResults();
            mazeRunner1.TrialCount = Iterations;
        }

        private void ScriptFSM_ScriptStart(object sender, ScriptMachineEventArgs e)
        {
            //ResetResults();
            ResetMazeSafe();
            RunDoorCommands(e.NextState.DoorCommands);
        }

        private void ScriptFSM_TrialComplete(object sender, int e)
        {
            ScriptTrialMachine sm = (ScriptTrialMachine)sender;
            
            if (sm.CurrentTrial < sm.TrialCount)
            {
                if (sm.PromptBetweenTrials)
                {
                    System.Windows.Forms.MessageBox.Show($"Click OK to start Trial {sm.CurrentTrial + 1} of {sm.TrialCount}");
                    ResetMaze();
                    sm.RunNextTrial();
                }
                else
                {
                    sm.StartWaitTimer();
                }
            }
        }

        private void ResetMazeMonitor()
        {
            mazeRunner1.Reset();
        }

        private void ScriptFSM_DataPointReady(object sender, MazeDataPoint e)
        {
            mazeRunner1.BeginInvoke(new InvokeAddDataPoint(AddMazeDataPoint), new object[] { e });
        }

        private void AddMazeDataPoint(MazeDataPoint dp)
        {
            mazeRunner1.AddDataPoint(dp);
        }

        private void ResetMazeSafe()
        {
            mazeDisplayHost1.BeginInvoke(new InvokeDelegateNoArg(ResetMaze));

        }
        private void ResetMaze()
        {
            MazeDisplay.Reset();
            Maze.Reset();
        }

        private void ResetResults()
        {
            mazeRunner1.Reset();
        }

        //private void startToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Maze.OpenDoor("DS0");
        //    MazeDisplay.OpenDoor("DS0");
        //}

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ResetMaze();
        }

        //private void cOM1ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    ToolStripMenuItem Item = (ToolStripMenuItem)sender;
        //    ComPort = Item.Text;
        //}

        private void ScriptFSM_StateChanged(object sender, ScriptMachineEventArgs e)
        {
            RunDoorCommands(e.NextState.DoorCommands);
            if (e.NextState.Type == ScriptState.StateType.Complete)
            {

                //System.Windows.Forms.MessageBox.Show($"Maze Complete!\nRun time: {ScriptFSM.RunTime}");
                //ScriptFSM.Reset();
            }
            else
            {
                e.NextState.Activate();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetMaze();
        }

        //private void openToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    var Dlg = new OpenFileDialog();
        //    Dlg.InitialDirectory = ScriptFolder;
        //    var Result = Dlg.ShowDialog();
        //    if (Result == DialogResult.OK)
        //    {
        //        LoadScript(Dlg.FileName);
        //    }
        //}

        private void controlPanel1_StartScript(object sender, EventArgs e)
        {
            mazeRunner1.Visible = true;
            ScriptEditor.Visible = false;
           
            StartScript();
        }

        private void controlPanel1_ResetMaze(object sender, EventArgs e)
        {
            ResetMaze();
            ResetResults();
        }

        private void controlPanel1_ComPortChanged(object sender, string e)
        {
            Properties.Settings.Default.ComPort = e;
            ComPort = e;
        }

        private void controlPanel1_ScriptChanged(object sender, string e)
        {
            ControlPanel cp = (ControlPanel)sender;
            LoadScript(cp.CurrentScriptFilename);
            ScriptEditor.Script = e;

        }

        private void CreateNewScript()
        {
            ScriptEditor.Text = File.ReadAllText(SCRIPT_TEMPLATE);
            ScriptEditor.NewScript = true;
        }

        private void controlPanel1_NewScript(object sender, EventArgs e)
        {
            CreateNewScript();
        }

        private void controlPanel1_EditScript(object sender, string e)
        {
            mazeRunner1.Visible = ScriptEditor.Visible;
            ScriptEditor.Visible = !ScriptEditor.Visible;
        }

        private void controlPanel1_StopScript(object sender, EventArgs e)
        {
            //timerUpdate.Stop();
            CancelSource.Cancel(true);
            //ResetMaze();
            //ResetResults();
            ScriptFSM.Reset();
            mazeRunner1.SetUpdateLcdCountdownVisibleSafe(false);
            

        }

        private void SaveResults()
        {
            string Folder = Path.Combine(ResultsFolder, controlPanel1.CurrentScript);
            Directory.CreateDirectory(Folder);
            string Filename = $@"{Folder}\{controlPanel1.ResultsName}.csv";
            using (StreamWriter fs = new StreamWriter(Filename))
            {
                //var Str = JsonConvert.SerializeObject(mazeRunner1.MazeDataPoints, Formatting.Indented);
                //fs.Write(Str);
                fs.WriteLine(String.Join(",", MazeDataPoint.GetFields()));
                foreach (MazeDataPoint dp in mazeRunner1.MazeDataPoints)
                {
                    fs.WriteLine(dp.ToString());
                }
            }
            
        }

        private void controlPanel1_ViewResultsFiles(object sender, string e)
        {
            if (e != null)
            {
                Process.Start(Path.Combine(ResultsFolder, e));
            }
            else
            {
                Process.Start(ResultsFolder);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mazeRunner1.SetUpdateLcdCountdownVisibleSafe(false);
        }
    }
}
