namespace comb1
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.Button();
            this.MAXC = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MXC = new System.Windows.Forms.TextBox();
            this.DtMc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MT = new System.Windows.Forms.TextBox();
            this.CRALE = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DrawRegion = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Interactive = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DrawRegion)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.AllowDrop = true;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "0006",
            "0008",
            "0009",
            "0010",
            "0012",
            "0015",
            "0018",
            "0021",
            "0024",
            "1408",
            "1410",
            "1412",
            " 2408",
            " 2410",
            " 2411",
            " 2412",
            " 2414",
            "2415",
            " 2418",
            "2421",
            "2424",
            " 4412",
            "4415",
            "4418",
            "4421",
            "4424",
            "6409",
            "6412"});
            this.comboBox1.Location = new System.Drawing.Point(101, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(64, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "0006";
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(1, -1);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(88, 23);
            this.Button1.TabIndex = 1;
            this.Button1.Text = "Start Analysis";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Design_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "NACA NUMBER";
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(90, -1);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 3;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // MAXC
            // 
            this.MAXC.AutoSize = true;
            this.MAXC.Location = new System.Drawing.Point(2, 57);
            this.MAXC.Name = "MAXC";
            this.MAXC.Size = new System.Drawing.Size(66, 13);
            this.MAXC.TabIndex = 4;
            this.MAXC.Text = "Max Camber";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Dist. to Max Cam.";
            // 
            // MXC
            // 
            this.MXC.Location = new System.Drawing.Point(101, 55);
            this.MXC.Name = "MXC";
            this.MXC.Size = new System.Drawing.Size(64, 20);
            this.MXC.TabIndex = 6;
            // 
            // DtMc
            // 
            this.DtMc.Location = new System.Drawing.Point(101, 80);
            this.DtMc.Name = "DtMc";
            this.DtMc.Size = new System.Drawing.Size(64, 20);
            this.DtMc.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Max Thickness";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Circle Radius At";
            // 
            // MT
            // 
            this.MT.Location = new System.Drawing.Point(101, 102);
            this.MT.Name = "MT";
            this.MT.Size = new System.Drawing.Size(64, 20);
            this.MT.TabIndex = 10;
            // 
            // CRALE
            // 
            this.CRALE.Location = new System.Drawing.Point(101, 138);
            this.CRALE.Name = "CRALE";
            this.CRALE.Size = new System.Drawing.Size(64, 20);
            this.CRALE.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Leading Edge";
            // 
            // DrawRegion
            // 
            this.DrawRegion.Location = new System.Drawing.Point(171, -1);
            this.DrawRegion.Name = "DrawRegion";
            this.DrawRegion.Size = new System.Drawing.Size(819, 443);
            this.DrawRegion.TabIndex = 13;
            this.DrawRegion.TabStop = false;
            this.DrawRegion.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawRegion_Paint);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(996, -1);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(574, 446);
            this.listBox1.TabIndex = 14;
            // 
            // Interactive
            // 
            this.Interactive.AutoSize = true;
            this.Interactive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Interactive.Location = new System.Drawing.Point(5, 178);
            this.Interactive.Name = "Interactive";
            this.Interactive.Size = new System.Drawing.Size(76, 17);
            this.Interactive.TabIndex = 15;
            this.Interactive.Text = "Interactive";
            this.Interactive.UseVisualStyleBackColor = true;
            this.Interactive.CheckedChanged += new System.EventHandler(this.Interactive_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1570, 532);
            this.Controls.Add(this.Interactive);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.DrawRegion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CRALE);
            this.Controls.Add(this.MT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DtMc);
            this.Controls.Add(this.MXC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MAXC);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DrawRegion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label MAXC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox MXC;
        private System.Windows.Forms.TextBox DtMc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox MT;
        private System.Windows.Forms.TextBox CRALE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox DrawRegion;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.CheckBox Interactive;
    }
}

