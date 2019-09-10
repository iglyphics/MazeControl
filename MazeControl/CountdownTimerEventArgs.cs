using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeControl
{
    public class CountdownTimerEventArgs : EventArgs
    {
        public string Label { get; set; }
        public int CurrentIteration { get; set; } = -1;

        public CountdownTimerEventArgs(CountdownTimer ct)
        {
            Label = ct.Label;
            CurrentIteration = ct.CurrentCount;
        }

    }
}
