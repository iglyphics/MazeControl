namespace MazeControl
{
    partial class LcdDisplay
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
            this.lblText = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelShadow = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(0, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(370, 49);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "label1";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblValue
            // 
            this.lblValue.BackColor = System.Drawing.Color.Black;
            this.lblValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblValue.Font = new System.Drawing.Font("DS-Digital", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblValue.Location = new System.Drawing.Point(0, 49);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(370, 104);
            this.lblValue.TabIndex = 1;
            this.lblValue.Text = "0";
            this.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblValue);
            this.panel1.Controls.Add(this.lblText);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(372, 154);
            this.panel1.TabIndex = 2;
            // 
            // panelShadow
            // 
            this.panelShadow.BackColor = System.Drawing.Color.Transparent;
            this.panelShadow.BackgroundImage = global::MazeControl.Properties.Resources.shadow;
            this.panelShadow.Location = new System.Drawing.Point(91, 175);
            this.panelShadow.Margin = new System.Windows.Forms.Padding(0);
            this.panelShadow.Name = "panelShadow";
            this.panelShadow.Size = new System.Drawing.Size(200, 100);
            this.panelShadow.TabIndex = 3;
            // 
            // LcdDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelShadow);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "LcdDisplay";
            this.Size = new System.Drawing.Size(372, 275);
            this.Load += new System.EventHandler(this.LcdDisplay_Load);
            this.Resize += new System.EventHandler(this.LcdDisplay_Resize);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelShadow;
    }
}
