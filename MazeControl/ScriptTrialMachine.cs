using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Linq;
using System.Timers;
using System.Threading;

namespace MazeControl
{
    public class ScriptTrialMachine
    {
        //public enum StatusType
        //{
        //    Inactive,
        //    Running,
        //    Completed,
        //    Aborted
        //}
        public ScriptMachine ScriptFSM { get; set; }

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
        public int TrialCount { get; set; } = 1;
        private int _CurrentTrial = 1;
        public bool PromptBetweenTrials = false;
        public int Delay { get; set; } = 5;
        private System.Timers.Timer WaitTimer = null;
        private int WaitCount = 0;
        private CancellationToken CancelToken;

        public int CurrentTrial
        {
            get
            {
                return _CurrentTrial;
            }
            set
            {
                _CurrentTrial = value;
            }
        }
        public ScriptTrialMachine(string Xml, CancellationToken CancelToken)
        {
            this.CancelToken = CancelToken;
            LoadXml(Xml);
        }

        public ScriptTrialMachine(XElement Xml, CancellationToken CancelToken)
        {
            this.CancelToken = CancelToken;
            LoadXml(Xml);
        }

        public void LoadXml(string Xml)
        {
            XDocument Doc = XDocument.Parse(Xml);

            var Root = Doc.Element("maze");
            var Session = Root.Element("session");
            if (Session != null)
            {
                //SessionCount = Session.AttributeValue<int>("count", 1);
                //SessionRest = Session.AttributeValue<int>("rest");
                Root = Session;
            }
            //var Trial = Root.Element("trial");
            //if (Trial != null)
            //{
            //    //TrialCount = Trial.AttributeValue<int>("count", 1);
            //    //PromptBetweenTrials = Trial.AttributeValue<bool>("prompt");
            //    Root = Trial;
            //}
            LoadXml(Root);
        }

        public void LoadXml(XElement Xml)
        {
            Xml = Xml.Element("trial");
            TrialCount = Xml.AttributeValue<int>("count");
            PromptBetweenTrials = Xml.AttributeValue<bool>("prompt");
            ScriptFSM = new ScriptMachine(Xml, CancelToken);
            ScriptFSM.StateChanged += ScriptFSM_StateChanged;
            ScriptFSM.ScriptStart += ScriptFSM_ScriptStart;
            ScriptFSM.DataPointReady += ScriptFSM_DataPointReady;
            ScriptFSM.ScriptEnd += ScriptFSM_ScriptEnd;
        }

        private void ScriptFSM_ScriptEnd(object sender, ScriptEndEventArgs e)
        {
            TrialComplete?.Invoke(this, CurrentTrial);
            if (CurrentTrial >= TrialCount)
            { 
                TrialSetComplete?.Invoke(this, new EventArgs());
            }
            //else
            //{
            //    CurrentTrial++;
            //    TrialStart?.Invoke(this, CurrentTrial);
            //}
        }

        private void ScriptFSM_ScriptStart(object sender, ScriptMachineEventArgs e)
        {
            ScriptStart?.Invoke(this, e);
        }

        private void ScriptFSM_DataPointReady(object sender, MazeDataPoint e)
        {
            e.Trial = CurrentTrial;
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
            TrialSetStart?.Invoke(this, new EventArgs());
            _StartTime = DateTime.Now;
            CurrentTrial = 1;
            RunTrial();
        }

        public void RunNextTrial()
        {
            CurrentTrial++;
            RunTrial();
        }

        public void RunTrial()
        {
            TrialStart?.Invoke(this, CurrentTrial);
            ScriptFSM.Run();
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
            WaitTimerStarted?.Invoke(this, Delay);
            WaitTimer = new System.Timers.Timer(1000);
            WaitCount = Delay;
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
