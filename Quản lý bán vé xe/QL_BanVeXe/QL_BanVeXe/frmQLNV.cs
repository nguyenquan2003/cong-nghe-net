using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using QL_BanVeXe;

namespace LogIn_SignIn
{
    public partial class frmQLNV : Form
    {
        DBConnect db = new DBConnect();
        SqlDataAdapter da;
        string MaNV;
        public frmQLNV()
        {
            InitializeComponent();
        }

        private void frmQLNV_Load(object sender, EventArgs e)
        {
            //LoadDataToListView();
            LoadDataToDataGridView();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFix_Click(object sender, EventArgs e)
        {

            if (MaNV == null)
            {
                MessageBox.Show("Hãy chọn nhân viên muốn chỉnh sửa!");
            }
            else
            {

                string selectQuery = "UPDATE NHANVIEN SET  MaQuyen=@MaQuyen, TenNV=@TenNV, NgaySinh=@NgaySinh, GioiTinh=@GioiTinh, DiaChi=@DiaChi,CCCD=@CCCD,SDT=@SDT,Email=@Email,NgayVaoLam=@NgayVaoLam WHERE MaNV=@MaNV";
                string TenNV = txtHoTen.Text;
                string NgaySinh = tmeBirth.Value.ToString();
                string NgayVaoLam = tmeDayIn.Value.ToString();
                string MaQuyen;
                if (cboChucVu.SelectedItem == "Quản Lý")
                {
                    MaQuyen = "Admin";
                }
                else
                {
                    MaQuyen = "Employee";
                }
                string GioiTinh = cboSex.SelectedItem.ToString();
                string DiaChi = txtAddress.Text;
                string CCCD = txtCCCD.Text;
                string SDT = txtPhoneNumber.Text;
                string Email = txtEmail.Text;
                
                    db.Open();
                    string query1 = $"SELECT COUNT(*) FROM NHANVIEN WHERE SDT = '{txtPhoneNumber.Text}' AND MaNV NOT IN ('{txtID.Text}')";
                    SqlCommand command1 = new SqlCommand(query1, db.Conn);
                    int count1 = (int)command1.ExecuteScalar();
                    db.Close();
                    db.Open();
                    string query2 = $"SELECT COUNT(*) FROM NHANVIEN WHERE CCCD = '{txtCCCD.Text}' AND MaNV NOT IN ('{txtID.Text}')";
                    SqlCommand command2 = new SqlCommand(query2, db.Conn);
                    int count2 = (int)command2.ExecuteScalar();
                    db.Close();
                    db.Open();
                    string query3 = $"SELECT COUNT(*) FROM NHANVIEN WHERE Email = '{txtEmail.Text}' AND MaNV NOT IN ('{txtID.Text}')";
                    SqlCommand command3 = new SqlCommand(query3, db.Conn);
                    int count3 = (int)command3.ExecuteScalar();
                    db.Close();
                    if (count1 > 0)
                    {
                        errorProvider1.SetError(txtPhoneNumber, "SDT đã tồn tại .");
                    }
                    if (count2 > 0)
                    {
                        errorProvider1.SetError(txtCCCD, "CCCD đã tồn tại .");
                    }
                    if (count3 > 0)
                    {
                        errorProvider1.SetError(txtEmail, "Email đã tồn tại .");
                    }
                    if (count1 == 0 && count2 == 0 && count3 == 0)
                    {
                        db.Open();
                        using (SqlCommand selectCommand = new SqlCommand(selectQuery, db.Conn))
                        {

                            selectCommand.Parameters.AddWithValue("@MaNV", MaNV);
                            selectCommand.Parameters.AddWithValue("@TenNV", TenNV);
                            selectCommand.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                            selectCommand.Parameters.AddWithValue("@NgayVaoLam", NgayVaoLam);
                            selectCommand.Parameters.AddWithValue("@MaQuyen", MaQuyen);
                            selectCommand.Parameters.AddWithValue("@GioiTinh", GioiTinh);
                            selectCommand.Parameters.AddWithValue("@DiaChi", DiaChi);
                            selectCommand.Parameters.AddWithValue("@CCCD", CCCD);
                            selectCommand.Parameters.AddWithValue("@SDT", SDT);
                            selectCommand.Parameters.AddWithValue("@Email", Email);
                            selectCommand.ExecuteReader();
                            MessageBox.Show("Chỉnh sửa thành công");

                        }   
                        db.Close();
                    }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int STT = (int)db.getScalar("SELECT MAX(CAST(RIGHT(MaNV, 3) AS INT)) AS MaxLastThreeDigits FROM NHANVIEN")+1;
            
            
            string selectQuery = "INSERT INTO NHANVIEN VALUES  (@MaNV,@TenDangNhap,@MaQuyen, @TenNV, @NgaySinh, @GioiTinh, @DiaChi,@CCCD,@SDT,@Email,@NgayVaoLam )";
            string newMaNV;
            string TenNV = txtHoTen.Text;
            DateTime NgaySinh = tmeBirth.Value;
            DateTime NgayVaoLam = tmeDayIn.Value;
            string MaQuyen;
            if (cboChucVu.SelectedItem == "Quản Lý")
            {
                MaQuyen = "Admin";
            }
            else
            {
                MaQuyen = "Employee";
            }
            string GioiTinh = cboSex.SelectedItem.ToString();
            string DiaChi = txtAddress.Text;
            string CCCD = txtCCCD.Text;
            string SDT = txtPhoneNumber.Text;
            string Email = txtEmail.Text;
            if (MaQuyen == "Admin")
            {
                if (STT < 10)
                {
                    newMaNV = "AD" + tmeDayIn.Value.ToString("yyyyMMdd") + "00" + STT.ToString();
                }
                else if (STT >= 10 && STT <= 99)
                {
                    newMaNV = "AD" + tmeDayIn.Value.ToString("yyyyMMdd") + "0" + STT.ToString();
                }
                else { newMaNV = "AD" + tmeDayIn.Value.ToString("yyyyMMdd") + STT.ToString(); }
            }
            else
            {
                if (STT < 10)
                {
                    newMaNV = "EM" + tmeDayIn.Value.ToString("yyyyMMdd") + "00" + STT.ToString();
                }
                else if (STT >= 10 && STT <= 99)
                {
                    newMaNV = "EM" + tmeDayIn.Value.ToString("yyyyMMdd") + "0" + STT.ToString();
                }
                else { newMaNV = "EM" + tmeDayIn.Value.ToString("yyyyMMdd") + STT.ToString(); }
            }
            string TenDangNhap = newMaNV.ToLower();
            
                db.Open();
                string query = "INSERT INTO TAIKHOAN VALUES (@TenDangNhap, @MatKhau)";
                SqlCommand command = new SqlCommand(query, db.Conn);
                command.Parameters.AddWithValue("@TenDangNhap", TenDangNhap);
                command.Parameters.AddWithValue("@MatKhau", "1");
                command.ExecuteReader();           
                db.Close();
                db.Open();
                string query1 = $"SELECT COUNT(*) FROM NHANVIEN WHERE SDT = '{txtPhoneNumber.Text}'";
                SqlCommand command1 = new SqlCommand(query1, db.Conn);
                int count1 = (int)command1.ExecuteScalar();
                db.Close();
                db.Open();
                string query2 = $"SELECT COUNT(*) FROM NHANVIEN WHERE CCCD = '{txtCCCD.Text}'";
                SqlCommand command2 = new SqlCommand(query2, db.Conn);
                int count2 = (int)command2.ExecuteScalar();
                db.Close();
                db.Open();
                string query3 = $"SELECT COUNT(*) FROM NHANVIEN WHERE Email = '{txtEmail.Text}'";
                SqlCommand command3 = new SqlCommand(query3, db.Conn);
                int count3 = (int)command3.ExecuteScalar();              
                db.Close();
                if (count1 > 0)
                {
                    errorProvider1.SetError(txtPhoneNumber, "SDT đã tồn tại .");
                }
                if (count2 > 0)
                {
                    errorProvider1.SetError(txtCCCD, "CCCD đã tồn tại .");
                }
                if (count3 > 0)
                {
                    errorProvider1.SetError(txtEmail, "Email đã tồn tại .");
                }
                if (count1 == 0 && count2 == 0 && count3 == 0)
                {
                    db.Open();
                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, db.Conn))
                    {

                        selectCommand.Parameters.AddWithValue("@MaNV", newMaNV);
                        selectCommand.Parameters.AddWithValue("@TenDangNhap", TenDangNhap);
                        selectCommand.Parameters.AddWithValue("@TenNV", TenNV);
                        selectCommand.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                        selectCommand.Parameters.AddWithValue("@NgayVaoLam", NgayVaoLam);
                        selectCommand.Parameters.AddWithValue("@MaQuyen", MaQuyen);
                        selectCommand.Parameters.AddWithValue("@GioiTinh", GioiTinh);
                        selectCommand.Parameters.AddWithValue("@DiaChi", DiaChi);
                        selectCommand.Parameters.AddWithValue("@CCCD", CCCD);
                        selectCommand.Parameters.AddWithValue("@SDT", SDT);
                        selectCommand.Parameters.AddWithValue("@Email", Email);
                        selectCommand.ExecuteReader();
                        
                        MessageBox.Show("Thêm thành công");
                    }
                    db.Close();
                    
                }       
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            string deleteQuery = $"DELETE FROM NHANVIEN WHERE MaNV = '{MaNV}'";
            string Query = "SELECT TenDangNhap FROM NHANVIEN WHERE MaNV = @MaNV";
            string deleteAcc = "DELETE FROM TAIKHOAN WHERE TenDangNhap = @TenDangNhap";

            if (MaNV == null)
            {
                MessageBox.Show("Hãy chọn nhân viên cần xóa");
            }
            else
            {
                db.Open();

                using (SqlCommand Command = new SqlCommand(Query, db.Conn))
                {
                    Command.Parameters.AddWithValue("MaNV", MaNV);

                    using (SqlDataReader reader = Command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.Read())
                        {
                            string TenDangNhap = reader["TenDangNhap"].ToString();
                            db.Close();
                            db.Open();

                            using (SqlCommand command = new SqlCommand(deleteAcc, db.Conn))
                            {
                                command.Parameters.AddWithValue("TenDangNhap", TenDangNhap);
                                command.ExecuteNonQuery();
                                
                            }

                            db.Close();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi r");
                        }
                    }
                }

                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, db.Conn))
                {
                    db.Open();
                    deleteCommand.ExecuteNonQuery();
                    db.Close();
                }

                MessageBox.Show("Đã xóa nhân viên thành công");
            }

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Lấy giá trị từ cột "MaNV" của hàng được chọn
                MaNV = selectedRow.Cells["MaNV"].Value.ToString();

                
                
            
            string selectQuery = "SELECT MaNV, NgayVaoLam, TenNV,TenDangNhap, DiaChi, NgaySinh, GioiTinh, MaQuyen, CCCD, SDT, Email FROM NHANVIEN WHERE MaNV=@MaNV";


            //db.Open();
            db.Open();

            using (SqlCommand selectCommand = new SqlCommand(selectQuery, db.Conn))
            {
                // Thêm tham số @MaNV vào câu truy vấn
                selectCommand.Parameters.AddWithValue("@MaNV", MaNV);           

                // Thực hiện truy vấn và đọc dữ liệu
                SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);
                // Đọc dữ liệu và thêm vào ListView
                while (reader.Read())
                {
                    DateTime ngaysinh;
                    DateTime ngayvaolam;
                    txtHoTen.Text = reader["TenNV"].ToString();
                    txtAddress.Text = reader["DiaChi"].ToString();
                    txtTenDangNhap.Text = reader["TenDangNhap"].ToString();
                    if (DateTime.TryParse(reader["NgaySinh"].ToString(), out ngaysinh))
                    {
                        tmeBirth.Value = ngaysinh;
                    }

                    if (DateTime.TryParse(reader["NgayVaoLam"].ToString(), out ngayvaolam))
                    {
                        tmeDayIn.Value = ngayvaolam;
                    }
                    if (reader["GioiTinh"].ToString() == "Nam")
                    {
                        cboSex.SelectedItem = "Nam";
                    }
                    else if (reader["GioiTinh"].ToString() == "Nu")
                    {
                        cboSex.SelectedItem = "Nữ";
                    }
                    else
                    {
                        cboSex.SelectedItem = "Khác";
                    }
                    txtID.Text = reader["MaNV"].ToString();

                    if (reader["MaQuyen"].ToString() == "Admin")
                    {
                        cboChucVu.SelectedItem = "Quản Lý";
                    }
                    else
                    {
                        cboChucVu.SelectedItem = "Nhân Viên";
                    }

                    txtCCCD.Text = reader["CCCD"].ToString();
                    txtPhoneNumber.Text = reader["SDT"].ToString();
                    txtEmail.Text = reader["Email"].ToString();

                }

            }
            db.Close();
        }

        private void LoadDataToDataGridView()
        {
            try
            {
                string query = "SELECT MaNV, TenNV,TenDangNhap, GioiTinh, MaQuyen, NgaySinh, NgayVaoLam, SDT, CCCD, Email FROM NHANVIEN";
                DataTable dt = new DataTable();
                da = new SqlDataAdapter(query, db.Conn);
                da.Fill(dt);
                dataGridView1.Columns.Clear();

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtID.Text = null;
            txtHoTen.Text = null;
            txtAddress.Text = null;
            txtTenDangNhap.Text = null;
            cboChucVu.SelectedItem=null;
            cboSex.SelectedItem = null;
            txtPhoneNumber.Text = null;
            txtCCCD.Text = null;
            txtEmail.Text = null;
        }

        private void ValidateSDT(string sdt)
        {
            // Kiểm tra SDT có tối thiểu 10 số
            if (sdt.Length < 10 /*|| !IsNumeric(sdt)*/)
            {
                errorProvider1.SetError(txtPhoneNumber, "SDT phải có ít nhất 10 số.");
            }
            else
            {
                errorProvider1.SetError(txtPhoneNumber, ""); // Xóa lỗi nếu hợp lệ
            }
        }

        private void ValidateCCCD(string cccd)
        {
            // Kiểm tra CCCD có tối thiểu 12 số
            if (cccd.Length < 12 /*||!IsNumeric(cccd)*/ )
            {
                errorProvider1.SetError(txtCCCD, "CCCD phải có ít nhất 12 số.");
            }
            else
            {
                errorProvider1.SetError(txtCCCD, ""); // Xóa lỗi nếu hợp lệ
            }
        }

        private void ValidateEmail(string email)
        {
            // Kiểm tra Email theo định dạng hợp lệ
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                errorProvider1.SetError(txtEmail, ""); // Xóa lỗi nếu hợp lệ
            }
            catch
            {
                errorProvider1.SetError(txtEmail, "Email không đúng định dạng.");
            }
        }

        private bool IsNumeric(string value)
        {
            // Kiểm tra xem chuỗi có phải là số hay không
            return int.TryParse(value, out _);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCCCD_TextChanged(object sender, EventArgs e)
        {
            ValidateCCCD(txtCCCD.Text);
        }

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            ValidateSDT(txtPhoneNumber.Text);
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            ValidateEmail(txtEmail.Text);
        }

        private void txtCCCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) )
            {
                // Nếu ký tự không phải là số và không phải là ký tự control (như Backspace), hủy sự kiện nhập
                e.Handled = true;
            }
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                // Nếu ký tự không phải là số và không phải là ký tự control (như Backspace), hủy sự kiện nhập
                e.Handled = true;
            }
        }
    }
}
