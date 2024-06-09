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
    public partial class DanhSachQuaHan : Form
    {
        SqlConnection connection;
        string str = DataHolder.str;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public event EventHandler Cloed2;
        public DanhSachQuaHan()
        {
            InitializeComponent();
        }

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
                command.CommandText = "SELECT * FROM DSQuaHan";
                adapter.SelectCommand = command;

                // Lưu chỉ mục của dòng hiện tại trước khi nạp dữ liệu mới
                int currentRowIndex = -1;
                if (dgv_QuaHan.CurrentRow != null)
                {
                    currentRowIndex = dgv_QuaHan.CurrentRow.Index;
                }

                table.Clear();
                adapter.Fill(table);
                dgv_QuaHan.DataSource = table;
                dgv_QuaHan.Columns[0].HeaderText = "Mã Phiếu Mượn";
                dgv_QuaHan.Columns[1].HeaderText = "Số Ngày Trễ";
                dgv_QuaHan.Columns[2].HeaderText = "Ghi Chú";
                dgv_QuaHan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Thiết lập lại chỉ mục của dòng hiện tại sau khi nạp dữ liệu mới
                if (currentRowIndex >= 0 && currentRowIndex < dgv_QuaHan.Rows.Count)
                {
                    dgv_QuaHan.CurrentCell = dgv_QuaHan.Rows[currentRowIndex].Cells["MaPhieuMuon"];
                }

                // Gán DataSource cho DataGridView
                dgv_QuaHan.DataSource = table;

                // Đặt FillWeight của cột ảnh là 10 (hoặc số khác tùy ý)
            }
            else
            {
                MessageBox.Show("Lỗi kết nối CSDL.");
            }
        }

        public string check_MaS_PM(string maPM)
        {
            string check = "";
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT MaSach FROM PhieuMuon WHERE MaPhieuMuon = @maPM", connection))
                {
                    command.Parameters.AddWithValue("@maPM", maPM);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            check = reader["MaSach"].ToString();
                            return check;
                        }
                    }
                }
            }
            return check;
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
        public string checkSL_PM(string maPM)
        {
            string check = "";
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT SoLuongMuon FROM PhieuMuon WHERE MaPhieuMuon = @maPM", connection))
                {
                    command.Parameters.AddWithValue("@maPM", maPM);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            check = reader["SoLuongMuon"].ToString();
                            return check;
                        }
                    }
                }
            }
            return check;
        }

        private void bt_xuly_Click(object sender, EventArgs e)
        {
            if (string.Compare(ghiChu.Text, "Đã xử lí") == 0)
            {
                MessageBox.Show("Bạn đã xử lí trường hợp này rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {

                int check_1;
                int check_2;
                string maSachMuon = check_MaS_PM(maPM.Text);
                string slSach = checkSL(maSachMuon);
                int.TryParse(slSach, out check_1);
                string SLMUON = checkSL_PM(maPM.Text);
                int.TryParse(SLMUON, out check_2);
                string check_3 = (check_1 + check_2).ToString();
                updateGHICHU_DSQH(maPM.Text);
                updateSL_SACH(check_3, maSachMuon);
                updateSL_tinhTrang_PT(maPM.Text);
                updateSL_tinhTrang_PM(maPM.Text);
                LoadData();
                MessageBox.Show("Đã xử lí", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        public void updateGHICHU_DSQH(string maPM)
        {
            connection = new SqlConnection(str);
            connection.Open();
            string check = "Đã xử lí";
            var command = connection.CreateCommand();
            command.CommandText = "UPDATE DSQuaHan SET  GhiChu = @tt WHERE MaPhieuMuon = @maPM";

            command.Parameters.AddWithValue("@tt", check);
            command.Parameters.AddWithValue("@maPM", maPM);
            command.ExecuteNonQuery();

        }
        public void updateSL_tinhTrang_PT(string maPM_PT)
        {
            connection = new SqlConnection(str);
            connection.Open();
            string check = "Đã xử lí (muộn)";
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

        private void dgv_quahan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_QuaHan.CurrentRow.Index;
            maPM.Text = dgv_QuaHan.Rows[i].Cells[0].Value.ToString();
            soNgayTre.Text = dgv_QuaHan.Rows[i].Cells[1].Value.ToString();
            ghiChu.Text = dgv_QuaHan.Rows[i].Cells[2].Value.ToString();
        }

        private void DanhSachQuaHan_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            connection = new SqlConnection(str);
            connection.Open();



            LoadData();

            dgv_QuaHan.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void bt_quaylai_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (Cloed2 != null)
            {
                Cloed2(this, EventArgs.Empty);
            }
            else if(GiaoDienNV.QuayLaiForm1)
            {
                this.Close();
            }
        }

        private void DanhSachQuaHan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GiaoDienNV.QuayLaiForm1)
            {
                GiaoDienNV form1 = new GiaoDienNV();
                form1.Show();
            }
        }


    }
}
