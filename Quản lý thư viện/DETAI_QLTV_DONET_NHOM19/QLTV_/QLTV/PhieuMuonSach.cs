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
using System.Globalization;

namespace QLTV
{
    public partial class PhieuMuonSach : Form
    {
        SqlConnection connection;
        string str = DataHolder.str;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public event EventHandler Cloed;

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
                command.CommandText = "SELECT * FROM PhieuMuon";
                adapter.SelectCommand = command;

                // Lưu chỉ mục của dòng hiện tại trước khi nạp dữ liệu mới
                int currentRowIndex = -1;
                if (dgv_PhieuMuon.CurrentRow != null)
                {
                    currentRowIndex = dgv_PhieuMuon.CurrentRow.Index;
                }

                table.Clear();
                adapter.Fill(table);
                dgv_PhieuMuon.DataSource = table;
                dgv_PhieuMuon.Columns[0].HeaderText = "Mã Phiếu Mượn";
                dgv_PhieuMuon.Columns[1].HeaderText = "Mã Độc Giả";
                dgv_PhieuMuon.Columns[2].HeaderText = "Mã Sách";
                dgv_PhieuMuon.Columns[3].HeaderText = "Mã Quản Lý";
                dgv_PhieuMuon.Columns[4].HeaderText = "Tên Sách";
                dgv_PhieuMuon.Columns[5].HeaderText = "Tên Độc Giả";
                dgv_PhieuMuon.Columns[6].HeaderText = "Số Lượng Mượn";
                dgv_PhieuMuon.Columns[7].HeaderText = "Ngày Mượn";
                dgv_PhieuMuon.Columns[8].HeaderText = "Hẹn Trả";
                dgv_PhieuMuon.Columns[9].HeaderText = "Tình Trạng";
                dgv_PhieuMuon.Columns[10].HeaderText = "Tên Nhân Viên";
                dgv_PhieuMuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                // Thiết lập lại chỉ mục của dòng hiện tại sau khi nạp dữ liệu mới
                if (currentRowIndex >= 0 && currentRowIndex < dgv_PhieuMuon.Rows.Count)
                {
                    dgv_PhieuMuon.CurrentCell = dgv_PhieuMuon.Rows[currentRowIndex].Cells["MaPhieuMuon"];
                }

                // Gán DataSource cho DataGridView
                dgv_PhieuMuon.DataSource = table;

                // Đặt FillWeight của cột ảnh là 10 (hoặc số khác tùy ý)
            }
            else
            {
                MessageBox.Show("Lỗi kết nối CSDL.");
            }
        }


        public PhieuMuonSach()
        {
            InitializeComponent();
            this.Closed += MainForm_Closed;
        }
        private void MainForm_Closed(object sender, EventArgs e)
        {
            LOADDSQUAHANCAPNHAT();
        }

        public void capNhatTinhTrang(string maPMuon)
        {

            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Update PhieuMuon set TinhTrang = @note where MaPhieuMuon =  @ma", connection))
                {
                    command.Parameters.AddWithValue("@ma", maPMuon);
                    command.Parameters.AddWithValue("@note", "Quá hạn");
                    int check = command.ExecuteNonQuery();
                    if (check > 0)
                    {
                        return;
                    }
                    else
                    {
                        MessageBox.Show("LỖI");
                    }
                }
            }
        }
        public bool kiemTraQuaHan(string henTra)
        {
            DateTime henTraDate;
            DateTime currentDate = DateTime.Now.Date;
            DateTime dateFromStr = DateTime.Parse(henTra);




            if (dateFromStr < currentDate)
            {
               
             
                return true;
            }
            else
            {
                return false;
            }

           
        }
        public void LOADDSQUAHANCAPNHAT()
        {
            connection = new SqlConnection(str);
            connection.Open();
            foreach (DataGridViewRow row in dgv_PhieuMuon.Rows)
            {

                if (row.Cells[0].Value != null)
                {

                    string maPhieuMuon = row.Cells[0].Value.ToString();

                    string tinhTrang = row.Cells[9].Value.ToString();
                    string henTra = row.Cells[8].Value.ToString();
                    
                   
                   


                    if (string.Compare(tinhTrang, "Chưa trả") == 0)
                    {

                        if (kiemTraQuaHan(henTra) == true)
                        {

                            capNhatTinhTrang(maPhieuMuon);
                            themDSQH(maPhieuMuon);
                        }

                    }
                    else if ((string.Compare(tinhTrang, "Quá hạn") == 0))
                    {
                       
                        capNhatSoNgayTre(henTra, maPhieuMuon);
                        
                    }


                }
                else
                {
                    return;
                }

            }
        }
        public void themDSQH(string maPM)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO DSQuaHan VALUES(@maPM,@songay,@GhiChu)", connection))
                {
                    command.Parameters.AddWithValue("@maPM", maPM);
                    command.Parameters.AddWithValue("@songay", 0);
                    command.Parameters.AddWithValue("@GhiChu", "Chưa xử lí");
                    int check = command.ExecuteNonQuery();
                    if (check > 0)
                    {
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Lỗi");
                    }
                }
            }
        }
        public void capNhatSoNgayTre(string henTra, string maPMuon)
        {
           
           
            DateTime currentDate = DateTime.Now.Date;
            DateTime dateFromStr = DateTime.Parse(henTra);
            int soNgay = (currentDate - dateFromStr).Days;
          
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Update DSQuaHan set SoNgayTre = @day where MaPhieuMuon =  @ma", connection))
                {
                    command.Parameters.AddWithValue("@ma", maPMuon);
                    command.Parameters.AddWithValue("@day", soNgay.ToString());
                    int check = command.ExecuteNonQuery();
                    if (check > 0)
                    {
                        return;
                    }
                    else
                    {
                        MessageBox.Show("LỖI");
                    }
                }
            }
        }

        public void LOAD_TEN_SACH()
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT TenSach FROM Sach", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string TenS = reader["TenSach"].ToString();


                            // Add the item to the ComboBox
                            TenSach.Items.Add(TenS);

                        }
                    }
                }
            }
        }
        public void LOAD_MA_SACH()
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT MaSach FROM Sach", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string maS = reader["MaSach"].ToString();


                            // Add the item to the ComboBox
                            MaSach.Items.Add(maS);
                            maSachMuon.Items.Add(maS);
                        }
                    }
                }
            }
        }
        public void LOAD_MADG()
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT MaDocGia FROM DocGia", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string maDGia = reader["MaDocGia"].ToString();


                            // Add the item to the ComboBox
                            maDG.Items.Add(maDGia);
                        }
                    }
                }
            }
        }
        public void loadding()
        {
            LOAD_MA_SACH();
            if (LOGIN.checkADMIN == false)
            {
                loadTenQL();
            }
            LOAD_MADG();
            LOAD_TEN_SACH();

            LoadData();
            
        }

        private void PhieuMuonSach_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            DATAOFSAKER.data_maQL = LOGIN.check;
            tinhTrang.Text = "Chưa trả";
            TenNV.Text = "ADMIN";
            loadding();
            LOADDSQUAHANCAPNHAT();
            dgv_PhieuMuon.EditMode = DataGridViewEditMode.EditOnEnter;
        }
        public void loadTenQL()
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT TenQuanLy FROM QuanLy Where MaQuanLy =  @ma", connection))
                {
                    command.Parameters.AddWithValue("@ma", DATAOFSAKER.data_maQL);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string ten = reader["TenQuanLy"].ToString();


                            // Add the item to the ComboBox
                            TenNV.Text = ten;
                            TenNV.Enabled = false;
                        }
                    }
                }
            }
        }
        public string loadTenTG(string maTG)
        {
            string tenTG = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT TenTacGia FROM TacGia WHERE MaTacGia = @maTG", connection))
                    {
                        command.Parameters.AddWithValue("@maTG", maTG);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                tenTG = reader["TenTacGia"].ToString();
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                // Ví dụ: Log lỗi, hiển thị thông báo cho người dùng, hoặc thực hiện hành động khác.
                // Ở đây tôi chỉ in lỗi ra màn hình để gỡ lỗi.
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            return tenTG;
        }
        public string loadTenSach(string maSach)
        {
            string tenSach = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT TenSach FROM Sach WHERE MaSach = @maSach", connection))
                    {
                        command.Parameters.AddWithValue("@maSach", maSach);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                tenSach = reader["TenSach"].ToString();
                                return tenSach;
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                // Ví dụ: Log lỗi, hiển thị thông báo cho người dùng, hoặc thực hiện hành động khác.
                // Ở đây tôi chỉ in lỗi ra màn hình để gỡ lỗi.
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            return tenSach;
        }
        public void LOADFORMSACH_(string TenSach)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT MaSach, SoLuong, MaTacGia FROM Sach WHERE TenSach = @TenSach", connection))
                {
                    command.Parameters.AddWithValue("@TenSach", TenSach);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            SL.Text = reader["SoLuong"].ToString();
                            MaSach.Text = reader["MaSach"].ToString();
                            string maTG = reader["MaTacGia"].ToString();
                            tenTGia.Text = loadTenTG(maTG);
                        }
                    }
                }
            }
        }

        public void LOADFORMSACH(string maSach)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT TenSach, SoLuong, MaTacGia FROM Sach WHERE MaSach = @maSach", connection))
                {
                    command.Parameters.AddWithValue("@maSach", maSach);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            SL.Text = reader["SoLuong"].ToString();
                            TenSach.Text = reader["TenSach"].ToString();
                            string maTG = reader["MaTacGia"].ToString();
                            tenTGia.Text = loadTenTG(maTG);
                        }
                    }
                }
            }
        }
        public void LOADTENDG(string maDG)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT TenDocGia FROM DocGia WHERE MaDocGia = @maDG", connection))
                {
                    command.Parameters.AddWithValue("@maDG", maDG);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TenDG.Text = reader["TenDocGia"].ToString();

                        }
                    }
                }
            }
        }


        private void MaSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            LOADFORMSACH(MaSach.Text);
            LoadData();
        }

        private void maDG_SelectedIndexChanged(object sender, EventArgs e)
        {
            LOADTENDG(maDG.Text);
            LoadData();

        }

        private void TenSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            LOADFORMSACH_(TenSach.Text);
            LoadData();
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
        public void loadtting()
        {
            timkiem.Clear();
            check1.Checked = false;
            check2.Checked = false;
            tenTGia.Clear();
            SL.Clear();
            TenSach.Text = null;
            MaSach.Text = null;
            maPM.Enabled = true;
            maPM.Clear();
            maDG.Text = null;
            maSachMuon.Text = null;
           
            TenDG.Clear();

            slMuon.Clear();
            dateM.Value = DateTime.Now;
            date_hen_tra.Value = DateTime.Now;

            tinhTrang.Text = "Chưa trả";
        }
   

        private void bt_muon_Click(object sender, EventArgs e)
        {
          
            connection = new SqlConnection(str);
            connection.Open();
            int slMUON;
            int.TryParse(slMuon.Text, out  slMUON);
            int slCo;
            int.TryParse(checkSL(maSachMuon.Text), out slCo);
            if (string.IsNullOrWhiteSpace(maPM.Text))
            {
                MessageBox.Show("Lỗi không điền đầy đủ thông tin (Mã Phiếu Mượn)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (slMUON > slCo)
            {
                MessageBox.Show("Trong thư viện không còn đủ sách hãy điều chỉnh số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (slMUON <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(date_hen_tra.Value < DateTime.Now)
            {
                MessageBox.Show("Ngày hẹn trả không hợp lệ !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string ngayM = dateM.Value.ToString("yyyy-MM-dd");
            string ngayT = date_hen_tra.Value.ToString("yyyy-MM-dd");
            try
            {
                string tens = loadTenSach(maSachMuon.Text);
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO PhieuMuon VALUES(@maPM,@maDG,@maS,@maQL,@TenSach,@tenDG,@sl,@ngayMuon,@henTra,@tinhTrang,@tenNV)";

                command.Parameters.AddWithValue("@maPM", maPM.Text);
                command.Parameters.AddWithValue("@maDG", maDG.Text);
                command.Parameters.AddWithValue("@maS", maSachMuon.Text);
                command.Parameters.AddWithValue("@TenSach", tens);
                command.Parameters.AddWithValue("@maQL", DATAOFSAKER.data_maQL);
                command.Parameters.AddWithValue("@tenDG", TenDG.Text);
                command.Parameters.AddWithValue("@sl", slMuon.Text);
                command.Parameters.AddWithValue("@ngayMuon", ngayM);
                command.Parameters.AddWithValue("@henTra", ngayT);
                command.Parameters.AddWithValue("@tinhTrang", tinhTrang.Text);
                command.Parameters.AddWithValue("@tenNV", TenNV.Text);
                command.ExecuteNonQuery();

                string sl_check = (slCo - slMUON).ToString();
                updateSL_SACH(sl_check, maSachMuon.Text);
                MessageBox.Show("Đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadtting();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi trùng Ma Phiếu Mượn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                LoadData();
                connection.Close();
            }
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();

            string check = checkSL_PM(maPM.Text);
            string checkMaS = check_MaS_PM(maPM.Text);
            string checkSLSACH = checkSL(checkMaS);
            int cong1;
            int.TryParse(check, out  cong1);
            int cong2;
            int.TryParse(checkSLSACH, out cong2);
            string check3 = (cong1 + cong2).ToString();


            int slMUON;
            int.TryParse(slMuon.Text, out  slMUON);

            if (string.Compare(maSachMuon.Text, checkMaS) == 0)
            {

                int check4;
                int.TryParse(check3, out check4);
                if (slMUON > check4)
                {

                    MessageBox.Show("Trong thư viện không còn đủ sách hãy điều chỉnh số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            updateSL_SACH(check3, checkMaS);
            int slCo;
            int.TryParse(checkSL(maSachMuon.Text), out slCo);

            if (slMUON > slCo)
            {
                MessageBox.Show("Trong thư viện không còn đủ sách hãy điều chỉnh số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (slMUON <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            loadding();
            string ngayM = dateM.Value.ToString("yyyy-MM-dd");
            string ngayT = date_hen_tra.Value.ToString("yyyy-MM-dd");
            string tens = loadTenSach(maSachMuon.Text);
            var command = connection.CreateCommand();
            command.CommandText = "UPDATE PhieuMuon SET MaSach = @maS, MaDocGia = @maDG , MaQuanLy = @maQL, TenSach = @TenSach, TenDocGia =  @tenDG, SoLuongMuon = @sl, NgayMuon = @ngayMuon, HenTra = @henTra, TinhTrang = @tinhTrang, TenNhanVien = @tenNV Where MaPhieuMuon = @maPM ";
            command.Parameters.AddWithValue("@maPM", maPM.Text);
            command.Parameters.AddWithValue("@maDG", maDG.Text);
            command.Parameters.AddWithValue("@maS", maSachMuon.Text);
            command.Parameters.AddWithValue("@TenSach", tens);
            command.Parameters.AddWithValue("@maQL", DATAOFSAKER.data_maQL);
            command.Parameters.AddWithValue("@tenDG", TenDG.Text);
            command.Parameters.AddWithValue("@sl", slMuon.Text);
            command.Parameters.AddWithValue("@ngayMuon", ngayM);
            command.Parameters.AddWithValue("@henTra", ngayT);
            command.Parameters.AddWithValue("@tinhTrang", tinhTrang.Text);
            command.Parameters.AddWithValue("@tenNV", TenNV.Text);
            command.ExecuteNonQuery();


            string sl_check = (slCo - slMUON).ToString();
            updateSL_SACH(sl_check, maSachMuon.Text);


            MessageBox.Show("Dữ liệu đã được sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData();
        }

        private void dgv_phieumuon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            maPM.Enabled = false;
            int i;

            i = dgv_PhieuMuon.CurrentRow.Index;
            maPM.Text = dgv_PhieuMuon.Rows[i].Cells[0].Value.ToString();
            maDG.Text = dgv_PhieuMuon.Rows[i].Cells[1].Value.ToString();
            maSachMuon.Text = dgv_PhieuMuon.Rows[i].Cells[2].Value.ToString();

            TenDG.Text = dgv_PhieuMuon.Rows[i].Cells[5].Value.ToString();
            slMuon.Text = dgv_PhieuMuon.Rows[i].Cells[6].Value.ToString();
            dateM.Text = dgv_PhieuMuon.Rows[i].Cells[7].Value.ToString();
            date_hen_tra.Text = dgv_PhieuMuon.Rows[i].Cells[8].Value.ToString();
            tinhTrang.Text = dgv_PhieuMuon.Rows[i].Cells[9].Value.ToString();
            TenNV.Text = dgv_PhieuMuon.Rows[i].Cells[10].Value.ToString();
        }

        private void bt_xoa_Click(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(str))
            {
                connection.Open();

                string maPm = maPM.Text;
                string maSachh = check_MaS_PM(maPm);
                string slmuon = checkSL_PM(maPm);
                int check, check1;
                if (!int.TryParse(slmuon, out  check) || !int.TryParse(checkSL(maSachh), out  check1))
                {
                    MessageBox.Show("Lỗi: Số lượng không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string check3 = (check1 + check).ToString();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.Transaction = transaction;
                            command.CommandText = "DELETE FROM PhieuMuon WHERE MaPhieuMuon = @ma";
                            command.Parameters.AddWithValue("@ma", maPm);

                            int rowsAffectedSach = command.ExecuteNonQuery();

                            if (rowsAffectedSach > 0)
                            {
                                updateSL_SACH(check3, maSachh);

                                transaction.Commit();

                                MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            else
                            {
                                transaction.Rollback();
                                MessageBox.Show("Không thể xóa dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            LoadData();
        }
        private void bt_quaylai_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (Cloed != null)
            {
                Cloed(this, EventArgs.Empty);
            }
            else if(GiaoDienNV.QuayLaiForm1)
            {
                this.Close();
            }
        }

        private void bt_load_Click(object sender, EventArgs e)
        {
            loadtting();
           
        }

        private void MaSach_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LOADFORMSACH(MaSach.Text);
            LoadData();
        }

        private void maDG_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LOADTENDG(maDG.Text);
            LoadData();
        }

        private void TenSach_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LOADFORMSACH_(TenSach.Text);
            LoadData();
        }

        private void PhieuMuonSach_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GiaoDienNV.QuayLaiForm1)
            {
                GiaoDienNV form1 = new GiaoDienNV();
                form1.Show();
            }
        }

        private void timkiem_TextChanged(object sender, EventArgs e)
        {

            if (check1.Checked)
            {
                string maDocGia = timkiem.Text;

                // Kết nối đến cơ sở dữ liệu
                using (var connection = new SqlConnection(str))
                {
                    connection.Open();

                    // Tạo và cấu hình SqlCommand
                    using (SqlCommand command = new SqlCommand("SearchPhieuMuonByMaDocGia", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaDocGia", maDocGia);

                        // Tạo SqlDataAdapter để lấy dữ liệu từ cơ sở dữ liệu
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Tạo DataTable để chứa dữ liệu từ cơ sở dữ liệu
                            DataTable dataTable = new DataTable();

                            // Đổ dữ liệu từ SqlDataAdapter vào DataTable
                            adapter.Fill(dataTable);

                            // Gán DataTable làm nguồn dữ liệu cho dgv_PhieuMuon
                            dgv_PhieuMuon.DataSource = dataTable;
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
                    using (SqlCommand command = new SqlCommand("SearchPhieuMuonByMaSach", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaSach", maSach);

                        // Tạo SqlDataAdapter để lấy dữ liệu từ cơ sở dữ liệu
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Tạo DataTable để chứa dữ liệu từ cơ sở dữ liệu
                            DataTable dataTable = new DataTable();

                            // Đổ dữ liệu từ SqlDataAdapter vào DataTable
                            adapter.Fill(dataTable);

                            // Gán DataTable làm nguồn dữ liệu cho dgv_PhieuMuon
                            dgv_PhieuMuon.DataSource = dataTable;
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn giá trị tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            if (string.IsNullOrEmpty(timkiem.Text))
            {
                LoadData(); // Thay thế bằng phương thức load dữ liệu của bạn
            }
        }


     

       
    }
    public static class DATAOFSAKER
    {
        public static string data_maQL { get; set; }
    }
}
