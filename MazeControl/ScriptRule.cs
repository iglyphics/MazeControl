using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


namespace MazeControl
{
    public class ScriptRule
    {
        public string Sensor { get; set; } = "";
        public List<ScriptDoorCommand> DoorCommands = new List<ScriptDoorCommand>();
        public List<ScriptRule> Rules = new List<ScriptRule>();
        public bool Active { get; set; } = true;
        public int Timeout = 0;
        public int ActivationCount = 1;
        public bool TriggerOnTimeOut = false;

        public ScriptRule()
        {

        }

        public ScriptRule(XElement Def)
        {
            Sensor = Def.AttributeValue<string>("sensor").ToUpper();
            Timeout = Def.AttributeValue<int>("timeout");
            TriggerOnTimeOut = Def.AttributeValue<bool>("trigger_on_timeout");
            foreach(var CmdDef in Def.Elements("command"))
            {
                ScriptDoorCommand Cmd = new ScriptDoorCommand(CmdDef);
                DoorCommands.Add(Cmd);
            }
        }

       
    }
}
