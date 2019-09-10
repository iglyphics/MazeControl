namespace MazeControl
{
    partial class Test
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
            this.controlPanel1 = new MazeControl.ControlPanel();
            this.SuspendLayout();
            // 
            // controlPanel1
            // 
            this.controlPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.controlPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.controlPanel1.ComPort = null;
            this.controlPanel1.CurrentScript = null;
            this.controlPanel1.Location = new System.Drawing.Point(130, 63);
            this.controlPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.controlPanel1.MinimumSize = new System.Drawing.Size(220, 171);
            this.controlPanel1.Name = "controlPanel1";
            this.controlPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.controlPanel1.ScriptFolder = "C:\\Users\\rhughes\\AppData\\Local\\MazeControl";
            this.controlPanel1.Size = new System.Drawing.Size(245, 171);
            this.controlPanel1.TabIndex = 0;
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.controlPanel1);
            this.Name = "Test";
            this.Text = "Test";
            this.ResumeLayout(false);

        }

        #endregion

        private ControlPanel controlPanel1;
    }
}