using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buoi_3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        void validation(TextBox a)
        {
            string b = a.Text;
            if (b.All(char.IsDigit) == false)
                this.errorPr.SetError(a,"Ban phai nhap so");
            else
                this.errorPr.Clear();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            txtKQ.Enabled = false;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Ban muốn thoat?", "Thoat",
                MessageBoxButtons.YesNo);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float a, b;
            try
            {

                a = float.Parse(txtA.Text);
                b = float.Parse(txtB.Text);
                txtKQ.Text = (a + b).ToString();
            }
            catch(Exception ex)
            {
               
                MessageBox.Show("Loi" +  ex);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            float a, b;
            validation(txtA);
            validation(txtB);
            a = float.Parse(txtA.Text);
            b = float.Parse(txtB.Text);
            txtKQ.Text = (a - b).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            float a, b;
            a = float.Parse(txtA.Text);
            b = float.Parse(txtB.Text);
            txtKQ.Text = (a * b).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            float a, b;
            a = float.Parse(txtA.Text);
            b = float.Parse(txtB.Text);
            txtKQ.Text = (a / b).ToString();
        }

        private void txtA_Leave(object sender, EventArgs e)
        {
            validation(txtA);
            //string b = txtA.Text;
            //if (b.All(char.IsDigit) == false)
            //    this.errorPr.SetError(txtA, "Ban phai nhap so");
            //else
            //    this.errorPr.Clear();
        }

        private void txtB_Leave(object sender, EventArgs e)
        {
            validation(txtB);
        }
    }
}

