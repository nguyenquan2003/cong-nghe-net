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
    public partial class ThemMenu : Form
    {
        public ThemMenu()
        {
            InitializeComponent();
        }

        SqlConnection conection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-V315BI4;Initial Catalog=QL_bida;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        MenuQL menuql = new MenuQL();

        public void loaddulieu()
        {
            if (conection != null && conection.State == ConnectionState.Closed)
            {
                conection.Open();
            }

            if (conection != null && conection.State == ConnectionState.Open)
            {
                command = conection.CreateCommand();
                command.CommandText = "SELECT * FROM danhsachmonan";
                adapter.SelectCommand = command;

                if (table != null)
                {
                    table.Clear();
                    adapter.Fill(table);
                    DataGridView dtgv = menuql.GetDataGridView();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (conection == null)
            {
                conection = new SqlConnection(str);
                conection.Open();
                loaddulieu(); ;
            }


            try
            {
                command = conection.CreateCommand();
                command.CommandText = "INSERT INTO DanhSachMonAn VALUES(@maMA, @tenMonAn, @DVT, @dongia)";

                command.Parameters.AddWithValue("@maMA", textBox1.Text);
                command.Parameters.AddWithValue("@tenmonan", textBox2.Text);
                command.Parameters.AddWithValue("@DVT", comboBox1.Text);
                command.Parameters.AddWithValue("@dongia", textBox4.Text);

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

        private void ThemMenu_Load(object sender, EventArgs e)
        {
            loaddulieu();
        }
    }
}
