using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeControl
{
    public class ScriptConditionEventArgs : EventArgs
    {
        public string NextState { get; set; } = "";
        public bool TimerExpired { get; set; } = false;

        public ScriptConditionEventArgs()
        {
        }

        public ScriptConditionEventArgs(string NextState, bool TimerExpired)
        {
            this.NextState = NextState;
            this.TimerExpired = TimerExpired;
        }
    }

    

}
