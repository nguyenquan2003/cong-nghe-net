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
    public partial class TacGia : Form
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
                command.CommandText = "SELECT * FROM TacGia";
                adapter.SelectCommand = command;

                // Lưu chỉ mục của dòng hiện tại trước khi nạp dữ liệu mới
                int currentRowIndex = -1;
                if (dgv_TacGia.CurrentRow != null)
                {
                    currentRowIndex = dgv_TacGia.CurrentRow.Index;
                }

                table.Clear();
                adapter.Fill(table);
                dgv_TacGia.DataSource = table;
                dgv_TacGia.Columns[0].HeaderText = "Mã Tác Giả";
                dgv_TacGia.Columns[1].HeaderText = "Tên Tác Giả";
                dgv_TacGia.Columns[2].HeaderText = "Năm Sinh";
                dgv_TacGia.Columns[3].HeaderText = "Tiểu Sử";
                dgv_TacGia.Columns[4].HeaderText = "Quê Quán";
                dgv_TacGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Thiết lập lại chỉ mục của dòng hiện tại sau khi nạp dữ liệu mới
                if (currentRowIndex >= 0 && currentRowIndex < dgv_TacGia.Rows.Count)
                {
                    dgv_TacGia.CurrentCell = dgv_TacGia.Rows[currentRowIndex].Cells["MaTacGia"];
                }

                // Gán DataSource cho DataGridView
                dgv_TacGia.DataSource = table;

                // Đặt FillWeight của cột ảnh là 10 (hoặc số khác tùy ý)
            }
            else
            {
                MessageBox.Show("Lỗi kết nối CSDL.");
            }
        }
        public TacGia()
        {
            InitializeComponent();
        }

        private void bt_quaylai_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (Cloed1 != null)
            {
                Cloed1(this, EventArgs.Empty);
            }  
        }

        private void TacGia_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            connection = new SqlConnection(str);
            connection.Open();
            LoadData();
            dgv_TacGia.EditMode = DataGridViewEditMode.EditOnEnter;
        }



        private void bt_add_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();

            if (string.IsNullOrWhiteSpace(maTG.Text))
            {
                MessageBox.Show("Lỗi không điền đầy đủ thông tin (Mã tác giả)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string ngaySinhs = ngaySinh.Value.ToString("yyyy-MM-dd");
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO TacGia VALUES(@maTG, @tenTG, @NamSinh,@TieuSu, @QueQuan)";

                command.Parameters.AddWithValue("@maTG", maTG.Text);
                command.Parameters.AddWithValue("@tenTG", tenTG.Text);



                command.Parameters.AddWithValue("@NamSinh", ngaySinhs);
                command.Parameters.AddWithValue("@TieuSu", TS.Text);
                command.Parameters.AddWithValue("@QueQuan", QQ.Text);


                command.ExecuteNonQuery();


                MessageBox.Show("Đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi mã tác giả đã tồn tại!!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                LoadData();
                connection.Close();
            }
        }
        public void loading()
        {
            timkiem.Clear();
            maTG.Enabled = true;
            maTG.Clear();
            tenTG.Clear();
            ngaySinh.Value = DateTime.Now;
            QQ.Clear();
            TS.Clear();
        }
        private void dgv_docgia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            maTG.Enabled = false;
            int i;
            i = dgv_TacGia.CurrentRow.Index;
            maTG.Text = dgv_TacGia.Rows[i].Cells[0].Value.ToString();
            tenTG.Text = dgv_TacGia.Rows[i].Cells[1].Value.ToString();
            ngaySinh.Text = dgv_TacGia.Rows[i].Cells[2].Value.ToString();
            TS.Text = dgv_TacGia.Rows[i].Cells[3].Value.ToString();
            QQ.Text = dgv_TacGia.Rows[i].Cells[4].Value.ToString();
        }

        private void bt_update_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "UPDATE TacGia SET  TenTacGia = @tentg, NamSinh = @namsinh, TieuSu = @tieusu, QueQuan = @quequan WHERE MaTacGia = @matg";

            command.Parameters.AddWithValue("@tentg", tenTG.Text);
            command.Parameters.AddWithValue("@namsinh", ngaySinh.Value.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@tieusu", TS.Text);
            command.Parameters.AddWithValue("@quequan", QQ.Text);

            command.Parameters.AddWithValue("@matg", maTG.Text);


            command.ExecuteNonQuery();

            MessageBox.Show("Dữ liệu đã được sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData();
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    var command = connection.CreateCommand();
                    command.Transaction = transaction;

                    string matg = maTG.Text; // Lấy mã sách từ TextBox maSach


                    command.CommandText = "DELETE FROM TacGia WHERE MaTacGia = @matg";
                    command.Parameters.AddWithValue("@matg", matg);

                    int rowsAffectedSach = command.ExecuteNonQuery();


                    // Kiểm tra số hàng bị ảnh hưởng bởi câu lệnh DELETE
                    if (rowsAffectedSach > 0)
                    {
                        transaction.Commit();
                        MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        // Hành động xóa không thành công, rollback transaction
                        transaction.Rollback();
                        MessageBox.Show("Không thể xóa tác giả ( Vẫn tồn tại trong bản SACH ) .", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi và rollback transaction nếu có lỗi xảy ra
                    transaction.Rollback();
                    MessageBox.Show("Không thể xóa tác giả ( Vẫn tồn tại trong bản SACH ) .", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            LoadData();
        }

        private void bt_load_Click(object sender, EventArgs e)
        {
            LoadData();
            loading();
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
                string maTL = timkiem.Text;

                // Kết nối đến cơ sở dữ liệu
                using (var connection = new SqlConnection(str))
                {
                    connection.Open();

                    // Tạo và cấu hình SqlCommand
                    using (SqlCommand command = new SqlCommand("SearchTacGia_Ma", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Ma", maTL);

                        // Tạo SqlDataAdapter để lấy dữ liệu từ cơ sở dữ liệu
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Tạo DataTable để chứa dữ liệu từ cơ sở dữ liệu
                            DataTable dataTable = new DataTable();

                            // Đổ dữ liệu từ SqlDataAdapter vào DataTable
                            adapter.Fill(dataTable);

                            // Gán DataTable làm nguồn dữ liệu cho dgv_PhieuMuon
                            dgv_TacGia.DataSource = dataTable;
                        }
                    }

                }
            }
            else if (check2.Checked)
            {
                string ten = timkiem.Text;

                using (var connection = new SqlConnection(str))
                {
                    // Kết nối đến cơ sở dữ liệu
                    connection.Open();

                    // Tạo và cấu hình SqlCommand
                    using (SqlCommand command = new SqlCommand("SearchTacGia_Ten", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Ten", ten);

                        // Tạo SqlDataAdapter để lấy dữ liệu từ cơ sở dữ liệu
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Tạo DataTable để chứa dữ liệu từ cơ sở dữ liệu
                            DataTable dataTable = new DataTable();

                            // Đổ dữ liệu từ SqlDataAdapter vào DataTable
                            adapter.Fill(dataTable);

                            // Gán DataTable làm nguồn dữ liệu cho dgv_PhieuMuon
                            dgv_TacGia.DataSource = dataTable;
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn giá trị tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
          
        }

        private void timkiem_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(timkiem.Text))
            {
                LoadData(); // Thay thế bằng phương thức load dữ liệu của bạn
            }
        }

        private void TS_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
