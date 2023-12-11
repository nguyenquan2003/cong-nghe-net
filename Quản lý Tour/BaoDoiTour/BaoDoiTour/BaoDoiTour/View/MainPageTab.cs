using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaoDoiTour.Controller;
using System.Data.SqlClient;
using BaoDoiTour.Tour;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace BaoDoiTour.View
{
    public partial class MainPageTab : UserControl
    {
        KetNoi kn = new KetNoi();
        public MainPageTab()
        {
            InitializeComponent();
        }

        //Thống kê doanh thu
        private void ThongKeDoanhThu()
        {
            kn.open();
            // Gọi stored procedure để lấy dữ liệu thống kê doanh thu
            using (SqlCommand command = new SqlCommand("ThongKeDoanhThuTheoThang", kn.Connect))
            {
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Đọc dữ liệu từ SqlDataReader
                        int nam = reader.GetInt32(0);
                        int thang = reader.GetInt32(1);
                        decimal doanhThu = reader.GetDecimal(2);

                        // Thêm dữ liệu vào biểu đồ
                        chartDoanhThu.Series["DoanhThu"].Points.AddXY("/" + thang + "/" + nam, doanhThu);
                    }
                }
            }
        }

        //Load tour đặt nhiều nhất
        private void LoadBestTour()
        {
            string sqlCmd = "EXEC TourDatNhieuNhat";
            try
            {
                Tour_BLL tourbll = new Tour_BLL();
                if (kn.Connect.State == ConnectionState.Closed)
                    kn.open();
                using (SqlDataReader reader = kn.getDataReader(sqlCmd))
                {
                    if (reader.Read())
                    {
                        string MaBestTour = reader.GetString(0);
                        int SLDat = reader.GetInt32(1);
                        tbl_Tour tour = tourbll.GetTour(MaBestTour);
                        lblTenBestTour.Text = tour.TenTour;
                        txtBestTourDesc.Multiline = true;
                        txtBestTourDesc.WordWrap = true;
                        txtBestTourDesc.Text = tour.MieuTa;
                        string DuongDan = tourbll.LayAnh(MaBestTour);
                        kn.close();
                        string imagePath = "../../Resource/img/tours/" + DuongDan;
                        if (System.IO.File.Exists(imagePath))
                        {
                            imgBestTour.ImageLocation = imagePath;
                        }
                    }
                }
            }
            finally
            {
                kn.close();
            }
        }

        //Load đánh giá
        private void LoadBieuDoDanhGia()
        {
            try
            {
                if (kn.Connect.State == ConnectionState.Closed)
                    kn.open();
                string query = "SELECT NgayDanhGia, DanhGia AS SoLuongDanhGia FROM DanhGia";
                SqlDataReader reader = kn.getDataReader(query);
                Series series = new Series("Đánh giá");
                while (reader.Read())
                {
                        DateTime ngayDanhGia = reader.GetDateTime(0);
                        int soLuongDanhGia = reader.GetInt32(1);

                        series.Points.AddXY(ngayDanhGia.ToShortDateString(), soLuongDanhGia);
                }
                // Đặt loại biểu đồ là đường
                series.ChartType = SeriesChartType.Line;

                // Thêm loạt dữ liệu vào biểu đồ
                chrtDanhGia.Series.Add(series);

                //Chỉnh thêm thắt 1 vài chi tiết cho nhìn vip pro hơn tý
                chrtDanhGia.ChartAreas[0].AxisX.Title = "Ngày";
                chrtDanhGia.ChartAreas[0].AxisY.Title = "Số lượng đánh giá";
                chrtDanhGia.Titles.Add("Biểu đồ đánh giá theo ngày");
            }
            finally
            {
                if (kn.Connect.State == ConnectionState.Open)
                    kn.close();
            }
        }

        //Man Hinh Chinh
        private void MainPageTab_Load(object sender, EventArgs e)
        {
            ThongKeDoanhThu();
            LoadBestTour();
            LoadBieuDoDanhGia();
        }
    }
}
