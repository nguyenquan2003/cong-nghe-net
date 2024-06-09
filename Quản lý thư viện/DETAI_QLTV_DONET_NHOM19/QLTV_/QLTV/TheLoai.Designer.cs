namespace QLTV
{
    partial class TheLoai
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
            this.pnl_top = new System.Windows.Forms.Panel();
            this.lb_top = new System.Windows.Forms.Label();
            this.pnl_chucnang = new System.Windows.Forms.Panel();
            this.bt_quaylai = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btload = new System.Windows.Forms.Button();
            this.bt_delete = new System.Windows.Forms.Button();
            this.bt_update = new System.Windows.Forms.Button();
            this.bt_add = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.add_new = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tenTL = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.maVT = new System.Windows.Forms.TextBox();
            this.dgv_TheLoai = new System.Windows.Forms.DataGridView();
            this.pnl_timkiem = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.find = new System.Windows.Forms.Button();
            this.timkiem = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.check2 = new System.Windows.Forms.RadioButton();
            this.check1 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.pnl_top.SuspendLayout();
            this.pnl_chucnang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TheLoai)).BeginInit();
            this.pnl_timkiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_top
            // 
            this.pnl_top.BackColor = System.Drawing.Color.Teal;
            this.pnl_top.Controls.Add(this.lb_top);
            this.pnl_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_top.Location = new System.Drawing.Point(0, 0);
            this.pnl_top.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_top.Name = "pnl_top";
            this.pnl_top.Size = new System.Drawing.Size(1317, 47);
            this.pnl_top.TabIndex = 9;
            this.pnl_top.Paint += new System.Windows.Forms.PaintEventHandler(this.paneltop_Paint);
            // 
            // lb_top
            // 
            this.lb_top.AutoSize = true;
            this.lb_top.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_top.ForeColor = System.Drawing.Color.White;
            this.lb_top.Location = new System.Drawing.Point(13, 14);
            this.lb_top.Name = "lb_top";
            this.lb_top.Size = new System.Drawing.Size(183, 20);
            this.lb_top.TabIndex = 0;
            this.lb_top.Text = "THÔNG TIN THỂ LOẠI";
            // 
            // pnl_chucnang
            // 
            this.pnl_chucnang.BackColor = System.Drawing.Color.White;
            this.pnl_chucnang.Controls.Add(this.bt_quaylai);
            this.pnl_chucnang.Controls.Add(this.label1);
            this.pnl_chucnang.Controls.Add(this.label2);
            this.pnl_chucnang.Controls.Add(this.btload);
            this.pnl_chucnang.Controls.Add(this.bt_delete);
            this.pnl_chucnang.Controls.Add(this.bt_update);
            this.pnl_chucnang.Controls.Add(this.bt_add);
            this.pnl_chucnang.Controls.Add(this.panel10);
            this.pnl_chucnang.Controls.Add(this.add_new);
            this.pnl_chucnang.Controls.Add(this.panel4);
            this.pnl_chucnang.Controls.Add(this.tenTL);
            this.pnl_chucnang.Controls.Add(this.panel3);
            this.pnl_chucnang.Controls.Add(this.maVT);
            this.pnl_chucnang.Location = new System.Drawing.Point(19, 222);
            this.pnl_chucnang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_chucnang.Name = "pnl_chucnang";
            this.pnl_chucnang.Size = new System.Drawing.Size(619, 460);
            this.pnl_chucnang.TabIndex = 14;
            // 
            // bt_quaylai
            // 
            this.bt_quaylai.BackColor = System.Drawing.Color.Teal;
            this.bt_quaylai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_quaylai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_quaylai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_quaylai.ForeColor = System.Drawing.Color.White;
            this.bt_quaylai.Location = new System.Drawing.Point(357, 366);
            this.bt_quaylai.Margin = new System.Windows.Forms.Padding(4);
            this.bt_quaylai.Name = "bt_quaylai";
            this.bt_quaylai.Size = new System.Drawing.Size(117, 57);
            this.bt_quaylai.TabIndex = 73;
            this.bt_quaylai.Text = "Quay lại";
            this.bt_quaylai.UseVisualStyleBackColor = false;
            this.bt_quaylai.Click += new System.EventHandler(this.bt_quaylai_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(116, 195);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 71;
            this.label1.Text = "Tên thể loại *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(116, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 70;
            this.label2.Text = "Mã thể loại *";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btload
            // 
            this.btload.BackColor = System.Drawing.Color.Teal;
            this.btload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btload.ForeColor = System.Drawing.Color.White;
            this.btload.Location = new System.Drawing.Point(235, 364);
            this.btload.Margin = new System.Windows.Forms.Padding(4);
            this.btload.Name = "btload";
            this.btload.Size = new System.Drawing.Size(117, 57);
            this.btload.TabIndex = 35;
            this.btload.Text = "Làm mới";
            this.btload.UseVisualStyleBackColor = false;
            this.btload.Click += new System.EventHandler(this.btload_Click);
            // 
            // bt_delete
            // 
            this.bt_delete.BackColor = System.Drawing.Color.Teal;
            this.bt_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_delete.ForeColor = System.Drawing.Color.White;
            this.bt_delete.Location = new System.Drawing.Point(108, 364);
            this.bt_delete.Margin = new System.Windows.Forms.Padding(4);
            this.bt_delete.Name = "bt_delete";
            this.bt_delete.Size = new System.Drawing.Size(117, 57);
            this.bt_delete.TabIndex = 34;
            this.bt_delete.Text = "Xóa";
            this.bt_delete.UseVisualStyleBackColor = false;
            this.bt_delete.Click += new System.EventHandler(this.bt_delete_Click);
            // 
            // bt_update
            // 
            this.bt_update.BackColor = System.Drawing.Color.Teal;
            this.bt_update.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_update.ForeColor = System.Drawing.Color.White;
            this.bt_update.Location = new System.Drawing.Point(332, 281);
            this.bt_update.Margin = new System.Windows.Forms.Padding(4);
            this.bt_update.Name = "bt_update";
            this.bt_update.Size = new System.Drawing.Size(143, 57);
            this.bt_update.TabIndex = 33;
            this.bt_update.Text = "Sửa";
            this.bt_update.UseVisualStyleBackColor = false;
            this.bt_update.Click += new System.EventHandler(this.bt_update_Click);
            // 
            // bt_add
            // 
            this.bt_add.BackColor = System.Drawing.Color.Teal;
            this.bt_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_add.ForeColor = System.Drawing.Color.White;
            this.bt_add.Location = new System.Drawing.Point(108, 281);
            this.bt_add.Margin = new System.Windows.Forms.Padding(4);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(143, 57);
            this.bt_add.TabIndex = 32;
            this.bt_add.Text = "Thêm";
            this.bt_add.UseVisualStyleBackColor = false;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Teal;
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(0, 456);
            this.panel10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(619, 4);
            this.panel10.TabIndex = 26;
            // 
            // add_new
            // 
            this.add_new.AutoSize = true;
            this.add_new.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_new.ForeColor = System.Drawing.Color.Gray;
            this.add_new.Location = new System.Drawing.Point(232, 14);
            this.add_new.Name = "add_new";
            this.add_new.Size = new System.Drawing.Size(113, 25);
            this.add_new.TabIndex = 21;
            this.add_new.Text = "ADD NEW";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gray;
            this.panel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel4.Location = new System.Drawing.Point(108, 225);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(367, 2);
            this.panel4.TabIndex = 9;
            // 
            // tenTL
            // 
            this.tenTL.BackColor = System.Drawing.Color.White;
            this.tenTL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tenTL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenTL.ForeColor = System.Drawing.Color.Black;
            this.tenTL.Location = new System.Drawing.Point(275, 195);
            this.tenTL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tenTL.Multiline = true;
            this.tenTL.Name = "tenTL";
            this.tenTL.Size = new System.Drawing.Size(197, 30);
            this.tenTL.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel3.Location = new System.Drawing.Point(108, 116);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(367, 2);
            this.panel3.TabIndex = 7;
            // 
            // maVT
            // 
            this.maVT.BackColor = System.Drawing.Color.White;
            this.maVT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maVT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maVT.ForeColor = System.Drawing.Color.Black;
            this.maVT.Location = new System.Drawing.Point(277, 80);
            this.maVT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maVT.Multiline = true;
            this.maVT.Name = "maVT";
            this.maVT.Size = new System.Drawing.Size(198, 36);
            this.maVT.TabIndex = 5;
            // 
            // dgv_TheLoai
            // 
            this.dgv_TheLoai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TheLoai.Location = new System.Drawing.Point(675, 62);
            this.dgv_TheLoai.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_TheLoai.Name = "dgv_TheLoai";
            this.dgv_TheLoai.Size = new System.Drawing.Size(619, 620);
            this.dgv_TheLoai.TabIndex = 13;
            this.dgv_TheLoai.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_docgia_CellContentClick);
            // 
            // pnl_timkiem
            // 
            this.pnl_timkiem.BackColor = System.Drawing.Color.White;
            this.pnl_timkiem.Controls.Add(this.panel1);
            this.pnl_timkiem.Controls.Add(this.find);
            this.pnl_timkiem.Controls.Add(this.timkiem);
            this.pnl_timkiem.Controls.Add(this.panel9);
            this.pnl_timkiem.Controls.Add(this.check2);
            this.pnl_timkiem.Controls.Add(this.check1);
            this.pnl_timkiem.Controls.Add(this.label3);
            this.pnl_timkiem.Location = new System.Drawing.Point(19, 66);
            this.pnl_timkiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_timkiem.Name = "pnl_timkiem";
            this.pnl_timkiem.Size = new System.Drawing.Size(619, 130);
            this.pnl_timkiem.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Location = new System.Drawing.Point(68, 112);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 4);
            this.panel1.TabIndex = 29;
            // 
            // find
            // 
            this.find.BackColor = System.Drawing.Color.Teal;
            this.find.Cursor = System.Windows.Forms.Cursors.Hand;
            this.find.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.find.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.find.ForeColor = System.Drawing.Color.White;
            this.find.Location = new System.Drawing.Point(440, 82);
            this.find.Margin = new System.Windows.Forms.Padding(4);
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(108, 34);
            this.find.TabIndex = 27;
            this.find.Text = "Tìm Kiếm";
            this.find.UseVisualStyleBackColor = false;
            this.find.Click += new System.EventHandler(this.find_Click);
            // 
            // timkiem
            // 
            this.timkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timkiem.ForeColor = System.Drawing.Color.Black;
            this.timkiem.Location = new System.Drawing.Point(68, 82);
            this.timkiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.timkiem.Multiline = true;
            this.timkiem.Name = "timkiem";
            this.timkiem.Size = new System.Drawing.Size(353, 34);
            this.timkiem.TabIndex = 26;
            this.timkiem.TextChanged += new System.EventHandler(this.timkiem_TextChanged);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Teal;
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 125);
            this.panel9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(619, 5);
            this.panel9.TabIndex = 25;
            // 
            // check2
            // 
            this.check2.AutoSize = true;
            this.check2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check2.ForeColor = System.Drawing.Color.Teal;
            this.check2.Location = new System.Drawing.Point(328, 46);
            this.check2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.check2.Name = "check2";
            this.check2.Size = new System.Drawing.Size(220, 22);
            this.check2.TabIndex = 24;
            this.check2.TabStop = true;
            this.check2.Text = "Tìm Kiếm Theo Tên Thể Loại";
            this.check2.UseVisualStyleBackColor = true;
            this.check2.CheckedChanged += new System.EventHandler(this.check2_CheckedChanged);
            // 
            // check1
            // 
            this.check1.AutoSize = true;
            this.check1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check1.ForeColor = System.Drawing.Color.Teal;
            this.check1.Location = new System.Drawing.Point(68, 46);
            this.check1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.check1.Name = "check1";
            this.check1.Size = new System.Drawing.Size(216, 22);
            this.check1.TabIndex = 23;
            this.check1.TabStop = true;
            this.check1.Text = "Tìm Kiếm Theo Mã Thể Loại";
            this.check1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(181, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(256, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Tìm kiếm thông tin danh sách";
            // 
            // TheLoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1317, 711);
            this.Controls.Add(this.pnl_chucnang);
            this.Controls.Add(this.dgv_TheLoai);
            this.Controls.Add(this.pnl_timkiem);
            this.Controls.Add(this.pnl_top);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TheLoai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TheLoai";
            this.Load += new System.EventHandler(this.TheLoai_Load);
            this.pnl_top.ResumeLayout(false);
            this.pnl_top.PerformLayout();
            this.pnl_chucnang.ResumeLayout(false);
            this.pnl_chucnang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TheLoai)).EndInit();
            this.pnl_timkiem.ResumeLayout(false);
            this.pnl_timkiem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_top;
        private System.Windows.Forms.Label lb_top;
        private System.Windows.Forms.Panel pnl_chucnang;
        private System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.Button bt_update;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label add_new;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tenTL;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox maVT;
        private System.Windows.Forms.DataGridView dgv_TheLoai;
        private System.Windows.Forms.Panel pnl_timkiem;
        private System.Windows.Forms.Button find;
        private System.Windows.Forms.TextBox timkiem;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.RadioButton check2;
        private System.Windows.Forms.RadioButton check1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btload;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_quaylai;
        private System.Windows.Forms.Panel panel1;
    }
}