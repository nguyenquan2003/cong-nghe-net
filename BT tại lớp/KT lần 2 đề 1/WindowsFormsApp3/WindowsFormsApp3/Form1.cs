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

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-FEOO7TS;Initial Catalog=HOCSINH;Integrated Security=True");
        DataSet HS = new DataSet();

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable lopTable = HS.Tables["LOP"];
            string maLop = textBox2.Text;
            string tenLop = textBox1.Text;
            DataRow newRow = lopTable.NewRow();
            newRow["MaLop"] = maLop;
            newRow["TenLop"] = tenLop;
            lopTable.Rows.Add(newRow);
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string maLop = selectedRow.Cells["MaLop"].Value.ToString();
                string tenLop = selectedRow.Cells["TenLop"].Value.ToString();
                textBox1.Text = tenLop;
                textBox2.Text = maLop;
            }
            else
            {
                MessageBox.Show("Hãy chọn hàng để sửa.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                dataGridView1.Rows.Remove(selectedRow);
            }
            else
            {
                MessageBox.Show("Hãy chọn hàng để xóa.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-FEOO7TS;Initial Catalog=HOCSINH;Integrated Security=True"))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    adapter.SelectCommand = new SqlCommand("SELECT * FROM LOP", connection);
                    adapter.Update(HS, "LOP");

                    MessageBox.Show("Dữ liệu đã được lưu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }
        }

        void LoadDuLieuDataG()
        {
            string strsel = "SELECT * FROM LOP";
            SqlDataAdapter da_Khoa = new SqlDataAdapter(strsel, cn);
            da_Khoa.Fill(HS, "LOP");
            dataGridView1.DataSource = HS.Tables["LOP"];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDuLieuDataG();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            //Form2 form2 = new Form2();
            //form2.Show();
        }
        //private void CloseForm()
        //{
        //    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    if (result == DialogResult.Yes)
        //    {
        //        this.Close();
        //    }
        //}
    }
}
