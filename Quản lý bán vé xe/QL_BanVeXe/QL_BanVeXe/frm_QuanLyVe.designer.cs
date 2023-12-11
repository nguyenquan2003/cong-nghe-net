namespace QLVe_XuatVe
{
    partial class frm_QuanLyVe
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgv_DSVe = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_MaVe = new System.Windows.Forms.TextBox();
            this.cbo_MaTuyen = new System.Windows.Forms.ComboBox();
            this.cbo_BienSo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_HoTenKH = new System.Windows.Forms.TextBox();
            this.txt_SDTKH = new System.Windows.Forms.TextBox();
            this.txt_TenGhe = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_SoLuong = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbo_GioDi = new System.Windows.Forms.ComboBox();
            this.cbo_NgayKH = new System.Windows.Forms.ComboBox();
            this.txt_TimKiem = new System.Windows.Forms.TextBox();
            this.btn_TimKiem = new System.Windows.Forms.Button();
            this.btn_CapNhat = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_HienThiDS = new System.Windows.Forms.Button();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.btn_Huy = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_GhiChu = new System.Windows.Forms.TextBox();
            this.txt_NgayDatVe = new System.Windows.Forms.DateTimePicker();
            this.cboMaNV = new System.Windows.Forms.ComboBox();
            this.col_GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_NgayKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_GioKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_NgayDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ViTriGhe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_SDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_MaXe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_MaLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_MaVe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DSVe)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(880, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Sách Vé";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Firebrick;
            this.label2.Location = new System.Drawing.Point(10, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Vé";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Firebrick;
            this.label3.Location = new System.Drawing.Point(10, 118);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã NV";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Firebrick;
            this.label4.Location = new System.Drawing.Point(10, 155);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mã LT";
            // 
            // dgv_DSVe
            // 
            this.dgv_DSVe.AllowUserToAddRows = false;
            this.dgv_DSVe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_DSVe.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.dgv_DSVe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DSVe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_MaVe,
            this.col_MaNV,
            this.col_MaLT,
            this.col_MaXe,
            this.col_TenKH,
            this.col_SDT,
            this.col_ViTriGhe,
            this.col_SoLuong,
            this.col_NgayDat,
            this.col_GioKH,
            this.col_NgayKH,
            this.col_GhiChu});
            this.dgv_DSVe.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv_DSVe.Location = new System.Drawing.Point(13, 255);
            this.dgv_DSVe.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dgv_DSVe.Name = "dgv_DSVe";
            this.dgv_DSVe.ReadOnly = true;
            this.dgv_DSVe.RowHeadersWidth = 51;
            this.dgv_DSVe.RowTemplate.Height = 24;
            this.dgv_DSVe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_DSVe.Size = new System.Drawing.Size(880, 166);
            this.dgv_DSVe.TabIndex = 4;
            this.dgv_DSVe.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DSVe_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Firebrick;
            this.label5.Location = new System.Drawing.Point(164, 84);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Biển Số";
            // 
            // txt_MaVe
            // 
            this.txt_MaVe.Location = new System.Drawing.Point(71, 82);
            this.txt_MaVe.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txt_MaVe.Name = "txt_MaVe";
            this.txt_MaVe.Size = new System.Drawing.Size(76, 20);
            this.txt_MaVe.TabIndex = 6;
            // 
            // cbo_MaTuyen
            // 
            this.cbo_MaTuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_MaTuyen.FormattingEnabled = true;
            this.cbo_MaTuyen.Location = new System.Drawing.Point(71, 149);
            this.cbo_MaTuyen.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.cbo_MaTuyen.Name = "cbo_MaTuyen";
            this.cbo_MaTuyen.Size = new System.Drawing.Size(242, 21);
            this.cbo_MaTuyen.TabIndex = 7;
            // 
            // cbo_BienSo
            // 
            this.cbo_BienSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_BienSo.FormattingEnabled = true;
            this.cbo_BienSo.Location = new System.Drawing.Point(222, 81);
            this.cbo_BienSo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.cbo_BienSo.Name = "cbo_BienSo";
            this.cbo_BienSo.Size = new System.Drawing.Size(92, 21);
            this.cbo_BienSo.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Firebrick;
            this.label6.Location = new System.Drawing.Point(322, 84);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Tên Khách Hàng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Firebrick;
            this.label7.Location = new System.Drawing.Point(322, 118);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Số Điện Thoại";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Firebrick;
            this.label8.Location = new System.Drawing.Point(322, 155);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Vị Trí Ghế";
            // 
            // txt_HoTenKH
            // 
            this.txt_HoTenKH.Location = new System.Drawing.Point(407, 83);
            this.txt_HoTenKH.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txt_HoTenKH.Name = "txt_HoTenKH";
            this.txt_HoTenKH.Size = new System.Drawing.Size(223, 20);
            this.txt_HoTenKH.TabIndex = 13;
            // 
            // txt_SDTKH
            // 
            this.txt_SDTKH.Location = new System.Drawing.Point(407, 117);
            this.txt_SDTKH.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txt_SDTKH.Name = "txt_SDTKH";
            this.txt_SDTKH.Size = new System.Drawing.Size(76, 20);
            this.txt_SDTKH.TabIndex = 14;
            // 
            // txt_TenGhe
            // 
            this.txt_TenGhe.Location = new System.Drawing.Point(407, 152);
            this.txt_TenGhe.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txt_TenGhe.Name = "txt_TenGhe";
            this.txt_TenGhe.Size = new System.Drawing.Size(76, 20);
            this.txt_TenGhe.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Firebrick;
            this.label9.Location = new System.Drawing.Point(500, 118);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Số Lượng";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Firebrick;
            this.label10.Location = new System.Drawing.Point(500, 155);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Ngày Đặt";
            // 
            // txt_SoLuong
            // 
            this.txt_SoLuong.Location = new System.Drawing.Point(554, 117);
            this.txt_SoLuong.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txt_SoLuong.Name = "txt_SoLuong";
            this.txt_SoLuong.Size = new System.Drawing.Size(76, 20);
            this.txt_SoLuong.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Firebrick;
            this.label11.Location = new System.Drawing.Point(646, 84);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Giờ KH";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Firebrick;
            this.label12.Location = new System.Drawing.Point(646, 118);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Ngày KH";
            // 
            // cbo_GioDi
            // 
            this.cbo_GioDi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_GioDi.FormattingEnabled = true;
            this.cbo_GioDi.Location = new System.Drawing.Point(728, 82);
            this.cbo_GioDi.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.cbo_GioDi.Name = "cbo_GioDi";
            this.cbo_GioDi.Size = new System.Drawing.Size(162, 21);
            this.cbo_GioDi.TabIndex = 23;
            // 
            // cbo_NgayKH
            // 
            this.cbo_NgayKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_NgayKH.FormattingEnabled = true;
            this.cbo_NgayKH.Location = new System.Drawing.Point(728, 116);
            this.cbo_NgayKH.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.cbo_NgayKH.Name = "cbo_NgayKH";
            this.cbo_NgayKH.Size = new System.Drawing.Size(162, 21);
            this.cbo_NgayKH.TabIndex = 24;
            // 
            // txt_TimKiem
            // 
            this.txt_TimKiem.Location = new System.Drawing.Point(543, 46);
            this.txt_TimKiem.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txt_TimKiem.Name = "txt_TimKiem";
            this.txt_TimKiem.Size = new System.Drawing.Size(223, 20);
            this.txt_TimKiem.TabIndex = 26;
            // 
            // btn_TimKiem
            // 
            this.btn_TimKiem.Location = new System.Drawing.Point(802, 43);
            this.btn_TimKiem.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btn_TimKiem.Name = "btn_TimKiem";
            this.btn_TimKiem.Size = new System.Drawing.Size(74, 25);
            this.btn_TimKiem.TabIndex = 27;
            this.btn_TimKiem.Text = "Tìm Kiếm";
            this.btn_TimKiem.UseVisualStyleBackColor = true;
            this.btn_TimKiem.Click += new System.EventHandler(this.btn_TimKiem_Click);
            // 
            // btn_CapNhat
            // 
            this.btn_CapNhat.Image = global::QL_BanVeXe.Properties.Resources.Pictogrammers_Material_File_File_replace_32;
            this.btn_CapNhat.Location = new System.Drawing.Point(113, 204);
            this.btn_CapNhat.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btn_CapNhat.Name = "btn_CapNhat";
            this.btn_CapNhat.Size = new System.Drawing.Size(94, 40);
            this.btn_CapNhat.TabIndex = 28;
            this.btn_CapNhat.Text = "Cập Nhật";
            this.btn_CapNhat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_CapNhat.UseVisualStyleBackColor = true;
            this.btn_CapNhat.Click += new System.EventHandler(this.btn_CapNhat_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.ForeColor = System.Drawing.Color.Red;
            this.btn_Xoa.Image = global::QL_BanVeXe.Properties.Resources.Paomedia_Small_N_Flat_Sign_error_32;
            this.btn_Xoa.Location = new System.Drawing.Point(228, 204);
            this.btn_Xoa.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(85, 42);
            this.btn_Xoa.TabIndex = 29;
            this.btn_Xoa.Text = "Xóa ";
            this.btn_Xoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_HienThiDS
            // 
            this.btn_HienThiDS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_HienThiDS.Image = global::QL_BanVeXe.Properties.Resources.Custom_Icon_Design_Pretty_Office_8_Eye_32;
            this.btn_HienThiDS.Location = new System.Drawing.Point(346, 204);
            this.btn_HienThiDS.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btn_HienThiDS.Name = "btn_HienThiDS";
            this.btn_HienThiDS.Size = new System.Drawing.Size(148, 42);
            this.btn_HienThiDS.TabIndex = 30;
            this.btn_HienThiDS.Text = "Hiện Thị Danh Sách";
            this.btn_HienThiDS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_HienThiDS.UseVisualStyleBackColor = true;
            this.btn_HienThiDS.Click += new System.EventHandler(this.btn_HienThiDS_Click);
            // 
            // btn_Luu
            // 
            this.btn_Luu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_Luu.Location = new System.Drawing.Point(566, 204);
            this.btn_Luu.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(85, 42);
            this.btn_Luu.TabIndex = 31;
            this.btn_Luu.Text = "Lưu";
            this.btn_Luu.UseVisualStyleBackColor = false;
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // btn_Huy
            // 
            this.btn_Huy.BackColor = System.Drawing.Color.Red;
            this.btn_Huy.Location = new System.Drawing.Point(680, 204);
            this.btn_Huy.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(85, 42);
            this.btn_Huy.TabIndex = 32;
            this.btn_Huy.Text = "Hủy";
            this.btn_Huy.UseVisualStyleBackColor = false;
            this.btn_Huy.Click += new System.EventHandler(this.btn_Huy_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Firebrick;
            this.label13.Location = new System.Drawing.Point(13, 185);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 13);
            this.label13.TabIndex = 34;
            this.label13.Text = "Ghi Chú";
            // 
            // txt_GhiChu
            // 
            this.txt_GhiChu.Location = new System.Drawing.Point(71, 181);
            this.txt_GhiChu.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txt_GhiChu.Name = "txt_GhiChu";
            this.txt_GhiChu.Size = new System.Drawing.Size(242, 20);
            this.txt_GhiChu.TabIndex = 35;
            // 
            // txt_NgayDatVe
            // 
            this.txt_NgayDatVe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_NgayDatVe.Location = new System.Drawing.Point(554, 149);
            this.txt_NgayDatVe.Name = "txt_NgayDatVe";
            this.txt_NgayDatVe.Size = new System.Drawing.Size(142, 20);
            this.txt_NgayDatVe.TabIndex = 36;
            // 
            // cboMaNV
            // 
            this.cboMaNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaNV.FormattingEnabled = true;
            this.cboMaNV.Location = new System.Drawing.Point(71, 117);
            this.cboMaNV.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.cboMaNV.Name = "cboMaNV";
            this.cboMaNV.Size = new System.Drawing.Size(242, 21);
            this.cboMaNV.TabIndex = 37;
            // 
            // col_GhiChu
            // 
            this.col_GhiChu.DataPropertyName = "ghiChu";
            this.col_GhiChu.HeaderText = "Ghi Chú";
            this.col_GhiChu.MinimumWidth = 6;
            this.col_GhiChu.Name = "col_GhiChu";
            this.col_GhiChu.ReadOnly = true;
            this.col_GhiChu.Width = 125;
            // 
            // col_NgayKH
            // 
            this.col_NgayKH.DataPropertyName = "ngayKH";
            this.col_NgayKH.HeaderText = "Ngày Khởi Hàng";
            this.col_NgayKH.MinimumWidth = 6;
            this.col_NgayKH.Name = "col_NgayKH";
            this.col_NgayKH.ReadOnly = true;
            this.col_NgayKH.Width = 125;
            // 
            // col_GioKH
            // 
            this.col_GioKH.DataPropertyName = "gioDi";
            this.col_GioKH.HeaderText = "Giờ Đi";
            this.col_GioKH.MinimumWidth = 6;
            this.col_GioKH.Name = "col_GioKH";
            this.col_GioKH.ReadOnly = true;
            this.col_GioKH.Width = 125;
            // 
            // col_NgayDat
            // 
            this.col_NgayDat.DataPropertyName = "ngayDatVe";
            this.col_NgayDat.HeaderText = "Ngày Đặt Vé";
            this.col_NgayDat.MinimumWidth = 6;
            this.col_NgayDat.Name = "col_NgayDat";
            this.col_NgayDat.ReadOnly = true;
            this.col_NgayDat.Width = 125;
            // 
            // col_SoLuong
            // 
            this.col_SoLuong.DataPropertyName = "soLuong";
            this.col_SoLuong.HeaderText = "Số Lượng";
            this.col_SoLuong.MinimumWidth = 6;
            this.col_SoLuong.Name = "col_SoLuong";
            this.col_SoLuong.ReadOnly = true;
            this.col_SoLuong.Width = 125;
            // 
            // col_ViTriGhe
            // 
            this.col_ViTriGhe.DataPropertyName = "tenGhe";
            this.col_ViTriGhe.HeaderText = "Vị Trí Ghế";
            this.col_ViTriGhe.MinimumWidth = 6;
            this.col_ViTriGhe.Name = "col_ViTriGhe";
            this.col_ViTriGhe.ReadOnly = true;
            this.col_ViTriGhe.Width = 125;
            // 
            // col_SDT
            // 
            this.col_SDT.DataPropertyName = "sDTKH";
            this.col_SDT.HeaderText = "Số Điện Thoại";
            this.col_SDT.MinimumWidth = 6;
            this.col_SDT.Name = "col_SDT";
            this.col_SDT.ReadOnly = true;
            this.col_SDT.Width = 125;
            // 
            // col_TenKH
            // 
            this.col_TenKH.DataPropertyName = "hoTenKH";
            this.col_TenKH.HeaderText = "Tên Khách Hàng";
            this.col_TenKH.MinimumWidth = 6;
            this.col_TenKH.Name = "col_TenKH";
            this.col_TenKH.ReadOnly = true;
            this.col_TenKH.Width = 125;
            // 
            // col_MaXe
            // 
            this.col_MaXe.DataPropertyName = "bienSo";
            this.col_MaXe.HeaderText = "Biển Số";
            this.col_MaXe.MinimumWidth = 6;
            this.col_MaXe.Name = "col_MaXe";
            this.col_MaXe.ReadOnly = true;
            this.col_MaXe.Width = 125;
            // 
            // col_MaLT
            // 
            this.col_MaLT.DataPropertyName = "maTuyen";
            this.col_MaLT.HeaderText = "Mã Tuyến";
            this.col_MaLT.MinimumWidth = 6;
            this.col_MaLT.Name = "col_MaLT";
            this.col_MaLT.ReadOnly = true;
            this.col_MaLT.Width = 125;
            // 
            // col_MaNV
            // 
            this.col_MaNV.DataPropertyName = "maNV";
            this.col_MaNV.HeaderText = "Mã Nhân Viên";
            this.col_MaNV.MinimumWidth = 6;
            this.col_MaNV.Name = "col_MaNV";
            this.col_MaNV.ReadOnly = true;
            this.col_MaNV.Width = 125;
            // 
            // col_MaVe
            // 
            this.col_MaVe.DataPropertyName = "maVe";
            this.col_MaVe.HeaderText = "Mã Vé";
            this.col_MaVe.MinimumWidth = 6;
            this.col_MaVe.Name = "col_MaVe";
            this.col_MaVe.ReadOnly = true;
            this.col_MaVe.Width = 125;
            // 
            // frm_QuanLyVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(856, 430);
            this.Controls.Add(this.cboMaNV);
            this.Controls.Add(this.txt_NgayDatVe);
            this.Controls.Add(this.txt_GhiChu);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btn_Huy);
            this.Controls.Add(this.btn_Luu);
            this.Controls.Add(this.btn_HienThiDS);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_CapNhat);
            this.Controls.Add(this.btn_TimKiem);
            this.Controls.Add(this.txt_TimKiem);
            this.Controls.Add(this.cbo_NgayKH);
            this.Controls.Add(this.cbo_GioDi);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_SoLuong);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_TenGhe);
            this.Controls.Add(this.txt_SDTKH);
            this.Controls.Add(this.txt_HoTenKH);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbo_BienSo);
            this.Controls.Add(this.cbo_MaTuyen);
            this.Controls.Add(this.txt_MaVe);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgv_DSVe);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "frm_QuanLyVe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_QuanLyVe";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_QuanLyVe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DSVe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgv_DSVe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_MaVe;
        private System.Windows.Forms.ComboBox cbo_MaTuyen;
        private System.Windows.Forms.ComboBox cbo_BienSo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_HoTenKH;
        private System.Windows.Forms.TextBox txt_SDTKH;
        private System.Windows.Forms.TextBox txt_TenGhe;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_SoLuong;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbo_GioDi;
        private System.Windows.Forms.ComboBox cbo_NgayKH;
        private System.Windows.Forms.TextBox txt_TimKiem;
        private System.Windows.Forms.Button btn_TimKiem;
        private System.Windows.Forms.Button btn_CapNhat;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_HienThiDS;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.Button btn_Huy;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_GhiChu;
        private System.Windows.Forms.DateTimePicker txt_NgayDatVe;
        private System.Windows.Forms.ComboBox cboMaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MaVe;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MaLT;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MaXe;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_SDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ViTriGhe;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_NgayDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_GioKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_NgayKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_GhiChu;
    }
}