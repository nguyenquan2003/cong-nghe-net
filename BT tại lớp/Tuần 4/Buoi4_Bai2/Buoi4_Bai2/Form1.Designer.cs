namespace Buoi4_Bai2
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
            this.btn_loadDL = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbo_dt = new System.Windows.Forms.ComboBox();
            this.lpl_kq = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dân tộc";
            // 
            // btn_loadDL
            // 
            this.btn_loadDL.Location = new System.Drawing.Point(192, 25);
            this.btn_loadDL.Name = "btn_loadDL";
            this.btn_loadDL.Size = new System.Drawing.Size(216, 42);
            this.btn_loadDL.TabIndex = 1;
            this.btn_loadDL.Text = "Load dữ liệu Combobox";
            this.btn_loadDL.UseVisualStyleBackColor = true;
            this.btn_loadDL.Click += new System.EventHandler(this.btn_loadDL_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(363, 214);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 66);
            this.button2.TabIndex = 2;
            this.button2.Text = "Hiện thị";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbo_dt
            // 
            this.cbo_dt.FormattingEnabled = true;
            this.cbo_dt.Items.AddRange(new object[] {
            "Kinh",
            "Hoa",
            "K\'Me",
            "H\'Mong",
            "Khác"});
            this.cbo_dt.Location = new System.Drawing.Point(192, 107);
            this.cbo_dt.Name = "cbo_dt";
            this.cbo_dt.Size = new System.Drawing.Size(233, 28);
            this.cbo_dt.TabIndex = 3;
            this.cbo_dt.SelectedIndexChanged += new System.EventHandler(this.cbo_dt_SelectedIndexChanged);
            // 
            // lpl_kq
            // 
            this.lpl_kq.AutoSize = true;
            this.lpl_kq.ForeColor = System.Drawing.Color.Red;
            this.lpl_kq.Location = new System.Drawing.Point(270, 314);
            this.lpl_kq.Name = "lpl_kq";
            this.lpl_kq.Size = new System.Drawing.Size(0, 20);
            this.lpl_kq.TabIndex = 4;
            this.lpl_kq.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lpl_kq);
            this.Controls.Add(this.cbo_dt);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_loadDL);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_loadDL;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbo_dt;
        private System.Windows.Forms.Label lpl_kq;
    }
}

