using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QLTV
{
    public partial class PhieuTraSach : Form
    {
        SqlConnection connection;
        string str = DataHolder.str;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public event EventHandler Cloed1;

        public void LoadData()
        {
            connection = new SqlConnection(str);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            if (connection.State == ConnectionState.Open)
            {
                if (table == null)
                {
                    // Xử lý trường hợp table là null
                    return;
                }

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM PhieuTra";
                adapter.SelectCommand = command;

                // Lưu chỉ mục của dòng hiện tại trước khi nạp dữ liệu mới
                int currentRowIndex = -1;
                if (dgv_PhieuTra.CurrentRow != null)
                {
                    currentRowIndex = dgv_PhieuTra.CurrentRow.Index;
                }

                table.Clear();
                adapter.Fill(table);
                dgv_PhieuTra.DataSource = table;
                dgv_PhieuTra.Columns[0].HeaderText = "Mã Phiếu Mượn";
                dgv_PhieuTra.Columns[1].HeaderText = "Mã Sách";
                dgv_PhieuTra.Columns[2].HeaderText = "Số Lượng Mượn";
                dgv_PhieuTra.Columns[3].HeaderText = "Ngày Mượn";
                dgv_PhieuTra.Columns[4].HeaderText = "Hẹn Trả";
                dgv_PhieuTra.Columns[5].HeaderText = "Tình Trạng";
                dgv_PhieuTra.Columns[6].HeaderText = "Ghi Chú";
                dgv_PhieuTra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                // Thiết lập lại chỉ mục của dòng hiện tại sau khi nạp dữ liệu mới
                if (currentRowIndex >= 0 && currentRowIndex < dgv_PhieuTra.Rows.Count)
                {
                    dgv_PhieuTra.CurrentCell = dgv_PhieuTra.Rows[currentRowIndex].Cells["MaPhieuMuon"];
                }

                // Gán DataSource cho DataGridView
                dgv_PhieuTra.DataSource = table;

                // Đặt FillWeight của cột ảnh là 10 (hoặc số khác tùy ý)
            }
            else
            {
                MessageBox.Show("Lỗi kết nối CSDL.");
            }
        }
        public PhieuTraSach()
        {
            InitializeComponent();
        }

        private void dgv_PhieuTra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void PhieuTraSach_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();

            LoadData();
            dgv_PhieuTra.EditMode = DataGridViewEditMode.EditOnEnter;
        }
        public string checkSL(string maSach)
        {
            string check = "";
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT SoLuong FROM Sach WHERE MaSach = @maS", connection))
                {
                    command.Parameters.AddWithValue("@maS", maSach);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            check = reader["SoLuong"].ToString();
                            return check;
                        }
                    }
                }
            }
            return check;
        }

        private void bt_tra_sach_Click(object sender, EventArgs e)
        {
            if (string.Compare(tinhTrang.Text, "Quá hạn") == 0)
            {
                MessageBox.Show("Không thể xử lí trường hợp quá hạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.Compare(tinhTrang.Text, "Đã trả") == 0)
            {
                MessageBox.Show("Bạn đã xử lí trường hợp này rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {

                int check_1;
                int check_2;
                string slSach = checkSL(maSachMuon.Text);
                int.TryParse(slMuon.Text, out check_1);
                int.TryParse(slSach, out check_2);
                string check_3 = (check_1 + check_2).ToString();

                updateSL_SACH(check_3, maSachMuon.Text);
                updateSL_tinhTrang_PT(maPM.Text);
                updateSL_tinhTrang_PM(maPM.Text);
                LoadData();
                MessageBox.Show("Đã xử lí!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("LỖI" + ex, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        public void updateSL_tinhTrang_PM(string maPM)
        {
            connection = new SqlConnection(str);
            connection.Open();
            string check = "Đã trả";
            var command = connection.CreateCommand();
            command.CommandText = "UPDATE PhieuMuon SET  TinhTrang = @tt WHERE MaPhieuMuon = @maPM";

            command.Parameters.AddWithValue("@tt", check);
            command.Parameters.AddWithValue("@maPM", maPM);
            command.ExecuteNonQuery();

        }
        public void updateSL_tinhTrang_PT(string maPM_PT)
        {
            connection = new SqlConnection(str);
            connection.Open();
            string check = "Đã xử lí";
            var command = connection.CreateCommand();
            command.CommandText = "UPDATE PhieuTra SET  GhiChu = @gc WHERE MaPhieuMuon = @maPM_PT";

            command.Parameters.AddWithValue("@gc", check);
            command.Parameters.AddWithValue("@maPM_PT", maPM_PT);
            command.ExecuteNonQuery();

        }
        public void updateSL_SACH(string slMuon, string maSach)
        {
            connection = new SqlConnection(str);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "UPDATE Sach SET  SoLuong = @sl WHERE MaSach = @maSach";

            command.Parameters.AddWithValue("@sl", slMuon);
            command.Parameters.AddWithValue("@maSach", maSach);
            command.ExecuteNonQuery();

        }




        private void bt_quaylai_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (Cloed1 != null)
            {
                Cloed1(this, EventArgs.Empty);
            }
            else if (GiaoDienNV.QuayLaiForm1)
            {
                this.Close();
            }
        }

        private void dgv_PhieuTra_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_PhieuTra.CurrentRow.Index;
            maPM.Text = dgv_PhieuTra.Rows[i].Cells[0].Value.ToString();
            maSachMuon.Text = dgv_PhieuTra.Rows[i].Cells[1].Value.ToString();
            slMuon.Text = dgv_PhieuTra.Rows[i].Cells[2].Value.ToString();
            dateM.Text = dgv_PhieuTra.Rows[i].Cells[3].Value.ToString();
            date_hen_tra.Text = dgv_PhieuTra.Rows[i].Cells[4].Value.ToString();
            tinhTrang.Text = dgv_PhieuTra.Rows[i].Cells[5].Value.ToString();
            ghiChu.Text = dgv_PhieuTra.Rows[i].Cells[6].Value.ToString();
        }

        private void PhieuTraSach_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GiaoDienNV.QuayLaiForm1)
            {
                GiaoDienNV form1 = new GiaoDienNV();
                form1.Show();
            }
        }

        private void timkiem_TextChanged(object sender, EventArgs e)
        {
            //if (check1.Checked)
            //{
            //    string ma = timkiem.Text;

            //    // Kết nối đến cơ sở dữ liệu
            //    using (var connection = new SqlConnection(str))
            //    {
            //        connection.Open();

            //        // Tạo và cấu hình SqlCommand
            //        using (SqlCommand command = new SqlCommand("SearchTraMuonByMaPM", connection))
            //        {
            //            command.CommandType = CommandType.StoredProcedure;
            //            command.Parameters.AddWithValue("@Ma", ma);

            //            // Tạo SqlDataAdapter để lấy dữ liệu từ cơ sở dữ liệu
            //            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            //            {
            //                // Tạo DataTable để chứa dữ liệu từ cơ sở dữ liệu
            //                DataTable dataTable = new DataTable();

            //                // Đổ dữ liệu từ SqlDataAdapter vào DataTable
            //                adapter.Fill(dataTable);

            //                // Gán DataTable làm nguồn dữ liệu cho dgv_PhieuMuon
            //                dgv_PhieuTra.DataSource = dataTable;
            //            }
            //        }

            //    }
            //}
            //else if (check2.Checked)
            //{
            //    string maSach = timkiem.Text;

            //    using (var connection = new SqlConnection(str))
            //    {
            //        // Kết nối đến cơ sở dữ liệu
            //        connection.Open();

            //        // Tạo và cấu hình SqlCommand
            //        using (SqlCommand command = new SqlCommand("SearchTraMuonByMaSach", connection))
            //        {
            //            command.CommandType = CommandType.StoredProcedure;
            //            command.Parameters.AddWithValue("@Ma", maSach);

            //            // Tạo SqlDataAdapter để lấy dữ liệu từ cơ sở dữ liệu
            //            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            //            {
            //                // Tạo DataTable để chứa dữ liệu từ cơ sở dữ liệu
            //                DataTable dataTable = new DataTable();

            //                // Đổ dữ liệu từ SqlDataAdapter vào DataTable
            //                adapter.Fill(dataTable);

            //                // Gán DataTable làm nguồn dữ liệu cho dgv_PhieuMuon
            //                dgv_PhieuTra.DataSource = dataTable;
            //            }
            //        }
            //    }

            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng chọn giá trị tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //}
            //if (string.IsNullOrEmpty(timkiem.Text))
            //{
            //    LoadData(); // Thay thế bằng phương thức load dữ liệu của bạn
            //}
        }

        private void find_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(timkiem.Text))
            {
                MessageBox.Show("Vui lòng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (check1.Checked)
            {
                string ma = timkiem.Text;

                // Kết nối đến cơ sở dữ liệu
                using (var connection = new SqlConnection(str))
                {
                    connection.Open();

                    // Tạo và cấu hình SqlCommand
                    using (SqlCommand command = new SqlCommand("SearchTraMuonByMaPM", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Ma", ma);

                        // Tạo SqlDataAdapter để lấy dữ liệu từ cơ sở dữ liệu
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Tạo DataTable để chứa dữ liệu từ cơ sở dữ liệu
                            DataTable dataTable = new DataTable();

                            // Đổ dữ liệu từ SqlDataAdapter vào DataTable
                            adapter.Fill(dataTable);

                            // Gán DataTable làm nguồn dữ liệu cho dgv_PhieuMuon
                            dgv_PhieuTra.DataSource = dataTable;
                        }
                    }

                }
            }
            else if (check2.Checked)
            {
                string maSach = timkiem.Text;

                using (var connection = new SqlConnection(str))
                {
                    // Kết nối đến cơ sở dữ liệu
                    connection.Open();

                    // Tạo và cấu hình SqlCommand
                    using (SqlCommand command = new SqlCommand("SearchTraMuonByMaSach", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Ma", maSach);

                        // Tạo SqlDataAdapter để lấy dữ liệu từ cơ sở dữ liệu
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Tạo DataTable để chứa dữ liệu từ cơ sở dữ liệu
                            DataTable dataTable = new DataTable();

                            // Đổ dữ liệu từ SqlDataAdapter vào DataTable
                            adapter.Fill(dataTable);

                            // Gán DataTable làm nguồn dữ liệu cho dgv_PhieuMuon
                            dgv_PhieuTra.DataSource = dataTable;
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn giá trị tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            //if (string.IsNullOrEmpty(timkiem.Text))
            //{
            //    LoadData(); // Thay thế bằng phương thức load dữ liệu của bạn
            //}
        }


    }
}
