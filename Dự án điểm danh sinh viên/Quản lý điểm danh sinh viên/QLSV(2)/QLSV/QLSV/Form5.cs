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

namespace QLSV
{
    public partial class Form5 : Form
    {
        SqlConnection con;
        string maGiangVien;
        Form4 form4;
        public Form5(Form4 form4, string maGiangVien)
        {
            //con = new SqlConnection("Data Source=LAPTOP-65O2D3FN;Initial Catalog=DIEMDANH;Integrated Security=True");
            con = new SqlConnection(@"Data Source=DESKTOP-0MNS8CK\SQLEXPRESS;Initial Catalog=qldiemdanh4ll11;Integrated Security=True");
            InitializeComponent();
            this.maGiangVien = maGiangVien;
            this.form4 = form4; // Lưu tham chiếu đến Form4
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            con.Open();

            string sql_gv = "SELECT * FROM GiangVien WHERE MaGV = @maGiangVien";

            using (SqlCommand command = new SqlCommand(sql_gv, con))
            {
                command.Parameters.AddWithValue("@maGiangVien", maGiangVien);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    textBox1.Text = reader["MaGV"].ToString();
                    textBox2.Text = reader["HoTenGV"].ToString();
                    textBox3.Text = reader["TrinhDo"].ToString();
                    textBox4.Text = reader["ChuyenMon"].ToString();
                }
            }
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            con.Close();

        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Ban muốn thoát ?", "Thoát", MessageBoxButtons.YesNo);
            if (r == DialogResult.No)
                e.Cancel = true;
            else
                form4.Show(); // Hiển thị lại Form4 khi Form5 đóng
        }
    }
}
