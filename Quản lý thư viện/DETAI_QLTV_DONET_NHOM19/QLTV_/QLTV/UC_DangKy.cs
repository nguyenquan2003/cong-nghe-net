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
    public partial class UC_DangKy : UserControl
    {
        SqlConnection connection;
        string str = DataHolder.str;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public UC_DangKy()
        {
            InitializeComponent();
        }
        public bool KiemTraMaNVTrongQuanLy(string maNV)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM QuanLy WHERE MaQuanLy = @maNV", connection))
                {
                    command.Parameters.AddWithValue("@maNV", maNV);
                    int rowCount = Convert.ToInt32(command.ExecuteScalar());

                    if (rowCount > 0)
                    {
                        // `maNV` trùng với ít nhất một giá trị `MaQuanLy` trong bảng `QuanLy`
                        return true;
                    }
                    else
                    {
                        // `maNV` không trùng với bất kỳ giá trị `MaQuanLy` nào trong bảng `QuanLy`
                        return false;
                    }
                }
            }
        }
        public void themTK(string maNV, string matkhau)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO TaiKhoan VALUES (@taikhoan,@matkhau)", connection))
                {
                    command.Parameters.AddWithValue("@taikhoan", maNV);
                    command.Parameters.AddWithValue("@matkhau", matkhau);
                    int rowCount = command.ExecuteNonQuery();

                    if (rowCount > 0)
                    {
                        MessageBox.Show("Thêm thành công", "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Lỗi", "Chia buồn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                }
            }
        }
        public bool KiemTraMaNVTrongTK(string maNV)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @maNV", connection))
                {
                    command.Parameters.AddWithValue("@maNV", maNV);
                    int rowCount = Convert.ToInt32(command.ExecuteScalar());

                    if (rowCount > 0)
                    {
                        // `maNV` trùng với ít nhất một giá trị `MaQuanLy` trong bảng `QuanLy`
                        return true;
                    }
                    else
                    {
                        // `maNV` không trùng với bất kỳ giá trị `MaQuanLy` nào trong bảng `QuanLy`
                        return false;
                    }
                }
            }
        }

        private void bt_dangky_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(manv.Text))
            {
                MessageBox.Show("Lỗi không điền đầy đủ thông tin (Tài khoản)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if ( string.IsNullOrWhiteSpace(matkhau.Text))
            {
                MessageBox.Show("Lỗi không điền đầy đủ thông tin (Mật khẩu)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (string.IsNullOrWhiteSpace(matkhau_.Text))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (KiemTraMaNVTrongQuanLy(manv.Text) == false)
            {
                MessageBox.Show("Mã nhân viên không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (matkhau.Text != matkhau_.Text )
            {
                MessageBox.Show("Mật khẩu không trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }


            if (KiemTraMaNVTrongQuanLy(manv.Text) == true)
            {
                if (KiemTraMaNVTrongTK(manv.Text) == false)
                {
                    themTK(manv.Text,matkhau_.Text);
                    this.Hide();
                    OnUserControlExit();
                    LOGIN.checkDK = true;                  
                    return;
                }
                else
                {
                    MessageBox.Show("Tài khoản đã tồn tại!!!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }    
                
            }
            
        }

        public event EventHandler UserControlExit;
       
         protected virtual void OnUserControlExit()
        {
            // Gửi thông báo qua sự kiện
            UserControlExit(this, EventArgs.Empty);
        }
        private void manv_TextChanged(object sender, EventArgs e)
        {
            taikhoan.Text = manv.Text;
        }

        private void hide_pictureBox_Click(object sender, EventArgs e)
        {
            if (matkhau_.PasswordChar == '\0')
            {
                view_nlmk.BringToFront();
                matkhau_.PasswordChar = '*';
            }
        }
     

        private void view_mk_Click(object sender, EventArgs e)
        {
            if (matkhau.PasswordChar == '*')
            {
                hide_mk.BringToFront();
                matkhau.PasswordChar = '\0';
            }
        }
        private void hide_mk_Click(object sender, EventArgs e)
        {
            if (matkhau.PasswordChar == '\0')
            {
                view_mk.BringToFront();
                matkhau.PasswordChar = '*';
            }
        }

        private void view_nlmk_Click(object sender, EventArgs e)
        {
            if (matkhau_.PasswordChar == '*')
            {
                hide_nlmk.BringToFront();
                matkhau_.PasswordChar = '\0';
            }
        }
        private void hide_nlmk_Click(object sender, EventArgs e)
        {
            if (matkhau_.PasswordChar == '\0')
            {
                view_nlmk.BringToFront();
                matkhau_.PasswordChar = '*';
            }
        }

        private void taikhoan_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
