
namespace BaoDoiTour.View
{
    partial class MainPageTab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPageTab));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBestTourDesc = new System.Windows.Forms.TextBox();
            this.lblTenBestTour = new System.Windows.Forms.Label();
            this.imgBestTour = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chrtDanhGia = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBestTour)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtDanhGia)).BeginInit();
            this.SuspendLayout();
            // 
            // chartDoanhThu
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend1);
            this.chartDoanhThu.Location = new System.Drawing.Point(19, 44);
            this.chartDoanhThu.Name = "chartDoanhThu";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "DoanhThu";
            this.chartDoanhThu.Series.Add(series1);
            this.chartDoanhThu.Size = new System.Drawing.Size(466, 266);
            this.chartDoanhThu.TabIndex = 0;
            this.chartDoanhThu.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(160)))), ((int)(((byte)(226)))));
            this.panel1.Controls.Add(this.txtBestTourDesc);
            this.panel1.Controls.Add(this.lblTenBestTour);
            this.panel1.Controls.Add(this.imgBestTour);
            this.panel1.Location = new System.Drawing.Point(512, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 266);
            this.panel1.TabIndex = 1;
            // 
            // txtBestTourDesc
            // 
            this.txtBestTourDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(160)))), ((int)(((byte)(226)))));
            this.txtBestTourDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtBestTourDesc.ForeColor = System.Drawing.Color.White;
            this.txtBestTourDesc.Location = new System.Drawing.Point(280, 44);
            this.txtBestTourDesc.Margin = new System.Windows.Forms.Padding(0);
            this.txtBestTourDesc.Multiline = true;
            this.txtBestTourDesc.Name = "txtBestTourDesc";
            this.txtBestTourDesc.ReadOnly = true;
            this.txtBestTourDesc.Size = new System.Drawing.Size(195, 205);
            this.txtBestTourDesc.TabIndex = 2;
            this.txtBestTourDesc.Text = "ccc";
            // 
            // lblTenBestTour
            // 
            this.lblTenBestTour.AutoSize = true;
            this.lblTenBestTour.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenBestTour.ForeColor = System.Drawing.Color.White;
            this.lblTenBestTour.Location = new System.Drawing.Point(276, 17);
            this.lblTenBestTour.Name = "lblTenBestTour";
            this.lblTenBestTour.Size = new System.Drawing.Size(66, 24);
            this.lblTenBestTour.TabIndex = 1;
            this.lblTenBestTour.Text = "label1";
            // 
            // imgBestTour
            // 
            this.imgBestTour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgBestTour.Image = ((System.Drawing.Image)(resources.GetObject("imgBestTour.Image")));
            this.imgBestTour.Location = new System.Drawing.Point(13, 17);
            this.imgBestTour.Name = "imgBestTour";
            this.imgBestTour.Size = new System.Drawing.Size(255, 232);
            this.imgBestTour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgBestTour.TabIndex = 0;
            this.imgBestTour.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Lime;
            this.panel2.Controls.Add(this.chrtDanhGia);
            this.panel2.Location = new System.Drawing.Point(19, 324);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(977, 306);
            this.panel2.TabIndex = 2;
            // 
            // chrtDanhGia
            // 
            chartArea2.Name = "ChartArea1";
            this.chrtDanhGia.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chrtDanhGia.Legends.Add(legend2);
            this.chrtDanhGia.Location = new System.Drawing.Point(172, 3);
            this.chrtDanhGia.Name = "chrtDanhGia";
            this.chrtDanhGia.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            this.chrtDanhGia.Size = new System.Drawing.Size(663, 300);
            this.chrtDanhGia.TabIndex = 0;
            this.chrtDanhGia.Text = "chart1";
            // 
            // MainPageTab
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chartDoanhThu);
            this.Name = "MainPageTab";
            this.Size = new System.Drawing.Size(1013, 639);
            this.Load += new System.EventHandler(this.MainPageTab_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBestTour)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chrtDanhGia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox imgBestTour;
        private System.Windows.Forms.Label lblTenBestTour;
        private System.Windows.Forms.TextBox txtBestTourDesc;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtDanhGia;
    }
}
