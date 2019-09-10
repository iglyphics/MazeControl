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
    public partial class MazeRunner : UserControl
    {
        public delegate void InvokeDelegateDouble(double Val);
        public delegate void InvokeDelegateInt(int Val);
        public delegate void InvokeDelegateBool(bool Val);
        public delegate void InvokeDelegate_String_Int(string Str, int Val);

        BindingSource source;
        public BindingList<MazeDataPoint> MazeDataPoints;
        private MazeDataPoint _CurrentDataPoint = null;
        public int _TrialCount = 0;
        private int _SessionCount = 0;

        public MazeRunner()
        {
            InitializeComponent();
        }

        public int SessionCount
        {
            get
            {
                return _SessionCount;
            }
            set
            {
                _SessionCount = value;
            }
        }

        public int TrialCount
        {
            get
            {
                return _TrialCount;
            }
            set
            {
                _TrialCount = value;
            }
        }
        private void MazeRunner_Load(object sender, EventArgs e)
        {
            MazeDataPoints = new BindingList<MazeDataPoint>();
            source = new BindingSource(MazeDataPoints, null);
            dgvDataPoints.DataSource = source;
        }

        public void Reset()
        {
            MazeDataPoints.Clear();
            TrialCount = 0;
            SessionCount = 0;
            lblSession.Text = "0 of 0";
            lblTrial.Text = "0 of 0";
            lblRunTime.Text = "";
            lcdCountDown.Visible = false;
        }

        public MazeDataPoint AddDataPoint(MazeDataPoint dp)
        {
            MazeDataPoints.Add(dp);
            _CurrentDataPoint = dp;
            return dp;
        }

        public void SetRunTime(double Secs)
        {
            lblRunTime.Text = String.Format("{0:0.00}", Secs);
            if (_CurrentDataPoint != null)
            {
                //_CurrentDataPoint.Update();
            }
        }

        public void SetStatus(string Status)
        {
            lblStatus.Text = Status;
        }

        public void SetTrialSafe(int Trial)
        {
            this.BeginInvoke(new InvokeDelegateInt(SetTrial), new object[] { Trial });
        }

        public void SetTrial(int Trial)
        {
            lblTrial.Text = $"{Trial} of {TrialCount}";
        }

        public void SetSessionSafe(int Session)
        {
            this.BeginInvoke(new InvokeDelegateInt(SetSession), new object[] { Session });
        }

        public void SetSession(int Session)
        {
            lblSession.Text = $"{Session} of {SessionCount}";
        }

        public void SetRunTimeSafe(double Secs)
        {
            this.BeginInvoke(new InvokeDelegateDouble(SetRunTime), new object[] { Secs });
        }

        public bool LcdVisible
        {
            get
            {
                return lcdCountDown.Visible;
            }
            set
            {
                lcdCountDown.Visible = value;
            }
        }

        public void SetUpdateLcdCountdownVisibleSafe(bool Visible)
        {
            this.BeginInvoke(new InvokeDelegateBool(SetUpdateLcdCountdownVisible), new object[] { Visible });
        }

        public void SetUpdateLcdCountdownVisible(bool Visible)
        {
            lcdCountDown.Visible = Visible;
        }

        public void UpdateLcdCountdownSafe(string Text, int Value)
        {
            this.BeginInvoke(new InvokeDelegate_String_Int(UpdateLcdCountdown), new object[] { Text, Value });
        }

        public void UpdateLcdCountdown(string Text, int Value)
        {
            lcdCountDown.Visible = true;
            lcdCountDown.Text = Text;
            lcdCountDown.Value = Value;
            if (Value <= 0)
            {
                lcdCountDown.Visible = false;
            }
        }

        private void MazeRunner_Resize(object sender, EventArgs e)
        {
            MazeRunner Ctl = (MazeRunner)sender;
            lcdCountDown.Left = Ctl.Width / 2 - lcdCountDown.Width / 2;
            //lcdCountDown.Top = Ctl.Height / 2 - lcdCountDown.Height / 2;
        }
    }
}
