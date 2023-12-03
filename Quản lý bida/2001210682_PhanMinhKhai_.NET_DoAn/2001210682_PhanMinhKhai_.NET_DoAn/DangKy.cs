using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace _2001210682_PhanMinhKhai_.NET_DoAn
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }

        private const string DDfile = @"../../DSdangky.txt";
        public class NhanVien
        {
            public string MaNV { get; set; }
            public string HoTen { get; set; }
            public string SoDT { get; set; }
            public string TaiKhoan { get; set; }
            public string MatKhau { get; set; }
            public NhanVien(string manv, string hoten, string sodt, string taikhoan, string matkhau)
            {
                MaNV = manv;
                HoTen = hoten;
                SoDT = sodt;
                TaiKhoan = taikhoan;
                MatKhau = matkhau;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Chỉ cho nhập số (textbox số điện thoại)
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //kiểm tra mã nhân viên đã có hay chưa
            string maNhanVien = textBox1.Text;
            string DDfile = @"../../DSdangky.txt";
            using (StreamReader reader = new StreamReader(DDfile))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line.Split('|')[0] == maNhanVien)
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng nhập mã nhân viên khác.");
                        return;
                    }
                }
            }
            //kiểm tra tài khoản đã có hay chưa
            string tenTK = textBox4.Text;
            using (StreamReader reader = new StreamReader(DDfile))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split('|');
                    if (parts.Length >= 4 && parts[4] == tenTK)
                    {
                        MessageBox.Show("Tài khoản đã tồn tại. Vui lòng chọn tên tài khoản khác.");
                        return;
                    }
                }
            }

            //lấy dữ liệu
            string hoTen = textBox2.Text;
            string soDienThoai = textBox3.Text;
            string tenTaiKhoan = textBox4.Text;
            string gioitinh = radioButton1.Checked ? "Nam" : "Nữ";
            string matKhau = textBox5.Text;
            string xacNhanMatKhau = textBox6.Text;

            //kiểm tra mật khẩu và xác nhận mật khẩu có giống nhau không
            if (matKhau != xacNhanMatKhau)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp. Vui lòng nhập lại.");
                return;
            }
            // Thêm dữ liệu vào file txt
            string data = "\n" + maNhanVien + "|" + hoTen + "|" + soDienThoai + "|" + gioitinh + "|" + tenTaiKhoan + "|" + matKhau;
            using (StreamWriter writer = new StreamWriter(DDfile, true))
            {
                writer.Write(data);
            }

            MessageBox.Show("Đăng ký thành công.");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox5.PasswordChar == '*')
            {
                pictureBox2.BringToFront();
                textBox5.PasswordChar = '\0';
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox5.PasswordChar == '\0')
            {
                pictureBox1.BringToFront();
                textBox5.PasswordChar = '*';
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (textBox6.PasswordChar == '*')
            {
                pictureBox4.BringToFront();
                textBox6.PasswordChar = '\0';
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (textBox6.PasswordChar == '\0')
            {
                pictureBox3.BringToFront();
                textBox6.PasswordChar = '*';
            }
        }


    }
}
