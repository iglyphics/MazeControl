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
using ScintillaNET;
using Maze3D;

namespace MazeControl
{
    public partial class ScriptEditor : UserControl
    {
        public event EventHandler<string> NewScriptCreated;
        private const string NEW_SCRIPT_NAME = "** New Script **";
        private string _ScriptName = NEW_SCRIPT_NAME;
        private bool _IsNewScript = true;
        public string ScriptFolder { get; set; } = "";
        public ScriptEditor()
        {
            InitializeComponent();
        }

        private void ScriptEditor_Load(object sender, EventArgs e)
        {
            scintilla1.StyleResetDefault();
            scintilla1.Styles[Style.Default].Font = "Consolas";
            scintilla1.Styles[Style.Default].Size = 10;
            scintilla1.StyleClearAll();

            // Set the XML Lexer
            scintilla1.Lexer = Lexer.Xml;

            scintilla1.StyleResetDefault();
            //scintilla1.Styles[Style.Default].Font = "Courier";
            //scintilla1.Styles[Style.Default].Size = 8;
            scintilla1.StyleClearAll();
            scintilla1.Styles[Style.Xml.Attribute].ForeColor = Color.Red;
            scintilla1.Styles[Style.Xml.Entity].ForeColor = Color.Blue;
            scintilla1.Styles[Style.Xml.Comment].ForeColor = Color.Green;
            scintilla1.Styles[Style.Xml.Tag].ForeColor = Color.DarkRed;
            //scintilla1.Styles[Style.Xml.Tag].Bold = true;
            scintilla1.Styles[Style.Xml.TagEnd].ForeColor = Color.DarkRed;
            //scintilla1.Styles[Style.Xml.TagEnd].Bold = true;

            scintilla1.Styles[Style.Xml.DoubleString].ForeColor = Color.Blue;
            scintilla1.Styles[Style.Xml.SingleString].ForeColor = Color.Blue;

            lblMazeCommand.Text = "";
        }

        public void ShowWhen(string Sensor)
        {
            lblMazeCommand.Text = $@"<when sensor=""{Sensor}"" state="""" />";
        }

        public void ShowDoorCommand(Maze3D.MazeDoor Door)
        {
            string Action = "open";
            if (Door.IsClosed)
            {
                Action = "close";
            }
            lblMazeCommand.Text = $@"<command door=""{Door.Name}"" action=""{Action}"" />";
        }

        public void ShowReward(Maze3D.MazePumpDial Dial)
        {
            lblMazeCommand.Text = $@"<reward tray=""{Dial.Name}"" count=""1"" />";
        }


        public new string Text
        {
            get
            {
                return scintilla1.Text;
            }
            set
            {
                scintilla1.Text = value;
            }
        }

        public string Script
        {
            get
            {
                return _ScriptName;
            }
            set
            {
                if (value.Trim() != "")
                {
                    _ScriptName = value;
                    lblScriptName.Text = value;
                    if (File.Exists(FullScriptName))
                    { 
                        scintilla1.Text = File.ReadAllText(FullScriptName);
                        _IsNewScript = false;
                    }
                }

            }

        }

        public bool NewScript
        {
            get
            {
                return _IsNewScript;
            }
            set
            {
                _IsNewScript = true;
                lblScriptName.Text = NEW_SCRIPT_NAME;
            }
        }

        public string FullScriptName
        {
            get
            {
                return Path.Combine(ScriptFolder, Script) + ".xml";
            }
        }

        private void btnCopySample_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lblMazeCommand.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_IsNewScript)
            {
                var Dlg = new SaveFileDialog();
                Dlg.InitialDirectory = ScriptFolder;
                Dlg.FileName = $@"Maze_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xml";
                Dlg.DefaultExt = "xml";
                Dlg.Filter = "XML File (*.xml)|*.xml";
                Dlg.AddExtension = true;
                if (Dlg.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(Dlg.FileName, scintilla1.Text);
                    _IsNewScript = false;
                    lblScriptName.Text = Path.GetFileNameWithoutExtension(Dlg.FileName);
                    NewScriptCreated?.Invoke(this, Dlg.FileName);
                }
            }
            else
            {
                File.WriteAllText(FullScriptName, scintilla1.Text);

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_IsNewScript)
            {
                if (System.Windows.Forms.MessageBox.Show($"Delete Script: {_ScriptName} ?", "Delete Script", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    File.Delete(FullScriptName);
                    scintilla1.Text = "";
                    NewScript = true;
                }
            }
        }
    }
}
