using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeControl
{
    public class ScriptEndEventArgs : EventArgs
    {
        public bool Success { get; set; } = true;
        public double RunTime { get; set; } = 0;
        
        public ScriptEndEventArgs()
        {
        }

        public ScriptEndEventArgs(bool Success, double RunTime)
        {
            this.Success = Success;
            this.RunTime = RunTime;
        }
    }

    

}
