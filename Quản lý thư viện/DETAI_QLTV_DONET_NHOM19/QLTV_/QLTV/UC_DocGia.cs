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
    public partial class UC_DocGia : UserControl
    {
        SqlConnection connection;
        string str = DataHolder.str;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public UC_DocGia()
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
                command.CommandText = "SELECT * FROM DocGia";
                adapter.SelectCommand = command;

                // Lưu chỉ mục của dòng hiện tại trước khi nạp dữ liệu mới
                int currentRowIndex = -1;
                if (dgv_DocGia.CurrentRow != null)
                {
                    currentRowIndex = dgv_DocGia.CurrentRow.Index;
                }

                table.Clear();
                adapter.Fill(table);
                dgv_DocGia.DataSource = table;
                dgv_DocGia.Columns[0].HeaderText = "Mã Độc Giả";
                dgv_DocGia.Columns[1].HeaderText = "Tên Độc Giả";
                dgv_DocGia.Columns[2].HeaderText = "Ngày Sinh";
                dgv_DocGia.Columns[3].HeaderText = "Giới Tính";
                dgv_DocGia.Columns[4].HeaderText = "Địa Chỉ";
                dgv_DocGia.Columns[5].HeaderText = "Ngày Làm Thẻ";
                dgv_DocGia.Columns[6].HeaderText = "Số Điện Thoại";


                // Thiết lập lại chỉ mục của dòng hiện tại sau khi nạp dữ liệu mới
                if (currentRowIndex >= 0 && currentRowIndex < dgv_DocGia.Rows.Count)
                {
                    dgv_DocGia.CurrentCell = dgv_DocGia.Rows[currentRowIndex].Cells["MaDocGia"];
                }

                // Gán DataSource cho DataGridView
                dgv_DocGia.DataSource = table;

                // Đặt FillWeight của cột ảnh là 10 (hoặc số khác tùy ý)
            }
            else
            {
                MessageBox.Show("Lỗi kết nối CSDL.");
            }
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();

            if (string.IsNullOrWhiteSpace(maDocGia.Text))
            {
                MessageBox.Show("Lỗi không điền đầy đủ thông tin (Mã độc giả)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string ngaySinhs = ngaySinh.Value.ToString("yyyy-MM-dd");
            string ngayvl = ngayLamThe.Value.ToString("yyyy-MM-dd");
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO DocGia VALUES(@maDG, @tenDG, @ngaySinh,@GioiTinh, @Dchi,@NgayLamThe,@SoDT)";

                command.Parameters.AddWithValue("@maDG", maDocGia.Text);
                command.Parameters.AddWithValue("@tenDG", hoTen.Text);
                command.Parameters.AddWithValue("@ngaySinh", ngaySinhs);
                command.Parameters.AddWithValue("@GioiTinh", gioiTinh.Text);
                command.Parameters.AddWithValue("@Dchi", diaChi.Text);
                command.Parameters.AddWithValue("@NgayLamThe", ngayvl);
                command.Parameters.AddWithValue("@SoDT", sdt.Text);
                command.ExecuteNonQuery();


                MessageBox.Show("Đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadding();
                LoadData();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi mã độc giả đã tồn tại!!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                LoadData();
                connection.Close();
            }
        }
        public void loadding()
        {
            maDocGia.Enabled = true;
            maDocGia.Clear();
            hoTen.Clear();
            ngaySinh.Value = DateTime.Now;
            ngayLamThe.Value = DateTime.Now;
            gioiTinh.Text = null;
            diaChi.Clear();
            sdt.Clear();
        }

        private void UC_DocGia_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            LoadData();

            dgv_DocGia.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void dgv_docgia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            maDocGia.Enabled = false;
            int i;
            i = dgv_DocGia.CurrentRow.Index;
            maDocGia.Text = dgv_DocGia.Rows[i].Cells[0].Value.ToString();
            hoTen.Text = dgv_DocGia.Rows[i].Cells[1].Value.ToString();
            ngaySinh.Text = dgv_DocGia.Rows[i].Cells[2].Value.ToString();
            gioiTinh.Text = dgv_DocGia.Rows[i].Cells[3].Value.ToString();
            diaChi.Text = dgv_DocGia.Rows[i].Cells[4].Value.ToString();
            ngayLamThe.Text = dgv_DocGia.Rows[i].Cells[5].Value.ToString();
            sdt.Text = dgv_DocGia.Rows[i].Cells[6].Value.ToString();
        }

        private void bt_load_Click(object sender, EventArgs e)
        {
            loadding();
            LoadData();
        }

        private void bt_update_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "UPDATE DocGia SET  TenDocGia = @ten,NgaySinh = @ngaySinh, GioiTinh = @gt, DiaChi =  @dc, NgayLamThe =  @ngaylt, SoDT =  @sodt  WHERE MaDocGia = @madg";

            command.Parameters.AddWithValue("@ten", hoTen.Text);
            command.Parameters.AddWithValue("@ngaySinh", ngaySinh.Value.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@gt", gioiTinh.Text);
            command.Parameters.AddWithValue("@dc", diaChi.Text);
            command.Parameters.AddWithValue("@sodt", sdt.Text);
            command.Parameters.AddWithValue("@ngaylt", ngayLamThe.Value.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@madg", maDocGia.Text);
            command.ExecuteNonQuery();

            MessageBox.Show("Dữ liệu đã được sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadding();
           
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

                    string madg = maDocGia.Text; // Lấy mã sách từ TextBox maSach


                    command.CommandText = "DELETE FROM DocGia WHERE MaDocGia = @madg";
                    command.Parameters.AddWithValue("@madg", madg);

                    int rowsAffectedSach = command.ExecuteNonQuery();


                    // Kiểm tra số hàng bị ảnh hưởng bởi câu lệnh DELETE
                    if (rowsAffectedSach > 0)
                    {
                        transaction.Commit();
                        MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        loadding();
                        LoadData();
                    }
                    else
                    {
                        // Hành động xóa không thành công, rollback transaction
                        transaction.Rollback();
                        MessageBox.Show("Không thể xóa tác giả ( Vẫn tồn tại trong phiếu mượn hoặc trả ) .", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi và rollback transaction nếu có lỗi xảy ra
                    transaction.Rollback();
                    MessageBox.Show("Không thể xóa tác giả ( Vẫn tồn tại trong phiếu mượn hoặc trả ) .", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            LoadData();
        }
        

 
    }
}
