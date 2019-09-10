using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeControl
{
    public partial class MazeDisplay : UserControl
    {
        public event EventHandler<DoorChangedEventArgs> DoorChanged;

        public MazeDisplay()
        {
            InitializeComponent();
        }

        private void Door_UserStateChanged(object sender, bool e)
        {
            MazeDoor Door = (MazeDoor)sender;
            DoorChanged?.Invoke(this, new DoorChangedEventArgs(Door.MazeDoorName, e));
        }
    }
}
