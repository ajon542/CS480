namespace Mandelbrot
{
    partial class Mandelbrot
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
            this.C0 = new System.Windows.Forms.Label();
            this.DrawRegion = new System.Windows.Forms.PictureBox();
            this.ResetButton = new System.Windows.Forms.Button();
            this.Help = new System.Windows.Forms.Label();
            this.colorSchemeCombo = new System.Windows.Forms.ComboBox();
            this.ColorSchemeLabel = new System.Windows.Forms.Label();
            this.XLabel = new System.Windows.Forms.Label();
            this.YLabel = new System.Windows.Forms.Label();
            this.xCoordLabel = new System.Windows.Forms.Label();
            this.yCoordLabel = new System.Windows.Forms.Label();
            this.IterationsLabel = new System.Windows.Forms.Label();
            this.IterationCountLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.DrawTimeLabel = new System.Windows.Forms.Label();
            this.C1 = new System.Windows.Forms.Label();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.imagUpDown = new System.Windows.Forms.NumericUpDown();
            this.sampleCombo = new System.Windows.Forms.ComboBox();
            this.SampleLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.realUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagUpDown)).BeginInit();
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
            // C0
            // 
            this.C0.AutoSize = true;
            this.C0.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.C0.Location = new System.Drawing.Point(6, 14);
            this.C0.Name = "C0";
            this.C0.Size = new System.Drawing.Size(19, 13);
            this.C0.TabIndex = 3;
            this.C0.Text = "C0";
            // 
            // DrawRegion
            // 
            this.DrawRegion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DrawRegion.Location = new System.Drawing.Point(167, 8);
            this.DrawRegion.Name = "DrawRegion";
            this.DrawRegion.Size = new System.Drawing.Size(800, 800);
            this.DrawRegion.TabIndex = 5;
            this.DrawRegion.TabStop = false;
            // 
            // ResetButton
            // 
            this.ResetButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
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
            this.Help.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Help.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Help.Location = new System.Drawing.Point(174, 14);
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(283, 20);
            this.Help.TabIndex = 7;
            this.Help.Text = "Click on a region of the screen to zoom";
            // 
            // colorSchemeCombo
            // 
            this.colorSchemeCombo.FormattingEnabled = true;
            this.colorSchemeCombo.Items.AddRange(new object[] {
            "Red",
            "Black to White",
            "Blue to Gold"});
            this.colorSchemeCombo.Location = new System.Drawing.Point(32, 150);
            this.colorSchemeCombo.Name = "colorSchemeCombo";
            this.colorSchemeCombo.Size = new System.Drawing.Size(106, 21);
            this.colorSchemeCombo.TabIndex = 8;
            this.colorSchemeCombo.SelectedIndexChanged += new System.EventHandler(this.ColorSchemeComboBox_SelectedIndexChanged);
            // 
            // ColorSchemeLabel
            // 
            this.ColorSchemeLabel.AutoSize = true;
            this.ColorSchemeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ColorSchemeLabel.Location = new System.Drawing.Point(32, 131);
            this.ColorSchemeLabel.Name = "ColorSchemeLabel";
            this.ColorSchemeLabel.Size = new System.Drawing.Size(79, 13);
            this.ColorSchemeLabel.TabIndex = 9;
            this.ColorSchemeLabel.Text = "Color Scheme";
            // 
            // XLabel
            // 
            this.XLabel.AutoSize = true;
            this.XLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.XLabel.Location = new System.Drawing.Point(32, 776);
            this.XLabel.Name = "XLabel";
            this.XLabel.Size = new System.Drawing.Size(43, 13);
            this.XLabel.TabIndex = 10;
            this.XLabel.Text = "XCoord";
            // 
            // YLabel
            // 
            this.YLabel.AutoSize = true;
            this.YLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.YLabel.Location = new System.Drawing.Point(32, 789);
            this.YLabel.Name = "YLabel";
            this.YLabel.Size = new System.Drawing.Size(43, 13);
            this.YLabel.TabIndex = 11;
            this.YLabel.Text = "YCoord";
            // 
            // xCoordLabel
            // 
            this.xCoordLabel.AutoSize = true;
            this.xCoordLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.xCoordLabel.Location = new System.Drawing.Point(9, 776);
            this.xCoordLabel.Name = "xCoordLabel";
            this.xCoordLabel.Size = new System.Drawing.Size(19, 13);
            this.xCoordLabel.TabIndex = 12;
            this.xCoordLabel.Text = "x:";
            // 
            // yCoordLabel
            // 
            this.yCoordLabel.AutoSize = true;
            this.yCoordLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.yCoordLabel.Location = new System.Drawing.Point(9, 789);
            this.yCoordLabel.Name = "yCoordLabel";
            this.yCoordLabel.Size = new System.Drawing.Size(19, 13);
            this.yCoordLabel.TabIndex = 13;
            this.yCoordLabel.Text = "y:";
            // 
            // IterationsLabel
            // 
            this.IterationsLabel.AutoSize = true;
            this.IterationsLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.IterationsLabel.Location = new System.Drawing.Point(6, 753);
            this.IterationsLabel.Name = "IterationsLabel";
            this.IterationsLabel.Size = new System.Drawing.Size(37, 13);
            this.IterationsLabel.TabIndex = 14;
            this.IterationsLabel.Text = "Iter:";
            // 
            // IterationCountLabel
            // 
            this.IterationCountLabel.AutoSize = true;
            this.IterationCountLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.IterationCountLabel.Location = new System.Drawing.Point(47, 753);
            this.IterationCountLabel.Name = "IterationCountLabel";
            this.IterationCountLabel.Size = new System.Drawing.Size(91, 13);
            this.IterationCountLabel.TabIndex = 15;
            this.IterationCountLabel.Text = "IterationCount";
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TimeLabel.Location = new System.Drawing.Point(6, 740);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(37, 13);
            this.TimeLabel.TabIndex = 16;
            this.TimeLabel.Text = "Time:";
            // 
            // DrawTimeLabel
            // 
            this.DrawTimeLabel.AutoSize = true;
            this.DrawTimeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DrawTimeLabel.Location = new System.Drawing.Point(47, 740);
            this.DrawTimeLabel.Name = "DrawTimeLabel";
            this.DrawTimeLabel.Size = new System.Drawing.Size(55, 13);
            this.DrawTimeLabel.TabIndex = 17;
            this.DrawTimeLabel.Text = "DrawTime";
            // 
            // C1
            // 
            this.C1.AutoSize = true;
            this.C1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.C1.Location = new System.Drawing.Point(6, 40);
            this.C1.Name = "C1";
            this.C1.Size = new System.Drawing.Size(19, 13);
            this.C1.TabIndex = 4;
            this.C1.Text = "C1";
            // 
            // CalculateButton
            // 
            this.CalculateButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CalculateButton.Location = new System.Drawing.Point(32, 64);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(106, 23);
            this.CalculateButton.TabIndex = 2;
            this.CalculateButton.Text = "Calculate";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // imagUpDown
            // 
            this.imagUpDown.Location = new System.Drawing.Point(32, 38);
            this.imagUpDown.Name = "imagUpDown";
            this.imagUpDown.Size = new System.Drawing.Size(106, 20);
            this.imagUpDown.TabIndex = 1;
            this.imagUpDown.ValueChanged += new System.EventHandler(this.ImagUpDown_ValueChanged);
            // 
            // sampleCombo
            // 
            this.sampleCombo.FormattingEnabled = true;
            this.sampleCombo.Items.AddRange(new object[] {
            "-1.476 + 0i",
            "-0.12 - 0.77i",
            "-0.162 + 1.04i",
            "-1.25 + 0i",
            "0.11 + 0.6557i"});
            this.sampleCombo.Location = new System.Drawing.Point(32, 195);
            this.sampleCombo.Name = "sampleCombo";
            this.sampleCombo.Size = new System.Drawing.Size(106, 21);
            this.sampleCombo.TabIndex = 19;
            this.sampleCombo.SelectedIndexChanged += new System.EventHandler(this.SamplesComboBox_SelectedIndexChanged);
            // 
            // SampleLabel
            // 
            this.SampleLabel.AutoSize = true;
            this.SampleLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SampleLabel.Location = new System.Drawing.Point(32, 178);
            this.SampleLabel.Name = "SampleLabel";
            this.SampleLabel.Size = new System.Drawing.Size(49, 13);
            this.SampleLabel.TabIndex = 18;
            this.SampleLabel.Text = "Samples";
            // 
            // Mandelbrot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 820);
            this.Controls.Add(this.sampleCombo);
            this.Controls.Add(this.SampleLabel);
            this.Controls.Add(this.DrawTimeLabel);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.IterationCountLabel);
            this.Controls.Add(this.IterationsLabel);
            this.Controls.Add(this.yCoordLabel);
            this.Controls.Add(this.xCoordLabel);
            this.Controls.Add(this.YLabel);
            this.Controls.Add(this.XLabel);
            this.Controls.Add(this.ColorSchemeLabel);
            this.Controls.Add(this.colorSchemeCombo);
            this.Controls.Add(this.Help);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.DrawRegion);
            this.Controls.Add(this.C1);
            this.Controls.Add(this.C0);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.imagUpDown);
            this.Controls.Add(this.realUpDown);
            this.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Name = "Mandelbrot";
            this.Text = "Mandelbrot Set Generator";
            ((System.ComponentModel.ISupportInitialize)(this.realUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown realUpDown;
        private System.Windows.Forms.Label C0;
        private System.Windows.Forms.PictureBox DrawRegion;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Label Help;
        private System.Windows.Forms.ComboBox colorSchemeCombo;
        private System.Windows.Forms.Label ColorSchemeLabel;
        private System.Windows.Forms.Label XLabel;
        private System.Windows.Forms.Label YLabel;
        private System.Windows.Forms.Label xCoordLabel;
        private System.Windows.Forms.Label yCoordLabel;
        private System.Windows.Forms.Label IterationsLabel;
        private System.Windows.Forms.Label IterationCountLabel;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label DrawTimeLabel;
        private System.Windows.Forms.Label C1;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.NumericUpDown imagUpDown;
        private System.Windows.Forms.ComboBox sampleCombo;
        private System.Windows.Forms.Label SampleLabel;
    }
}

