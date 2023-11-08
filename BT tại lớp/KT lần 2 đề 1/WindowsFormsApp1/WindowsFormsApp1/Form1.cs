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
namespace WindowsFormsApp1
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
            DataTable lopTable = HS.Tables["HOCSINH"];
            string maHS = textBox1.Text;
            string hoTen = textBox2.Text;
            string maLop = comboBox1.Text;
            string noiSinh = textBox4.Text;
            string ngaySinhText = textBox5.Text;
            if (DateTime.TryParse(ngaySinhText, out DateTime ngaySinh))
            {
                DataRow newRow = lopTable.NewRow();
                newRow["MaHS"] = maHS;
                newRow["HoTen"] = hoTen;
                newRow["MaLop"] = maLop;
                newRow["NoiSinh"] = noiSinh;
                newRow["NgaySinh"] = ngaySinh;
                lopTable.Rows.Add(newRow);
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                comboBox1.Text = string.Empty;
                textBox4.Text = string.Empty;
                textBox5.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Định dạng ngày tháng không hợp lệ. Vui lòng nhập ngày hợp lệ (ví dụ: YYYY-MM-DD)");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                DataTable lopTable = HS.Tables["HOCSINH"];
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM HOCSINH", cn);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);
                da.Update(lopTable);
                cn.Close();
                MessageBox.Show("Dữ liệu đã được lưu thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }
        }
        void LoadDuLieuDataG()
        {
            string strsel = "SELECT * FROM HOCSINH";
            SqlDataAdapter da_Khoa = new SqlDataAdapter(strsel, cn);
            da_Khoa.Fill(HS, "HOCSINH");
            dataGridView1.DataSource = HS.Tables["HOCSINH"];
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDuLieuDataG();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string maHS = selectedRow.Cells["MaHS"].Value.ToString();
                string hoTen = selectedRow.Cells["HoTen"].Value.ToString();
                string maLop = selectedRow.Cells["MaLop"].Value.ToString();
                string noiSinh = selectedRow.Cells["NoiSinh"].Value.ToString();
                string ngaySinh = selectedRow.Cells["NgaySinh"].Value.ToString();

                textBox2.ReadOnly = false;  
                comboBox1.Enabled = true;
                textBox4.ReadOnly = false;  
                textBox5.ReadOnly = false;
                textBox1.Text = maHS;
                textBox2.Text = hoTen;
                comboBox1.Text = maLop;
                textBox4.Text = noiSinh;
                textBox5.Text = ngaySinh;
                textBox1.ReadOnly = true;
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            //Form2 form2 = new Form2();
            //form2.Show();
        }
    }
}
