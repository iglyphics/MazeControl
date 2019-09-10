using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;


namespace MazeControl
{
    public partial class ControlPanel : UserControl
    {
        public delegate void InvokeDelegate();

        public event EventHandler<string> ViewResultsFiles;
        public event EventHandler StartScript;
        public event EventHandler StopScript;
        public event EventHandler ResetMaze;
        public event EventHandler<string> ComPortChanged;
        public event EventHandler<string> ScriptChanged;
        public event EventHandler<string> EditScript;
        public event EventHandler NewScript;
        private string _CurrentScript;
        private string _ComPort;
        private string _ScriptFolder = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\MazeControl";

        public ControlPanel()
        {
            Directory.CreateDirectory(_ScriptFolder);
            InitializeComponent();
        }

        [Browsable(false)]
        public string ScriptFolder
        {
            get
            {
                return _ScriptFolder;
            }
            set
            {
                if (Directory.Exists(value))
                {
                    _ScriptFolder = value;
                }
            }
        }

        public string CurrentScript
        {
            get
            {
                return _CurrentScript;
            }
            set
            {
                PopulateScriptList();
                _CurrentScript = value;
                cbScripts.SelectedItem = value;
            }
        }

        public string ComPort
        {
            get
            {
                return _ComPort;
            }
            set
            {
                _ComPort = value;
                //cbComPort.SelectedItem = value;
                tsbComPort.Text = $"ComPort: {_ComPort}";
            }
        }

        public string ResultsName
        {
            get
            {
                return txtResultsName.Text;
            }
            set
            {
                txtResultsName.Text = value; 
            }
        }
        public string CurrentScriptFilename
        {
            get
            {
                return Path.Combine(_ScriptFolder, $@"{_CurrentScript}.xml");
            }
        }

        private void PopulateScriptList()
        {
            cbScripts.Items.Clear();
            string[] Files = Directory.GetFiles(_ScriptFolder);
            foreach (string f in Files)
            {
                cbScripts.Items.Add(Path.GetFileNameWithoutExtension(f));
            }
        }

        private void PopulateComPortList()
        {
            //cbComPort.Items.Clear();
            //string[] Ports = SerialPort.GetPortNames();
            //cbComPort.Items.AddRange(Ports);
        }

        private void PopulateComPortList2()
        {
            
            tsbComPort.DropDownItems.Clear();
            string[] Ports = SerialPort.GetPortNames();
            foreach(string Port in Ports)
            {
                var Item = new ToolStripMenuItem(Port);
                if (Port.ToLower() == _ComPort.ToLower())
                {
                    Item.Checked = true;
                }
                tsbComPort.DropDownItems.Add(Item);
                Item.Click += ComPortItem_Click;
            }
        }

        private void ComPortItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem Item = (ToolStripMenuItem)sender;
            _ComPort = Item.Text;
            ComPortChanged?.Invoke(this, _ComPort);
        }

        public string SelectedScript
        {
            get
            {
                return cbScripts.SelectedText;
            }
        }

        private void ControlPanel_Load(object sender, EventArgs e)
        {
            btnStop.Visible = false;
            btnStartScript.Visible = true;
            PopulateComPortList();
            PopulateScriptList();
            //cbComPort.SelectedItem = SerialPort.GetPortNames().FirstOrDefault();
            //ToolTip toolTip1 = new ToolTip();
            //toolTip1.AutoPopDelay = 5000;
            //toolTip1.InitialDelay = 1000;
            //toolTip1.ReshowDelay = 500;
            //// Force the ToolTip text to be displayed whether or not the form is active.
            //toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            //toolTip1.SetToolTip(this.pboxEditScript, "Show/Hide the Script Editor");
            //toolTip1.SetToolTip(this.pboxNewScript, "Create new script from a template");


        }

        private void btnStartScript_Click(object sender, EventArgs e)
        {
            if (txtResultsName.Text.Trim() != "")
            {
                Button b = (Button)sender;
                b.Visible = false;
                btnStop.Visible = true;
                StartScript?.Invoke(this, new EventArgs());
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Enter a name for the results to be save as.");
            }
        }

        private void cbScripts_DropDown(object sender, EventArgs e)
        {
            PopulateScriptList();
        }

        private void btnResetMaze_Click(object sender, EventArgs e)
        {
            ResetMaze?.Invoke(this, new EventArgs());
        }

        private void cbScripts_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb.SelectedItem != null)
            {
                _CurrentScript = cb.SelectedItem.ToString();
                ScriptChanged?.Invoke(this, _CurrentScript);
                txtResultsName.Text = $"Results_{_CurrentScript}_{DateTime.Now.ToString("yyyyMMddHHmmss")}";
            }
        }

        private void cbComPort_SelectedValueChanged(object sender, EventArgs e)
        {
            //ComboBox cb = (ComboBox)sender;
            //_ComPort = cb.SelectedItem.ToString();
            //ComPortChanged?.Invoke(this, _ComPort);
        }

        private void pboxNewScript_Click(object sender, EventArgs e)
        {
            NewScript?.Invoke(this, new EventArgs());
            cbScripts.SelectedItem = null;
            cbScripts.Text = "** New Script **";
        }

        private void cbComPort_DropDown(object sender, EventArgs e)
        {
            PopulateComPortList();
        }

        private void pboxEditScript_Click(object sender, EventArgs e)
        {
            EditScript?.Invoke(this, CurrentScript);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Visible = false;
            btnStartScript.Visible = true;
            StopScript?.Invoke(this, new EventArgs());
        }

        public void ResetButtonsSafe()
        {
            this.BeginInvoke(new InvokeDelegate(ResetButtons));
        }

        public void ResetButtons()
        {
            btnStartScript.Visible = true;
            btnStop.Visible = false;
        }

        private void tsbComPort_DropDownOpening(object sender, EventArgs e)
        {
            PopulateComPortList2();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void tsbViewResults_Click(object sender, EventArgs e)
        {
            ViewResultsFiles?.Invoke(this, _CurrentScript);
        }
    }
}
