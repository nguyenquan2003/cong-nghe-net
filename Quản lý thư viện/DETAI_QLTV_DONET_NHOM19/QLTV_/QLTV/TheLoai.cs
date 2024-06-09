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
    public partial class TheLoai : Form
    {
        SqlConnection connection;
        string str = DataHolder.str;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public event EventHandler Cloed2;

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
                command.CommandText = "SELECT * FROM TheLoai";
                adapter.SelectCommand = command;

                // Lưu chỉ mục của dòng hiện tại trước khi nạp dữ liệu mới
                int currentRowIndex = -1;
                if (dgv_TheLoai.CurrentRow != null)
                {
                    currentRowIndex = dgv_TheLoai.CurrentRow.Index;
                }

                table.Clear();
                adapter.Fill(table);
                dgv_TheLoai.DataSource = table;
                dgv_TheLoai.Columns[0].HeaderText = "Mã Thể Loại";
                dgv_TheLoai.Columns[1].HeaderText = "Tên Thể Loại";
                dgv_TheLoai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Thiết lập lại chỉ mục của dòng hiện tại sau khi nạp dữ liệu mới
                if (currentRowIndex >= 0 && currentRowIndex < dgv_TheLoai.Rows.Count)
                {
                    dgv_TheLoai.CurrentCell = dgv_TheLoai.Rows[currentRowIndex].Cells["MaTheLoai"];
                }

                // Gán DataSource cho DataGridView
                dgv_TheLoai.DataSource = table;

                // Đặt FillWeight của cột ảnh là 10 (hoặc số khác tùy ý)
            }
            else
            {
                MessageBox.Show("Lỗi kết nối CSDL.");
            }
        }
        public TheLoai()
        {
            InitializeComponent();
        }

        
        private void TheLoai_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            connection = new SqlConnection(str);
            connection.Open();
            LoadData();

            dgv_TheLoai.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void loading()
        {
            maVT.Enabled = true;
            maVT.Clear();
            tenTL.Clear();
        }
        private void dgv_docgia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            maVT.Enabled = false;
            int i;
            i = dgv_TheLoai.CurrentRow.Index;
            maVT.Text = dgv_TheLoai.Rows[i].Cells[0].Value.ToString();
            tenTL.Text = dgv_TheLoai.Rows[i].Cells[1].Value.ToString();

        }

        private void paneltop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maVT.Text))
            {
                MessageBox.Show("Lỗi không điền đầy đủ thông tin (Mã vai trò)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            connection = new SqlConnection(str);
            connection.Open();

            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO TheLoai VALUES(@maTl, @tenTl)";

                command.Parameters.AddWithValue("@maTl", maVT.Text);
                command.Parameters.AddWithValue("@tenTl", tenTL.Text);


                command.ExecuteNonQuery();


                MessageBox.Show("Đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                maVT.Clear();
                tenTL.Clear();
            }
            catch (SqlException ex)
            {


                MessageBox.Show("Lỗi mã thể loại đã tồn tại!!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                LoadData();
                connection.Close();
            }
        }

        private void bt_update_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "UPDATE TheLoai SET  TenTheLoai = @tentl WHERE MaTheLoai = @matl";

            command.Parameters.AddWithValue("@tentl", tenTL.Text);

            command.Parameters.AddWithValue("@matl", maVT.Text);


            command.ExecuteNonQuery();

            MessageBox.Show("Dữ liệu đã được sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            maVT.Enabled = true;
            maVT.Clear();
            tenTL.Clear();
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


                    command.CommandText = "DELETE FROM TheLoai WHERE MaTheLoai = @matl";
                    command.Parameters.AddWithValue("@matl", maVT.Text);

                    int rowsAffectedSach = command.ExecuteNonQuery();


                    // Kiểm tra số hàng bị ảnh hưởng bởi câu lệnh DELETE
                    if (rowsAffectedSach > 0)
                    {
                        transaction.Commit();
                        MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        
                        maVT.Clear();
                        tenTL.Clear();
                        loading();
                    }
                    else
                    {
                        // Hành động xóa không thành công, rollback transaction
                        transaction.Rollback();
                        MessageBox.Show("Không thể xóa thể loại ( Vẫn tồn tại trong bản SACH ) .", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btload_Click(object sender, EventArgs e)
        {
            maVT.Enabled = true;
            maVT.Clear();
            tenTL.Clear();
            timkiem.Clear();
        }

        private void bt_quaylai_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (Cloed2 != null)
            {
                Cloed2(this, EventArgs.Empty);
            }
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
                    using (SqlCommand command = new SqlCommand("SearchTheLoai_Ma", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaTheLoai", maTL);

                        // Tạo SqlDataAdapter để lấy dữ liệu từ cơ sở dữ liệu
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Tạo DataTable để chứa dữ liệu từ cơ sở dữ liệu
                            DataTable dataTable = new DataTable();

                            // Đổ dữ liệu từ SqlDataAdapter vào DataTable
                            adapter.Fill(dataTable);

                            // Gán DataTable làm nguồn dữ liệu cho dgv_PhieuMuon
                            dgv_TheLoai.DataSource = dataTable;
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
                    using (SqlCommand command = new SqlCommand("SearchTheLoai_Ten", connection))
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
                            dgv_TheLoai.DataSource = dataTable;
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

        private void check2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
