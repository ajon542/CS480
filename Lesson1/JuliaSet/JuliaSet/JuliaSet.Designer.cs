namespace JuliaSet
{
    partial class JuliaSet
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
            this.realUpDown = new System.Windows.Forms.NumericUpDown();
            this.imagUpDown = new System.Windows.Forms.NumericUpDown();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.C0 = new System.Windows.Forms.Label();
            this.C1 = new System.Windows.Forms.Label();
            this.DrawRegion = new System.Windows.Forms.PictureBox();
            this.ResetButton = new System.Windows.Forms.Button();
            this.Help = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.realUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawRegion)).BeginInit();
            this.SuspendLayout();
            // 
            // realUpDown
            // 
            this.realUpDown.Location = new System.Drawing.Point(32, 12);
            this.realUpDown.Name = "realUpDown";
            this.realUpDown.Size = new System.Drawing.Size(106, 20);
            this.realUpDown.TabIndex = 0;
            this.realUpDown.ValueChanged += new System.EventHandler(this.RealUpDown_ValueChanged);
            // 
            // imagUpDown
            // 
            this.imagUpDown.Location = new System.Drawing.Point(32, 38);
            this.imagUpDown.Name = "imagUpDown";
            this.imagUpDown.Size = new System.Drawing.Size(106, 20);
            this.imagUpDown.TabIndex = 1;
            this.imagUpDown.ValueChanged += new System.EventHandler(this.ImagUpDown_ValueChanged);
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(32, 64);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(106, 23);
            this.CalculateButton.TabIndex = 2;
            this.CalculateButton.Text = "Calculate";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // C0
            // 
            this.C0.AutoSize = true;
            this.C0.Location = new System.Drawing.Point(6, 14);
            this.C0.Name = "C0";
            this.C0.Size = new System.Drawing.Size(20, 13);
            this.C0.TabIndex = 3;
            this.C0.Text = "C0";
            // 
            // C1
            // 
            this.C1.AutoSize = true;
            this.C1.Location = new System.Drawing.Point(6, 40);
            this.C1.Name = "C1";
            this.C1.Size = new System.Drawing.Size(20, 13);
            this.C1.TabIndex = 4;
            this.C1.Text = "C1";
            // 
            // DrawRegion
            // 
            this.DrawRegion.Location = new System.Drawing.Point(167, 8);
            this.DrawRegion.Name = "DrawRegion";
            this.DrawRegion.Size = new System.Drawing.Size(800, 800);
            this.DrawRegion.TabIndex = 5;
            this.DrawRegion.TabStop = false;
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(32, 93);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(106, 23);
            this.ResetButton.TabIndex = 6;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // Help
            // 
            this.Help.AutoSize = true;
            this.Help.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Help.Location = new System.Drawing.Point(174, 14);
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(283, 20);
            this.Help.TabIndex = 7;
            this.Help.Text = "Click on a region of the screen to zoom";
            // 
            // JuliaSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 820);
            this.Controls.Add(this.Help);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.DrawRegion);
            this.Controls.Add(this.C1);
            this.Controls.Add(this.C0);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.imagUpDown);
            this.Controls.Add(this.realUpDown);
            this.Name = "JuliaSet";
            this.Text = "Julia Set Generator";
            ((System.ComponentModel.ISupportInitialize)(this.realUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawRegion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown realUpDown;
        private System.Windows.Forms.NumericUpDown imagUpDown;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.Label C0;
        private System.Windows.Forms.Label C1;
        private System.Windows.Forms.PictureBox DrawRegion;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Label Help;
    }
}

