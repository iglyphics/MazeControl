using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeControl
{
    public class ScriptStateEventArgs : EventArgs
    {
        public string NextState { get; set; } = "";
        public bool TimerExpired { get; set; } = false;
        public ScriptCondition Condition { get; set; } = null;

        public ScriptStateEventArgs()
        {
        }

        public ScriptStateEventArgs(ScriptCondition Condition, string NextState, bool TimerExpired)
        {
            this.Condition = Condition;
            this.NextState = NextState;
            this.TimerExpired = TimerExpired;
        }
    }

    

}
