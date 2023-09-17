using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi4_Bai2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = "Dân tộc được chọn: ";
            if (cbo_dt.SelectedIndex >= 0)
                lpl_kq.Text = s + cbo_dt.SelectedItem.ToString();
            else

                lpl_kq.Text = "Bạn chưa chọn dân tộc";

        }

        private void btn_loadDL_Click(object sender, EventArgs e)
        {
            string[] dt = { "Kinh", "Hoa", "K’Me", "H’Mong", "Khác" };
            foreach (string s in dt)
            {
                cbo_dt.Items.Add(s);
            }
        }

        private void cbo_dt_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Dân tộc được chọn:" +
                cbo_dt.SelectedItem.ToString());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
