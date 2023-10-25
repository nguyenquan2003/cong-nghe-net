using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool trungKhoa(string ms)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                string s = listView1.Items[i].SubItems[0].Text;  // lay ma sinh vien
                if (string.Compare(ms, s, true) == 0)
                    return false;
            }
            return true;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            //ListViewItem item = new ListViewItem();
            //ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem();

            //item.Text = txt_mssv.Text;
            //subitem.Text = txt_hoten.Text;
            //item.SubItems.Add(subitem);
            //listView1.Items.Add(item);
            if(trungKhoa(txt_mssv.Text)){
                ListViewItem item = new ListViewItem();
                item.Text = txt_mssv.Text;
                item.SubItems.Add(txt_hoten.Text);
                listView1.Items.Add(item);// dua du lieu  vao list view
            }
            else
                MessageBox.Show("Trung khoa");
        }
        

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem l in listView1.SelectedItems)
            {
                l.Remove();
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (listView1.FocusedItem != null && listView1.FocusedItem.Index >= 0)
            {
                ListViewItem item = listView1.FocusedItem;
                item.SubItems[0].Text = txt_mssv.Text;
                item.SubItems[1].Text = txt_hoten.Text;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0 )
            {
                foreach (ListViewItem i in listView1.SelectedItems)
                    i.Remove();
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


    }
}
