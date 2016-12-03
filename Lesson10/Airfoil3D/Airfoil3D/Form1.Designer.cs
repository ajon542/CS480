namespace Airfoil3D
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
            this.IndexUpDown = new System.Windows.Forms.NumericUpDown();
            this.RotationUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ScaleUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.OffsetUpDown = new System.Windows.Forms.NumericUpDown();
            this.ScaleTypeCombo = new System.Windows.Forms.ComboBox();
            this.PivotLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DrawRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IndexUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // DrawRegion
            // 
            this.DrawRegion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DrawRegion.Location = new System.Drawing.Point(172, 12);
            this.DrawRegion.Name = "DrawRegion";
            this.DrawRegion.Size = new System.Drawing.Size(800, 800);
            this.DrawRegion.TabIndex = 0;
            this.DrawRegion.TabStop = false;
            // 
            // IndexUpDown
            // 
            this.IndexUpDown.Location = new System.Drawing.Point(117, 12);
            this.IndexUpDown.Name = "IndexUpDown";
            this.IndexUpDown.Size = new System.Drawing.Size(49, 20);
            this.IndexUpDown.TabIndex = 1;
            // 
            // RotationUpDown
            // 
            this.RotationUpDown.Location = new System.Drawing.Point(117, 39);
            this.RotationUpDown.Name = "RotationUpDown";
            this.RotationUpDown.Size = new System.Drawing.Size(49, 20);
            this.RotationUpDown.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Airfoil Index";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Rotation";
            // 
            // ScaleUpDown
            // 
            this.ScaleUpDown.Location = new System.Drawing.Point(117, 66);
            this.ScaleUpDown.Name = "ScaleUpDown";
            this.ScaleUpDown.Size = new System.Drawing.Size(49, 20);
            this.ScaleUpDown.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Scale";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Offset";
            // 
            // OffsetUpDown
            // 
            this.OffsetUpDown.Location = new System.Drawing.Point(117, 92);
            this.OffsetUpDown.Name = "OffsetUpDown";
            this.OffsetUpDown.Size = new System.Drawing.Size(49, 20);
            this.OffsetUpDown.TabIndex = 8;
            // 
            // ScaleTypeCombo
            // 
            this.ScaleTypeCombo.FormattingEnabled = true;
            this.ScaleTypeCombo.Location = new System.Drawing.Point(76, 118);
            this.ScaleTypeCombo.Name = "ScaleTypeCombo";
            this.ScaleTypeCombo.Size = new System.Drawing.Size(90, 21);
            this.ScaleTypeCombo.TabIndex = 9;
            this.ScaleTypeCombo.SelectedIndexChanged += new System.EventHandler(this.ScaleTypeCombo_SelectedIndexChanged);
            // 
            // PivotLabel
            // 
            this.PivotLabel.AutoSize = true;
            this.PivotLabel.Location = new System.Drawing.Point(12, 118);
            this.PivotLabel.Name = "PivotLabel";
            this.PivotLabel.Size = new System.Drawing.Size(58, 13);
            this.PivotLabel.TabIndex = 10;
            this.PivotLabel.Text = "Pivot Point";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 820);
            this.Controls.Add(this.PivotLabel);
            this.Controls.Add(this.ScaleTypeCombo);
            this.Controls.Add(this.OffsetUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ScaleUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RotationUpDown);
            this.Controls.Add(this.IndexUpDown);
            this.Controls.Add(this.DrawRegion);
            this.Name = "Form1";
            this.Text = "Airfoil Design";
            ((System.ComponentModel.ISupportInitialize)(this.DrawRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IndexUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DrawRegion;
        private System.Windows.Forms.NumericUpDown IndexUpDown;
        private System.Windows.Forms.NumericUpDown RotationUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ScaleUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown OffsetUpDown;
        private System.Windows.Forms.ComboBox ScaleTypeCombo;
        private System.Windows.Forms.Label PivotLabel;
    }
}

