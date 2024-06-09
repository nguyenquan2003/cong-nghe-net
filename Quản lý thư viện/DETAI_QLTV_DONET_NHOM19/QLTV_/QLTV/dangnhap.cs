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
    public partial class dangnhap : Form
    {
        SqlConnection connection;
        string str = DataHolder.str;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
      
        public dangnhap()
        {
            InitializeComponent();
            //Tạo 1 UC mới = UC_DocGia, thêm nó vào panelright và cho ẩn nó đi     
           
           
        }


        private void bt_dangnhap_Click(object sender, EventArgs e)
        {

        }

        private void bt_dangky_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            DangKy dk = new DangKy();
           
            dk.ShowDialog();

            return;
            
          
        }

        private void txt_taikhoan_Click(object sender, EventArgs e)
        {
            txt_taikhoan.SelectAll();
        }

        private void txt_matkhau_Click(object sender, EventArgs e)
        {
            txt_matkhau.SelectAll();
        }

        private void view_pictureBox_Click(object sender, EventArgs e)
        {
            if (txt_matkhau.PasswordChar == '*')
            {
                hide_pictureBox.BringToFront();
                txt_matkhau.PasswordChar = '\0';
            }
        }

        private void hide_pictureBox_Click(object sender, EventArgs e)
        {
            if (txt_matkhau.PasswordChar == '\0')
            {
                view_pictureBox.BringToFront();
                txt_matkhau.PasswordChar = '*';
            }
        }

        private void bt_dangnhap_MouseEnter(object sender, EventArgs e)
        {
            bt_dangnhap.BackColor = Color.LightSteelBlue;
        }

        private void bt_dangnhap_MouseLeave(object sender, EventArgs e)
        {
            Color myColor = Color.FromArgb(30, 30, 30);
            bt_dangnhap.BackColor = myColor;
        }

        private void bt_dangky_MouseEnter(object sender, EventArgs e)
        {
            bt_dangky.BackColor = Color.LightSteelBlue;
        }

        private void bt_dangky_MouseLeave(object sender, EventArgs e)
        {
            Color myColor = Color.FromArgb(30, 30, 30);
            bt_dangky.BackColor = myColor;
        }
        public bool KiemTraTaiKhoan(string tk, string matkhau)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT MatKhau FROM TaiKhoan WHERE TenDangNhap = @taikhoan", connection))
                {
                    command.Parameters.AddWithValue("@taikhoan", tk);
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

        
        private void bt_dangnhap_Click_1(object sender, EventArgs e)
        {
            if(string.Compare(txt_taikhoan.Text,"admin")==0 && string.Compare(txt_matkhau.Text,"123")==0  )
            {
                LOGIN.check = "ADMIN";
                LOGIN.checkADMIN = true;
                MessageBox.Show("Đăng nhập thành công!!!", "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Hide();
                
                GiaoDienAD x = new GiaoDienAD();
                x.Show();
                return;
                
            }
            if(string.IsNullOrWhiteSpace(txt_taikhoan.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản!!!","Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
           else if(string.IsNullOrWhiteSpace(txt_matkhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(KiemTraTaiKhoan(txt_taikhoan.Text,txt_matkhau.Text)==true)
            {
                LOGIN.checkADMIN = false;
                MessageBox.Show("Đăng nhập thành công!!!", "Chúc mừng", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                LOGIN.check = txt_taikhoan.Text;
                this.Hide();
               
                GiaoDienNV nv = new GiaoDienNV();
                nv.Show();
                
            }
            else
            {
                MessageBox.Show("Thông tin tài khoản hoặc mật khẩu không đúng!!!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            QuenMatKhau qmk = new QuenMatKhau();
            qmk.Show();
            return;
        }

      


 


     







    }
    public static class LOGIN
    {
        public static string check { get; set; }
        public static bool checkADMIN { get; set; }
        public static bool checkDK { get; set; }
    }
}
