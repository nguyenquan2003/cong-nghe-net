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
using QL_BanVeXe;
using System.Reflection;

namespace LogIn_SignIn
{
    public partial class LogIn : Form
    {

        DBConnect db= new DBConnect();
        

        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
           
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            txtUser.Text = "";
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtPassword.UseSystemPasswordChar = false;
        }     
        private void btnLogIn_MouseEnter(object sender, EventArgs e)
        {
            btnLogIn.BackColor = Color.DodgerBlue;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPassword.Text;
            db.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM TAIKHOAN WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau", db.Conn);

            cmd.Parameters.AddWithValue("@TenDangNhap", username);
            cmd.Parameters.AddWithValue("@MatKhau", password);

            int userCount = (int)cmd.ExecuteScalar();
            if (userCount > 0)
            {
              
                    // Chuyển sang form frmQLNV
                    QLBVX form_TrangChu = new QLBVX();
                    form_TrangChu.Show();
                    this.Hide();
                
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công");
            }


        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LogIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string username = txtUser.Text;
                string password = txtPassword.Text;
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM TAIKHOAN WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau", db.Conn);

                cmd.Parameters.AddWithValue("@TenDangNhap", username);
                cmd.Parameters.AddWithValue("@MatKhau", password);

                int userCount = (int)cmd.ExecuteScalar();
                if (userCount > 0)
                {

                    // Chuyển sang form frmQLNV
                    frmQLNV formQLNV = new frmQLNV();
                    formQLNV.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Đăng nhập không thành công");
                }
            }
        }
    }
}
