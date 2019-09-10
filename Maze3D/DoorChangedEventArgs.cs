using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Maze3D
{
    public class DoorChangedEventArgs : RoutedEventArgs
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
