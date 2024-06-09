using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLTV
{
    public partial class UC_ThongKe : UserControl
    {
        SqlConnection connection;
        string str = DataHolder.str;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

        // Định dạng ngày theo định dạng yêu cầu (dd/MM/yyyy)
        
        public int CountPhieuMuonSach()
        {
            int count = 0;

            using (SqlConnection connection = new SqlConnection(str))
            {
                string formattedDate = firstDayOfMonth.ToString("yyyy/MM/dd");
                connection.Open();
                
                string queryString = "SELECT COUNT(*) FROM PhieuMuon WHERE NgayMuon >= @NgayMuon";

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    // Thêm tham số vào câu truy vấn
                    command.Parameters.AddWithValue("@NgayMuon", formattedDate );

                    // Thực hiện truy vấn và lấy giá trị COUNT
                    count = (int)command.ExecuteScalar();
                }
                
            }


            return count;
        }
        public int CountPhieuTraChuaTra()
        {
            int count = 0;
            string formattedDate = firstDayOfMonth.ToString("yyyy/MM/dd");
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM PhieuTra WHERE TinhTrang = N'Chưa trả' and NgayMuon >= @NgayMuon or TinhTrang = N'Quá hạn' and NgayMuon >= @NgayMuon", connection))
                {
                    command.Parameters.AddWithValue("@NgayMuon", formattedDate);
                    count = (int)command.ExecuteScalar();
                    
                }
            }
          
            return count;
        }
        public int CountPhieuTraDaTra()
        {
            int count = 0;
            string formattedDate = firstDayOfMonth.ToString("yyyy/MM/dd");
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM PhieuTra WHERE TinhTrang = N'Đã trả' and NgayMuon >= @NgayMuon", connection))
                {
                    command.Parameters.AddWithValue("@NgayMuon", formattedDate);
                    count = (int)command.ExecuteScalar();
                }
            }

            return count;
        }
        public int CountPhieuQuaHan()
        {
            int count = 0;
            string formattedDate = firstDayOfMonth.ToString("yyyy/MM/dd");
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM PhieuMuon WHERE TinhTrang = N'Quá hạn' and NgayMuon >= @NgayMuon", connection))
                {
                    command.Parameters.AddWithValue("@NgayMuon", formattedDate);
                    count = (int)command.ExecuteScalar();
                }
            }

            return count;
        }
        public int CountTheLoai()
        {
            int count = 0;

            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM TheLoai", connection))
                {

                    count = (int)command.ExecuteScalar();
                }
            }

            return count;
        }


        public UC_ThongKe()
        {
            InitializeComponent();
        }

        private void UC_ThongKe_Load(object sender, EventArgs e)
        {
            string month = DateTime.Now.Month.ToString();
            string formattedDate = firstDayOfMonth.ToString("yyyy/MM/dd");
            DATA_RP.date = formattedDate;
            lb_top.Text = lb_top.Text + " " + month;
            lb_sl_muon.Text = CountPhieuMuonSach().ToString();
            lb_sl_chua_tra.Text = CountPhieuTraChuaTra().ToString();
            lb_sl_tra.Text = CountPhieuTraDaTra().ToString();
            lb_qua_han.Text = CountPhieuQuaHan().ToString();
            lb_theloai.Text = CountTheLoai().ToString();
        }

        private void tongmuon_Click(object sender, EventArgs e)
        {
            DATA_RP.check = 3;
            string formattedDate = firstDayOfMonth.ToString("yyyy/MM/dd");
            // Tạo kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                // Truy vấn dữ liệu từ bảng PhieuMuon
                string query = "SELECT * FROM PhieuMuon Where NgayMuon >= @NgayMuon";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NgayMuon", formattedDate);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Gán dữ liệu từ bảng PhieuMuon cho DataGridView dgv_ThongKe
                        dgv_ThongKe.DataSource = dt;
                    }
                }
            }
        }

        private void datra_Click(object sender, EventArgs e)
        {
            DATA_RP.check = 2;
            string formattedDate = firstDayOfMonth.ToString("yyyy/MM/dd");
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                // Truy vấn dữ liệu từ bảng PhieuMuon
                string query = "SELECT * FROM PhieuMuon Where TinhTrang =N'Đã trả' and NgayMuon >= @NgayMuon";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NgayMuon", formattedDate);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Gán dữ liệu từ bảng PhieuMuon cho DataGridView dgv_ThongKe
                        dgv_ThongKe.DataSource = dt;
                    }
                }
            }
        }

        private void chuatra_Click(object sender, EventArgs e)
        {
            DATA_RP.check = 1;
            string formattedDate = firstDayOfMonth.ToString("yyyy/MM/dd");
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                // Truy vấn dữ liệu từ bảng PhieuMuon
                string query = "SELECT * FROM PhieuMuon Where TinhTrang = N'Chưa trả' and NgayMuon >= @NgayMuon or TinhTrang = N'Quá hạn' and NgayMuon >= @NgayMuon";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NgayMuon", formattedDate);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgv_ThongKe.DataSource = dt;
                        dgv_ThongKe.Columns[0].HeaderText = "Mã Phiếu Mượn";
                        dgv_ThongKe.Columns[1].HeaderText = "Mã Độc Giả";
                        dgv_ThongKe.Columns[2].HeaderText = "Mã Sách";
                        dgv_ThongKe.Columns[3].HeaderText = "Mã Quản Lý";
                        dgv_ThongKe.Columns[4].HeaderText = "Tên Sách";
                        dgv_ThongKe.Columns[5].HeaderText = "Tên Độc Giả";
                        dgv_ThongKe.Columns[6].HeaderText = "Số Lượng Mượn";
                        dgv_ThongKe.Columns[7].HeaderText = "Ngày Mượn";
                        dgv_ThongKe.Columns[8].HeaderText = "Hẹn Trả";
                        dgv_ThongKe.Columns[9].HeaderText = "Tình Trạng";
                        dgv_ThongKe.Columns[10].HeaderText = "Tên Nhân Viên";

                        // Gán dữ liệu từ bảng PhieuMuon cho DataGridView dgv_ThongKe
                        dgv_ThongKe.DataSource = dt;
                    }
                }
            }
        }

        private void report_Click(object sender, EventArgs e)
        {
            if (DATA_RP.check == 1 || DATA_RP.check == 2 || DATA_RP.check == 3)
            {
                BAOCAO_PM_1 bc = new BAOCAO_PM_1();
                bc.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lỗi chưa chọn thông tin xuất!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

        }


       
    }
    public static class DATA_RP
    {
        public static int check { get; set; }
        public static string date { get; set; }
    }
}
