namespace DoAnCuoiKy
{
    partial class frmBaoCao
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
            this.cbo_MaTuyen = new System.Windows.Forms.ComboBox();
            this.cbo_BienSo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_NgayKH = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXuat = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chọn lộ trình";
            // 
            // cbo_MaTuyen
            // 
            this.cbo_MaTuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_MaTuyen.FormattingEnabled = true;
            this.cbo_MaTuyen.Location = new System.Drawing.Point(92, 6);
            this.cbo_MaTuyen.Name = "cbo_MaTuyen";
            this.cbo_MaTuyen.Size = new System.Drawing.Size(348, 21);
            this.cbo_MaTuyen.TabIndex = 2;
            // 
            // cbo_BienSo
            // 
            this.cbo_BienSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_BienSo.FormattingEnabled = true;
            this.cbo_BienSo.Location = new System.Drawing.Point(92, 33);
            this.cbo_BienSo.Name = "cbo_BienSo";
            this.cbo_BienSo.Size = new System.Drawing.Size(134, 21);
            this.cbo_BienSo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Chọn xe";
            // 
            // cbo_NgayKH
            // 
            this.cbo_NgayKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_NgayKH.FormattingEnabled = true;
            this.cbo_NgayKH.Location = new System.Drawing.Point(92, 59);
            this.cbo_NgayKH.Name = "cbo_NgayKH";
            this.cbo_NgayKH.Size = new System.Drawing.Size(134, 21);
            this.cbo_NgayKH.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Chọn ngày KH";
            // 
            // btnXuat
            // 
            this.btnXuat.Location = new System.Drawing.Point(476, 13);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(104, 23);
            this.btnXuat.TabIndex = 7;
            this.btnXuat.Text = "Xuất báo cáo";
            this.btnXuat.UseVisualStyleBackColor = true;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(476, 42);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 23);
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QL_BanVeXe.rptBaoCao.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(9, 95);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(788, 344);
            this.reportViewer1.TabIndex = 9;
            // 
            // frmBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.cbo_NgayKH);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbo_BienSo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbo_MaTuyen);
            this.Controls.Add(this.label1);
            this.Name = "frmBaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBaoCao";
            this.Load += new System.EventHandler(this.frmBaoCao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_MaTuyen;
        private System.Windows.Forms.ComboBox cbo_BienSo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbo_NgayKH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.Button btnThoat;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}