
namespace BaoDoiTour.View
{
    partial class InRPTChiTietHoaDon
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
            this.rptVChiTietHoaDon = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // rptVChiTietHoaDon
            // 
            this.rptVChiTietHoaDon.ActiveViewIndex = -1;
            this.rptVChiTietHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rptVChiTietHoaDon.Cursor = System.Windows.Forms.Cursors.Default;
            this.rptVChiTietHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptVChiTietHoaDon.Location = new System.Drawing.Point(0, 0);
            this.rptVChiTietHoaDon.Name = "rptVChiTietHoaDon";
            this.rptVChiTietHoaDon.Size = new System.Drawing.Size(800, 450);
            this.rptVChiTietHoaDon.TabIndex = 0;
            this.rptVChiTietHoaDon.Load += new System.EventHandler(this.rptVHoaDon_Load);
            // 
            // InRPTChiTietHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rptVChiTietHoaDon);
            this.Name = "InRPTChiTietHoaDon";
            this.Text = "InRPTChiTietHoaDon";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer rptVChiTietHoaDon;
    }
}