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
    public partial class ChiTietHoaDon : Form
    {
        public ChiTietHoaDon()
        {
            InitializeComponent();
        }

        SqlConnection conection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-V315BI4;Initial Catalog=QL_bida;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        string maHD = DATAHD.Data_maHD;
        void loaddulieu()
        {
            if (conection != null && conection.State == ConnectionState.Closed)
            {
                conection.Open();
            }

            if (conection != null && conection.State == ConnectionState.Open)
            {
                command = conection.CreateCommand();

                command.CommandText = "SELECT maMA, tenMonAn, donGia FROM ChiTietHoaDon WHERE maHD = @maHD";
                command.Parameters.AddWithValue("@maHD", maHD);
                adapter.SelectCommand = command;
                if (table != null)
                {
                    table.Clear();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                    dataGridView1.Columns[0].HeaderText = "Mã món ăn";
                    dataGridView1.Columns[1].HeaderText = "Tên món ăn";
                    dataGridView1.Columns[2].HeaderText = "Giá";
                }
                else
                {

                }
            }
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

        private void ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT maHD FROM chitietHoaDon WHERE maHD = @maHD";
                    command.Parameters.AddWithValue("@maHD", maHD);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string ten = reader["maHD"].ToString();
                        label2.Text = ten;
                    }
                }
            }
            conection = new SqlConnection(str);
            conection.Open();
            loaddulieu();
            canChinh();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
