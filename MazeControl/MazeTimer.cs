using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MazeControl
{
    public class MazeTimer : Timer
    {
        public MazeTimer(float Seconds) : base(Seconds * 1000)
        {

        }
    }
}
