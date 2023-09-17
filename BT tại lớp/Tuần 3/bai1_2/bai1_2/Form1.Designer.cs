namespace bai1_2
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.radioBtn_bac2 = new System.Windows.Forms.RadioButton();
            this.radioBtn_bac1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_nhapa = new System.Windows.Forms.TextBox();
            this.txt_nhapb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_nhapc = new System.Windows.Forms.TextBox();
            this.txt_kq = new System.Windows.Forms.TextBox();
            this.btn_giai = new System.Windows.Forms.Button();
            this.thoat = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_tieptuc = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "nhap a";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.radioBtn_bac2);
            this.groupBox1.Controls.Add(this.radioBtn_bac1);
            this.groupBox1.Location = new System.Drawing.Point(26, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 109);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "ban vui long chon";
            // 
            // radioBtn_bac2
            // 
            this.radioBtn_bac2.AutoSize = true;
            this.radioBtn_bac2.Location = new System.Drawing.Point(24, 71);
            this.radioBtn_bac2.Name = "radioBtn_bac2";
            this.radioBtn_bac2.Size = new System.Drawing.Size(92, 21);
            this.radioBtn_bac2.TabIndex = 1;
            this.radioBtn_bac2.TabStop = true;
            this.radioBtn_bac2.Text = "Pt bac hai";
            this.radioBtn_bac2.UseVisualStyleBackColor = true;
            this.radioBtn_bac2.CheckedChanged += new System.EventHandler(this.radioBtn_bac2_CheckedChanged);
            // 
            // radioBtn_bac1
            // 
            this.radioBtn_bac1.AutoSize = true;
            this.radioBtn_bac1.Location = new System.Drawing.Point(24, 37);
            this.radioBtn_bac1.Name = "radioBtn_bac1";
            this.radioBtn_bac1.Size = new System.Drawing.Size(101, 21);
            this.radioBtn_bac1.TabIndex = 1;
            this.radioBtn_bac1.TabStop = true;
            this.radioBtn_bac1.Text = "Pt bac nhat";
            this.radioBtn_bac1.UseVisualStyleBackColor = true;
            this.radioBtn_bac1.CheckedChanged += new System.EventHandler(this.radioBtn_bac1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "nhap b";
            // 
            // txt_nhapa
            // 
            this.txt_nhapa.Location = new System.Drawing.Point(91, 199);
            this.txt_nhapa.Name = "txt_nhapa";
            this.txt_nhapa.Size = new System.Drawing.Size(152, 22);
            this.txt_nhapa.TabIndex = 2;
            // 
            // txt_nhapb
            // 
            this.txt_nhapb.Location = new System.Drawing.Point(91, 238);
            this.txt_nhapb.Name = "txt_nhapb";
            this.txt_nhapb.Size = new System.Drawing.Size(152, 22);
            this.txt_nhapb.TabIndex = 2;
            this.txt_nhapb.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "nhap c";
            // 
            // txt_nhapc
            // 
            this.txt_nhapc.Location = new System.Drawing.Point(91, 274);
            this.txt_nhapc.Name = "txt_nhapc";
            this.txt_nhapc.Size = new System.Drawing.Size(152, 22);
            this.txt_nhapc.TabIndex = 2;
            this.txt_nhapc.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txt_kq
            // 
            this.txt_kq.Location = new System.Drawing.Point(91, 322);
            this.txt_kq.Multiline = true;
            this.txt_kq.Name = "txt_kq";
            this.txt_kq.Size = new System.Drawing.Size(247, 73);
            this.txt_kq.TabIndex = 2;
            this.txt_kq.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // btn_giai
            // 
            this.btn_giai.Location = new System.Drawing.Point(263, 224);
            this.btn_giai.Name = "btn_giai";
            this.btn_giai.Size = new System.Drawing.Size(75, 41);
            this.btn_giai.TabIndex = 3;
            this.btn_giai.Text = "giai";
            this.btn_giai.UseVisualStyleBackColor = true;
            this.btn_giai.Click += new System.EventHandler(this.btn_giai_Click);
            // 
            // thoat
            // 
            this.thoat.Location = new System.Drawing.Point(263, 274);
            this.thoat.Name = "thoat";
            this.thoat.Size = new System.Drawing.Size(75, 41);
            this.thoat.TabIndex = 3;
            this.thoat.Text = "thoat";
            this.thoat.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 325);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "ket qua";
            // 
            // btn_tieptuc
            // 
            this.btn_tieptuc.Location = new System.Drawing.Point(263, 171);
            this.btn_tieptuc.Name = "btn_tieptuc";
            this.btn_tieptuc.Size = new System.Drawing.Size(75, 41);
            this.btn_tieptuc.TabIndex = 3;
            this.btn_tieptuc.Text = "tiep tuc";
            this.btn_tieptuc.UseVisualStyleBackColor = true;
            this.btn_tieptuc.Click += new System.EventHandler(this.btn_tieptuc_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 430);
            this.Controls.Add(this.thoat);
            this.Controls.Add(this.btn_tieptuc);
            this.Controls.Add(this.btn_giai);
            this.Controls.Add(this.txt_kq);
            this.Controls.Add(this.txt_nhapc);
            this.Controls.Add(this.txt_nhapb);
            this.Controls.Add(this.txt_nhapa);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioBtn_bac2;
        private System.Windows.Forms.RadioButton radioBtn_bac1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_nhapa;
        private System.Windows.Forms.TextBox txt_nhapb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_nhapc;
        private System.Windows.Forms.TextBox txt_kq;
        private System.Windows.Forms.Button btn_giai;
        private System.Windows.Forms.Button thoat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_tieptuc;
    }
}

