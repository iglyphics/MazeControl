using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


namespace MazeControl
{
    public class ScriptState
    {
        public enum StateType
        {
            Start,
            Complete,
            Normal
        }
        public string Name { get; set; } = "";
        public StateType Type = StateType.Normal;
        public List<ScriptDoorCommand> DoorCommands = new List<ScriptDoorCommand>();
        public List<ScriptCondition> Conditions = new List<ScriptCondition>();
        public event EventHandler<ScriptStateEventArgs> StateCompleted;
        public event EventHandler<ScriptStateEventArgs> StateConditionTriggered;

        public ScriptState()
        {

        }

        public ScriptState(XElement Def)
        {
            Name = Def.AttributeValue<string>("name").ToLower();
            if (Def.AttributeValue<bool>("start"))
            {
                Type = StateType.Start;
            }
            else if (Def.AttributeValue<bool>("complete"))
            {
                Type = StateType.Complete;
            }
            foreach(var CmdDef in Def.Elements("command"))
            {
                ScriptDoorCommand Cmd = new ScriptDoorCommand(CmdDef);
                DoorCommands.Add(Cmd);
            }
            foreach (var CondDef in Def.Elements("when"))
            {
                ScriptCondition Cond = new ScriptCondition(CondDef);
                Cond.TimerExpired += Cond_TimerExpired;
                Conditions.Add(Cond);
            }
        }

        public void Activate()
        {
            foreach(var Cond in Conditions)
            {
                Cond.Activate();
            }
        }

        public void Deactivate()
        {
            foreach (var Cond in Conditions)
            {
                Cond.Deactivate();
            }
        }

        private void Cond_TimerExpired(object sender, ScriptConditionEventArgs e)
        {
            ScriptCondition Cond = (ScriptCondition)sender;
            StateCompleted?.Invoke(this, new ScriptStateEventArgs(Cond, e.NextState, true));
        }

        public void MatchSensor(string Sensor)
        {
            foreach(var Cond in Conditions)
            {
                if (Cond.MatchSensor(Sensor))
                {
                    StateConditionTriggered?.Invoke(this, new ScriptStateEventArgs(Cond, Cond.NextState, false));
                    if (Cond.NextState.Trim() != "")
                    {
                        Deactivate();
                        StateCompleted?.Invoke(this, new ScriptStateEventArgs(Cond, Cond.NextState, false));
                    }
                }
            }
        }
    }
}
