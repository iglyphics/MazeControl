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
    public partial class MazeDoor : UserControl
    {
        public enum OrientationType { Vertical, Horizontal}
        private OrientationType _Orientation = MazeDoor.OrientationType.Horizontal;
        private string _MazeDoorName = "";
        public event EventHandler<bool> UserStateChanged;
        public static Dictionary<string, MazeDoor> Doors = new Dictionary<string, MazeDoor>();
        private bool _IsOpen = true;

        public MazeDoor()
        {
            InitializeComponent();
            IsOpen = true;
            Orientation = OrientationType.Horizontal;
        }

        public string MazeDoorName
        {
            get
            {
                return _MazeDoorName;
            }
            set
            {
                if (Doors.ContainsKey(_MazeDoorName))
                {
                    Doors.Remove(_MazeDoorName);
                }
                _MazeDoorName = value;
                Doors[_MazeDoorName] = this;
            }
        }

        public bool IsOpen
        {
            get
            {
                return _IsOpen;
            }

            set
            {
                _IsOpen = value;
                if (_IsOpen)
                {
                    panel1.BackColor = Color.Transparent;
                    panel1.BorderStyle = BorderStyle.Fixed3D;
                }
                else
                {
                    panel1.BackColor = Color.Red;
                    panel1.BorderStyle = BorderStyle.FixedSingle; 
                }
            }
        }

        public OrientationType Orientation
        {
            get
            {
                return _Orientation;
            }
            set
            {
                _Orientation = value;
                if (_Orientation == OrientationType.Horizontal)
                {
                    Width = 50;
                    Height = 10;
                }
                else
                {
                    Width = 10;
                    Height = 50;
                }
            }
        }

        public void Open()
        {
            IsOpen = true;
        }

        public void Close()
        {
            IsOpen = false;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            IsOpen = !IsOpen;
            UserStateChanged?.Invoke(this, IsOpen);
        }
    }
}
