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
            load_lable();
        }
        //cách 1: tạo bằng code
        void load_lable()
        {
            Label lb = new Label();
            this.Controls.Add(lb);
            lb.BackColor = Color.Aqua;
            for (int i = 0;i< 10; i++)
            {
                lb.Text = "Hello World : " + i;
            }
        }

        //cách 2: tạo bằng design
        /*
        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = "Free Edu";
        }
        private void From1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            Hiển thị Form con như một cửa sổ riêng lẻ cho phép
            tương tác với các Form khác trong ứng dụng mà không cần chặn.
            f.label1.Text = "hello world";

            f.ShowDialog();
            Hiển thị Form con như một hộp thoại modal, chặn tất cả tương tác
            với các Form khác cho đến khi Form con đóng lại.
            Người dùng phải xử lý Form con trước khi quay lại làm việc với các Form khác.
       
        }
        */
    }
}
