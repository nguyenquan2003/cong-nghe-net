namespace Buoi4_Bai1TaiLop
{
    partial class frmTreeView
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
            this.trv_DS = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbo_phongban = new System.Windows.Forms.ComboBox();
            this.txt_maso = new System.Windows.Forms.TextBox();
            this.txt_diachi = new System.Windows.Forms.TextBox();
            this.txt_hoten = new System.Windows.Forms.TextBox();
            this.btn_ThemNV = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.btn_ThemPB = new System.Windows.Forms.Button();
            this.btn_XoaPB = new System.Windows.Forms.Button();
            this.txt_phongban = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(270, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "HỒ SƠ NHÂN VIÊN";
            // 
            // trv_DS
            // 
            this.trv_DS.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trv_DS.Location = new System.Drawing.Point(32, 62);
            this.trv_DS.Name = "trv_DS";
            this.trv_DS.Size = new System.Drawing.Size(247, 244);
            this.trv_DS.TabIndex = 1;
            this.trv_DS.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.frmTreeView_AfterSelect);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã số";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(374, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(382, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(390, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 20);
            this.label5.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(398, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 20);
            this.label6.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(406, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 20);
            this.label7.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(327, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Phòng ban";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(327, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "Địa chỉ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(526, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 20);
            this.label10.TabIndex = 10;
            this.label10.Text = "Họ tên";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 337);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 20);
            this.label11.TabIndex = 11;
            this.label11.Text = "Phòng ban";
            // 
            // cbo_phongban
            // 
            this.cbo_phongban.FormattingEnabled = true;
            this.cbo_phongban.Items.AddRange(new object[] {
            "Giám đốc",
            "Tổ chức hành chính",
            "Kế hoạch",
            "Kế Toán"});
            this.cbo_phongban.Location = new System.Drawing.Point(458, 192);
            this.cbo_phongban.Name = "cbo_phongban";
            this.cbo_phongban.Size = new System.Drawing.Size(294, 28);
            this.cbo_phongban.TabIndex = 12;
            // 
            // txt_maso
            // 
            this.txt_maso.Location = new System.Drawing.Point(394, 82);
            this.txt_maso.Name = "txt_maso";
            this.txt_maso.Size = new System.Drawing.Size(100, 26);
            this.txt_maso.TabIndex = 13;
            // 
            // txt_diachi
            // 
            this.txt_diachi.Location = new System.Drawing.Point(394, 140);
            this.txt_diachi.Name = "txt_diachi";
            this.txt_diachi.Size = new System.Drawing.Size(358, 26);
            this.txt_diachi.TabIndex = 14;
            // 
            // txt_hoten
            // 
            this.txt_hoten.Location = new System.Drawing.Point(603, 82);
            this.txt_hoten.Name = "txt_hoten";
            this.txt_hoten.Size = new System.Drawing.Size(150, 26);
            this.txt_hoten.TabIndex = 15;
            // 
            // btn_ThemNV
            // 
            this.btn_ThemNV.Location = new System.Drawing.Point(338, 248);
            this.btn_ThemNV.Name = "btn_ThemNV";
            this.btn_ThemNV.Size = new System.Drawing.Size(84, 35);
            this.btn_ThemNV.TabIndex = 16;
            this.btn_ThemNV.Text = "THÊM";
            this.btn_ThemNV.UseVisualStyleBackColor = true;
            this.btn_ThemNV.Click += new System.EventHandler(this.btn_ThemNV_Click);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Location = new System.Drawing.Point(447, 248);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(84, 35);
            this.btn_Thoat.TabIndex = 17;
            this.btn_Thoat.Text = "THOÁT";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_ThemPB
            // 
            this.btn_ThemPB.Location = new System.Drawing.Point(128, 368);
            this.btn_ThemPB.Name = "btn_ThemPB";
            this.btn_ThemPB.Size = new System.Drawing.Size(152, 35);
            this.btn_ThemPB.TabIndex = 18;
            this.btn_ThemPB.Text = "Thêm phòng ban";
            this.btn_ThemPB.UseVisualStyleBackColor = true;
            this.btn_ThemPB.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_XoaPB
            // 
            this.btn_XoaPB.Location = new System.Drawing.Point(128, 408);
            this.btn_XoaPB.Name = "btn_XoaPB";
            this.btn_XoaPB.Size = new System.Drawing.Size(152, 35);
            this.btn_XoaPB.TabIndex = 19;
            this.btn_XoaPB.Text = "Xóa phòng ban";
            this.btn_XoaPB.UseVisualStyleBackColor = true;
            this.btn_XoaPB.Click += new System.EventHandler(this.btn_XoaPB_Click);
            // 
            // txt_phongban
            // 
            this.txt_phongban.Location = new System.Drawing.Point(128, 337);
            this.txt_phongban.Name = "txt_phongban";
            this.txt_phongban.Size = new System.Drawing.Size(152, 26);
            this.txt_phongban.TabIndex = 20;
            // 
            // frmTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 449);
            this.Controls.Add(this.txt_phongban);
            this.Controls.Add(this.btn_XoaPB);
            this.Controls.Add(this.btn_ThemPB);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_ThemNV);
            this.Controls.Add(this.txt_hoten);
            this.Controls.Add(this.txt_diachi);
            this.Controls.Add(this.txt_maso);
            this.Controls.Add(this.cbo_phongban);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trv_DS);
            this.Controls.Add(this.label1);
            this.Name = "frmTreeView";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView trv_DS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbo_phongban;
        private System.Windows.Forms.TextBox txt_maso;
        private System.Windows.Forms.TextBox txt_diachi;
        private System.Windows.Forms.TextBox txt_hoten;
        private System.Windows.Forms.Button btn_ThemNV;
        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.Button btn_ThemPB;
        private System.Windows.Forms.Button btn_XoaPB;
        private System.Windows.Forms.TextBox txt_phongban;
    }
}

