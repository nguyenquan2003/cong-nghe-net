using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace _2001210779_NguyenNgocQuan
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-FEOO7TS;Initial Catalog=QLNHANVIEN;Integrated Security=True");
        DataSet QLNHANVIEN = new DataSet();

        void LoadDuLieuDataG()
        {
            string strsel = "SELECT * FROM NHANVIEN";
            SqlDataAdapter da_NhanVien = new SqlDataAdapter(strsel, cn);
            da_NhanVien.Fill(QLNHANVIEN, "NHANVIEN");
            dataGridView1.DataSource = QLNHANVIEN.Tables["NHANVIEN"];
            dataGridView1.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns["NgayVL"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable nhanVienTable = QLNHANVIEN.Tables["NHANVIEN"];
            string maNV = textBox1.Text;
            string hoTen = textBox2.Text;
            string maPhong = comboBox1.Text;
            string noiSinh = textBox4.Text;
            string ngaySinhText = textBox5.Text;
            string ngayVLText = textBox6.Text;
            if (DateTime.TryParse(ngaySinhText, out DateTime ngaySinh) && DateTime.TryParse(ngayVLText, out DateTime ngayVL))
            {
                DataRow newRow = nhanVienTable.NewRow();
                newRow["MaNV"] = maNV;
                newRow["HoTen"] = hoTen;
                newRow["MaPhong"] = maPhong;
                newRow["NoiSinh"] = noiSinh;
                newRow["NgaySinh"] = ngaySinh;
                newRow["NgayVL"] = ngayVLText;
                nhanVienTable.Rows.Add(newRow);
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                comboBox1.Text = string.Empty;
                textBox4.Text = string.Empty;
                textBox5.Text = string.Empty;
                textBox6.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Định dạng ngày tháng không hợp lệ. Vui lòng nhập ngày hợp lệ (ví dụ: dd/MM/yyyy)");
            }
        }

        void LoadComboBoxData()
        {
            cn.Open();
            string query = "SELECT DISTINCT MaPhong FROM NHANVIEN";
            SqlCommand cmd = new SqlCommand(query, cn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["MaPhong"].ToString());
            }
            cn.Close();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            LoadDuLieuDataG();
            LoadComboBoxData();        
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string maNV = selectedRow.Cells["MaNV"].Value.ToString();
                string hoTen = selectedRow.Cells["HoTen"].Value.ToString();
                string maPhong = selectedRow.Cells["MaPhong"].Value.ToString();
                string noiSinh = selectedRow.Cells["NoiSinh"].Value.ToString();
                DateTime ngaySinh = Convert.ToDateTime(selectedRow.Cells["NgaySinh"].Value);
                DateTime ngayVL = Convert.ToDateTime(selectedRow.Cells["NgayVL"].Value);
                textBox2.ReadOnly = false;
                comboBox1.Enabled = true;
                textBox4.ReadOnly = false;
                textBox1.ReadOnly = true;
                textBox1.Text = maNV;
                textBox2.Text = hoTen;
                comboBox1.Text = maPhong;
                textBox4.Text = noiSinh;
                textBox5.Text = ngaySinh.ToString("dd/MM/yyyy");
                textBox6.Text = ngayVL.ToString("dd/MM/yyyy"); 
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
                cn.Open();
                DataTable lopTable = QLNHANVIEN.Tables["NHANVIEN"];
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM NHANVIEN", cn);
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

        private void CloseFrom()
        {
            DialogResult kq = MessageBox.Show
            ("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            CloseFrom();
        }
    }
}
