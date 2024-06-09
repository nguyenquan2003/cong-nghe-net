namespace QLTV
{
    partial class DanhSachQuaHan
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
            this.pnl_dsqh = new System.Windows.Forms.Panel();
            this.pnl_thongtin = new System.Windows.Forms.Panel();
            this.bt_quaylai = new System.Windows.Forms.Button();
            this.bt_xuly = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ghiChu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.soNgayTre = new System.Windows.Forms.TextBox();
            this.lb_soluongcon = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.maPM = new System.Windows.Forms.TextBox();
            this.dgv_QuaHan = new System.Windows.Forms.DataGridView();
            this.pnl_top = new System.Windows.Forms.Panel();
            this.lb_top = new System.Windows.Forms.Label();
            this.pnl_dsqh.SuspendLayout();
            this.pnl_thongtin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_QuaHan)).BeginInit();
            this.pnl_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_dsqh
            // 
            this.pnl_dsqh.Controls.Add(this.pnl_thongtin);
            this.pnl_dsqh.Controls.Add(this.dgv_QuaHan);
            this.pnl_dsqh.Controls.Add(this.pnl_top);
            this.pnl_dsqh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_dsqh.Location = new System.Drawing.Point(0, 0);
            this.pnl_dsqh.Name = "pnl_dsqh";
            this.pnl_dsqh.Size = new System.Drawing.Size(1133, 838);
            this.pnl_dsqh.TabIndex = 0;
            // 
            // pnl_thongtin
            // 
            this.pnl_thongtin.BackColor = System.Drawing.Color.White;
            this.pnl_thongtin.Controls.Add(this.bt_quaylai);
            this.pnl_thongtin.Controls.Add(this.bt_xuly);
            this.pnl_thongtin.Controls.Add(this.label3);
            this.pnl_thongtin.Controls.Add(this.panel4);
            this.pnl_thongtin.Controls.Add(this.ghiChu);
            this.pnl_thongtin.Controls.Add(this.label2);
            this.pnl_thongtin.Controls.Add(this.panel3);
            this.pnl_thongtin.Controls.Add(this.soNgayTre);
            this.pnl_thongtin.Controls.Add(this.lb_soluongcon);
            this.pnl_thongtin.Controls.Add(this.panel5);
            this.pnl_thongtin.Controls.Add(this.maPM);
            this.pnl_thongtin.Location = new System.Drawing.Point(26, 68);
            this.pnl_thongtin.Name = "pnl_thongtin";
            this.pnl_thongtin.Size = new System.Drawing.Size(1082, 312);
            this.pnl_thongtin.TabIndex = 73;
            // 
            // bt_quaylai
            // 
            this.bt_quaylai.BackColor = System.Drawing.Color.Teal;
            this.bt_quaylai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_quaylai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_quaylai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_quaylai.ForeColor = System.Drawing.Color.White;
            this.bt_quaylai.Location = new System.Drawing.Point(823, 183);
            this.bt_quaylai.Margin = new System.Windows.Forms.Padding(4);
            this.bt_quaylai.Name = "bt_quaylai";
            this.bt_quaylai.Size = new System.Drawing.Size(177, 68);
            this.bt_quaylai.TabIndex = 72;
            this.bt_quaylai.Text = "Quay lại";
            this.bt_quaylai.UseVisualStyleBackColor = false;
            this.bt_quaylai.Click += new System.EventHandler(this.bt_quaylai_Click);
            // 
            // bt_xuly
            // 
            this.bt_xuly.BackColor = System.Drawing.Color.Teal;
            this.bt_xuly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_xuly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_xuly.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_xuly.ForeColor = System.Drawing.Color.White;
            this.bt_xuly.Location = new System.Drawing.Point(823, 34);
            this.bt_xuly.Margin = new System.Windows.Forms.Padding(4);
            this.bt_xuly.Name = "bt_xuly";
            this.bt_xuly.Size = new System.Drawing.Size(177, 68);
            this.bt_xuly.TabIndex = 71;
            this.bt_xuly.Text = "Xử lý";
            this.bt_xuly.UseVisualStyleBackColor = false;
            this.bt_xuly.Click += new System.EventHandler(this.bt_xuly_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(41, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 70;
            this.label3.Text = "Ghi Chú";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gray;
            this.panel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel4.Location = new System.Drawing.Point(44, 249);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(528, 2);
            this.panel4.TabIndex = 69;
            // 
            // ghiChu
            // 
            this.ghiChu.BackColor = System.Drawing.Color.White;
            this.ghiChu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ghiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghiChu.ForeColor = System.Drawing.Color.Black;
            this.ghiChu.Location = new System.Drawing.Point(214, 218);
            this.ghiChu.Multiline = true;
            this.ghiChu.Name = "ghiChu";
            this.ghiChu.Size = new System.Drawing.Size(358, 30);
            this.ghiChu.TabIndex = 68;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(40, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 67;
            this.label2.Text = "Số Ngày Trễ";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel3.Location = new System.Drawing.Point(44, 153);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(528, 2);
            this.panel3.TabIndex = 66;
            // 
            // soNgayTre
            // 
            this.soNgayTre.BackColor = System.Drawing.Color.White;
            this.soNgayTre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.soNgayTre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soNgayTre.ForeColor = System.Drawing.Color.Black;
            this.soNgayTre.Location = new System.Drawing.Point(214, 122);
            this.soNgayTre.Multiline = true;
            this.soNgayTre.Name = "soNgayTre";
            this.soNgayTre.Size = new System.Drawing.Size(358, 30);
            this.soNgayTre.TabIndex = 65;
            // 
            // lb_soluongcon
            // 
            this.lb_soluongcon.AutoSize = true;
            this.lb_soluongcon.BackColor = System.Drawing.Color.White;
            this.lb_soluongcon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_soluongcon.ForeColor = System.Drawing.Color.Teal;
            this.lb_soluongcon.Location = new System.Drawing.Point(41, 39);
            this.lb_soluongcon.Name = "lb_soluongcon";
            this.lb_soluongcon.Size = new System.Drawing.Size(136, 20);
            this.lb_soluongcon.TabIndex = 64;
            this.lb_soluongcon.Text = "Mã Phiếu Mượn *";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gray;
            this.panel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel5.Location = new System.Drawing.Point(44, 70);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(528, 2);
            this.panel5.TabIndex = 63;
            // 
            // maPM
            // 
            this.maPM.BackColor = System.Drawing.Color.White;
            this.maPM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maPM.ForeColor = System.Drawing.Color.Black;
            this.maPM.Location = new System.Drawing.Point(214, 39);
            this.maPM.Multiline = true;
            this.maPM.Name = "maPM";
            this.maPM.Size = new System.Drawing.Size(358, 30);
            this.maPM.TabIndex = 62;
            // 
            // dgv_QuaHan
            // 
            this.dgv_QuaHan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_QuaHan.Location = new System.Drawing.Point(26, 414);
            this.dgv_QuaHan.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_QuaHan.Name = "dgv_QuaHan";
            this.dgv_QuaHan.Size = new System.Drawing.Size(1082, 411);
            this.dgv_QuaHan.TabIndex = 5;
            this.dgv_QuaHan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_quahan_CellContentClick);
            // 
            // pnl_top
            // 
            this.pnl_top.BackColor = System.Drawing.Color.Teal;
            this.pnl_top.Controls.Add(this.lb_top);
            this.pnl_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_top.Location = new System.Drawing.Point(0, 0);
            this.pnl_top.Name = "pnl_top";
            this.pnl_top.Size = new System.Drawing.Size(1133, 47);
            this.pnl_top.TabIndex = 4;
            // 
            // lb_top
            // 
            this.lb_top.AutoSize = true;
            this.lb_top.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_top.ForeColor = System.Drawing.Color.White;
            this.lb_top.Location = new System.Drawing.Point(22, 13);
            this.lb_top.Name = "lb_top";
            this.lb_top.Size = new System.Drawing.Size(192, 20);
            this.lb_top.TabIndex = 0;
            this.lb_top.Text = "DANH SÁCH QUÁ HẠN";
            // 
            // DanhSachQuaHan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 838);
            this.Controls.Add(this.pnl_dsqh);
            this.Name = "DanhSachQuaHan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DanhSachQuaHan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DanhSachQuaHan_FormClosing);
            this.Load += new System.EventHandler(this.DanhSachQuaHan_Load);
            this.pnl_dsqh.ResumeLayout(false);
            this.pnl_thongtin.ResumeLayout(false);
            this.pnl_thongtin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_QuaHan)).EndInit();
            this.pnl_top.ResumeLayout(false);
            this.pnl_top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_dsqh;
        private System.Windows.Forms.Panel pnl_top;
        private System.Windows.Forms.Label lb_top;
        private System.Windows.Forms.DataGridView dgv_QuaHan;
        private System.Windows.Forms.Label lb_soluongcon;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox maPM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox soNgayTre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox ghiChu;
        private System.Windows.Forms.Button bt_xuly;
        private System.Windows.Forms.Button bt_quaylai;
        private System.Windows.Forms.Panel pnl_thongtin;

    }
}