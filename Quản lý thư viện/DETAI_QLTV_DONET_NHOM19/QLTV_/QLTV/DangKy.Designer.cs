namespace QLTV
{
    partial class DangKy
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
            this.pennodangky = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pennodangky
            // 
            this.pennodangky.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pennodangky.Location = new System.Drawing.Point(0, 0);
            this.pennodangky.Name = "pennodangky";
            this.pennodangky.Size = new System.Drawing.Size(1195, 658);
            this.pennodangky.TabIndex = 0;
            // 
            // DangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 658);
            this.Controls.Add(this.pennodangky);
            this.Name = "DangKy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DangKy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DangKy_FormClosing);
            this.Load += new System.EventHandler(this.DangKy_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pennodangky;
    }
}