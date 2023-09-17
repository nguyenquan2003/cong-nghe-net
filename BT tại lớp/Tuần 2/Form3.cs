using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
namespace buoi_3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public bool IsEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Length == 0)
                this.errorPr.SetError(ctr, "Băt buộc nhập");
            else
            {

            string a = txtEmail.Text;
            if (IsEmail(a) == true)
                this.errorPr.Clear();
            else
                this.errorPr.SetError(ctr, "NHap dung dia chi mail");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMK.Text == txtMK1.Text)
            {

                MessageBox.Show("Đăng ký thanh công", "Thông báo", MessageBoxButtons.YesNo);
                txtID.Clear();
                txtEmail.Clear();
                txtMK.Clear();
                txtMK1.Clear();
            }
            else
                MessageBox.Show("Mật khẩu không giống nhau", "Thông báo", MessageBoxButtons.YesNo);
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Length == 0)
                this.errorPr.SetError(ctr, "Băt buộc nhập");
            else
                this.errorPr.Clear();
        }

        private void txtMK_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Length == 0)
                this.errorPr.SetError(ctr, "Băt buộc nhập");
            else
                this.errorPr.Clear();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Ban muốn đóng form", "Thông bao", MessageBoxButtons.YesNo);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}
