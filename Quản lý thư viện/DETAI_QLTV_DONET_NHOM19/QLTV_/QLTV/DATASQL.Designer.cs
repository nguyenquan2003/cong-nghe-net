namespace QLTV
{
    partial class DATASQL
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
            this.bt_load = new System.Windows.Forms.Button();
            this.data_sql = new System.Windows.Forms.TextBox();
            this.report = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_thoat = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_load
            // 
            this.bt_load.BackColor = System.Drawing.Color.White;
            this.bt_load.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_load.Location = new System.Drawing.Point(350, 278);
            this.bt_load.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_load.Name = "bt_load";
            this.bt_load.Size = new System.Drawing.Size(287, 75);
            this.bt_load.TabIndex = 2;
            this.bt_load.Text = "Kết nối";
            this.bt_load.UseVisualStyleBackColor = false;
            this.bt_load.Click += new System.EventHandler(this.bt_load_Click);
            this.bt_load.MouseEnter += new System.EventHandler(this.bt_load_MouseEnter);
            this.bt_load.MouseLeave += new System.EventHandler(this.bt_load_MouseLeave);
            // 
            // data_sql
            // 
            this.data_sql.Location = new System.Drawing.Point(350, 125);
            this.data_sql.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.data_sql.Name = "data_sql";
            this.data_sql.Size = new System.Drawing.Size(693, 22);
            this.data_sql.TabIndex = 3;
            // 
            // report
            // 
            this.report.Location = new System.Drawing.Point(350, 198);
            this.report.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.report.Name = "report";
            this.report.Size = new System.Drawing.Size(693, 22);
            this.report.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1147, 78);
            this.panel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 21.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(74, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(969, 41);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vui lòng nhập đường dẫn SQL và đường dẫn chứa tệp Reports";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 126);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "Đường dẫn SQL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(77, 199);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "Đường dẫn chứa tệp Reports";
            // 
            // bt_thoat
            // 
            this.bt_thoat.BackColor = System.Drawing.Color.White;
            this.bt_thoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_thoat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bt_thoat.Location = new System.Drawing.Point(756, 277);
            this.bt_thoat.Margin = new System.Windows.Forms.Padding(4);
            this.bt_thoat.Name = "bt_thoat";
            this.bt_thoat.Size = new System.Drawing.Size(287, 75);
            this.bt_thoat.TabIndex = 11;
            this.bt_thoat.Text = "Thoát";
            this.bt_thoat.UseVisualStyleBackColor = false;
            this.bt_thoat.Click += new System.EventHandler(this.bt_thoat_Click);
            this.bt_thoat.MouseEnter += new System.EventHandler(this.bt_thoat_MouseEnter);
            this.bt_thoat.MouseLeave += new System.EventHandler(this.bt_thoat_MouseLeave);
            // 
            // DATASQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1147, 381);
            this.Controls.Add(this.bt_thoat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.report);
            this.Controls.Add(this.data_sql);
            this.Controls.Add(this.bt_load);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DATASQL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATASQL";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bt_load;
        private System.Windows.Forms.TextBox data_sql;
        private System.Windows.Forms.TextBox report;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_thoat;
    }
}