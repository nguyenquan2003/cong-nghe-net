namespace Buoi4_Bai1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lstLeft = new System.Windows.Forms.ListBox();
            this.lstRight = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(352, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = ">";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(352, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 35);
            this.button2.TabIndex = 1;
            this.button2.Text = ">>";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(352, 141);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(82, 35);
            this.button3.TabIndex = 2;
            this.button3.Text = "<";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(352, 186);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(82, 35);
            this.button4.TabIndex = 3;
            this.button4.Text = "<<";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lstLeft
            // 
            this.lstLeft.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLeft.FormattingEnabled = true;
            this.lstLeft.ItemHeight = 27;
            this.lstLeft.Items.AddRange(new object[] {
            "Cốc",
            "Ổi",
            "Xoài",
            "Me ",
            "Bưởi ",
            "Cam"});
            this.lstLeft.Location = new System.Drawing.Point(90, 53);
            this.lstLeft.Name = "lstLeft";
            this.lstLeft.Size = new System.Drawing.Size(184, 193);
            this.lstLeft.TabIndex = 4;
            this.lstLeft.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // lstRight
            // 
            this.lstRight.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstRight.FormattingEnabled = true;
            this.lstRight.ItemHeight = 27;
            this.lstRight.Location = new System.Drawing.Point(518, 53);
            this.lstRight.Name = "lstRight";
            this.lstRight.Size = new System.Drawing.Size(184, 193);
            this.lstRight.TabIndex = 5;
            this.lstRight.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstRight);
            this.Controls.Add(this.lstLeft);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox lstLeft;
        private System.Windows.Forms.ListBox lstRight;
    }
}

