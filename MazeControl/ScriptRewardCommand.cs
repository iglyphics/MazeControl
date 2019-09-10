using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MazeControl
{
    public class ScriptRewardCommand
    {
        public string Dispenser { get; set; }
        public int Delay = 0;
        public int Count = 1;

        public ScriptRewardCommand()
        {

        }

        public ScriptRewardCommand(XElement Def)
        {
            Dispenser = Def.AttributeValue<string>("tray");
            int Count = Def.AttributeValue<int>("count");
            Delay = Def.AttributeValue<int>("delay");
        }
    }
}

   
