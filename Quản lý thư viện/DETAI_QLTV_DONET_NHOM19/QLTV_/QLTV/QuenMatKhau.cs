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
    public partial class QuenMatKhau : Form
    {
        SqlConnection connection;
        string str = DataHolder.str;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public QuenMatKhau()
        {
            InitializeComponent();
        }

        private void bt_dangnhap_MouseEnter(object sender, EventArgs e)
        {
            bt_gui.BackColor = Color.LightSteelBlue;
        }

        private void bt_dangnhap_MouseLeave(object sender, EventArgs e)
        {
            Color myColor = Color.FromArgb(30, 30, 30);
            bt_gui.BackColor = myColor;
        }

        private void bt_quaylai_Click(object sender, EventArgs e)
        {
            this.Hide();
            dangnhap dn = new dangnhap();
            dn.Show();
            return;
        }

        private void bt_quaylai_MouseEnter(object sender, EventArgs e)
        {
            bt_quaylai.BackColor = Color.LightSteelBlue;
        }

        private void bt_quaylai_MouseLeave(object sender, EventArgs e)
        {
            Color myColor = Color.FromArgb(30, 30, 30);
            bt_quaylai.BackColor = myColor;
        }

        private void view_mkm_Click(object sender, EventArgs e)
        {
            if (matkhau.PasswordChar == '*')
            {
                hide_mkm.BringToFront();
                matkhau.PasswordChar = '\0';
            }
        }

        private void hide_mkm_Click(object sender, EventArgs e)
        {
            if (matkhau.PasswordChar == '\0')
            {
                view_mkm.BringToFront();
                matkhau.PasswordChar = '*';
            }
        }

        private void view_nlmkm_Click(object sender, EventArgs e)
        {
            if (matkhau_.PasswordChar == '*')
            {
                hide_nlmkm.BringToFront();
                matkhau_.PasswordChar = '\0';
            }
        }

        private void hide_nlmkm_Click(object sender, EventArgs e)
        {
            if (matkhau_.PasswordChar == '\0')
            {
                view_nlmkm.BringToFront();
                matkhau_.PasswordChar = '*';
            }
        }
        public bool KiemTraMatKhau_NV(string MaNV, string matkhau)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT MatKhau FROM QuanLy WHERE MaQuanLy = @maQL", connection))
                {
                    command.Parameters.AddWithValue("@maQL", MaNV);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string storedMatKhau = reader["MatKhau"].ToString();
                        reader.Close();

                        if (storedMatKhau == matkhau)
                        {
                            // Mật khẩu trùng khớp
                            return true;
                        }
                        else
                        {
                            // Mật khẩu không khớp
                            return false;
                        }
                    }
                    else
                    {
                        // Không tìm thấy tài khoản
                        return false;
                    }
                }
            }
        }
        public bool KiemTraMaNV_TK(string maNV)
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
        public void LayLaiPass(string maNV, string matkhau)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UPDATE TaiKhoan SET MatKhau = @matkhau WHERE TenDangNhap = @taikhoan", connection))
                {
                    command.Parameters.AddWithValue("@taikhoan", maNV);
                    command.Parameters.AddWithValue("@matkhau", matkhau);
                    int rowCount = command.ExecuteNonQuery();

                    if (rowCount > 0)
                    {
                        MessageBox.Show("Lấy lại mật khẩu thành công!", "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Lỗi", "Lấy lại mật khẩu không thành công!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                }
            }
        }

        private void bt_gui_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_taikhoan.Text))
            {
                MessageBox.Show("Lỗi không điền đầy đủ thông tin (Mã nhân viên)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (string.IsNullOrWhiteSpace(matkhauNV.Text))
            {
                MessageBox.Show("Lỗi không điền đầy đủ thông tin (Mật khẩu nhân viên)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (string.IsNullOrWhiteSpace(matkhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu muốn đổi lại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (string.Compare(matkhau.Text,matkhau_.Text)==1)
            {
                MessageBox.Show("Mật khẩu mới nhắc lại không trùng!!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if(KiemTraMaNV_TK(txt_taikhoan.Text)==false)
            {
                MessageBox.Show("Tài khoản hiện chưa đăng kí thông tin xin quay lại trang đăng kí để đăng kí tài khoản cho nhân viên. ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if(KiemTraMatKhau_NV(txt_taikhoan.Text,matkhauNV.Text)==false)
            {
                MessageBox.Show("Mật khẩu nhân viên không đúng hãy nhập lại hoặc liên hệ quản lí để được cấp lại mật khẩu nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            LayLaiPass(txt_taikhoan.Text, matkhau_.Text);
            txt_taikhoan.Clear();
            matkhauNV.Clear();
            matkhau.Clear();
            matkhau_.Clear();


        }

      



    }
}
