namespace MazeControl
{
    partial class ScriptEditor
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
            this.scintilla1 = new ScintillaNET.Scintilla();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.lblScriptName = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.lblMazeCommand = new System.Windows.Forms.ToolStripLabel();
            this.btnCopySample = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // scintilla1
            // 
            this.scintilla1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scintilla1.Lexer = ScintillaNET.Lexer.Xml;
            this.scintilla1.Location = new System.Drawing.Point(0, 27);
            this.scintilla1.Margin = new System.Windows.Forms.Padding(4);
            this.scintilla1.Name = "scintilla1";
            this.scintilla1.Size = new System.Drawing.Size(543, 297);
            this.scintilla1.TabIndex = 0;
            this.scintilla1.UseTabs = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnDelete,
            this.lblScriptName});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(543, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::MazeControl.Properties.Resources.save_icon;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(24, 24);
            this.btnSave.Text = "toolStripButton1";
            this.btnSave.ToolTipText = "Save script";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::MazeControl.Properties.Resources.trash_bin_1;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(24, 24);
            this.btnDelete.Text = "toolStripButton2";
            this.btnDelete.ToolTipText = "Delete script";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblScriptName
            // 
            this.lblScriptName.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblScriptName.Name = "lblScriptName";
            this.lblScriptName.Size = new System.Drawing.Size(113, 24);
            this.lblScriptName.Text = "** New Script **";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMazeCommand,
            this.btnCopySample});
            this.toolStrip2.Location = new System.Drawing.Point(0, 324);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(543, 27);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // lblMazeCommand
            // 
            this.lblMazeCommand.Name = "lblMazeCommand";
            this.lblMazeCommand.Size = new System.Drawing.Size(111, 24);
            this.lblMazeCommand.Text = "toolStripLabel1";
            // 
            // btnCopySample
            // 
            this.btnCopySample.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCopySample.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCopySample.Image = global::MazeControl.Properties.Resources.copy;
            this.btnCopySample.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopySample.Name = "btnCopySample";
            this.btnCopySample.Size = new System.Drawing.Size(24, 24);
            this.btnCopySample.Text = "toolStripButton1";
            this.btnCopySample.ToolTipText = "Copy hint text to clipboard";
            this.btnCopySample.Click += new System.EventHandler(this.btnCopySample_Click);
            // 
            // ScriptEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.scintilla1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.toolStrip2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ScriptEditor";
            this.Size = new System.Drawing.Size(543, 351);
            this.Load += new System.EventHandler(this.ScriptEditor_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ScintillaNET.Scintilla scintilla1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripLabel lblScriptName;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel lblMazeCommand;
        private System.Windows.Forms.ToolStripButton btnCopySample;
    }
}
