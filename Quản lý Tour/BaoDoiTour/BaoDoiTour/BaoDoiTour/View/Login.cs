using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaoDoiTour.Controller;
using BaoDoiTour.User;
using BaoDoiTour.Model;
using System.Data.SqlClient;
using BaoDoiTour.KhachHang;

namespace BaoDoiTour.View
{
    public partial class Login : Form
    {
        //Khởi tạo các biến
        private bool hidePassword = true;
        KetNoi kn = new KetNoi();
        User_BLL userBLL;
        int countError = 0;
        //Các hàm
        public Login()
        {
            InitializeComponent();
            userBLL = new User_BLL();
        }

        #region Xử lý login

        //Xử lý login nhân viên
        private void xuLyLoginNV()
        {
            NhanVien.tbl_NhanVien User = new NhanVien.tbl_NhanVien();
            tbl_User currentUser = new tbl_User();
            currentUser.Email = txtUsernameLogin.Text.Trim();
            currentUser.MatKhau = txtPasswordLogin.Text.Trim();
            currentUser.Quyen = userBLL.phQuyen(currentUser, cbLoginNV.Checked);
            currentUser.MaUser = userBLL.getMa(currentUser, cbLoginNV.Checked);
            if (currentUser.Quyen.ToUpper() == "ADMIN")
            {
                MainLayout main = new MainLayout(currentUser);
                main.Show();
                this.Hide();
            }
            else if (currentUser.Quyen.ToUpper() == "NV")
            {
                MainLayout main = new MainLayout(currentUser);
                main.Show();
                this.Hide();
            }
            else if (userBLL.phQuyen(currentUser, cbLoginNV.Checked) == "Fail")
            {
                countError++;
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //Xử lý login khách hàng
        private void xuLyLoginKH()
        {
            KhachHang.tbl_KhachHang User = new KhachHang.tbl_KhachHang();
            tbl_User currentUser = new tbl_User();
            currentUser.Email = txtUsernameLogin.Text.Trim();
            currentUser.MatKhau = txtPasswordLogin.Text.Trim();
            currentUser.Quyen = userBLL.phQuyen(currentUser, cbLoginNV.Checked);
            currentUser.MaUser = userBLL.getMa(currentUser, cbLoginNV.Checked);
            if (currentUser.Quyen.ToUpper() == "KH")
            {
                MainLayout main = new MainLayout(currentUser);
                main.Show();
                this.Hide();
            }
            else if (currentUser.Quyen.ToUpper() == "FAIL")
            {
                countError++;
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (countError >= 5)
            {
                LoiDangNhap loiForm = new LoiDangNhap();
                this.Hide();
                loiForm.Show();
            }
            if (cbLoginNV.Checked)
            {
                xuLyLoginNV();
            }
            else
            {
                xuLyLoginKH();
            }
        }
        #endregion

        private void linkToLoginTab_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabUserLogin.SelectedTab = loginTab;
        }

        private void linkToRegisterTab_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabUserLogin.SelectedTab = registerTab;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtPasswordLogin.PasswordChar = '\u25CF';
            txtPasswordRegis.PasswordChar = '\u25CF';
            txtRePasswordRegis.PasswordChar = '\u25CF';
        }

        //Show close password
        private void imgShowHidePassword_Click(object sender, EventArgs e)
        {
            hidePassword = !hidePassword;
            if (hidePassword)
            {
                imgShowHidePassword.Image = Properties.Resources.eyelashes_2d_39px;
                txtPasswordLogin.PasswordChar = '\u25CF';
            }
            else
            {
                imgShowHidePassword.Image = Properties.Resources.eye_open_39px;
                txtPasswordLogin.PasswordChar = '\0';
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            hidePassword = !hidePassword;
            if (hidePassword)
            {
                imgShowPassRegis.Image = Properties.Resources.eyelashes_2d_39px;
                txtPasswordRegis.PasswordChar = '\u25CF';
            }
            else
            {
                imgShowPassRegis.Image = Properties.Resources.eye_open_39px;
                txtPasswordRegis.PasswordChar = '\0';
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            hidePassword = !hidePassword;
            if (hidePassword)
            {
                imgShowRePassRegis.Image = Properties.Resources.eyelashes_2d_39px;
                txtRePasswordRegis.PasswordChar = '\u25CF';
            }
            else
            {
                imgShowRePassRegis.Image = Properties.Resources.eye_open_39px;
                txtRePasswordRegis.PasswordChar = '\0';
            }
        }

        private void xuLyDky(tbl_User user)
        {
            TTDKyNV form = new TTDKyNV(user);
            form.Show();
        }

        private void btnDkyTKhoan_Click(object sender, EventArgs e)
        {
            string email = txtEmailRegis.Text.Trim();
            string password = txtPasswordRegis.Text.Trim();
            string rePassword = txtRePasswordRegis.Text.Trim();

            BaoDoiTour.Controller.CommonFunction fc = new BaoDoiTour.Controller.CommonFunction();
            if (!fc.ktraEmail(txtEmailRegis.Text.Trim()))
            {
                MessageBox.Show("Chưa đúng định dạng email");
                return;
            }

            if (email.Length <= 0 || password.Length <= 0 || rePassword.Length <= 0)
            {
                MessageBox.Show("Chưa điền đầy đủ thông tin");
                return;
            }

            // Kiểm tra xem mật khẩu và nhập lại mật khẩu có trùng khớp
            if (password != rePassword)
            {
                MessageBox.Show("Mật khẩu và nhập lại mật khẩu không khớp.");
                return;
            }

            // Kiểm tra mật khẩu có ít nhất 6 kí tự
            if (password.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 kí tự.");
                return;
            }

            try
            {
                tbl_User user = new tbl_User
                {
                    Email = email,
                    MatKhau = password,
                    Quyen = "KH"
                };
                xuLyDky(user);
                txtEmailRegis.Clear();
                txtPasswordRegis.Clear();
                txtRePasswordRegis.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
            finally
            {
                kn.close();
            }
        }

        private void linkToQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMK fm = new QuenMK();
            fm.Show();
        }

        private void txtEmailRegis_Leave(object sender, EventArgs e)
        {
            BaoDoiTour.Controller.CommonFunction fc = new BaoDoiTour.Controller.CommonFunction();
            if (fc.ktraEmail(txtEmailRegis.Text))
            {
                errorFormInput.SetError((Control)sender, "");
            }
            else
            {
                errorFormInput.SetError((Control)sender, "Chưa đúng định dạng Email");
            }
        }

        private void txtPasswordRegis_Leave(object sender, EventArgs e)
        {
            BaoDoiTour.Controller.CommonFunction fc = new BaoDoiTour.Controller.CommonFunction();
            if (fc.ktraDkyPassword(txtPasswordRegis.Text.Trim()))
            {
                errorFormInput.SetError((Control)sender, "");
            }
            else
            {
                errorFormInput.SetError((Control)sender, "Mật khẩu phải có ít nhất 6 kí tự trở lên");
            }
        }

        private void txtRePasswordRegis_Leave(object sender, EventArgs e)
        {
            if (txtRePasswordRegis.Text.Trim() == txtPasswordRegis.Text.Trim())
            {
                errorFormInput.SetError((Control)sender, "");
            }
            else
            {
                errorFormInput.SetError((Control)sender, "Nhập lại mật khẩu chưa khớp");
            }
        }
    }
}
