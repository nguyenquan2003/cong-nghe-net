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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLSV
{
    public partial class Form9 : Form
    {

        private Form8 form8;
        //string connectionString = @"Data Source=LAPTOP-65O2D3FN;Initial Catalog=DIEMDANH;Integrated Security=True";
        string connectionString = @"Data Source=DESKTOP-0MNS8CK\SQLEXPRESS;Initial Catalog=qldiemdanh4ll11;Integrated Security=True";
        //public string SelectedCellValue { get; set; }
        // public string StudentID { get; set; }
        private string maSV;
        private string a;
      
        public Form9(Form8 form8, string maSV, string a)
        {
            InitializeComponent();
            this.form8 = form8;
            this.maSV = maSV;
            this.a = a;
            //label3.Text = maSV;
            //label4.Text=a;
            tenlopmonhoc();
            LoadData();

        }
        void tenlopmonhoc()
        {
            //string connectionString = @"Data Source=LAPTOP-65O2D3FN;Initial Catalog=DIEMDANH;Integrated Security=True";
            //string query = "select tenLopMh from Lopmonhoc where malopMH=@maLop";
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    SqlCommand command = new SqlCommand(query, connection);
            //    try
            //    {
            //        connection.Open();
            //        command.Parameters.AddWithValue("@malop", a);
            //        SqlDataReader reader = command.ExecuteReader();
            //        if (reader.Read())
            //        {
            //            // Lấy giá trị từ cột "ColumnName"
            //            string value = reader.GetString(reader.GetOrdinal("malopMH"));

            //            // Hiển thị kết quả trên TextBox
            //            textBox1.Text = value;
            //            textBox1.Enabled = false;




            //        }
            //        reader.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}
        }
        private void LoadData()
        {
            tenlopmonhoc();
            string maSinhVien = maSV;
            string maLop = a;
            try
            {
                string connectionString = @"Data Source=DESKTOP-0MNS8CK\SQLEXPRESS;Initial Catalog=qldiemdanh4ll11;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT CONCAT(DAY(Ngay), '-', MONTH(Ngay), '-', YEAR(Ngay)) AS Ngay,
            SUM(CONVERT(INT, VangCoPhep)) AS VangCoPhep, SUM(CONVERT(INT, VangKhongPhep)) AS VangKhongPhep,
            GhiChu FROM DIEMDANH WHERE MaSV = @maSinhVien AND(VangCoPhep = 1 OR VangKhongPhep = 1)
            AND MaLopMH = @maLop GROUP BY CONCAT(DAY(Ngay), '-', MONTH(Ngay), '-', YEAR(Ngay)), GhiChu";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@maSinhVien", maSinhVien);
                    cmd.Parameters.AddWithValue("@maLop", a);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.AllowUserToAddRows = false;

                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        column.ReadOnly = true;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            tenlopmonhoc();
            textBox1.Text = Form8.TenMonHoc; // lấy giá trị của giá trị của biến MonHoc từ Form8.
        }

        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {

            this.form8.Show();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.form8.Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
       
    }
}
