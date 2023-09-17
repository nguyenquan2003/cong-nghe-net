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
    public partial class Bai4 : Form
    {
        int[] a = new int[10];
        public Bai4()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtDayso.Clear();
            txtSo.Clear();
            txtSo.Focus();
            txtTong.Clear();
            txtTongChan.Clear();
            txtTongLe.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = txtSo.Text;
            if (a.Length == 0 || a.All(char.IsDigit) == false)
            {

                MessageBox.Show("Nhap lai", "Thong bao", MessageBoxButtons.OK);
                txtSo.Focus();
            }
            else
            {

                txtDayso.Text = txtDayso.Text + a+ " ";
                txtSo.Clear();
                txtSo.Focus();
            }
        }

        private void txtSo_Leave(object sender, EventArgs e)
        {
            //string a = txtSo.Text;
            //if (a.Length == 0)
            //    MessageBox.Show("Phai nhap gia tri", "Thong bao", MessageBoxButtons.OK);
            // else
            //    if(a.All(char.IsDigit)==false)
            //        MessageBox.Show("Phai nhap so", "Thong bao", MessageBoxButtons.OK);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int tong = 0, tongchan = 0, tongle = 0;
            string s = txtDayso.Text.Trim();
            string [] a = s.Split(' ');
            //List<int> so = new List<int>();
            int so;
            // so = int.Parse(a[3]);
            //  txtTongChan.Text = so.ToString();
            //txtTongLe.Text = a.Length.ToString();
            for (int i = 0; i < a.Length; i++)
            {
                so = int.Parse(a[i]);
                tong += so;
                if (so % 2 == 0)
                    tongchan += so;
                else
                    tongle += so;
            }
            txtTong.Text = tong.ToString();
            txtTongChan.Text = tongchan.ToString();
            txtTongLe.Text = tongle.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
