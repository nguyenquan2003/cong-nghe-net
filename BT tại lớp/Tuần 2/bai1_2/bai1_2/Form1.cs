using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai1_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioBtn_bac1_CheckedChanged(object sender, EventArgs e)
        {
            txt_nhapc.Enabled = false;
        }

        private void radioBtn_bac2_CheckedChanged(object sender, EventArgs e)
        {
            txt_nhapc.Enabled = true;
        }

        private void btn_tieptuc_Click(object sender, EventArgs e)
        {
            txt_nhapa.Clear();
            txt_nhapb.Clear();
            txt_nhapc.Clear();
            txt_nhapa.Focus();
        }

        private void btn_giai_Click(object sender, EventArgs e)
        {
            int a = int.Parse(txt_nhapa.Text);
            int b = int.Parse(txt_nhapb.Text);
            double data,x1,x2;
            if (radioBtn_bac1.Checked == true)
            {
                if (a == 0 && b == 0)
                    txt_kq.Text = "PTVSN";
                else if (a == 0 && b != 0)
                    txt_kq.Text = "PTVN";
                else if (a != 0 && b != 0)
                    txt_kq.Text = (-b / a).ToString();
            }
            else
            {
                int c = int.Parse(txt_nhapc.Text);
                data = ((b * b) - (4 * a * c));
                if (data < 0)
                    txt_kq.Text = "pt vo ngh";
                else
                {
                    if (data == 0)
                        txt_kq.Text = "Pt co nghiem kep: " + (-b) / (2 * a);
                    else
                    {
                        data = Math.Sqrt(data);
                        x1 = (-b + data) / (2 * a);
                        x2 = (-b - data) / (2 * a);
                        txt_kq.Text= "Pt co 2 nghiem biet:  "+" x1= " + txt_kq.Text
                    }
                }
            }
        }



    }
}
