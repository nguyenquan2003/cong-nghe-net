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
    public partial class UC_MuonTraSach : UserControl
    {
        SqlConnection connection;
        string str = DataHolder.str;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public event EventHandler Button1Clicked;
        public event EventHandler FORMMUONSACH;
        public event EventHandler FORMTRASACH;
        public event EventHandler FORMDSQUAHAN;
        PhieuMuonSach pmsach = new PhieuMuonSach();
        PhieuTraSach ptsach = new PhieuTraSach();
        DanhSachQuaHan dsquahan = new DanhSachQuaHan();
        public UC_MuonTraSach()
        {
            InitializeComponent();
            pmsach.Cloed += FROMCLOED;
            ptsach.Cloed1 += FROMCLOED1;
            dsquahan.Cloed2 += FROMCLOED2;
        }


        //MƯỢN SÁCH
        private void FROMCLOED(object sender, EventArgs e)
        {
            if (FORMMUONSACH != null)
            {
                FORMMUONSACH(this, EventArgs.Empty);
            }

        }
        private void bt_muonsach_Click(object sender, EventArgs e)
        {
            if (Button1Clicked != null)
            {
                Button1Clicked(this, EventArgs.Empty);
            }

            pmsach.Show(); 
        }

        //TRẢ SÁCH
        private void FROMCLOED1(object sender, EventArgs e)
        {
            if (FORMTRASACH != null)
            {
                FORMTRASACH(this, EventArgs.Empty);
            }

        }
        private void bt_trasach_Click(object sender, EventArgs e)
        {
            if (Button1Clicked != null)
            {
                Button1Clicked(this, EventArgs.Empty);
            }

            ptsach.Show();
        }

        //DANH SÁCH QUÁ HẠN
        private void FROMCLOED2(object sender, EventArgs e)
        {
            if (FORMDSQUAHAN != null)
            {
                FORMDSQUAHAN(this, EventArgs.Empty);
            }

        }
        private void bt_dsquahan_Click(object sender, EventArgs e)
        {
            if (Button1Clicked != null)
            {
                Button1Clicked(this, EventArgs.Empty);
            }

            dsquahan.Show();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            string maPM = txt_timkiem.Text;

            // Kết nối đến cơ sở dữ liệu
            using (var connection = new SqlConnection(str))
            {
                connection.Open();

                // Tạo và cấu hình SqlCommand
                using (SqlCommand command = new SqlCommand("SearchPhieuMuonByMaPM", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MAPM", maPM);

                    // Tạo SqlDataAdapter để lấy dữ liệu từ cơ sở dữ liệu
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        // Tạo DataTable để chứa dữ liệu từ cơ sở dữ liệu
                        DataTable dataTable = new DataTable();

                        // Đổ dữ liệu từ SqlDataAdapter vào DataTable
                        adapter.Fill(dataTable);
                        dgv_MuonTraSach.DataSource = dataTable;
                        dgv_MuonTraSach.Columns[0].HeaderText = "Mã Phiếu Mượn";
                        dgv_MuonTraSach.Columns[1].HeaderText = "Mã Độc Giả";
                        dgv_MuonTraSach.Columns[2].HeaderText = "Mã Sách";
                        dgv_MuonTraSach.Columns[3].HeaderText = "Mã Quản Lý";
                        dgv_MuonTraSach.Columns[4].HeaderText = "Tên Sách";
                        dgv_MuonTraSach.Columns[5].HeaderText = "Tên Độc Giả";
                        dgv_MuonTraSach.Columns[6].HeaderText = "Số Lượng Mượn";
                        dgv_MuonTraSach.Columns[7].HeaderText = "Ngày Mượn";
                        dgv_MuonTraSach.Columns[8].HeaderText = "Hẹn Trả";
                        dgv_MuonTraSach.Columns[9].HeaderText = "Tình Trạng";
                        dgv_MuonTraSach.Columns[10].HeaderText = "Tên Nhân Viên";


                        // Gán DataTable làm nguồn dữ liệu cho dgv_PhieuMuon
                        dgv_MuonTraSach.DataSource = dataTable;
                    }
                }
            }
        }

        
    }
}
