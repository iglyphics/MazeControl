using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeControl
{
    public class DoorChangedEventArgs : EventArgs
    {
        public string Name { get; set; }
        public bool IsOpen { get; set; }

        public DoorChangedEventArgs(string Name, bool IsOpen)
        {
            this.Name = Name;
            this.IsOpen = IsOpen;
        }
    }
}
