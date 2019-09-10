namespace MazeControl
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.mazeRunner1 = new MazeControl.MazeRunner();
            this.ScriptEditor = new MazeControl.ScriptEditor();
            this.SerialMonitor = new System.Windows.Forms.RichTextBox();
            this.controlPanel1 = new MazeControl.ControlPanel();
            this.mazeDisplayHost1 = new MazeControl.MazeDisplayHost();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerUpdate
            // 
            this.timerUpdate.Enabled = true;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.MainSplitContainer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1295, 658);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MainSplitContainer.Margin = new System.Windows.Forms.Padding(4);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.mazeRunner1);
            this.MainSplitContainer.Panel1.Controls.Add(this.ScriptEditor);
            this.MainSplitContainer.Panel1.Controls.Add(this.SerialMonitor);
            this.MainSplitContainer.Panel1.Controls.Add(this.controlPanel1);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.mazeDisplayHost1);
            this.MainSplitContainer.Size = new System.Drawing.Size(1293, 656);
            this.MainSplitContainer.SplitterDistance = 310;
            this.MainSplitContainer.SplitterWidth = 5;
            this.MainSplitContainer.TabIndex = 4;
            // 
            // mazeRunner1
            // 
            this.mazeRunner1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mazeRunner1.LcdVisible = false;
            this.mazeRunner1.Location = new System.Drawing.Point(0, 209);
            this.mazeRunner1.Margin = new System.Windows.Forms.Padding(5);
            this.mazeRunner1.Name = "mazeRunner1";
            this.mazeRunner1.SessionCount = 0;
            this.mazeRunner1.Size = new System.Drawing.Size(310, 330);
            this.mazeRunner1.TabIndex = 6;
            this.mazeRunner1.TrialCount = 0;
            // 
            // ScriptEditor
            // 
            this.ScriptEditor.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ScriptEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScriptEditor.Location = new System.Drawing.Point(0, 209);
            this.ScriptEditor.Margin = new System.Windows.Forms.Padding(5);
            this.ScriptEditor.Name = "ScriptEditor";
            this.ScriptEditor.NewScript = true;
            this.ScriptEditor.Script = "** New Script **";
            this.ScriptEditor.ScriptFolder = "";
            this.ScriptEditor.Size = new System.Drawing.Size(310, 330);
            this.ScriptEditor.TabIndex = 4;
            this.ScriptEditor.Visible = false;
            // 
            // SerialMonitor
            // 
            this.SerialMonitor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SerialMonitor.Location = new System.Drawing.Point(0, 539);
            this.SerialMonitor.Margin = new System.Windows.Forms.Padding(4);
            this.SerialMonitor.Name = "SerialMonitor";
            this.SerialMonitor.Size = new System.Drawing.Size(310, 117);
            this.SerialMonitor.TabIndex = 3;
            this.SerialMonitor.Text = "";
            // 
            // controlPanel1
            // 
            this.controlPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.controlPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.controlPanel1.ComPort = "COM4";
            this.controlPanel1.CurrentScript = null;
            this.controlPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlPanel1.Location = new System.Drawing.Point(0, 0);
            this.controlPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.controlPanel1.MinimumSize = new System.Drawing.Size(220, 171);
            this.controlPanel1.Name = "controlPanel1";
            this.controlPanel1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.controlPanel1.ResultsName = "";
            this.controlPanel1.ScriptFolder = "C:\\Users\\rhughes\\AppData\\Local\\MazeControl";
            this.controlPanel1.Size = new System.Drawing.Size(310, 209);
            this.controlPanel1.TabIndex = 5;
            this.controlPanel1.ViewResultsFiles += new System.EventHandler<string>(this.controlPanel1_ViewResultsFiles);
            this.controlPanel1.StartScript += new System.EventHandler(this.controlPanel1_StartScript);
            this.controlPanel1.StopScript += new System.EventHandler(this.controlPanel1_StopScript);
            this.controlPanel1.ResetMaze += new System.EventHandler(this.controlPanel1_ResetMaze);
            this.controlPanel1.ComPortChanged += new System.EventHandler<string>(this.controlPanel1_ComPortChanged);
            this.controlPanel1.ScriptChanged += new System.EventHandler<string>(this.controlPanel1_ScriptChanged);
            this.controlPanel1.EditScript += new System.EventHandler<string>(this.controlPanel1_EditScript);
            this.controlPanel1.NewScript += new System.EventHandler(this.controlPanel1_NewScript);
            // 
            // mazeDisplayHost1
            // 
            this.mazeDisplayHost1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.mazeDisplayHost1.BackgroundImage = global::MazeControl.Properties.Resources.St__Jude_Logo_small;
            this.mazeDisplayHost1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.mazeDisplayHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mazeDisplayHost1.Location = new System.Drawing.Point(0, 0);
            this.mazeDisplayHost1.Margin = new System.Windows.Forms.Padding(5);
            this.mazeDisplayHost1.Name = "mazeDisplayHost1";
            this.mazeDisplayHost1.Size = new System.Drawing.Size(978, 656);
            this.mazeDisplayHost1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 658);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Maze Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox SerialMonitor;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private MazeDisplayHost mazeDisplayHost1;
        private ScriptEditor ScriptEditor;
        private ControlPanel controlPanel1;
        private MazeRunner mazeRunner1;
    }
}

