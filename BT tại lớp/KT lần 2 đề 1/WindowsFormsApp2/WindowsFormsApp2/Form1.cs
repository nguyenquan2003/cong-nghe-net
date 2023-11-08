using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Thực hiện kiểm tra tên người dùng và mật khẩu trong cơ sở dữ liệu ở đây.
            // Đây chỉ là một ví dụ đơn giản, bạn cần thay thế nó bằng cách kết nối đến cơ sở dữ liệu thực tế.

            // Ví dụ kiểm tra tên người dùng và mật khẩu cứng-coded:
            if (username == "admin" && password == "password")
            {
                // Đăng nhập thành công, mở form khác lên ở đây.
                // Ví dụ: Form2 form2 = new Form2(); form2.Show();
                MessageBox.Show("Đăng nhập thành công!");
            }
            else
            {
                MessageBox.Show("Tên người dùng hoặc mật khẩu không đúng.");
            }
        }
        private void CloseForm()
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
    }
}
