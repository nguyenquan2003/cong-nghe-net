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
        void ShowResult(Label lb, Panel pnl)
        {
            RadioButton ckb = null;
            foreach(RadioButton item in pnl.Controls)
            {
                if(item.Checked)
                {
                    ckb = item;
                    break;
                }
            }
            if(ckb!=null)
            {
                lb.Text = ckb.Text;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ShowResult(label1, panel1);
            ShowResult(label2, panel2);
            ShowResult(label3, panel3);

        }
        //tự động thay đổi label khi chọn radio
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio.Checked)
            {
                label1.Text = radio.Text;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio.Checked)
            {
                label2.Text = radio.Text;
            }
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio.Checked)
            {
                label3.Text = radio.Text;
            }
        }
    }
}
