using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeControl
{
    public class LoopControl
    {
        public int Iterations { get; set; } = 0;
        private int _CurrentIteration = -1;
        private bool _EndOfLoop = false;

        public LoopControl(int Iterations)
        {
            this.Iterations = Iterations;
            _CurrentIteration = 0;
            _EndOfLoop = false;
        }

        public int CurrentIteration
        {
            get
            {
                int RetVal = -1;
                if (!_EndOfLoop)
                {
                    RetVal = _CurrentIteration;
                }
                return RetVal;
            }
        }

        public bool EndOfLoop
        {
            get
            {
                return _EndOfLoop;
            }
        }

        public int Next()
        {
            int RetVal = -1;
            if (_CurrentIteration < Iterations)
            {
                _CurrentIteration++;
                RetVal = _CurrentIteration;
            }
            else
            {
                _EndOfLoop = true;
            }
            return RetVal;
        }

        public void Reset()
        {
            _CurrentIteration = 1;
            _EndOfLoop = false;
        }
    }
}
