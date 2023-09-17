namespace bai1
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_tinh = new System.Windows.Forms.Button();
            this.rd_thuong = new System.Windows.Forms.RadioButton();
            this.rd_tich = new System.Windows.Forms.RadioButton();
            this.rd_tru = new System.Windows.Forms.RadioButton();
            this.rd_cong = new System.Windows.Forms.RadioButton();
            this.txt_so_kq = new System.Windows.Forms.TextBox();
            this.txt_so_b = new System.Windows.Forms.TextBox();
            this.txt_so_a = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_tinh);
            this.groupBox1.Controls.Add(this.rd_thuong);
            this.groupBox1.Controls.Add(this.rd_tich);
            this.groupBox1.Controls.Add(this.rd_tru);
            this.groupBox1.Controls.Add(this.rd_cong);
            this.groupBox1.Controls.Add(this.txt_so_kq);
            this.groupBox1.Controls.Add(this.txt_so_b);
            this.groupBox1.Controls.Add(this.txt_so_a);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(39, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 270);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btn_tinh
            // 
            this.btn_tinh.Location = new System.Drawing.Point(132, 220);
            this.btn_tinh.Name = "btn_tinh";
            this.btn_tinh.Size = new System.Drawing.Size(75, 23);
            this.btn_tinh.TabIndex = 9;
            this.btn_tinh.Text = "tinh";
            this.btn_tinh.UseVisualStyleBackColor = true;
            this.btn_tinh.Click += new System.EventHandler(this.btn_tinh_Click);
            // 
            // rd_thuong
            // 
            this.rd_thuong.AutoSize = true;
            this.rd_thuong.Location = new System.Drawing.Point(263, 174);
            this.rd_thuong.Name = "rd_thuong";
            this.rd_thuong.Size = new System.Drawing.Size(33, 21);
            this.rd_thuong.TabIndex = 8;
            this.rd_thuong.TabStop = true;
            this.rd_thuong.Text = "/";
            this.rd_thuong.UseVisualStyleBackColor = true;
            // 
            // rd_tich
            // 
            this.rd_tich.AutoSize = true;
            this.rd_tich.Location = new System.Drawing.Point(192, 174);
            this.rd_tich.Name = "rd_tich";
            this.rd_tich.Size = new System.Drawing.Size(35, 21);
            this.rd_tich.TabIndex = 8;
            this.rd_tich.TabStop = true;
            this.rd_tich.Text = "x";
            this.rd_tich.UseVisualStyleBackColor = true;
            // 
            // rd_tru
            // 
            this.rd_tru.AutoSize = true;
            this.rd_tru.Location = new System.Drawing.Point(120, 174);
            this.rd_tru.Name = "rd_tru";
            this.rd_tru.Size = new System.Drawing.Size(34, 21);
            this.rd_tru.TabIndex = 8;
            this.rd_tru.TabStop = true;
            this.rd_tru.Text = "-";
            this.rd_tru.UseVisualStyleBackColor = true;
            // 
            // rd_cong
            // 
            this.rd_cong.AutoSize = true;
            this.rd_cong.Location = new System.Drawing.Point(49, 174);
            this.rd_cong.Name = "rd_cong";
            this.rd_cong.Size = new System.Drawing.Size(37, 21);
            this.rd_cong.TabIndex = 8;
            this.rd_cong.TabStop = true;
            this.rd_cong.Text = "+";
            this.rd_cong.UseVisualStyleBackColor = true;
            // 
            // txt_so_kq
            // 
            this.txt_so_kq.Location = new System.Drawing.Point(93, 107);
            this.txt_so_kq.Name = "txt_so_kq";
            this.txt_so_kq.Size = new System.Drawing.Size(159, 22);
            this.txt_so_kq.TabIndex = 5;
            this.txt_so_kq.Click += new System.EventHandler(this.txt_so_kq_Click);
            // 
            // txt_so_b
            // 
            this.txt_so_b.Location = new System.Drawing.Point(250, 38);
            this.txt_so_b.Name = "txt_so_b";
            this.txt_so_b.Size = new System.Drawing.Size(100, 22);
            this.txt_so_b.TabIndex = 6;
            this.txt_so_b.TextChanged += new System.EventHandler(this.txt_so_b_TextChanged);
            this.txt_so_b.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_so_b_KeyPress);
            // 
            // txt_so_a
            // 
            this.txt_so_a.Location = new System.Drawing.Point(44, 38);
            this.txt_so_a.Name = "txt_so_a";
            this.txt_so_a.Size = new System.Drawing.Size(100, 22);
            this.txt_so_a.TabIndex = 7;
            this.txt_so_a.TextChanged += new System.EventHandler(this.txt_so_a_TextChanged);
            this.txt_so_a.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_so_a_KeyPress);
            this.txt_so_a.Leave += new System.EventHandler(this.txt_so_a_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "ket qua";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "b=";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "a=";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 340);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_tinh;
        private System.Windows.Forms.RadioButton rd_thuong;
        private System.Windows.Forms.RadioButton rd_tich;
        private System.Windows.Forms.RadioButton rd_tru;
        private System.Windows.Forms.RadioButton rd_cong;
        private System.Windows.Forms.TextBox txt_so_kq;
        private System.Windows.Forms.TextBox txt_so_b;
        private System.Windows.Forms.TextBox txt_so_a;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

