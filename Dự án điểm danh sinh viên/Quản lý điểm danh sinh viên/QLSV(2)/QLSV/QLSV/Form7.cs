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
using static System.Net.Mime.MediaTypeNames;
namespace QLSV
{
    public partial class Form7 : Form
    {
        //Form1 f1;
        //Form2 f2;
         Form4 f4;
        SqlConnection con;
        public Form7(string text, Form4 f4)
        {
            InitializeComponent();
            //con = new SqlConnection("Data Source=LAPTOP-65O2D3FN;Initial Catalog=DIEMDANH;Integrated Security=True");
            con = new SqlConnection(@"Data Source=DESKTOP-0MNS8CK\SQLEXPRESS;Initial Catalog=qldiemdanh4ll11;Integrated Security=True");
            lb_ma.Text = text;
            //f1 = new Form1();
            //f2 = new Form2(f1);
            this.f4 = f4; // Khởi tạo _form4
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            txt_oldP.PasswordChar = '•';
            txt_newP.PasswordChar = '•';
            txt_reP.PasswordChar = '•';
        }
        bool kt_oldPass()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string sql = "select Password from dbo.account where UserName= @username";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@username", lb_ma.Text);
                string password = cmd.ExecuteScalar().ToString();
                con.Close();
                if (txt_oldP.Text == password)
                {
                    return true;
                }
                else
                {
                    //MessageBox.Show("Mật khẩu chưa đúng");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                return false;
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_oldP.Text = "";
            txt_newP.Text = "";
            txt_reP.Text = "";
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                string oldPassword = txt_oldP.Text;
                string newPassword = txt_newP.Text;
                string confirmPassword = txt_reP.Text;

                // Kiểm tra cả 3 textbox được nhập dữ liệu hay chưa
                if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
                {
                    MessageBox.Show("Hãy nhập đầy đủ");
                    return;
                }

                // Kiểm tra mật khẩu cũ có đúng không
                if (!kt_oldPass())
                {
                    MessageBox.Show("Mật khẩu cũ không đúng.");
                    return;
                }

                // Kiểm tra 2 textbox của pass mới được nhập giống nhau không
                if (newPassword != confirmPassword)
                {
                    MessageBox.Show("Mật khẩu mới và mật khẩu xác nhận không khớp.");
                    return;
                }

                // Kiểm tra mật khẩu cũ phải khác mật khẩu mới
                if (oldPassword == newPassword)
                {
                    MessageBox.Show("Mật khẩu mới phải khác mật khẩu cũ.");
                    return;
                }

                // Cập nhật mật khẩu mới vào cơ sở dữ liệu
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string sql = "update account set Password= @newPassword where UserName = @userName";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@newPassword", newPassword);
                cmd.Parameters.AddWithValue("@userName", lb_ma.Text);
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật thành công.");
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công. Vui lòng kiểm tra lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                btn_reset_Click(sender, e); // Gọi hàm btn_reset_Click() khi có lỗi xảy ra
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            
                f4.Show(); // Hiển thị lại Form4 khi Form5 đóng
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
