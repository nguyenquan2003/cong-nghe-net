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
    public partial class ThemNV : Form
    {
        public ThemNV()
        {
            InitializeComponent();
        }

        SqlConnection conection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-V315BI4;Initial Catalog=QL_bida;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        QLNV nv = new QLNV();
        public void loaddulieu()
        {
            if (conection != null && conection.State == ConnectionState.Closed)
            {
                conection.Open();
            }

            if (conection != null && conection.State == ConnectionState.Open)
            {
                command = conection.CreateCommand();
                command.CommandText = "SELECT * FROM nhanvien";
                adapter.SelectCommand = command;

                if (table != null)
                {
                    table.Clear();
                    adapter.Fill(table);
                    DataGridView dtgv = nv.GetDataGridView();
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
                loaddulieu(); ;
            }


            try
            {
                string ngaysinh = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                command = conection.CreateCommand();
                command.CommandText = "INSERT INTO nhanvien VALUES(@manv, @hoten, @gioitinh, @ngaysinh, @cccd, @sdt, @quequan, @diachi, @chucvu)";

                command.Parameters.AddWithValue("@manv", textBox1.Text);
                command.Parameters.AddWithValue("@hoten", textBox2.Text);
                command.Parameters.AddWithValue("@gioitinh", comboBox1.Text);
                command.Parameters.AddWithValue("@ngaysinh", ngaysinh);
                command.Parameters.AddWithValue("@cccd", textBox5.Text);
                command.Parameters.AddWithValue("@sdt", textBox6.Text);
                command.Parameters.AddWithValue("@quequan", textBox7.Text);
                command.Parameters.AddWithValue("@diachi", textBox8.Text);
                command.Parameters.AddWithValue("@chucvu", comboBox2.Text);

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
