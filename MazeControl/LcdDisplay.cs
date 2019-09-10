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
    public partial class LcdDisplay : UserControl
    {
        //public int Digits { get; set; } = 3;
        private int _Value = 0;
        
        public LcdDisplay()
        {
            InitializeComponent();
        }

        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
                lblValue.Text = _Value.ToString();
            }
        }

        public override string Text
        {
            get => lblText.Text;
            set => lblText.Text = value;
        }

        private void LcdDisplay_Load(object sender, EventArgs e)
        {

        }

        private void LcdDisplay_Resize(object sender, EventArgs e)
        {
            panel1.Left = 0;
            panel1.Top = 0;
            panel1.Width = this.Width - 8;
            panelShadow.Left = 8;
            panelShadow.Top = 8;
            panelShadow.Width = panel1.Width;
            panelShadow.Height = panel1.Height;
        }

       
    }
}
