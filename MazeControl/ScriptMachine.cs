using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Linq;
using System.Messaging;
using System.Threading;

namespace MazeControl
{
    public class ScriptMachine
    {
        public enum StatusType
        {
            Inactive,
            Running,
            Completed,
            TrialDelay,
            SessionRest,
            Aborted,
            Habituating
        }

        //public event EventHandler ScriptCompleted;
        //public event EventHandler ScriptAborted;
        //public event EventHandler<int> TrialStart;
        //public event EventHandler<int> TrialComplete;


        public event EventHandler TrialAborted;
        public event EventHandler<int> SessionRestStart;
        public event EventHandler<int> SessionRestTick;
        public event EventHandler SessionRestEnd;
        public event EventHandler<int> SessionSetStart;
        public event EventHandler SessionSetComplete;
        public event EventHandler<int> SessionStart;
        public event EventHandler<int> SessionComplete;

        public event EventHandler<int> TrialDelayStart;
        public event EventHandler<int> TrialDelayTick;
        public event EventHandler TrialDelayEnd;
        public event EventHandler<int> TrialSetStart;
        public event EventHandler TrialSetComplete;
        public event EventHandler<int> TrialStart;
        public event EventHandler<int> TrialComplete;


        public event EventHandler<MazeDataPoint> DataPointReady;
        public event EventHandler<StatusType> StatusChanged;
        public event EventHandler<ScriptMachineEventArgs> ScriptStart;
        public event EventHandler<ScriptEndEventArgs> ScriptEnd;
        public event EventHandler<ScriptMachineEventArgs> StateChanged;
        public event EventHandler<ScriptStateEventArgs> StateConditionTriggered;
        public Dictionary<string, ScriptState> States = new Dictionary<string, ScriptState>(StringComparer.CurrentCultureIgnoreCase);
        private ScriptState _CurrentState = null;
        private StatusType _Status = StatusType.Inactive;
        private DateTime _StartTime;
        private DateTime _EndTime;
        private MazeDataPoint _MazeDataPoint;
        private ScriptState StartState = null;
        public static string QueueName = @".\ScriptEngine";
        private System.Timers.Timer TestTimer;
        private LoopControl _SessionLoop;
        private LoopControl _TrialLoop;
        public CountdownTimer SessionRest { get; set; }
        public CountdownTimer TrialDelay { get; set; }
        public bool PromptBetweenTrials { get; set; } = false;
        private CancellationToken CancelToken;

        public ScriptMachine(string Text, CancellationToken ct)
        {
            CancelToken = ct;
            LoadXml(Text);

            //XDocument Doc = XDocument.Parse(Text);
            //XElement Root = Doc.Element("maze");
            //LoadXml(Root);
        }

        public ScriptMachine(XElement Xml, CancellationToken ct)
        {
            CancelToken = ct;
            LoadXml(Xml);
        }

        public ScriptState CurrentState
        {
            get
            {
                return _CurrentState;
            }
            set
            {
                _CurrentState = value;
            }
        }

        public StatusType Status
        {
            get
            {
                return _Status;
            }

            set
            {
                _Status = value;
                StatusChanged?.Invoke(this, _Status);
            }
        }

        public double RunTime
        {
            get
            {
                double RetVal = 0;
                if (_Status == StatusType.Completed || _Status == StatusType.Aborted)
                {
                    RetVal = (_EndTime - _StartTime).TotalSeconds; ;
                }
                else if(_Status == StatusType.Running)
                {
                    RetVal = (DateTime.Now - _StartTime).TotalSeconds;
                }
                return RetVal;
            }
        }

        public void LoadXml(string Xml)
        {
            XDocument Doc = XDocument.Parse(Xml);

            var Root = Doc.Element("maze");
            var Session = Root.Element("session");
            if (Session != null)
            {
                _SessionLoop = new LoopControl(Session.AttributeValue<int>("count", 1));
                SessionRest = new CountdownTimer(Session.AttributeValue<int>("rest"), "Session");
                Root = Session;
            }
            var Trial = Root.Element("trial");
            if (Trial != null)
            {
                _TrialLoop = new LoopControl(Trial.AttributeValue<int>("count", 1));
                TrialDelay = new CountdownTimer(Trial.AttributeValue<int>("delay", 1), "Trial");
                PromptBetweenTrials = Trial.AttributeValue<bool>("prompt");
                Root = Trial;
            }
            LoadXml(Root);
        }

        public void LoadXml(XElement Xml)
        {
            TestTimer = new System.Timers.Timer(1000);
            TestTimer.Elapsed += TestTimer_Elapsed;
            TestTimer.Start();
            States.Clear();
            var RuleDefs = Xml.Elements("state");
            foreach (XElement StateDef in RuleDefs)
            {
                var State = new ScriptState(StateDef);
                States[State.Name] = State;
                State.StateCompleted += State_StateCompleted;
                State.StateConditionTriggered += State_StateConditionTriggered;
            }
            Reset();
        }

        private void State_StateConditionTriggered(object sender, ScriptStateEventArgs e)
        {
            StateConditionTriggered?.Invoke(sender, e);
        }

        private void TestTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Queues.TestQueue.Enqueue(1234);
        }

        private void State_StateCompleted(object sender, ScriptStateEventArgs e)
        {
           
            CurrentState = null;
            States.TryGetValue(e.NextState, out _CurrentState);
            if (CurrentState.Type == ScriptState.StateType.Complete)
            {
                Status = StatusType.Completed;
                _EndTime = DateTime.Now;
                //_MazeDataPoint.Stop();
                //DataPointReady?.Invoke(this, _MazeDataPoint);
                //ScriptEnd?.Invoke(this, new ScriptEndEventArgs(true, RunTime));
                //CurrentState = StartState;
            }
            StateChanged?.Invoke(this, new ScriptMachineEventArgs(CurrentState));
            _MazeDataPoint.Stop();
            _MazeDataPoint.ExitAction = e.Condition.Label;
            //DataPointReady?.Invoke(this, _MazeDataPoint);
            _MazeDataPoint = new MazeDataPoint(CurrentState.Name);
            _MazeDataPoint.Session = _SessionLoop.CurrentIteration;
            _MazeDataPoint.Trial = _TrialLoop.CurrentIteration;
            DataPointReady?.Invoke(this, _MazeDataPoint);

            if (CurrentState.Type == ScriptState.StateType.Complete)
            {
                ScriptEnd?.Invoke(this, new ScriptEndEventArgs(true, RunTime));
                //CurrentState = StartState;

                if (_TrialLoop.Next() > 0)
                {
                    RunTrial();
                }
                else
                {
                    _TrialLoop.Reset();
                    if (_SessionLoop.Next() > 0)
                    {
                        RunSession();
                    }
                    else
                    {
                        SessionSetComplete?.Invoke(this, new EventArgs());
                    }
                }
            }
        }

        public void Run()
        {
            _SessionLoop.Reset();
            _TrialLoop.Reset();
            SessionSetStart?.Invoke(this, _SessionLoop.Iterations);
            RunSession();
        }

        public async void RunSession()
        {
            if (_SessionLoop.CurrentIteration > 1)
            {
                _Status = StatusType.SessionRest;
                await SessionRest.RunAsync(CancelToken);
            }
            SessionStart?.Invoke(this, _SessionLoop.CurrentIteration);
            RunTrialSet();
        }

        public void RunTrialSet()
        {
            TrialSetStart?.Invoke(this, _TrialLoop.Iterations);
            RunTrial();
        }

        public async void RunTrial()
        {
            TrialStart?.Invoke(this, _TrialLoop.CurrentIteration );
            _Status = StatusType.TrialDelay;
            try
            {
                await TrialDelay.RunAsync(CancelToken);
                if (!CancelToken.IsCancellationRequested)
                {
                    CurrentState = StartState;
                    ScriptMachineEventArgs e = new ScriptMachineEventArgs(StartState);
                    ScriptStart?.Invoke(this, e);
                    _MazeDataPoint = new MazeDataPoint(CurrentState.Name);
                    _MazeDataPoint.Session = _SessionLoop.CurrentIteration;
                    _MazeDataPoint.Trial = _TrialLoop.CurrentIteration;
                    DataPointReady?.Invoke(this, _MazeDataPoint);
                    CurrentState.Activate();
                    _Status = StatusType.Running;
                    _StartTime = DateTime.Now;
                }
                else
                {
                    TrialAborted?.Invoke(this, new EventArgs());
                }
            }
            catch(Exception ex)
            {
                TrialAborted?.Invoke(this, new EventArgs());
            }
        }

        public List<ScriptDoorCommand> GetCurrentCommands()
        {
            List<ScriptDoorCommand> RetVal = new List<ScriptDoorCommand>();
            if (CurrentState != null)
            {
                RetVal = CurrentState.DoorCommands;
            }
            return RetVal;
        }

        public void Reset()
        {
            _Status = StatusType.Inactive;
            CurrentState = null;
            foreach (var State in States.Values)
            {
                if (State.Type == ScriptState.StateType.Start)
                {
                    StartState = State;
                    CurrentState = State;
                }
            }
        }

        public void Abort()
        {
            _Status = StatusType.Aborted;
            _EndTime = DateTime.Now;
        }

        public void MatchSensor(string Sensor)
        {
            if (!CancelToken.IsCancellationRequested)
            {
                if (_Status == StatusType.Running && CurrentState != null)
                {
                    CurrentState.MatchSensor(Sensor);
                }
            }
            else
            {
                TrialAborted?.Invoke(this, new EventArgs());
            }
        }

        //public MessageQueue GetMessageQueue()
        //{
        //    MessageQueue Queue = null;
        //    if (!MessageQueue.Exists(QueueName))
        //    {
        //        Queue = MessageQueue.Create(QueueName);
        //    }
        //    else
        //    {
        //        Queue = new MessageQueue(QueueName);
        //    }
        //    return Queue;
        //}

        //public void SendMessage()
        //{
        //    MessageQueue myQueue = GetMessageQueue();
        //    Message Msg = new Message(1234, new BinaryMessageFormatter());
        //    myQueue.Send(Msg);
        //}

        //public object ReceiveMessage()
        //{
        //    object RetVal = null;

        //    MessageQueue myQueue = GetMessageQueue();
        //    myQueue.Formatter = new BinaryMessageFormatter();
        //    Message myMessage = myQueue.Receive();
        //    RetVal = myMessage.Body;
        //    return RetVal;
        //}
    }
}
