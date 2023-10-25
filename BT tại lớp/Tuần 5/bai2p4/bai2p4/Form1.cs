using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai2p4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e) // add combobox
        {
            string[] dt = { "Kinh", "Hoa", "Ede" };
            cbo_dt.Items.AddRange(dt);
            cbo_dt.SelectedIndex = 0;
        }

        private void btn_them_Click(object sender, EventArgs e) //them
        {
            string ht = txt_hoten.Text;
            string masv = txt_masv.Text;
            string gt;
            if (rdo_btn_nam.Checked == true)
                gt = "Nam";
            else gt = "Nu";
            string nn = "";
            if (chkb_anh.Checked == true)
                nn += "Anh ";
            if (chkb_phap.Checked == true)
                nn += "Phap ";
            if (chkb_hoa.Checked == true)
                nn += "Hoa ";
            ListViewItem item = new ListViewItem(new[] { ht, masv, gt, nn, cbo_dt.Text });
            listView1.Items.Add(item);
            txt_hoten.Clear();
            txt_masv.Clear();
            chkb_anh.Checked = false;
            chkb_phap.Checked = false;
            chkb_hoa.Checked = false;
        }

        private void listView1_Click(object sender, EventArgs e) // listview click
        {
            chkb_anh.Checked = false;
            chkb_phap.Checked = false;
            chkb_hoa.Checked = false;
            int i = listView1.FocusedItem.Index;
            txt_hoten.Text = listView1.Items[i].SubItems[0].Text;
            txt_masv.Text = listView1.Items[i].SubItems[1].Text;
            if (listView1.Items[i].SubItems[1].Text == "Nam")
                rdo_btn_nam.Checked = true;
            else
                rdo_btn_nu.Checked = true;
            cbo_dt.Text = listView1.Items[i].SubItems[4].Text;
            string[] s = listView1.Items[i].SubItems[3].Text.Trim().Split(' ');
            for (int so = 0; so < s.Length; so++)
            {
                if (s[so] == "Anh")
                    chkb_anh.Checked = true;
                if (s[so] == "Phap")
                    chkb_phap.Checked = true;
                if (s[so] == "Hoa")
                    chkb_hoa.Checked = true;
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            int i = listView1.FocusedItem.Index;
            listView1.Items[i].SubItems[0].Text = txt_hoten.Text;
            listView1.Items[i].SubItems[1].Text = txt_masv.Text;

            if (rdo_btn_nam.Checked == true)
                listView1.Items[i].SubItems[2].Text = "Nam";
            else
                listView1.Items[i].SubItems[2].Text = "Nu";
            string nn = "";
            if (chkb_anh.Checked == true)
                nn += "Anh ";
            if (chkb_phap.Checked == true)
                nn += "Phap";
            if (chkb_hoa.Checked == true)
                nn += "Hoa";
            listView1.Items[i].SubItems[3].Text = nn;
            listView1.Items[i].SubItems[4].Text = cbo_dt.Text;
        }
        

    }
}
