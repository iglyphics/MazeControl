using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Timers;

namespace MazeControl
{
    public class ScriptCondition
    {
        public string Sensor { get; set; } = "";
        public string NextState { get; set; } = "";
        public float Timeout { get; set; } = 0;
        public string Label { get; set; } = "";
        private Timer Timer = null;
        public List<ScriptRewardCommand> RewardCommands = new List<ScriptRewardCommand>();
        public event EventHandler<ScriptConditionEventArgs> TimerExpired;


        public ScriptCondition()
        {

        }

        public ScriptCondition(XElement Def)
        {
            Sensor = Def.AttributeValue<string>("sensor").ToLower();
            NextState = Def.AttributeValue<string>("state").ToLower();
            Timeout = Def.AttributeValue<float>("timeout");
            Label = Def.AttributeValue<string>("label");
            if (Label == "")
            {
                if (Timeout > 0)
                {
                    Label = $"Timeout:{Timeout}";
                }
                else
                {
                    Label = Sensor;
                }
            }
            var RewardDefs = Def.Elements("reward");
            foreach(var RewardDef in RewardDefs)
            {
                var Reward = new ScriptRewardCommand(RewardDef);
                RewardCommands.Add(Reward);
            }
        }

        public void Activate()
        {
            if (Timeout > 0)
            {
                Timer = new MazeTimer(Timeout);
                Timer.Elapsed += Timer_Elapsed;
                Timer.Start();
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Deactivate();
            TimerExpired?.Invoke(this, new ScriptConditionEventArgs(NextState, true));
        }

        public void Deactivate()
        {
            if (Timer != null)
            {
                Timer.Stop();
            }
            Timer = null;
        }

        public bool MatchSensor(string Sensor)
        {
            bool RetVal = false;
            if (Timeout == 0 && this.Sensor.ToLower() == Sensor.ToLower())
            {
                RetVal = true;
            }
            return RetVal;
        }
    }
}
