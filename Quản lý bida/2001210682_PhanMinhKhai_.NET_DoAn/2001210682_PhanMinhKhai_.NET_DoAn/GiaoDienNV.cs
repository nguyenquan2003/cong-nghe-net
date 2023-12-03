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

namespace _2001210682_PhanMinhKhai_.NET_DoAn
{
    public partial class GiaoDienNV : Form
    {
        public GiaoDienNV()
        {
            InitializeComponent();
        }

        SqlConnection conection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-V315BI4;Initial Catalog=QL_bida;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public void loaddulieu()
        {
            if (conection != null && conection.State == ConnectionState.Closed)
            {
                conection.Open();
            }
            else
            {

            }
        }
        string maNV = DATANV.Data_maNV;

        private Form currentFormChild;
        private void OpenChilForm(Form childForm)
        {
            if(currentFormChild!=null)
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

        void canChinh()
        {
            // Lấy chiều rộng và chiều cao của màn hình
            int screenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

            // Đặt tọa độ của form ở giữa màn hình
            this.Top = (screenHeight - this.Height) / 2;
            this.Left = (screenWidth - this.Width) / 2;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChilForm(new MenuNV());
            label1.Text = button1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChilForm(new DanhSachBan());
            label1.Text = button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChilForm(new LichSuCaNV());
            label1.Text = button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChilForm(new KhachHang());
            label1.Text = button4.Text;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dn = new DangNhap();
            dn.ShowDialog();
            dn = null;
            return;
        }

        private void GiaoDienNV_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT hoTen FROM NHANVIEN WHERE maNV = @maNV";
                    command.Parameters.AddWithValue("@maNV", maNV);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string ten = reader["hoTen"].ToString();
                        label3.Text = ten;
                    }
                }
            }
            canChinh();
        }
    }
}
