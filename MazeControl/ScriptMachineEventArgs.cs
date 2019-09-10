using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeControl
{
    public class ScriptMachineEventArgs : EventArgs
    {
        public ScriptState NextState { get; set; } = null;
        
        public ScriptMachineEventArgs()
        {
        }

        public ScriptMachineEventArgs(ScriptState NextState)
        {
            this.NextState = NextState;
        }
    }

    

}
