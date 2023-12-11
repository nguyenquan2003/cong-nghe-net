namespace LogIn_SignIn
{
    partial class frmQLNV
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
            this.qLNVDataSet = new LogIn_SignIn.QLNVDataSet();
            this.qLNVDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLNVDataSet1 = new LogIn_SignIn.QLNVDataSet1();
            this.qLNVDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnFix = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoVaTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDangNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaQuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayVaoLam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtID = new System.Windows.Forms.TextBox();
            this.cboChucVu = new System.Windows.Forms.ComboBox();
            this.tmeBirth = new System.Windows.Forms.DateTimePicker();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.cboSex = new System.Windows.Forms.ComboBox();
            this.tmeDayIn = new System.Windows.Forms.DateTimePicker();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
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
            this.label12 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.qLNVDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLNVDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLNVDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLNVDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // qLNVDataSet
            // 
            this.qLNVDataSet.DataSetName = "QLNVDataSet";
            this.qLNVDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // qLNVDataSetBindingSource
            // 
            this.qLNVDataSetBindingSource.DataSource = this.qLNVDataSet;
            this.qLNVDataSetBindingSource.Position = 0;
            // 
            // qLNVDataSet1
            // 
            this.qLNVDataSet1.DataSetName = "QLNVDataSet1";
            this.qLNVDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // qLNVDataSet1BindingSource
            // 
            this.qLNVDataSet1BindingSource.DataSource = this.qLNVDataSet1;
            this.qLNVDataSet1BindingSource.Position = 0;
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(322, 420);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(218, 53);
            this.btnRemove.TabIndex = 23;
            this.btnRemove.Text = "Xóa NV";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnFix
            // 
            this.btnFix.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFix.Location = new System.Drawing.Point(599, 420);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(218, 53);
            this.btnFix.TabIndex = 22;
            this.btnFix.Text = "Chỉnh sửa";
            this.btnFix.UseVisualStyleBackColor = true;
            this.btnFix.Click += new System.EventHandler(this.btnFix_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(45, 420);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(218, 53);
            this.btnAdd.TabIndex = 24;
            this.btnAdd.Text = "Thêm NV";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(482, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(538, 54);
            this.label1.TabIndex = 25;
            this.label1.Text = "QUẢN LÝ NHÂN VIÊN";
            // 
            // dataGridView1
            // 
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.HoVaTen,
            this.TenDangNhap,
            this.GioiTinh,
            this.MaQuyen,
            this.NgaySinh,
            this.NgayVaoLam,
            this.SDT,
            this.CCCD,
            this.Email});
            this.dataGridView1.Location = new System.Drawing.Point(52, 517);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1319, 211);
            this.dataGridView1.TabIndex = 26;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "Mã NV";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Width = 125;
            // 
            // HoVaTen
            // 
            this.HoVaTen.HeaderText = "Họ và Tên";
            this.HoVaTen.MinimumWidth = 6;
            this.HoVaTen.Name = "HoVaTen";
            this.HoVaTen.Width = 170;
            // 
            // TenDangNhap
            // 
            this.TenDangNhap.HeaderText = "Tên Đăng Nhập";
            this.TenDangNhap.MinimumWidth = 6;
            this.TenDangNhap.Name = "TenDangNhap";
            this.TenDangNhap.Width = 170;
            // 
            // GioiTinh
            // 
            this.GioiTinh.HeaderText = "Giới Tính";
            this.GioiTinh.MinimumWidth = 6;
            this.GioiTinh.Name = "GioiTinh";
            this.GioiTinh.Width = 90;
            // 
            // MaQuyen
            // 
            this.MaQuyen.HeaderText = "Chức Vụ";
            this.MaQuyen.MinimumWidth = 6;
            this.MaQuyen.Name = "MaQuyen";
            this.MaQuyen.Width = 125;
            // 
            // NgaySinh
            // 
            this.NgaySinh.HeaderText = "Ngày Sinh";
            this.NgaySinh.MinimumWidth = 6;
            this.NgaySinh.Name = "NgaySinh";
            this.NgaySinh.Width = 125;
            // 
            // NgayVaoLam
            // 
            this.NgayVaoLam.HeaderText = "Ngày vào làm";
            this.NgayVaoLam.MinimumWidth = 6;
            this.NgayVaoLam.Name = "NgayVaoLam";
            this.NgayVaoLam.Width = 125;
            // 
            // SDT
            // 
            this.SDT.HeaderText = "SĐT";
            this.SDT.MinimumWidth = 6;
            this.SDT.Name = "SDT";
            this.SDT.Width = 125;
            // 
            // CCCD
            // 
            this.CCCD.HeaderText = "CCCD";
            this.CCCD.MinimumWidth = 6;
            this.CCCD.Name = "CCCD";
            this.CCCD.Width = 125;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.Width = 135;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(222, 103);
            this.txtID.Multiline = true;
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(260, 42);
            this.txtID.TabIndex = 63;
            // 
            // cboChucVu
            // 
            this.cboChucVu.FormattingEnabled = true;
            this.cboChucVu.ItemHeight = 16;
            this.cboChucVu.Items.AddRange(new object[] {
            "Quản Lý",
            "Nhân Viên"});
            this.cboChucVu.Location = new System.Drawing.Point(682, 192);
            this.cboChucVu.Name = "cboChucVu";
            this.cboChucVu.Size = new System.Drawing.Size(117, 24);
            this.cboChucVu.TabIndex = 61;
            // 
            // tmeBirth
            // 
            this.tmeBirth.Location = new System.Drawing.Point(222, 274);
            this.tmeBirth.MaximumSize = new System.Drawing.Size(250, 100);
            this.tmeBirth.Name = "tmeBirth";
            this.tmeBirth.Size = new System.Drawing.Size(247, 22);
            this.tmeBirth.TabIndex = 60;
            // 
            // txtCCCD
            // 
            this.txtCCCD.Location = new System.Drawing.Point(1098, 264);
            this.txtCCCD.Multiline = true;
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Size = new System.Drawing.Size(276, 42);
            this.txtCCCD.TabIndex = 59;
            this.txtCCCD.TextChanged += new System.EventHandler(this.txtCCCD_TextChanged);
            this.txtCCCD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCCCD_KeyPress);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(1098, 103);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(276, 119);
            this.txtAddress.TabIndex = 58;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(682, 103);
            this.txtHoTen.Multiline = true;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(260, 42);
            this.txtHoTen.TabIndex = 57;
            // 
            // cboSex
            // 
            this.cboSex.FormattingEnabled = true;
            this.cboSex.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cboSex.Location = new System.Drawing.Point(682, 272);
            this.cboSex.Name = "cboSex";
            this.cboSex.Size = new System.Drawing.Size(117, 24);
            this.cboSex.TabIndex = 71;
            // 
            // tmeDayIn
            // 
            this.tmeDayIn.Location = new System.Drawing.Point(222, 348);
            this.tmeDayIn.MaximumSize = new System.Drawing.Size(250, 100);
            this.tmeDayIn.Name = "tmeDayIn";
            this.tmeDayIn.Size = new System.Drawing.Size(247, 22);
            this.tmeDayIn.TabIndex = 70;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(1098, 338);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(276, 42);
            this.txtEmail.TabIndex = 69;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(682, 338);
            this.txtPhoneNumber.Multiline = true;
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(260, 42);
            this.txtPhoneNumber.TabIndex = 68;
            this.txtPhoneNumber.TextChanged += new System.EventHandler(this.txtPhoneNumber_TextChanged);
            this.txtPhoneNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhoneNumber_KeyPress);
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(222, 180);
            this.txtTenDangNhap.Multiline = true;
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.ReadOnly = true;
            this.txtTenDangNhap.Size = new System.Drawing.Size(260, 42);
            this.txtTenDangNhap.TabIndex = 73;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 42);
            this.label2.TabIndex = 74;
            this.label2.Text = "Mã NV: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 42);
            this.label3.TabIndex = 75;
            this.label3.Text = "Tên Đăng Nhập: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(48, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 42);
            this.label4.TabIndex = 76;
            this.label4.Text = "Ngày Sinh: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(48, 338);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 42);
            this.label5.TabIndex = 77;
            this.label5.Text = "Ngày Vào Làm: ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(535, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 42);
            this.label6.TabIndex = 78;
            this.label6.Text = "Họ và Tên: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(535, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 42);
            this.label7.TabIndex = 79;
            this.label7.Text = "Chức Vụ: ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(535, 264);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 42);
            this.label8.TabIndex = 80;
            this.label8.Text = "Giới Tính: ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(535, 338);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 42);
            this.label9.TabIndex = 81;
            this.label9.Text = "SĐT: ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(976, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 42);
            this.label10.TabIndex = 82;
            this.label10.Text = "Địa Chỉ: ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(976, 264);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 42);
            this.label11.TabIndex = 83;
            this.label11.Text = "CCCD: ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(976, 338);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 42);
            this.label12.TabIndex = 84;
            this.label12.Text = "Email: ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(876, 420);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(218, 53);
            this.btnUpdate.TabIndex = 85;
            this.btnUpdate.Text = "Cập Nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(1153, 420);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(218, 53);
            this.btnDelete.TabIndex = 86;
            this.btnDelete.Text = "Hủy";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmQLNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1386, 753);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label12);
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
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.cboSex);
            this.Controls.Add(this.tmeDayIn);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.cboChucVu);
            this.Controls.Add(this.tmeBirth);
            this.Controls.Add(this.txtCCCD);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnFix);
            this.Name = "frmQLNV";
            this.Text = "frmQLNV";
            this.Load += new System.EventHandler(this.frmQLNV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qLNVDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLNVDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLNVDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLNVDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource qLNVDataSetBindingSource;
        private QLNVDataSet qLNVDataSet;
        private System.Windows.Forms.BindingSource qLNVDataSet1BindingSource;
        private QLNVDataSet1 qLNVDataSet1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnFix;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ComboBox cboChucVu;
        private System.Windows.Forms.DateTimePicker tmeBirth;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.ComboBox cboSex;
        private System.Windows.Forms.DateTimePicker tmeDayIn;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.TextBox txtTenDangNhap;
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
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoVaTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDangNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaQuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayVaoLam;
        private System.Windows.Forms.DataGridViewTextBoxColumn SDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
    }
}