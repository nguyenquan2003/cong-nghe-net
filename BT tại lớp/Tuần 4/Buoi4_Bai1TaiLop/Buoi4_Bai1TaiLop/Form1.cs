using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Buoi4_Bai1TaiLop
{
    public partial class frmTreeView : Form
    {
        public frmTreeView()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn muốn thoát?", "Thoát", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
                this.Close();
        }
        private bool kiemtra(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) // Kiểm tra chuỗi null hoặc chỉ gồm khoảng trắng
                return false;

            foreach (TreeNode node in trv_DS.Nodes)
            {
                // So sánh chuỗi không phân biệt chữ hoa và chữ thường
                if (string.Compare(node.Text, s, true) == 0)
                    return false; // Trả về false nếu đã tồn tại trong TreeView
            }

            return true; // Trả về true nếu không tồn tại trong TreeView
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Kiểm tra txt_Phongban có tồn tại trong TreeView chưa
            if (kiemtra(txt_phongban.Text))
            {
                TreeNode newNode = new TreeNode(txt_phongban.Text);
                trv_DS.Nodes.Add(newNode);
                cbo_phongban.Items.Add(txt_phongban.Text);
                txt_phongban.Text = "";
                txt_phongban.Focus();
            }
            else
            {
                MessageBox.Show("Phòng ban đã tồn tại!");
                txt_phongban.Text = "";
                txt_phongban.Focus();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Ban muốn thoat?", "Thoát",
                MessageBoxButtons.YesNo);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void frmTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] pb={"Giám đốc","Tổ chức hành chính","Kế hoạch", "Kế Toán" };
            foreach (string s in pb)
            {
                trv_DS.Nodes.Add(s); //thêm node vào treeview
                //cbo_phongban.Items.Add(s); //thêm item vào combobox
            }
            cbo_phongban.SelectedIndex = 0; //item đầu tiên trên được chọn
        }

        private void btn_XoaPB_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo",
                
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, 
                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    
            // Một phòng ban trong treeView được chọn
            if (trv_DS.SelectedNode != null)
                {
                    cbo_phongban.Items.Remove(trv_DS.SelectedNode.Text);
                    trv_DS.Nodes.Remove(trv_DS.SelectedNode);
                }
            }

        private void btn_ThemNV_Click(object sender, EventArgs e)
        {
            //tìm index của node có nội dung là item được chọn trong
            //combobox phòng ban
            int index = -1;
            foreach (TreeNode node in trv_DS.Nodes)
            {
                if (node.Text == cbo_phongban.Text)
                {
                    index = node.Index;
                    break;
                }
            }
            if (index != -1)
            {
                string hoTen = txt_hoten.Text;
                string maSo = txt_maso.Text;
                string nodeText = hoTen + " (" + maSo + ")";

                trv_DS.Nodes[index].Nodes.Add(nodeText);
                trv_DS.ExpandAll(); // Mở rộng treeview
            }
            else
            {
                MessageBox.Show("Không tìm thấy phòng ban!");
            }

        }

    }
}
