using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using BaoDoiTour.Controller;
using System.Data.SqlClient;

namespace BaoDoiTour.View
{
    public partial class QuenMK : Form
    {
        KetNoi kn = new KetNoi();
        public QuenMK()
        {
            InitializeComponent();
        }

        private void guiMK(string toEmail, string matKhau)
        {
            // Thông tin tài khoản email
            string fromEmail = "trantiendat25082003@gmail.com"; // Email người gửi
            string password = "najv qsrw vzhz inqx"; // Mật khẩu email người gửi

            // Cấu hình đối tượng MailMessage
            MailMessage mail = new MailMessage(fromEmail, toEmail);
            mail.Subject = "Gửi lại mật khẩu";
            mail.Body = "Xin kính chào quý khách : \n Dưới đây là mật khẩu của quý khách lưu ý đừng cung cấp mật khẩu cho bất cứ ai : \n" + matKhau + "\nLưu ý không cần trả lời lại email này. Xin cám ơn !";

            // Cấu hình đối tượng SmtpClient
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587; // Cổng SMTP của Gmail
            smtpClient.Credentials = new NetworkCredential(fromEmail, password);
            smtpClient.EnableSsl = true; // Kích hoạt SSL để bảo mật giao tiếp

            smtpClient.Send(mail);
            MessageBox.Show("Gửi lại mật khẩu thành công!");
        }

        private void txtEmailQuenMK_Leave(object sender, EventArgs e)
        {
            CommonFunction fc = new CommonFunction();
            if (!fc.ktraEmail(txtEmailQuenMK.Text.Trim())) {
                errorProvider1.SetError((Control)sender, "Chưa đúng định dạng email");
            }else
            {
                errorProvider1.SetError((Control)sender, "");
            }
        }

        private void btnLayMatKhau_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmailQuenMK.Text.Trim();

                // Tạo truy vấn SQL để kiểm tra xem email tồn tại trong bảng KhachHang hay không
                string query = "SELECT MatKhau FROM KhachHang WHERE Email = '" + email + "'";

                // Thực hiện truy vấn và kiểm tra kết quả
                SqlDataReader reader = kn.getDataReader(query);
                if (reader.Read())
                {
                    // Nếu tồn tại, lấy mật khẩu và lưu vào biến matKhau
                    string matKhau = reader["MatKhau"].ToString();
                    guiMK(email, matKhau);
                    txtEmailQuenMK.Text = "";
                }
                else
                {
                    // Nếu không tồn tại, thông báo lỗi
                    MessageBox.Show("Không tìm thấy khách hàng có email " + email);
                }
            }
            finally
            {
                if (kn.Connect.State == ConnectionState.Open)
                    kn.close();
            }
        }
    }
}
