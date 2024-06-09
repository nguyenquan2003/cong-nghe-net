using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;


namespace QLTV
{
    public partial class SACH : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = DataHolder.str;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        private bool processing = false;
        bool pictureBoxUpdated = true;
        public event EventHandler Cloed;
        public SACH()
        {
            InitializeComponent();
        }
        
        public void LoadData()
        {
            processing = false;
            if (connection != null && connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(str);
                connection.Open();
            }
            if (connection != null && connection.State == ConnectionState.Open)
            {
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Sach";
                adapter.SelectCommand = command;
                if (table != null)
                {
                    table.Clear();
                    adapter.Fill(table);
                    dgv_Sach.DataSource = table;
                    dgv_Sach.Columns[0].HeaderText = "Mã Sách";
                    dgv_Sach.Columns[1].HeaderText = "Tên Sách";
                    dgv_Sach.Columns[2].HeaderText = "Ảnh Bìa";
                    dgv_Sach.Columns[3].HeaderText = "Nhà Xuất Bản";
                    dgv_Sach.Columns[4].HeaderText = "Mô Tả";
                    dgv_Sach.Columns[5].HeaderText = "Số Lượng";
                    dgv_Sach.Columns[6].HeaderText = "Mã Thể Loại";
                    dgv_Sach.Columns[7].HeaderText = "Mã Tác Giả";
                    dgv_Sach.Columns[8].HeaderText = "Năm Xuất Bản";
                    dgv_Sach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    MessageBox.Show("Lỗi kết nối CSDL.");
                }
            }


        }
        private void SACH_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            LoadData();

            dgv_Sach.EditMode = DataGridViewEditMode.EditOnEnter;
            LoadTheLoaiList(maTL);
            LoadTacGiaList(MaTG);
            loadx();
            LoadData();
        }
        private void bt_mo_Click(object sender, EventArgs e)
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
        public void LoadTheLoaiList(ComboBox comboBox)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT MaTheLoai FROM TheLoai", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string maTheLoai = reader["MaTheLoai"].ToString();


                            // Add the item to the ComboBox
                            comboBox.Items.Add(maTheLoai);
                        }
                    }
                }
            }
        }
        public void LoadTacGiaList(ComboBox comboBox)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT MaTacGia FROM TacGia", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string maTG = reader["MaTacGia"].ToString();


                            // Add the item to the ComboBox
                            comboBox.Items.Add(maTG);
                        }
                    }
                }
            }
        }
        private void add_Click(object sender, EventArgs e)
        {
            string maS = maSach.Text;
            string ten = tenSach.Text;
            string nhaxb = nhaXB.Text;
            string moT = moTa.Text;
            string sl = Sl.Text;
            string maTheLoai = maTL.Text;
            string maTg = MaTG.Text;
            string nam = namXB.Text;

            connection = new SqlConnection(str);
            connection.Open();

            try
            {

                if (string.IsNullOrWhiteSpace(maSach.Text))
                {
                    MessageBox.Show("Lỗi không điền đầy đủ thông tin (MÃ SÁCH)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Sach VALUES(@maSach, @tenSach, @AnhBia, @NhaXB, @mota, @sl, @maTheLoai, @maTG,@nam)";

                command.Parameters.AddWithValue("@maSach", maS);
                command.Parameters.AddWithValue("@tenSach", ten);
                command.Parameters.AddWithValue("@NhaXB", nhaxb);
                command.Parameters.AddWithValue("@mota", moT);
                command.Parameters.AddWithValue("@sl", sl);
                command.Parameters.AddWithValue("@maTheLoai", maTheLoai);
                command.Parameters.AddWithValue("@maTG", maTg);
                command.Parameters.AddWithValue("@nam", nam);
                if (pictureBox1.Image != null)
                {
                    byte[] anh = ImageToByteArray(pictureBox1.Image);
                    command.Parameters.AddWithValue("@AnhBia", anh);

                }
                else
                {
                    MessageBox.Show("Chưa thêm hình ảnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }



                command.ExecuteNonQuery();

                LOADIMG(maSach.Text);
                MessageBox.Show("Đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loading();
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Mã Sách đã tồn tại!!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                LoadData();
                connection.Close();
            }
        }
        private void bt_save_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            if (pictureBoxUpdated == false)
            {
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE SACH SET TenSach = @ten, AnhBia = @anh, NhaXB = @nhaxb, MoTa = @mota, SoLuong = @sl, MaTheLoai = @matl, MaTacGia = @matg, NamXuatBan = @nam WHERE MaSach = @maS";

                command.Parameters.AddWithValue("@ten", tenSach.Text);
                command.Parameters.AddWithValue("@nhaxb", nhaXB.Text);
                command.Parameters.AddWithValue("@mota", moTa.Text);
                command.Parameters.AddWithValue("@sl", Sl.Text);
                command.Parameters.AddWithValue("@matl", maTL.Text);
                command.Parameters.AddWithValue("@matg", MaTG.Text);
                command.Parameters.AddWithValue("@maS", maSach.Text);
                command.Parameters.AddWithValue("@nam", namXB.Text);
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
                processing = true;

                LOADIMG(maSach.Text);


                MessageBox.Show("Dữ liệu đã được sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                loading();
                LoadData();
                pictureBoxUpdated = true;
            }
            else
            {
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE SACH SET TenSach = @ten, NhaXB = @nhaxb, MoTa = @mota, SoLuong = @sl, MaTheLoai = @matl, MaTacGia = @matg, NamXuatBan = @nam WHERE MaSach = @maS";

                command.Parameters.AddWithValue("@ten", tenSach.Text);
                command.Parameters.AddWithValue("@nhaxb", nhaXB.Text);
                command.Parameters.AddWithValue("@mota", moTa.Text);
                command.Parameters.AddWithValue("@sl", Sl.Text);
                command.Parameters.AddWithValue("@matl", maTL.Text);
                command.Parameters.AddWithValue("@matg", MaTG.Text);
                command.Parameters.AddWithValue("@maS", maSach.Text);
                command.Parameters.AddWithValue("@nam", namXB.Text);

                command.ExecuteNonQuery();
                processing = true;




                MessageBox.Show("Dữ liệu đã được sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();

            }
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

                    string maS = maSach.Text; // Lấy mã sách từ TextBox maSach
                    command.CommandText = "DELETE FROM Sach WHERE MaSach = @maS";
                    command.Parameters.AddWithValue("@maS", maS);

                    int rowsAffectedSach = command.ExecuteNonQuery();

                    // Kiểm tra số hàng bị ảnh hưởng bởi câu lệnh DELETE
                    if (rowsAffectedSach > 0)
                    {
                        // Xóa hình ảnh liên quan
                        string imageDirectory = Path.Combine(Application.StartupPath, "..\\..\\image\\SACH");
                        string imageFileName = maS + ".jpg";
                        string imagePath = Path.Combine(imageDirectory, imageFileName);

                        if (File.Exists(imagePath))
                        {
                            processing = true;
                            File.Delete(imagePath);
                        }

                        // Commit transaction nếu xóa thành công
                        transaction.Commit();

                        MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        loading();

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
                    MessageBox.Show("Lỗi: SACH vẫn tồn tại ở phiếu mượn!!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }


            LoadData();
        }
        private void loadx()
        {

            if (dgv_Sach != null)
            {
                foreach (DataGridViewRow row in dgv_Sach.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        string cellValue = row.Cells[0].Value.ToString();
                        UpdateAnh(cellValue);
                    }
                }
            }


        }
        public void loading()
        {
            maSach.Clear();
            tenSach.Clear();
            namXB.Clear();
            nhaXB.Clear();
            moTa.Clear();
            Sl.Clear();
            maTL.Text = null;
            MaTG.Text = null;
            pictureBox1.Image = null;
        }
        private void load_Click(object sender, EventArgs e)
        {
            LoadData();
            loading();
        }
        private void dgv_Sach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_Sach.CurrentRow.Index;
            maSach.Text = dgv_Sach.Rows[i].Cells[0].Value.ToString();
            tenSach.Text = dgv_Sach.Rows[i].Cells[1].Value.ToString();
            nhaXB.Text = dgv_Sach.Rows[i].Cells[3].Value.ToString();
            moTa.Text = dgv_Sach.Rows[i].Cells[4].Value.ToString();
            Sl.Text = dgv_Sach.Rows[i].Cells[5].Value.ToString();
            maTL.Text = dgv_Sach.Rows[i].Cells[6].Value.ToString();
            MaTG.Text = dgv_Sach.Rows[i].Cells[7].Value.ToString();
            namXB.Text = dgv_Sach.Rows[i].Cells[8].Value.ToString();
            object cellValue = dgv_Sach.Rows[i].Cells[2].Value;

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
        private void dgv_Sach_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_Sach.Columns["AnhBia"].Index)
            {
                DataGridViewImageCell cell = dgv_Sach.Rows[e.RowIndex].Cells["AnhBia"] as DataGridViewImageCell;

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

            dgv_Sach.RowTemplate.Height = 150;
        }
        public void LOADIMG(string maSach)
        {
            processing = true;
            string imagePath = CHECK.linkIMG;

            // Tạo đường dẫn đầy đủ cho thư mục ảnh
            string imageDirectory = Path.Combine(Application.StartupPath, "..\\..\\image\\SACH");

            // Kiểm tra xem thư mục có tồn tại không, nếu không thì tạo mới
            if (!Directory.Exists(imageDirectory))
            {
                Directory.CreateDirectory(imageDirectory);
            }

            // Tạo tên tệp theo định dạng "SHxxx.jpg"
            string newImageName = maSach + ".jpg";
            string newImagePath = Path.Combine(imageDirectory, newImageName);

            try
            {
                // Kiểm tra xem tệp có tồn tại hay không
                if (File.Exists(newImagePath))
                {
                    processing = true;

                    // Nếu tồn tại, xóa tệp cũ
                    File.Delete(newImagePath);
                }

                // Sao chép ảnh đã chọn vào thư mục ảnh với tên mới
                File.Copy(imagePath, newImagePath);

                processing = false;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi sao chép ảnh
                Console.WriteLine("Lỗi khi sao chép ảnh: " + ex.Message);
                processing = false;
            }
        }
        private void UpdateImage(string maSach, byte[] anh)
        {

            if (string.IsNullOrEmpty(maSach) || anh == null)
            {
                MessageBox.Show("Mã sách hoặc hình ảnh không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (connection = new SqlConnection(str))
            {
                connection.Open();

                try
                {
                    var command = connection.CreateCommand();
                    command.CommandText = "UPDATE Sach SET AnhBia = @anh WHERE MaSach = @maS";

                    command.Parameters.AddWithValue("@maS", maSach);
                    command.Parameters.AddWithValue("@anh", anh);

                    command.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        public void Load_ma_TL_TG()
        {
            connection = new SqlConnection(str);
            connection.Open();


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
        private void UpdateAnh(string maSach)
        {
            string imageName = maSach + ".jpg"; // Tạo tên tệp ảnh dựa trên MaSach


            string imagePath = Path.Combine(Application.StartupPath, "..\\..\\image\\SACH", imageName);

            if (File.Exists(imagePath))
            {
                try
                {
                    Image image = Image.FromFile(imagePath);
                    byte[] anh = ImageToByteArray(image);


                    UpdateImage(maSach, anh);


                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi tải hình ảnh: " + ex.Message);
                }
            }
            else
            {

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

        private void bt_update_Click(object sender, EventArgs e)
        {

        }

        public UC_QLSach myUserControl1;
        
        private void SACH_FormClosing(object sender, FormClosingEventArgs e)
        {

            // Ẩn tất cả các UserControl trong Panel
            this.Hide();

            // Truy cập đến Form cha (GiaoDienAD)
            Form parentForm = this.Owner; // Sử dụng Owner để truy cập đến form cha

            // Lấy thể hiện của Form GiaoDienAD
            GiaoDienAD gdad = parentForm as GiaoDienAD;

            // Kiểm tra xem parentForm có phải là Form GiaoDienAD hay không
            if (gdad != null)
            {
                // Hiển thị UserControl UC_QLSach
                UC_QLSach myUserControl1 = new UC_QLSach();
                myUserControl1.Dock = DockStyle.Fill;

                // Xóa các UserControl hiện tại (nếu có)
                gdad.Controls.Clear();

                // Thêm UC_QLSach vào Form GiaoDienAD
                gdad.Controls.Add(myUserControl1);
                myUserControl1.Visible = true;
            }

        }
        

        private void bt_quaylai_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (Cloed != null)
            {
                Cloed(this, EventArgs.Empty);
            }  
            
        }



    }
    public static class CHECK
    {
        public static string linkIMG { get; set; }
        public static PictureBox A { get; set; }
    }

}
