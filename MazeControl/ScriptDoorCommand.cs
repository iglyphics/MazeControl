using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MazeControl
{
    public class ScriptDoorCommand
    {
        public enum DoorAction
        {
            Open,
            Close
        }
        public string Door { get; set; }
        public DoorAction Action { get; set; }
        public int Delay = 0;

        public ScriptDoorCommand()
        {

        }

        public ScriptDoorCommand(XElement Def)
        {
            Door = Def.AttributeValue<string>("door");
            string Action = Def.AttributeValue<string>("action").ToLower().Trim();
            if (Action.StartsWith("o"))
            {
                this.Action = DoorAction.Open;
            }
            else
            {
                this.Action = DoorAction.Close;
            }
            Delay = Def.AttributeValue<int>("delay");
        }
    }
}

   
