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
            this.DrawTimeLabel.Location = new System.Drawing.Point(169, 739);
            this.DrawTimeLabel.Name = "DrawTimeLabel";
            this.DrawTimeLabel.Size = new System.Drawing.Size(55, 13);
            this.DrawTimeLabel.TabIndex = 25;
            this.DrawTimeLabel.Text = "DrawTime";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.DrawTimeLabel);
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
    }
}

