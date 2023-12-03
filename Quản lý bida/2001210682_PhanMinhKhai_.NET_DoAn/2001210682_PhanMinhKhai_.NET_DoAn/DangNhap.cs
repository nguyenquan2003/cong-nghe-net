using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace _2001210682_PhanMinhKhai_.NET_DoAn
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát ?", "Thông Báo", MessageBoxButtons.YesNo);
            if(r == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangKy dk = new DangKy();
            dk.ShowDialog();
            dk = null;
            this.Show();
            return;
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string TaiKhoan = textBox1.Text;
            string MatKhau = textBox2.Text;
            string maNV = "";
            string filePath = @"../../DSdangky.txt";
            bool dn = false;

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] userInfo = line.Split('|');

                    if (string.Compare(TaiKhoan, "admin", true) == 0 && string.Compare(MatKhau, "123", true) == 0)
                    {
                        dn = true;
                        break;
                    }
                    else if (userInfo.Length >= 6 && userInfo[4] == TaiKhoan && userInfo[5] == MatKhau)
                    {
                        dn = true;
                        maNV = userInfo[0];
                        break;

                    }
                }
            }

            if (dn)
            {
                this.Hide();
                if (string.Compare(TaiKhoan, "admin", true) == 0)
                {
                    GiaoDienQL ql = new GiaoDienQL();
                    ql.ShowDialog();
                }
                else
                {
                    DATANV.Data_maNV = maNV;
                    GiaoDienNV nv = new GiaoDienNV();
                    nv.ShowDialog();
                }

            }
            else
            {
                MessageBox.Show("Thông tin đăng nhập không chính xác. Vui lòng nhập lại!", "Thông Báo");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '*')
            {
                pictureBox2.BringToFront();
                textBox2.PasswordChar = '\0';
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '\0')
            {
                pictureBox1.BringToFront();
                textBox2.PasswordChar = '*';
            }
        }
    }

    public static class DATANV
    {
        public static string Data_maNV { get; set; }
    }
}
