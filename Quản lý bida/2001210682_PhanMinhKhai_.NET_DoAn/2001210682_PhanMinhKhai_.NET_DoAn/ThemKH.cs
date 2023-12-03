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
    public partial class ThemKH : Form
    {
        public ThemKH()
        {
            InitializeComponent();
        }

        SqlConnection conection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-V315BI4;Initial Catalog=QL_bida;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        KhachHang kh = new KhachHang();
        public void loaddulieu()
        {
            if (conection != null && conection.State == ConnectionState.Closed)
            {
                conection.Open();
            }

            if (conection != null && conection.State == ConnectionState.Open)
            {
                command = conection.CreateCommand();
                command.CommandText = "SELECT * FROM khachhang";
                adapter.SelectCommand = command;

                if (table != null)
                {
                    table.Clear();
                    adapter.Fill(table);
                    DataGridView dtgv = kh.GetDataGridView();
                    dtgv.DataSource = table;
                }
                else
                {

                }
            }
            else
            {

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (conection == null)
            {
                conection = new SqlConnection(str);
                conection.Open();
                loaddulieu();
            }


            try
            {
                // Sử dụng tham số và câu lệnh SQL
                command = conection.CreateCommand();
                command.CommandText = "INSERT INTO khachhang VALUES(@makh, @tenkh, @sdt, @email)";

                // Thêm tham số và gán giá trị từ chuỗi đã được định dạng
                command.Parameters.AddWithValue("@makh", textBox1.Text);
                command.Parameters.AddWithValue("@tenkh", textBox2.Text);
                command.Parameters.AddWithValue("@sdt", textBox3.Text);
                command.Parameters.AddWithValue("@email", textBox4.Text);

                // Sử dụng ExecuteNonQuery để thực hiện truy vấn
                command.ExecuteNonQuery();

                loaddulieu();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi!!!" + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
               
            }
            finally
            {
                loaddulieu();
                conection.Close();
                this.Close();
            }
        }
    }
}
