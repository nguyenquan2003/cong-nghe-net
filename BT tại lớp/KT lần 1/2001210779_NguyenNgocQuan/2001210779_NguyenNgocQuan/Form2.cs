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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            button3.Click += Button3_Click;

            textBox1.Focus();
            textBox1.TextChanged += TextBox_TextChanged;
            textBox2.TextChanged += TextBox_TextChanged;
            textBox3.TextChanged += TextBox_TextChanged;
            textBox4.TextChanged += TextBox_TextChanged;
            UpdateTextBoxes();
        }
        private List<int> randomNumbers = new List<int>();
        private void Button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int n) && n > 5)
            {
                Random random = new Random();
                randomNumbers.Clear();
                for (int i = 0; i < n; i++)
                {
                    int randomNumber = random.Next(1, 100); // ngẫu nhiên từ 1 đến 99
                    randomNumbers.Add(randomNumber);
                }
                textBox2.Text = string.Join(" ", randomNumbers);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập một số nguyên dương n > 5.");
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (randomNumbers.Count == 0)
            {
                MessageBox.Show("Vui lòng tạo dãy số ngẫu nhiên trước.");
                return;
            }
            int tong = 0;
            int tongchan = 0;
            int tongle = 0;
            List<int> perfectSquares = new List<int>();
            foreach (int num in randomNumbers)
            {
                tong += num;
                if (num % 2 == 0)
                {
                    tongchan += num;
                }
                else
                {
                    tongle += num;
                }

                // Kiểm tra số chính phương
                double sqrt = Math.Sqrt(num);
                if (sqrt % 1 == 0)
                {
                    perfectSquares.Add(num);
                }
            }
            textBox3.Text = string.Join(" ", perfectSquares);
            textBox4.Text = tong.ToString();
            textBox5.Text = tongchan.ToString();
            textBox6.Text = tongle.ToString();
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            if (randomNumbers.Count == 0)
            {
                MessageBox.Show("Vui lòng tạo dãy số ngẫu nhiên trước.");
                return;
            }
            randomNumbers.Sort((a, b) => b.CompareTo(a));
            textBox2.Text = string.Join(" ", randomNumbers);
        }
        private void CloseForm()
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            CloseForm();
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
            textBox5.Enabled = textBox1NotEmpty && textBox2NotEmpty;
            textBox6.Enabled = textBox1NotEmpty && textBox2NotEmpty;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Hide();
        }
    }
}
