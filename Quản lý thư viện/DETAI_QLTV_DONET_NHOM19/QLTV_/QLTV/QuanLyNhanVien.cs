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
using System.IO;
using System.Drawing.Imaging;

namespace QLTV
{
    public partial class QuanLyNhanVien : Form
    {
        SqlConnection connection;
        string str = DataHolder.str;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        bool pictureBoxUpdated = true;
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
                command.CommandText = "SELECT * FROM QuanLy";
                adapter.SelectCommand = command;

                // Lưu chỉ mục của dòng hiện tại trước khi nạp dữ liệu mới
                int currentRowIndex = -1;
                if (dgv_NhanVien.CurrentRow != null)
                {
                    currentRowIndex = dgv_NhanVien.CurrentRow.Index;
                }

                table.Clear();
                adapter.Fill(table);
                dgv_NhanVien.DataSource = table;
                dgv_NhanVien.Columns[0].HeaderText = "Mã Quản Lý";
                dgv_NhanVien.Columns[1].HeaderText = "Tên Quản Lý";
                dgv_NhanVien.Columns[2].HeaderText = "Ngày Sinh";
                dgv_NhanVien.Columns[3].HeaderText = "Giới Tính";
                dgv_NhanVien.Columns[4].HeaderText = "Địa Chỉ";
                dgv_NhanVien.Columns[5].HeaderText = "Ngày Vào Làm";
                dgv_NhanVien.Columns[6].HeaderText = "Số Điện Thoại";
                dgv_NhanVien.Columns[7].HeaderText = "Ảnh Thẻ";
                dgv_NhanVien.Columns[8].HeaderText = "Vai Trò";
                dgv_NhanVien.Columns[9].HeaderText = "Mật Khẩu";
                dgv_NhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Thiết lập lại chỉ mục của dòng hiện tại sau khi nạp dữ liệu mới
                if (currentRowIndex >= 0 && currentRowIndex < dgv_NhanVien.Rows.Count)
                {
                    dgv_NhanVien.CurrentCell = dgv_NhanVien.Rows[currentRowIndex].Cells["MaQuanLy"];
                }

                // Gán DataSource cho DataGridView
                dgv_NhanVien.DataSource = table;

                // Đặt FillWeight của cột ảnh là 10 (hoặc số khác tùy ý)
            }
            else
            {
                MessageBox.Show("Lỗi kết nối CSDL.");
            }
        }
        public void LOADIMG(string maSach)
        {
            string imagePath = CHECK.linkIMG;

            // Tạo đường dẫn đầy đủ cho thư mục ảnh
            string imageDirectory = Path.Combine(Application.StartupPath, "..\\..\\image\\NHANVIEN\\");

            // Kiểm tra xem thư mục có tồn tại không, nếu không thì tạo mới
            if (!Directory.Exists(imageDirectory))
            {
                try
                {
                    Directory.CreateDirectory(imageDirectory);
                    Console.WriteLine("Thư mục đã được tạo: " + imageDirectory);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi tạo thư mục: " + ex.Message);
                    return;
                }
            }

            // Tạo tên tệp theo định dạng "SHxxx.jpg"
            string newImageName = maSach + ".jpg";
            string newImagePath = Path.Combine(imageDirectory, newImageName);

            try
            {
                // Kiểm tra xem tệp có tồn tại hay không
                if (File.Exists(newImagePath))
                {
                    // Nếu tồn tại, xóa tệp cũ
                    File.Delete(newImagePath);
                }

                // Sao chép ảnh đã chọn vào thư mục ảnh với tên mới
                File.Copy(imagePath, newImagePath);
                Console.WriteLine("Ảnh đã được sao chép thành công.");

            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi sao chép ảnh
                Console.WriteLine("Lỗi khi sao chép ảnh: " + ex.Message);
            }
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, ImageFormat.Jpeg); // Đây sẽ chuyển đổi hình ảnh thành định dạng JPEG
                return memoryStream.ToArray();
            }
        }
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            connection = new SqlConnection(str);
            connection.Open();
            LoadData();
            pictureBoxUpdated = true;
            dgv_NhanVien.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bt_quaylai_Click(object sender, EventArgs e)
        {
            this.Hide();
            GiaoDienAD gdad = new GiaoDienAD();
            gdad.Show();
            gdad = null;
            return;
        }

        private void bt_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Chọn ảnh";
            open.Filter = "Image Files(*.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png)|*.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png";

            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = open.FileName;
                CHECK.linkIMG = open.FileName;
                 pictureBoxUpdated = false;
            }
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();

            if (string.IsNullOrWhiteSpace(maQLy.Text))
            {
                MessageBox.Show("Lỗi không điền đầy đủ thông tin (Mã độc giả)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string ngaySinhs = ngaySinh.Value.ToString("yyyy-MM-dd");
            string ngayvl = ngayVL.Value.ToString("yyyy-MM-dd");
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO QuanLy VALUES(@maQL, @tenQL, @ngaySinh, @GioiTinh, @Dchi, @NgayVL, @SoDT, @Anh, @VaiTro, @matkhau)";

                command.Parameters.AddWithValue("@maQL", maQLy.Text);
                command.Parameters.AddWithValue("@tenQL", hoTen.Text);
                command.Parameters.AddWithValue("@ngaySinh", ngaySinhs);
                command.Parameters.AddWithValue("@GioiTinh", gioiTinh.Text);
                command.Parameters.AddWithValue("@Dchi", diaChi.Text);
                command.Parameters.AddWithValue("@NgayVL", ngayvl);
                command.Parameters.AddWithValue("@SoDT", sdt.Text);
                command.Parameters.AddWithValue("@VaiTro", vaitro.Text);
                command.Parameters.AddWithValue("@matkhau", password.Text);
                if (pictureBox1.Image != null)
                {
                    byte[] anh = ImageToByteArray(pictureBox1.Image);
                    command.Parameters.AddWithValue("@Anh", anh);
                }
                else
                {
                    MessageBox.Show("Chưa thêm hình ảnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }



                command.ExecuteNonQuery();
                LOADIMG(maQLy.Text);
                MessageBox.Show("Đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại"  , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                LoadData();
                connection.Close();
            }
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            if (pictureBoxUpdated == false)
            {
                connection = new SqlConnection(str);
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE QuanLy SET TenQuanLy = @ten, AnhThe = @anh,NgaySinh =  @ngaySinh, GioiTinh =  @gt, DiaChi =  @dc, NgayVL  = @ngayvl, SoDT =  @sdt, VaiTro =  @vaitro, MatKhau =  @matkhau WHERE MaQuanLy = @ma";
                string ngaySinhs = ngaySinh.Value.ToString("yyyy-MM-dd");
                string ngayvl = ngayVL.Value.ToString("yyyy-MM-dd");
                command.Parameters.AddWithValue("@ma", maQLy.Text);
                command.Parameters.AddWithValue("@ten", hoTen.Text);
                command.Parameters.AddWithValue("@ngaySinh", ngaySinhs);
                command.Parameters.AddWithValue("@gt", gioiTinh.Text);
                command.Parameters.AddWithValue("@dc", diaChi.Text);
                command.Parameters.AddWithValue("@ngayvl", ngayvl);
                command.Parameters.AddWithValue("@sdt", sdt.Text);
                command.Parameters.AddWithValue("@vaitro", vaitro.Text);
                command.Parameters.AddWithValue("@matkhau", password.Text);
                if (pictureBox1.Image != null)
                {
                    byte[] anh = ImageToByteArray(pictureBox1.Image);
                    command.Parameters.AddWithValue("@anh", anh);
                }
                else
                {
                    command.Parameters.AddWithValue("@anh", DBNull.Value);
                }
                command.ExecuteNonQuery();

                LOADIMG(maQLy.Text);
                MessageBox.Show("Dữ liệu đã được sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
                pictureBoxUpdated = true;
            }
            else
            {
                connection = new SqlConnection(str);
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE QuanLy SET TenQuanLy = @ten, NgaySinh =  @ngaySinh, GioiTinh =  @gt, DiaChi =  @dc, NgayVL  = @ngayvl, SoDT =  @sdt, VaiTro =  @vaitro, MatKhau =  @matkhau WHERE MaQuanLy = @ma";
                string ngaySinhs = ngaySinh.Value.ToString("yyyy-MM-dd");
                string ngayvl = ngayVL.Value.ToString("yyyy-MM-dd");
                command.Parameters.AddWithValue("@ma", maQLy.Text);
                command.Parameters.AddWithValue("@ten", hoTen.Text);
                command.Parameters.AddWithValue("@ngaySinh", ngaySinhs);
                command.Parameters.AddWithValue("@gt", gioiTinh.Text);
                command.Parameters.AddWithValue("@dc", diaChi.Text);
                command.Parameters.AddWithValue("@ngayvl", ngayvl);
                command.Parameters.AddWithValue("@sdt", sdt.Text);
                command.Parameters.AddWithValue("@vaitro", vaitro.Text);
                command.Parameters.AddWithValue("@matkhau", password.Text);
               
                command.ExecuteNonQuery();

              
                MessageBox.Show("Dữ liệu đã được sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
            }
            
        }

        private void bt_xoa_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    var command = connection.CreateCommand();
                    command.Transaction = transaction;

                    string maQL = maQLy.Text; // Lấy mã sách từ TextBox maSach
                    command.CommandText = "DELETE FROM QuanLy WHERE MaQuanLy = @ma";
                    command.Parameters.AddWithValue("@ma", maQL);

                    int rowsAffectedSach = command.ExecuteNonQuery();

                    // Kiểm tra số hàng bị ảnh hưởng bởi câu lệnh DELETE
                    if (rowsAffectedSach > 0)
                    {
                        // Xóa hình ảnh liên quan
                        string imageDirectory = Path.Combine(Application.StartupPath, "..\\..\\image\\NHANVIEN\\");
                        string imageFileName = maQL + ".jpg";
                        string imagePath = Path.Combine(imageDirectory, imageFileName);

                        if (File.Exists(imagePath))
                        {
                            File.Delete(imagePath);
                        }

                        // Commit transaction nếu xóa thành công
                        transaction.Commit();

                        MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        load();
                        //loading();

                    }
                    else
                    {
                        // Hành động xóa không thành công, rollback transaction
                        transaction.Rollback();
                        MessageBox.Show("Không thể xóa dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi và rollback transaction nếu có lỗi xảy ra
                    transaction.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            LoadData();
        }

        private void dgv_NV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_NhanVien.CurrentRow.Index;
            maQLy.Text = dgv_NhanVien.Rows[i].Cells[0].Value.ToString();
            hoTen.Text = dgv_NhanVien.Rows[i].Cells[1].Value.ToString();
            ngaySinh.Text = dgv_NhanVien.Rows[i].Cells[2].Value.ToString();
            gioiTinh.Text = dgv_NhanVien.Rows[i].Cells[3].Value.ToString();
            diaChi.Text = dgv_NhanVien.Rows[i].Cells[4].Value.ToString();
            ngayVL.Text = dgv_NhanVien.Rows[i].Cells[5].Value.ToString();
            sdt.Text = dgv_NhanVien.Rows[i].Cells[6].Value.ToString();
            vaitro.Text = dgv_NhanVien.Rows[i].Cells[8].Value.ToString();
            password.Text = dgv_NhanVien.Rows[i].Cells[9].Value.ToString();
            object cellValue = dgv_NhanVien.Rows[i].Cells[7].Value;
            if (cellValue != null && cellValue != DBNull.Value)
            {
                if (cellValue is byte[])
                {
                    byte[] imageBytes = (byte[])cellValue;
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                else if (cellValue is Image)
                {
                    pictureBox1.Image = (Image)cellValue;
                }
                else if (cellValue is string)
                {
                    // If the image is stored as a string (file path), you can load it
                    string imagePath = (string)cellValue;
                    pictureBox1.Image = Image.FromFile(imagePath);
                }


            }
            else
            {
                pictureBox1.Image = null;
            }
        }
        private Size CalculateNewSize(Image originalImage, int maxWidth, int maxHeight)
        {
            int newWidth, newHeight;
            double aspectRatio = (double)originalImage.Width / originalImage.Height;

            if (originalImage.Width > originalImage.Height)
            {
                newWidth = maxWidth;
                newHeight = (int)(maxWidth / aspectRatio);
            }
            else
            {
                newHeight = maxHeight;
                newWidth = (int)(maxHeight * aspectRatio);
            }

            return new Size(newWidth, newHeight);
        }

        private void dgv_NV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_NhanVien.Columns["AnhThe"].Index)
            {
                DataGridViewImageCell cell = dgv_NhanVien.Rows[e.RowIndex].Cells["AnhThe"] as DataGridViewImageCell;

                if (cell != null && cell.Value != null && cell.Value is byte[])
                {
                    using (MemoryStream ms = new MemoryStream((byte[])cell.Value))
                    {
                        Image originalImage = Image.FromStream(ms);
                        int maxWidth = cell.Size.Width - cell.InheritedStyle.Padding.Horizontal;
                        int maxHeight = cell.Size.Height - cell.InheritedStyle.Padding.Vertical;

                        // Calculate the new size while preserving the aspect ratio
                        Size newSize = CalculateNewSize(originalImage, maxWidth, maxHeight);

                        // Create a new image with the calculated size
                        Image resizedImage = new Bitmap(newSize.Width, newSize.Height);
                        using (Graphics graphics = Graphics.FromImage(resizedImage))
                        {
                            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            graphics.DrawImage(originalImage, new Rectangle(0, 0, newSize.Width, newSize.Height));
                        }

                        // Set the cell value to the resized image
                        e.Value = resizedImage;
                    }
                }


            }

            dgv_NhanVien.RowTemplate.Height = 150;
        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bt_load_Click(object sender, EventArgs e)
        {
            load();
        }
        void load()
        {
            maQLy.Clear();
            hoTen.Clear();
            gioiTinh.Text = null;
            diaChi.Clear();
            sdt.Clear();
            password.Clear();
            ngaySinh.Value = DateTime.Now;
            ngayVL.Value = DateTime.Now;
            vaitro.Text = null;
            pictureBox1.Image = null;
        }
    }
}
