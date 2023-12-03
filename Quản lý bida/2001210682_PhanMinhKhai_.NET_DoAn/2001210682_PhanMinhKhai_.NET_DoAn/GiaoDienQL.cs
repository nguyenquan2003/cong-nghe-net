using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2001210682_PhanMinhKhai_.NET_DoAn
{
    public partial class GiaoDienQL : Form
    {
        public GiaoDienQL()
        {
            InitializeComponent();
        }

        private Form currentFormChild;
        private void OpenChilForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel3.Controls.Add(childForm);
            panel3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dn = new DangNhap();
            dn.ShowDialog();
            dn = null;
            return;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChilForm(new QLNV());
            label1.Text = button5.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChilForm(new KhachHang());
            label1.Text = button4.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChilForm(new MenuQL());
            label1.Text = button1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChilForm(new DanhSachBan());
            label1.Text = button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChilForm(new LichSuCaQL());
            label1.Text = button3.Text;
        }

        private void GiaoDienQL_Load(object sender, EventArgs e)
        {
            // Lấy chiều rộng và chiều cao của màn hình
            int screenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

            // Đặt tọa độ của form ở giữa màn hình
            this.Top = (screenHeight - this.Height) / 2;
            this.Left = (screenWidth - this.Width) / 2;
        }
    }
}
