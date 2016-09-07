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
            this.UpdateButton = new System.Windows.Forms.Button();
            this.C0 = new System.Windows.Forms.Label();
            this.C1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.realUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // realUpDown
            // 
            this.realUpDown.Location = new System.Drawing.Point(581, 695);
            this.realUpDown.Name = "realUpDown";
            this.realUpDown.Size = new System.Drawing.Size(106, 20);
            this.realUpDown.TabIndex = 0;
            this.realUpDown.ValueChanged += new System.EventHandler(this.RealUpDown_ValueChanged);
            // 
            // imagUpDown
            // 
            this.imagUpDown.Location = new System.Drawing.Point(581, 730);
            this.imagUpDown.Name = "imagUpDown";
            this.imagUpDown.Size = new System.Drawing.Size(106, 20);
            this.imagUpDown.TabIndex = 1;
            this.imagUpDown.ValueChanged += new System.EventHandler(this.ImagUpDown_ValueChanged);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(693, 730);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(79, 23);
            this.UpdateButton.TabIndex = 2;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // C0
            // 
            this.C0.AutoSize = true;
            this.C0.Location = new System.Drawing.Point(555, 697);
            this.C0.Name = "C0";
            this.C0.Size = new System.Drawing.Size(20, 13);
            this.C0.TabIndex = 3;
            this.C0.Text = "C0";
            // 
            // C1
            // 
            this.C1.AutoSize = true;
            this.C1.Location = new System.Drawing.Point(555, 732);
            this.C1.Name = "C1";
            this.C1.Size = new System.Drawing.Size(20, 13);
            this.C1.TabIndex = 4;
            this.C1.Text = "C1";
            // 
            // JuliaSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 762);
            this.Controls.Add(this.C1);
            this.Controls.Add(this.C0);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.imagUpDown);
            this.Controls.Add(this.realUpDown);
            this.Name = "JuliaSet";
            this.Text = "Julia Set Generator";
            ((System.ComponentModel.ISupportInitialize)(this.realUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown realUpDown;
        private System.Windows.Forms.NumericUpDown imagUpDown;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Label C0;
        private System.Windows.Forms.Label C1;
    }
}

