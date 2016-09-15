namespace Windmill
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
            this.DrawRegion = new System.Windows.Forms.PictureBox();
            this.DrawTimeLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.yCoordLabel = new System.Windows.Forms.Label();
            this.xCoordLabel = new System.Windows.Forms.Label();
            this.YLabel = new System.Windows.Forms.Label();
            this.XLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DrawRegion)).BeginInit();
            this.SuspendLayout();
            // 
            // DrawRegion
            // 
            this.DrawRegion.Location = new System.Drawing.Point(172, 12);
            this.DrawRegion.Name = "DrawRegion";
            this.DrawRegion.Size = new System.Drawing.Size(800, 740);
            this.DrawRegion.TabIndex = 0;
            this.DrawRegion.TabStop = false;
            // 
            // DrawTimeLabel
            // 
            this.DrawTimeLabel.AutoSize = true;
            this.DrawTimeLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrawTimeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DrawTimeLabel.Location = new System.Drawing.Point(57, 710);
            this.DrawTimeLabel.Name = "DrawTimeLabel";
            this.DrawTimeLabel.Size = new System.Drawing.Size(55, 13);
            this.DrawTimeLabel.TabIndex = 25;
            this.DrawTimeLabel.Text = "DrawTime";
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TimeLabel.Location = new System.Drawing.Point(16, 710);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(37, 13);
            this.TimeLabel.TabIndex = 24;
            this.TimeLabel.Text = "Time:";
            // 
            // yCoordLabel
            // 
            this.yCoordLabel.AutoSize = true;
            this.yCoordLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yCoordLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.yCoordLabel.Location = new System.Drawing.Point(16, 736);
            this.yCoordLabel.Name = "yCoordLabel";
            this.yCoordLabel.Size = new System.Drawing.Size(19, 13);
            this.yCoordLabel.TabIndex = 21;
            this.yCoordLabel.Text = "y:";
            // 
            // xCoordLabel
            // 
            this.xCoordLabel.AutoSize = true;
            this.xCoordLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xCoordLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.xCoordLabel.Location = new System.Drawing.Point(16, 723);
            this.xCoordLabel.Name = "xCoordLabel";
            this.xCoordLabel.Size = new System.Drawing.Size(19, 13);
            this.xCoordLabel.TabIndex = 20;
            this.xCoordLabel.Text = "x:";
            // 
            // YLabel
            // 
            this.YLabel.AutoSize = true;
            this.YLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.YLabel.Location = new System.Drawing.Point(39, 736);
            this.YLabel.Name = "YLabel";
            this.YLabel.Size = new System.Drawing.Size(43, 13);
            this.YLabel.TabIndex = 19;
            this.YLabel.Text = "YCoord";
            // 
            // XLabel
            // 
            this.XLabel.AutoSize = true;
            this.XLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.XLabel.Location = new System.Drawing.Point(39, 723);
            this.XLabel.Name = "XLabel";
            this.XLabel.Size = new System.Drawing.Size(43, 13);
            this.XLabel.TabIndex = 18;
            this.XLabel.Text = "XCoord";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.DrawTimeLabel);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.yCoordLabel);
            this.Controls.Add(this.xCoordLabel);
            this.Controls.Add(this.YLabel);
            this.Controls.Add(this.XLabel);
            this.Controls.Add(this.DrawRegion);
            this.Name = "Form1";
            this.Text = "2D Transformations";
            ((System.ComponentModel.ISupportInitialize)(this.DrawRegion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DrawRegion;
        private System.Windows.Forms.Label DrawTimeLabel;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label yCoordLabel;
        private System.Windows.Forms.Label xCoordLabel;
        private System.Windows.Forms.Label YLabel;
        private System.Windows.Forms.Label XLabel;
    }
}

