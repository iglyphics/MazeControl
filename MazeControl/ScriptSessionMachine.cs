using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Linq;
using System.Threading;

namespace MazeControl
{
    public class ScriptSessionMachine
    {
        //public enum StatusType
        //{
        //    Inactive,
        //    Running,
        //    Completed,
        //    Aborted
        //}
        public ScriptTrialMachine ScriptFSM { get; set; }

        public event EventHandler SessionSetStart;
        public event EventHandler SessionSetComplete;
        public event EventHandler<int> SessionStart;
        public event EventHandler<int> SessionComplete;

        public event EventHandler TrialSetStart;
        public event EventHandler TrialSetComplete;
        public event EventHandler<int> TrialStart;
        public event EventHandler<int> TrialComplete;
        public event EventHandler<MazeDataPoint> DataPointReady;
        public event EventHandler<ScriptMachineEventArgs> ScriptStart;
        public event EventHandler<ScriptMachineEventArgs> StateChanged;
        public event EventHandler<int> WaitTimerStarted;
        public event EventHandler<int> WaitTimerUpdate;
        public event EventHandler WaitTimerDone;
        //private ScriptMachine.StatusType _Status = StatusType.Inactive;
        private DateTime _StartTime;
        private DateTime _EndTime;
        public int SessionCount { get; set; } = 1;
        private int _CurrentSession = 1;
        public bool PromptBetweenSessions = false;
        public int Rest { get; set; } = 5;
        private System.Timers.Timer WaitTimer = null;
        private int WaitCount = 0;
        private CancellationToken CancelToken;

        public int CurrentSession
        {
            get
            {
                return _CurrentSession;
            }
            set
            {
                _CurrentSession = value;
            }
        }

        public int CurrentTrial
        {
            get
            {
                return ScriptFSM.CurrentTrial;
            }
        }

        public ScriptSessionMachine(string Xml, CancellationToken CancelToken)
        {
            this.CancelToken = CancelToken;
            XDocument Doc = XDocument.Parse(Xml);
            XElement Root = Doc.Element("maze");
            LoadXml(Root);
        }

        public ScriptSessionMachine(XElement Xml, CancellationToken CancelToken)
        {
            this.CancelToken = CancelToken;
            LoadXml(Xml);
        }

        public void LoadXml(XElement Xml)
        {
            var Root = Xml.Element("session");
            if (Root != null)
            {
                SessionCount = Root.AttributeValue<int>("count", 1);
                Rest = Root.AttributeValue<int>("rest");
            }
            ScriptFSM = new ScriptTrialMachine(Root, CancelToken);
            ScriptFSM.StateChanged += ScriptFSM_StateChanged;
            ScriptFSM.ScriptStart += ScriptFSM_ScriptStart;
            ScriptFSM.DataPointReady += ScriptFSM_DataPointReady;

            ScriptFSM.TrialStart += ScriptFSM_TrialStart;
            ScriptFSM.TrialComplete += ScriptFSM_TrialComplete;
            ScriptFSM.TrialSetStart += ScriptFSM_TrialSetStart;
            ScriptFSM.TrialSetComplete += ScriptFSM_TrialSetComplete;

            ScriptFSM.WaitTimerDone += ScriptFSM_WaitTimerDone;
            ScriptFSM.WaitTimerUpdate += ScriptFSM_WaitTimerUpdate;
            //ScriptFSM.ScriptEnd += ScriptFSM_ScriptEnd;
        }

        private void ScriptFSM_TrialSetComplete(object sender, EventArgs e)
        {
            RunNextSession();
        }

        private void ScriptFSM_WaitTimerUpdate(object sender, int e)
        {
            WaitTimerUpdate?.Invoke(sender, e);
        }

        private void ScriptFSM_WaitTimerDone(object sender, EventArgs e)
        {
            WaitTimerDone?.Invoke(sender, e);
        }

        private void ScriptFSM_TrialSetStart(object sender, EventArgs e)
        {
            TrialSetStart?.Invoke(sender, e);
        }

        private void ScriptFSM_TrialComplete(object sender, int e)
        {
            TrialComplete?.Invoke(sender, e);
        }

        private void ScriptFSM_TrialStart(object sender, int e)
        {
            TrialStart?.Invoke(sender, e);
        }

        //private void ScriptFSM_ScriptEnd(object sender, ScriptEndEventArgs e)
        //{
        //    TrialComplete?.Invoke(this, CurrentTrial);
        //    if (CurrentSession >= SessionCount)
        //    { 
        //        TrialSetComplete?.Invoke(this, new EventArgs());
        //    }
        //    //else
        //    //{
        //    //    CurrentTrial++;
        //    //    TrialStart?.Invoke(this, CurrentTrial);
        //    //}
        //}

        private void ScriptFSM_ScriptStart(object sender, ScriptMachineEventArgs e)
        {
            ScriptStart?.Invoke(this, e);
        }

        private void ScriptFSM_DataPointReady(object sender, MazeDataPoint e)
        {
            e.Session = CurrentSession;
            DataPointReady?.Invoke(this, e);
        }

        private void ScriptFSM_StateChanged(object sender, ScriptMachineEventArgs e)
        {
            StateChanged?.Invoke(this, e);
            //if (e.NextState.Type == ScriptState.StateType.Complete)
            //{
            //    TrialComplete?.Invoke(this, CurrentTrial);
            //    if (CurrentTrial >= TrialCount)
            //    {

            //    }
            //}
        }

        public ScriptMachine.StatusType Status
        {
            get
            {
                return ScriptFSM.Status;
            }
            set
            {
                ScriptFSM.Status = value;
            }
        }

        public double RunTime
        {
            get
            {
                return ScriptFSM.RunTime;
            }
        }

        public void Run()
        {
            CurrentSession = 1;
            ScriptFSM.Run();
        }

        public void RunNextSession()
        {
            CurrentSession++;
            RunTrial();
        }


        public void RunNextTrial()
        {
            ScriptFSM.RunNextTrial();
        }

        public void RunTrial()
        {
            ScriptFSM.Run();
        }


        public List<ScriptDoorCommand> GetCurrentCommands()
        {
            List<ScriptDoorCommand> RetVal = new List<ScriptDoorCommand>();
           
            return RetVal;
        }

        public void Reset()
        {
         
        }

        public void Abort()
        {
            ScriptFSM.Abort();
            _EndTime = DateTime.Now;
        }

        public void MatchSensor(string Sensor)
        {
            ScriptFSM.MatchSensor(Sensor);
        }

        public void StartWaitTimer()
        {
            WaitTimerStarted?.Invoke(this, Rest);
            WaitTimer = new System.Timers.Timer(1000);
            WaitCount = Rest;
            WaitTimer.Elapsed += WaitTimer_Elapsed;
            WaitTimerUpdate?.Invoke(this, WaitCount);
            WaitTimer.Start();
        }

        private void WaitTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            WaitCount--;
            if (WaitCount <= 0)
            {
                WaitCount = 0;
                WaitTimer.Stop();
                WaitTimerDone?.Invoke(this, new EventArgs());
            }
            WaitTimerUpdate?.Invoke(this, WaitCount);
        }
    }
}
