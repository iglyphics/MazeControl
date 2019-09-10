namespace MazeControl
{
    partial class MazeRunner
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
            this.dgvDataPoints = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSession = new System.Windows.Forms.Label();
            this.lblTrial = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRunTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelDGV = new System.Windows.Forms.Panel();
            this.lcdCountDown = new MazeControl.LcdDisplay();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataPoints)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelDGV.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDataPoints
            // 
            this.dgvDataPoints.AllowUserToAddRows = false;
            this.dgvDataPoints.AllowUserToDeleteRows = false;
            this.dgvDataPoints.AllowUserToOrderColumns = true;
            this.dgvDataPoints.AllowUserToResizeRows = false;
            this.dgvDataPoints.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDataPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataPoints.Location = new System.Drawing.Point(0, 0);
            this.dgvDataPoints.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDataPoints.Name = "dgvDataPoints";
            this.dgvDataPoints.ReadOnly = true;
            this.dgvDataPoints.RowHeadersVisible = false;
            this.dgvDataPoints.Size = new System.Drawing.Size(299, 358);
            this.dgvDataPoints.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Session:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(238, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Trial:";
            // 
            // lblSession
            // 
            this.lblSession.AutoSize = true;
            this.lblSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSession.Location = new System.Drawing.Point(4, 27);
            this.lblSession.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(50, 17);
            this.lblSession.TabIndex = 7;
            this.lblSession.Text = "0 of 0";
            // 
            // lblTrial
            // 
            this.lblTrial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTrial.AutoSize = true;
            this.lblTrial.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrial.Location = new System.Drawing.Point(234, 27);
            this.lblTrial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrial.Name = "lblTrial";
            this.lblTrial.Size = new System.Drawing.Size(50, 17);
            this.lblTrial.TabIndex = 8;
            this.lblTrial.Text = "0 of 0";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblRunTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 416);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(299, 25);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 20);
            this.lblStatus.Text = "Idle";
            // 
            // lblRunTime
            // 
            this.lblRunTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRunTime.Name = "lblRunTime";
            this.lblRunTime.Size = new System.Drawing.Size(18, 20);
            this.lblRunTime.Text = "0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblSession);
            this.panel1.Controls.Add(this.lblTrial);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 58);
            this.panel1.TabIndex = 10;
            // 
            // panelDGV
            // 
            this.panelDGV.Controls.Add(this.lcdCountDown);
            this.panelDGV.Controls.Add(this.dgvDataPoints);
            this.panelDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDGV.Location = new System.Drawing.Point(0, 58);
            this.panelDGV.Name = "panelDGV";
            this.panelDGV.Size = new System.Drawing.Size(299, 358);
            this.panelDGV.TabIndex = 11;
            // 
            // lcdCountDown
            // 
            this.lcdCountDown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lcdCountDown.BackColor = System.Drawing.Color.Transparent;
            this.lcdCountDown.Location = new System.Drawing.Point(7, 44);
            this.lcdCountDown.Name = "lcdCountDown";
            this.lcdCountDown.Size = new System.Drawing.Size(277, 149);
            this.lcdCountDown.TabIndex = 1;
            this.lcdCountDown.Value = 0;
            this.lcdCountDown.Visible = false;
            // 
            // MazeRunner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelDGV);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MazeRunner";
            this.Size = new System.Drawing.Size(299, 441);
            this.Load += new System.EventHandler(this.MazeRunner_Load);
            this.Resize += new System.EventHandler(this.MazeRunner_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataPoints)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelDGV.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDataPoints;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSession;
        private System.Windows.Forms.Label lblTrial;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblRunTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelDGV;
        private LcdDisplay lcdCountDown;
    }
}
