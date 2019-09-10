using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Maze3D;

namespace MazeControl
{
    public partial class MazeDisplayHost : UserControl
    {
        Maze3DControl Ctl;

        public MazeDisplayHost()
        {
            InitializeComponent();
        }

        private void MazeDisplayHost_Load(object sender, EventArgs e)
        {
            Ctl = (Maze3DControl)elementHost1.Child;
            Ctl.AddModel("Mouse Maze.stl");
        }

        public Maze3DControl MazeDisplay
        {
            get
            {
                return Ctl;
            }
        }

    }
}
