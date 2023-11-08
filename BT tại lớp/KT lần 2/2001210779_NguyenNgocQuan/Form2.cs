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

namespace _2001210779_NguyenNgocQuan
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-FEOO7TS;Initial Catalog=QLNHANVIEN;Integrated Security=True");
        DataSet QLNHANVIEN = new DataSet();
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable lopTable = QLNHANVIEN.Tables["PHONGBAN"];
            string maPhong = textBox1.Text;
            string tenPhong = textBox2.Text;
            DataRow newRow = lopTable.NewRow();
            newRow["MaPhong"] = maPhong;
            newRow["TenPhong"] = tenPhong;
            lopTable.Rows.Add(newRow);
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;  
        }
        void LoadDuLieuDataG()
        {
            string strsel = "SELECT * FROM PHONGBAN";
            SqlDataAdapter da_Khoa = new SqlDataAdapter(strsel, cn);
            da_Khoa.Fill(QLNHANVIEN, "PHONGBAN");
            dataGridView1.DataSource = QLNHANVIEN.Tables["PHONGBAN"];
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadDuLieuDataG();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.Remove(selectedRow);
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn hàng để xóa.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string tenPhong = selectedRow.Cells["TenPhong"].Value.ToString(); 
                string maPhong = selectedRow.Cells["MaPhong"].Value.ToString();
                textBox1.Text = maPhong;
                textBox2.Text = tenPhong;
                textBox1.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Hãy chọn hàng để sửa.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-FEOO7TS;Initial Catalog=QLNHANVIEN;Integrated Security=True"))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    adapter.SelectCommand = new SqlCommand("SELECT * FROM PHONGBAN", connection);
                    adapter.Update(QLNHANVIEN, "PHONGBAN");

                    MessageBox.Show("Dữ liệu đã được lưu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Hide();
        }
    }
}
