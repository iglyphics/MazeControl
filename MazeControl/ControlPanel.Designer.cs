namespace MazeControl
{
    partial class ControlPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPanel));
            this.label1 = new System.Windows.Forms.Label();
            this.cbScripts = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtResultsName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tsbNewScript = new System.Windows.Forms.ToolStripButton();
            this.tsbEditScript = new System.Windows.Forms.ToolStripButton();
            this.tsbComPort = new System.Windows.Forms.ToolStripDropDownButton();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnResetMaze = new System.Windows.Forms.Button();
            this.btnStartScript = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.tsbViewResults = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Script:";
            // 
            // cbScripts
            // 
            this.cbScripts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbScripts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbScripts.FormattingEnabled = true;
            this.cbScripts.Location = new System.Drawing.Point(7, 57);
            this.cbScripts.Margin = new System.Windows.Forms.Padding(4);
            this.cbScripts.Name = "cbScripts";
            this.cbScripts.Size = new System.Drawing.Size(228, 24);
            this.cbScripts.Sorted = true;
            this.cbScripts.TabIndex = 1;
            this.toolTip1.SetToolTip(this.cbScripts, "Select a script to run");
            this.cbScripts.DropDown += new System.EventHandler(this.cbScripts_DropDown);
            this.cbScripts.SelectedValueChanged += new System.EventHandler(this.cbScripts_SelectedValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtResultsName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.cbScripts);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnResetMaze);
            this.panel1.Controls.Add(this.btnStartScript);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(239, 208);
            this.panel1.TabIndex = 9;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtResultsName
            // 
            this.txtResultsName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResultsName.Location = new System.Drawing.Point(7, 106);
            this.txtResultsName.Name = "txtResultsName";
            this.txtResultsName.Size = new System.Drawing.Size(228, 22);
            this.txtResultsName.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Save Results As:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewScript,
            this.tsbEditScript,
            this.tsbComPort,
            this.tsbViewResults});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(239, 27);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNewScript
            // 
            this.tsbNewScript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNewScript.Image = global::MazeControl.Properties.Resources.new_doc;
            this.tsbNewScript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewScript.Name = "tsbNewScript";
            this.tsbNewScript.Size = new System.Drawing.Size(24, 24);
            this.tsbNewScript.Text = "toolStripButton1";
            this.tsbNewScript.ToolTipText = "Create new script from template";
            this.tsbNewScript.Click += new System.EventHandler(this.pboxNewScript_Click);
            // 
            // tsbEditScript
            // 
            this.tsbEditScript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditScript.Image = global::MazeControl.Properties.Resources.file_edit_16x16;
            this.tsbEditScript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditScript.Name = "tsbEditScript";
            this.tsbEditScript.Size = new System.Drawing.Size(24, 24);
            this.tsbEditScript.Text = "toolStripButton2";
            this.tsbEditScript.ToolTipText = "Hide/Show Script Editor";
            this.tsbEditScript.Click += new System.EventHandler(this.pboxEditScript_Click);
            // 
            // tsbComPort
            // 
            this.tsbComPort.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbComPort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbComPort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem});
            this.tsbComPort.Image = ((System.Drawing.Image)(resources.GetObject("tsbComPort.Image")));
            this.tsbComPort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbComPort.Name = "tsbComPort";
            this.tsbComPort.Size = new System.Drawing.Size(123, 24);
            this.tsbComPort.Text = "ComPort: None";
            this.tsbComPort.DropDownOpening += new System.EventHandler(this.tsbComPort_DropDownOpening);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(108, 26);
            this.testToolStripMenuItem.Text = "test";
            // 
            // btnResetMaze
            // 
            this.btnResetMaze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetMaze.Image = global::MazeControl.Properties.Resources.Refresh;
            this.btnResetMaze.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResetMaze.Location = new System.Drawing.Point(136, 146);
            this.btnResetMaze.Margin = new System.Windows.Forms.Padding(4);
            this.btnResetMaze.Name = "btnResetMaze";
            this.btnResetMaze.Size = new System.Drawing.Size(99, 50);
            this.btnResetMaze.TabIndex = 6;
            this.btnResetMaze.Text = "Reset";
            this.btnResetMaze.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnResetMaze, "Reset maze");
            this.btnResetMaze.UseVisualStyleBackColor = true;
            this.btnResetMaze.Click += new System.EventHandler(this.btnResetMaze_Click);
            // 
            // btnStartScript
            // 
            this.btnStartScript.Image = global::MazeControl.Properties.Resources.Play;
            this.btnStartScript.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStartScript.Location = new System.Drawing.Point(7, 146);
            this.btnStartScript.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartScript.Name = "btnStartScript";
            this.btnStartScript.Size = new System.Drawing.Size(99, 50);
            this.btnStartScript.TabIndex = 5;
            this.btnStartScript.Text = "Start";
            this.btnStartScript.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnStartScript, "Start script");
            this.btnStartScript.UseVisualStyleBackColor = true;
            this.btnStartScript.Click += new System.EventHandler(this.btnStartScript_Click);
            // 
            // btnStop
            // 
            this.btnStop.Image = global::MazeControl.Properties.Resources.stop;
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStop.Location = new System.Drawing.Point(7, 146);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(99, 50);
            this.btnStop.TabIndex = 9;
            this.btnStop.Text = "Stop";
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnStop, "Stop running script");
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // tsbViewResults
            // 
            this.tsbViewResults.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbViewResults.Image = global::MazeControl.Properties.Resources.page_excel;
            this.tsbViewResults.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbViewResults.Name = "tsbViewResults";
            this.tsbViewResults.Size = new System.Drawing.Size(24, 24);
            this.tsbViewResults.Text = "tsbViewResults";
            this.tsbViewResults.ToolTipText = "View results files";
            this.tsbViewResults.Click += new System.EventHandler(this.tsbViewResults_Click);
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(220, 171);
            this.Name = "ControlPanel";
            this.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Size = new System.Drawing.Size(245, 212);
            this.Load += new System.EventHandler(this.ControlPanel_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbScripts;
        private System.Windows.Forms.Button btnStartScript;
        private System.Windows.Forms.Button btnResetMaze;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNewScript;
        private System.Windows.Forms.ToolStripButton tsbEditScript;
        private System.Windows.Forms.ToolStripDropDownButton tsbComPort;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtResultsName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton tsbViewResults;
    }
}
