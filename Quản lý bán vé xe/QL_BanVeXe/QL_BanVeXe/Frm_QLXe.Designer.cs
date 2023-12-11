namespace QuanLyXe
{
    partial class Frm_QLXe
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
            this.txt_MaXe = new System.Windows.Forms.TextBox();
            this.btn_Huy = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.txt_SoGhe = new System.Windows.Forms.TextBox();
            this.cbo_LoaiXe = new System.Windows.Forms.ComboBox();
            this.btn_Hienthi = new System.Windows.Forms.Button();
            this.btn_CapNhat = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(354, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ XE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(247, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Xe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(247, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Loại Xe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(242, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số Ghế";
            // 
            // txt_MaXe
            // 
            this.txt_MaXe.Location = new System.Drawing.Point(344, 105);
            this.txt_MaXe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_MaXe.Name = "txt_MaXe";
            this.txt_MaXe.Size = new System.Drawing.Size(236, 26);
            this.txt_MaXe.TabIndex = 4;
            // 
            // btn_Huy
            // 
            this.btn_Huy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Huy.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Huy.ForeColor = System.Drawing.Color.White;
            this.btn_Huy.Location = new System.Drawing.Point(667, 105);
            this.btn_Huy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(146, 52);
            this.btn_Huy.TabIndex = 11;
            this.btn_Huy.Text = "Hủy";
            this.btn_Huy.UseVisualStyleBackColor = false;
            this.btn_Huy.Click += new System.EventHandler(this.btn_Huy_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 422);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(915, 194);
            this.dataGridView1.TabIndex = 12;
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.ForeColor = System.Drawing.Color.Red;
            this.btn_Xoa.Image = global::QL_BanVeXe.Properties.Resources.Paomedia_Small_N_Flat_Sign_error_32;
            this.btn_Xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Xoa.Location = new System.Drawing.Point(579, 305);
            this.btn_Xoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(167, 65);
            this.btn_Xoa.TabIndex = 9;
            this.btn_Xoa.Text = "  Xóa Xe";
            this.btn_Xoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // txt_SoGhe
            // 
            this.txt_SoGhe.Location = new System.Drawing.Point(344, 237);
            this.txt_SoGhe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_SoGhe.Name = "txt_SoGhe";
            this.txt_SoGhe.Size = new System.Drawing.Size(236, 26);
            this.txt_SoGhe.TabIndex = 13;
            // 
            // cbo_LoaiXe
            // 
            this.cbo_LoaiXe.FormattingEnabled = true;
            this.cbo_LoaiXe.Location = new System.Drawing.Point(344, 172);
            this.cbo_LoaiXe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbo_LoaiXe.Name = "cbo_LoaiXe";
            this.cbo_LoaiXe.Size = new System.Drawing.Size(236, 28);
            this.cbo_LoaiXe.TabIndex = 14;
            // 
            // btn_Hienthi
            // 
            this.btn_Hienthi.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Hienthi.ForeColor = System.Drawing.Color.Cyan;
            this.btn_Hienthi.Image = global::QL_BanVeXe.Properties.Resources.Custom_Icon_Design_Pretty_Office_8_Eye_32;
            this.btn_Hienthi.Location = new System.Drawing.Point(634, 213);
            this.btn_Hienthi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Hienthi.Name = "btn_Hienthi";
            this.btn_Hienthi.Size = new System.Drawing.Size(253, 52);
            this.btn_Hienthi.TabIndex = 10;
            this.btn_Hienthi.Text = "   Hiển thị danh sách xe";
            this.btn_Hienthi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Hienthi.UseVisualStyleBackColor = true;
            this.btn_Hienthi.Click += new System.EventHandler(this.btn_Hienthi_Click);
            // 
            // btn_CapNhat
            // 
            this.btn_CapNhat.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CapNhat.Image = global::QL_BanVeXe.Properties.Resources.Pictogrammers_Material_File_File_replace_32;
            this.btn_CapNhat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CapNhat.Location = new System.Drawing.Point(389, 305);
            this.btn_CapNhat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_CapNhat.Name = "btn_CapNhat";
            this.btn_CapNhat.Size = new System.Drawing.Size(167, 65);
            this.btn_CapNhat.TabIndex = 8;
            this.btn_CapNhat.Text = "  Cập Nhật";
            this.btn_CapNhat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_CapNhat.UseVisualStyleBackColor = true;
            this.btn_CapNhat.Click += new System.EventHandler(this.btn_CapNhat_Click);
            // 
            // btn_Them
            // 
            this.btn_Them.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_Them.Image = global::QL_BanVeXe.Properties.Resources.Martz90_Circle_Addon1_Text_plus_32;
            this.btn_Them.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Them.Location = new System.Drawing.Point(205, 305);
            this.btn_Them.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(167, 65);
            this.btn_Them.TabIndex = 7;
            this.btn_Them.Text = "  Thêm Xe";
            this.btn_Them.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // Frm_QLXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(916, 648);
            this.Controls.Add(this.cbo_LoaiXe);
            this.Controls.Add(this.txt_SoGhe);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_Huy);
            this.Controls.Add(this.btn_Hienthi);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_CapNhat);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.txt_MaXe);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm_QLXe";
            this.Text = "Quản lí Xe";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_MaXe;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_CapNhat;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Hienthi;
        private System.Windows.Forms.Button btn_Huy;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txt_SoGhe;
        private System.Windows.Forms.ComboBox cbo_LoaiXe;
    }
}

