namespace MazeControl
{
    partial class MazeDisplay
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.mouseSensor6 = new MazeControl.MouseSensor();
            this.mouseSensor5 = new MazeControl.MouseSensor();
            this.mouseSensor4 = new MazeControl.MouseSensor();
            this.mouseSensor3 = new MazeControl.MouseSensor();
            this.mouseSensor2 = new MazeControl.MouseSensor();
            this.mouseSensor1 = new MazeControl.MouseSensor();
            this.DS2 = new MazeControl.MazeDoor();
            this.DP2 = new MazeControl.MazeDoor();
            this.DA2 = new MazeControl.MazeDoor();
            this.DS1 = new MazeControl.MazeDoor();
            this.DS0 = new MazeControl.MazeDoor();
            this.DP1 = new MazeControl.MazeDoor();
            this.DA1 = new MazeControl.MazeDoor();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Location = new System.Drawing.Point(54, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 100);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Location = new System.Drawing.Point(204, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(100, 100);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.mouseSensor6);
            this.panel3.Controls.Add(this.mouseSensor5);
            this.panel3.Controls.Add(this.mouseSensor4);
            this.panel3.Controls.Add(this.mouseSensor3);
            this.panel3.Controls.Add(this.mouseSensor2);
            this.panel3.Controls.Add(this.mouseSensor1);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.DS2);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.DP2);
            this.panel3.Controls.Add(this.DA2);
            this.panel3.Controls.Add(this.DS1);
            this.panel3.Controls.Add(this.DS0);
            this.panel3.Controls.Add(this.DP1);
            this.panel3.Controls.Add(this.DA1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(8, 8);
            this.panel3.Margin = new System.Windows.Forms.Padding(8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(354, 200);
            this.panel3.TabIndex = 9;
            // 
            // mouseSensor6
            // 
            this.mouseSensor6.AutoSize = true;
            this.mouseSensor6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mouseSensor6.Location = new System.Drawing.Point(98, 10);
            this.mouseSensor6.Margin = new System.Windows.Forms.Padding(0);
            this.mouseSensor6.MazeSensorName = "MS1";
            this.mouseSensor6.Name = "mouseSensor6";
            this.mouseSensor6.Size = new System.Drawing.Size(31, 32);
            this.mouseSensor6.TabIndex = 14;
            this.mouseSensor6.Tripped = false;
            // 
            // mouseSensor5
            // 
            this.mouseSensor5.AutoSize = true;
            this.mouseSensor5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mouseSensor5.Location = new System.Drawing.Point(12, 75);
            this.mouseSensor5.Margin = new System.Windows.Forms.Padding(0);
            this.mouseSensor5.MazeSensorName = "MA1";
            this.mouseSensor5.Name = "mouseSensor5";
            this.mouseSensor5.Size = new System.Drawing.Size(31, 32);
            this.mouseSensor5.TabIndex = 13;
            this.mouseSensor5.Tripped = false;
            // 
            // mouseSensor4
            // 
            this.mouseSensor4.AutoSize = true;
            this.mouseSensor4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mouseSensor4.Location = new System.Drawing.Point(142, 158);
            this.mouseSensor4.Margin = new System.Windows.Forms.Padding(0);
            this.mouseSensor4.MazeSensorName = "MP1";
            this.mouseSensor4.Name = "mouseSensor4";
            this.mouseSensor4.Size = new System.Drawing.Size(31, 32);
            this.mouseSensor4.TabIndex = 12;
            this.mouseSensor4.Tripped = false;
            // 
            // mouseSensor3
            // 
            this.mouseSensor3.AutoSize = true;
            this.mouseSensor3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mouseSensor3.Location = new System.Drawing.Point(312, 75);
            this.mouseSensor3.Margin = new System.Windows.Forms.Padding(0);
            this.mouseSensor3.MazeSensorName = "MA2";
            this.mouseSensor3.Name = "mouseSensor3";
            this.mouseSensor3.Size = new System.Drawing.Size(31, 32);
            this.mouseSensor3.TabIndex = 11;
            this.mouseSensor3.Tripped = false;
            // 
            // mouseSensor2
            // 
            this.mouseSensor2.AutoSize = true;
            this.mouseSensor2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mouseSensor2.Location = new System.Drawing.Point(183, 158);
            this.mouseSensor2.Margin = new System.Windows.Forms.Padding(0);
            this.mouseSensor2.MazeSensorName = "MP2";
            this.mouseSensor2.Name = "mouseSensor2";
            this.mouseSensor2.Size = new System.Drawing.Size(31, 32);
            this.mouseSensor2.TabIndex = 10;
            this.mouseSensor2.Tripped = false;
            // 
            // mouseSensor1
            // 
            this.mouseSensor1.AutoSize = true;
            this.mouseSensor1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mouseSensor1.Location = new System.Drawing.Point(228, 10);
            this.mouseSensor1.Margin = new System.Windows.Forms.Padding(0);
            this.mouseSensor1.MazeSensorName = "MS2";
            this.mouseSensor1.Name = "mouseSensor1";
            this.mouseSensor1.Size = new System.Drawing.Size(31, 32);
            this.mouseSensor1.TabIndex = 9;
            this.mouseSensor1.Tripped = false;
            // 
            // DS2
            // 
            this.DS2.BackColor = System.Drawing.Color.Transparent;
            this.DS2.IsOpen = true;
            this.DS2.Location = new System.Drawing.Point(216, 0);
            this.DS2.Margin = new System.Windows.Forms.Padding(0);
            this.DS2.MazeDoorName = "DS2";
            this.DS2.Name = "DS2";
            this.DS2.Orientation = MazeControl.MazeDoor.OrientationType.Vertical;
            this.DS2.Size = new System.Drawing.Size(10, 50);
            this.DS2.TabIndex = 8;
            this.DS2.UserStateChanged += new System.EventHandler<bool>(this.Door_UserStateChanged);
            // 
            // DP2
            // 
            this.DP2.BackColor = System.Drawing.Color.Transparent;
            this.DP2.IsOpen = true;
            this.DP2.Location = new System.Drawing.Point(216, 150);
            this.DP2.Margin = new System.Windows.Forms.Padding(0);
            this.DP2.MazeDoorName = "DP2";
            this.DP2.Name = "DP2";
            this.DP2.Orientation = MazeControl.MazeDoor.OrientationType.Vertical;
            this.DP2.Size = new System.Drawing.Size(10, 50);
            this.DP2.TabIndex = 7;
            this.DP2.UserStateChanged += new System.EventHandler<bool>(this.Door_UserStateChanged);
            // 
            // DA2
            // 
            this.DA2.BackColor = System.Drawing.Color.Transparent;
            this.DA2.IsOpen = true;
            this.DA2.Location = new System.Drawing.Point(304, 61);
            this.DA2.Margin = new System.Windows.Forms.Padding(0);
            this.DA2.MazeDoorName = "DA2";
            this.DA2.Name = "DA2";
            this.DA2.Orientation = MazeControl.MazeDoor.OrientationType.Horizontal;
            this.DA2.Size = new System.Drawing.Size(50, 10);
            this.DA2.TabIndex = 2;
            this.DA2.UserStateChanged += new System.EventHandler<bool>(this.Door_UserStateChanged);
            // 
            // DS1
            // 
            this.DS1.BackColor = System.Drawing.Color.Transparent;
            this.DS1.IsOpen = true;
            this.DS1.Location = new System.Drawing.Point(131, 0);
            this.DS1.Margin = new System.Windows.Forms.Padding(0);
            this.DS1.MazeDoorName = "DS1";
            this.DS1.Name = "DS1";
            this.DS1.Orientation = MazeControl.MazeDoor.OrientationType.Vertical;
            this.DS1.Size = new System.Drawing.Size(10, 50);
            this.DS1.TabIndex = 6;
            this.DS1.UserStateChanged += new System.EventHandler<bool>(this.Door_UserStateChanged);
            // 
            // DS0
            // 
            this.DS0.BackColor = System.Drawing.Color.Transparent;
            this.DS0.IsOpen = true;
            this.DS0.Location = new System.Drawing.Point(154, 122);
            this.DS0.Margin = new System.Windows.Forms.Padding(0);
            this.DS0.MazeDoorName = "DS0";
            this.DS0.Name = "DS0";
            this.DS0.Orientation = MazeControl.MazeDoor.OrientationType.Horizontal;
            this.DS0.Size = new System.Drawing.Size(50, 10);
            this.DS0.TabIndex = 3;
            this.DS0.UserStateChanged += new System.EventHandler<bool>(this.Door_UserStateChanged);
            // 
            // DP1
            // 
            this.DP1.BackColor = System.Drawing.Color.Transparent;
            this.DP1.IsOpen = true;
            this.DP1.Location = new System.Drawing.Point(131, 150);
            this.DP1.Margin = new System.Windows.Forms.Padding(0);
            this.DP1.MazeDoorName = "DP1";
            this.DP1.Name = "DP1";
            this.DP1.Orientation = MazeControl.MazeDoor.OrientationType.Vertical;
            this.DP1.Size = new System.Drawing.Size(10, 50);
            this.DP1.TabIndex = 5;
            this.DP1.UserStateChanged += new System.EventHandler<bool>(this.Door_UserStateChanged);
            // 
            // DA1
            // 
            this.DA1.BackColor = System.Drawing.Color.Transparent;
            this.DA1.IsOpen = true;
            this.DA1.Location = new System.Drawing.Point(4, 61);
            this.DA1.Margin = new System.Windows.Forms.Padding(0);
            this.DA1.MazeDoorName = "DA1";
            this.DA1.Name = "DA1";
            this.DA1.Orientation = MazeControl.MazeDoor.OrientationType.Horizontal;
            this.DA1.Size = new System.Drawing.Size(50, 10);
            this.DA1.TabIndex = 4;
            this.DA1.UserStateChanged += new System.EventHandler<bool>(this.Door_UserStateChanged);
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4.BackColor = System.Drawing.Color.DimGray;
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(8);
            this.panel4.Size = new System.Drawing.Size(370, 216);
            this.panel4.TabIndex = 10;
            // 
            // MazeDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel4);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MazeDisplay";
            this.Size = new System.Drawing.Size(370, 216);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private MazeDoor DA2;
        private MazeDoor DS0;
        private MazeDoor DA1;
        private MazeDoor DP1;
        private MazeDoor DS1;
        private MazeDoor DS2;
        private MazeDoor DP2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private MouseSensor mouseSensor1;
        private MouseSensor mouseSensor6;
        private MouseSensor mouseSensor5;
        private MouseSensor mouseSensor4;
        private MouseSensor mouseSensor3;
        private MouseSensor mouseSensor2;
    }
}
