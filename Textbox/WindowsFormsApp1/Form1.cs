using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //label1.Text = textBox1.Text;lấy giá trị văn bản (chuỗi) từ một ô văn bản (textBox)
        }

        //mỗi khi text thay đổi text change tự động thay đổi
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            int number = 0;

            if (Int32.TryParse(textBox1.Text, out number))
                label1.Text = (number * number).ToString();
            else
                label1.Text = "Vui lòng nhập số!";
        }
    }
}
