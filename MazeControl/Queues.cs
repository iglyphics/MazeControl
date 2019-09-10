using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeControl
{
    public static class Queues
    {
        public static ConcurrentQueue<MazeDataPoint> DataPointQueue = new ConcurrentQueue<MazeDataPoint>();
        public static ConcurrentQueue<int> TestQueue = new ConcurrentQueue<int>();
    }
}
