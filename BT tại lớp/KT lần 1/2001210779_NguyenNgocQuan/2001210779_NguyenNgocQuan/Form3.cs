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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            textBox3.TextChanged += TextBox_TextChanged;
            UpdateTextBoxes();

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Phòng Vip");
            comboBox1.Items.Add("Phòng thường");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = radioButton1.Checked;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown2.Enabled = radioButton2.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown3.Enabled = checkBox1.Checked;
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown4.Enabled = checkBox2.Checked;
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown5.Enabled = checkBox3.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách và số bàn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            double tongtien = 0;
            if (radioButton1.Checked)
            {
                tongtien += (double)numericUpDown1.Value * 25000;
            }
            else if (radioButton2.Checked)
            {
                tongtien += (double)numericUpDown2.Value * 35000;
            }
            if (checkBox1.Checked)
            {
                tongtien += (double)numericUpDown3.Value * 800000;
            }
            if (checkBox2.Checked)
            {
                tongtien += (double)numericUpDown4.Value * 600000;
            }
            if (checkBox3.Checked)
            {
                tongtien += (double)numericUpDown5.Value * 500000;
            }
            if (comboBox1.SelectedItem != null)
            {
                if (comboBox1.SelectedItem.ToString() == "Phòng VIP")
                {
                    tongtien *= 1.15;
                }
            }
            textBox3.Text = string.Format("{0:N0} VNĐ", tongtien);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
            textBox3.Clear();
        }
        private void CloseForm()
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
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
        }

    }
}
