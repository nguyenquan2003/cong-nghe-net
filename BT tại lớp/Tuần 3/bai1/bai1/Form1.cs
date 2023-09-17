using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txt_so_a_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '-' || e.KeyChar == (char)Keys.Back)
                //||e.KeyChar==(char)Keys.Delete)
                errorProvider1.Clear();
            else
                errorProvider1.SetError(txt_so_a, "Loi");
        }

        //private void txt_so_a_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
        //    {
        //        e.Handled = true;
        //        String message = "Khong phai so nhap lai";
        //        String title = "Thong bao";
        //        MessageBox.Show(message, title);
        //    }
        //}

        private void txt_so_a_Leave(object sender, EventArgs e)
        {
             //kiem tra ko co du lieu
            if (txt_so_a.Text.Trim().Length == 0)
            {
                String message = "ban chua nhap du lieu";
                String title = "Thong bao";
                MessageBox.Show(message, title);
            }

        }

        private void txt_so_kq_Click(object sender, EventArgs e)
        {
        //    string s = "Ket qua la: \n";
        //    float a = float.Parse(txt_so_a.Text);
        //    float b = float.Parse(txt_so_b.Text);
        //    tinhToan dt = new tinhToan(a, b);
        //    if (rd_cong.Checked)
        //    {
        //        txt_so_kq.Text = dt.Cong().ToString();
        //        MessageBox.Show(s + a + "+" + b + "=" + dt.Cong(), "thong bao ket qua");
        //    }
        //    else if (rd_tru.Checked)
        //    {
        //        txt_so_kq.Text = dt.Cong().ToString();
        //        MessageBox.Show(s + a + "-" + b + "=" + dt.Tru(), "thong bao ket qua");
        //    }
        //    else if (rd_tich.Checked)
        //    {
        //        txt_so_kq.Text = dt.Nhan().ToString();
        //        MessageBox.Show(s + a + "*" + b + "=" + dt.Nhan(), "thong bao ket qua");
        //    }
        //    else if (rd_thuong.Checked)
        //    {
        //        txt_so_kq.Text = dt.Chia().ToString();
        //        MessageBox.Show(s + a + "/" + b + "=" + dt.Chia(), "thong bao ket qua");
        //    }
        //    else
        //        MessageBox.Show("phep chia bi loi.","thong bao ket qua");
        }

        public class tinhToan
        {
            float _a, _b;
            public float a
            {
                get { return _a; }
                set { _a = value; }
            }
            public float b
            {
                get { return _b; }
                set { _b = value; }
            }
            public tinhToan()
            {
                a = b = 0;
            }

            public tinhToan(float a, float b)
            {
                _a = a;
                _b = b;
            }
            public float Cong() { return _a + _b; }
            public float Tru() { return _a - _b; }
            public float Nhan() { return _a * _b; }

            public float Chia() { return _a / _b; }
        }

        // su kien xay ra khi thay doi txt a
        private void txt_so_a_TextChanged(object sender, EventArgs e)
        {
            if (txt_so_a.Text.Trim().Length > 0 && !Char.IsDigit(txt_so_a.Text, txt_so_a.Text.Trim().Length - 1)) // neu xoa het se loi
            {
                String message = "";
                String title = "Thong bao";
                MessageBox.Show(message, title);
            }
        }

        private void txt_so_b_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '-' || e.KeyChar == '.'))
            {
                e.Handled = true;
                errorProvider1.SetError(txt_so_b, "Nhap so");
            }
            else
                errorProvider1.Clear();
        }

        private void txt_so_b_TextChanged(object sender, EventArgs e)
        {
            //if (txt_so_a.Text.Trim().Length > 0 && !Char.IsDigit(txt_so_a.Text, txt_so_a.Text.Trim().Length - 1)) // neu xoa het se loi
            //{
            //    String message = "";
            //    String title = "Thong bao";
            //    MessageBox.Show(message, title);
            //}
        }

        private void btn_tinh_Click(object sender, EventArgs e)
        {
            string s = "Ket qua la: \n";
            float a = float.Parse(txt_so_a.Text);
            float b = float.Parse(txt_so_b.Text);
            tinhToan dt = new tinhToan(a, b);
            if (rd_cong.Checked)
            {
                txt_so_kq.Text = dt.Cong().ToString();
                MessageBox.Show(s + a + "+" + b + "=" + dt.Cong(), "thong bao ket qua");
            }
            else if (rd_tru.Checked)
            {
                txt_so_kq.Text = dt.Tru().ToString();
                MessageBox.Show(s + a + "-" + b + "=" + dt.Tru(), "thong bao ket qua");
            }
            else if (rd_tich.Checked)
            {
                txt_so_kq.Text = dt.Nhan().ToString();
                MessageBox.Show(s + a + "*" + b + "=" + dt.Nhan(), "thong bao ket qua");
            }
            else if (rd_thuong.Checked)
            {
                if(b!=0)
                {

                    txt_so_kq.Text = dt.Chia().ToString();
                    MessageBox.Show(s + a + "/" + b + "=" + dt.Chia(), "thong bao ket qua");
                }
           
                 else
                    MessageBox.Show("phep chia bi loi.", "thong bao ket qua");
            }
        }


    }
}
