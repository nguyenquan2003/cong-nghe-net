using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2001210779_NguyenNgocQuan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Focus();
            textBox1.TextChanged += TextBox_TextChanged;
            textBox2.TextChanged += TextBox_TextChanged;
            UpdateTextBoxes();
        }
        private int timUC(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        private List<int> timTatCaUC(int a, int b)
        {
            List<int> USC = new List<int>();
            for (int i = 1; i <= Math.Min(a, b); i++)
            {
                if (a % i == 0 && b % i == 0)
                {
                    USC.Add(i);
                }
            }
            return USC;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int x) && int.TryParse(textBox2.Text, out int y))
            {
                if (x > 0 && y > 0)
                {
                    int uc = timUC(x, y);
                    List<int> tatCaUC = timTatCaUC(x, y);

                    textBox3.Text = uc.ToString();
                    textBox4.Text = string.Join(", ", tatCaUC);

                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số nguyên dương.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số nguyên hợp lệ.");
            }
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateTextBoxes();
        }
        private void UpdateTextBoxes()
        {
            bool textBox1NotEmpty = !string.IsNullOrEmpty(textBox1.Text);
            bool textBox2NotEmpty = !string.IsNullOrEmpty(textBox2.Text);
            textBox3.Enabled = textBox1NotEmpty && textBox2NotEmpty;
            textBox4.Enabled = textBox1NotEmpty && textBox2NotEmpty;
        }
        private void CloseFrom()
        {
            DialogResult kq = MessageBox.Show
            ("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            CloseFrom();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }
    }
}
