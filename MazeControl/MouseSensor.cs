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
    public partial class MouseSensor : UserControl
    {
        private bool _Tripped = true;
        private string _MazeSensorName = "";
        public static Dictionary<string, MouseSensor> Sensors = new Dictionary<string, MouseSensor>();
        public MouseSensor()
        {
            _Tripped = false;
            InitializeComponent();
        }

        public bool Tripped
        {
            get
            {
                return _Tripped;
            }

            set
            {
                _Tripped = value;
                if (_Tripped)
                {
                    pictureBox1.Image = global::MazeControl.Properties.Resources.MouseIcon;
                }
                else
                {
                    pictureBox1.Image = global::MazeControl.Properties.Resources.NoMouseIcon;
                }
            }
        }

        public string MazeSensorName
        {
            get
            {
                return _MazeSensorName;
            }
            set
            {
                if (Sensors.ContainsKey(_MazeSensorName))
                {
                    Sensors.Remove(_MazeSensorName);
                }
                _MazeSensorName = value;
                Sensors[_MazeSensorName] = this;
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Tripped = !Tripped;
        }
    }
}
