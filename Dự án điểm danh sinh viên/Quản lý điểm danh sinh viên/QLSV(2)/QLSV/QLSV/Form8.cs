using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static  System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLSV
{
    public partial class Form8 : Form
    {
        //SqlConnection cn = new SqlConnection(@"Data Source=LAPTOP-65O2D3FN;Initial Catalog=DIEMDANH;Integrated Security=True");
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-0MNS8CK\SQLEXPRESS;Initial Catalog=qldiemdanh4ll11;Integrated Security=True");
        DataSet DiemDanh = new DataSet();
        private Form3 _form3;
        public static string TenMonHoc; //tạo một biến public static trong Form1 để lưu trữ giá trị của ô bạn muốn chuyển.

        public Form8(Form3 form3)
        {
            InitializeComponent();
            _form3 = form3;
        }
        void LoadDuLieuDataG()
        {
            string maSinhVien = _form3.Username_SV;
            textBox2.Text = maSinhVien;
            string strsel = @"SELECT MONHOC.TenMH AS TENMONHOC, DIEMDANH.MaLopMH,
    SUM( CASE WHEN DIEMDANH.VangCoPhep = 1 THEN 1 ELSE 0 END) +
    SUM( CASE WHEN DIEMDANH.VangKhongPhep = 1 THEN 1 ELSE 0 END) AS TongSoVang
    FROM DIEMDANH
    INNER JOIN LOPMONHOC ON DIEMDANH.MaLopMH = LOPMONHOC.MaLopMH
    INNER JOIN MONHOC ON LOPMONHOC.MaMH = MONHOC.MaMH
    WHERE DIEMDANH.MaSV = @maSinhVien
    GROUP BY MONHOC.TenMH, DIEMDANH.MaLopMH;";

            SqlCommand cmd = new SqlCommand(strsel, cn);
            cmd.Parameters.AddWithValue("@maSinhVien", maSinhVien);

            SqlDataAdapter da_NhanVien = new SqlDataAdapter(cmd);
            da_NhanVien.Fill(DiemDanh, "DIEMDANH");
            dataGridView1.DataSource = DiemDanh.Tables["DIEMDANH"];

            // Thêm cột "STT" vào DataGridView
            if (!dataGridView1.Columns.Contains("STT"))
            {
                DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn();
                sttColumn.Name = "STT";
                sttColumn.HeaderText = "STT";
                dataGridView1.Columns.Insert(0, sttColumn); // Thêm cột vào vị trí đầu tiên
            }

            // Cập nhật số thứ tự cho cột "STT"
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["STT"].Value = i + 1;
            }
            dataGridView1.AllowUserToAddRows = false;
        }

        private void LoadDataFromDatabase()
        {
            string maSinhVien = _form3.Username_SV;
            try
            {
                using (SqlConnection connection = cn)
                {
                    connection.Open();
                    string query = "SELECT HoTenSV, MaSV, GioiTinh, MaLop, NgaySinh FROM SINHVIEN where MaSV=@maSinhVien";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@maSinhVien", maSinhVien);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            string hoTen = reader.GetString(0);
                            //string maSV = reader.GetString(1);
                            string gioiTinh = reader.GetString(2);
                            string maLop = reader.GetString(3);
                            DateTime ngaySinh = reader.GetDateTime(4);

                            textBox1.Text = hoTen;
                            textBox3.Text = gioiTinh;
                            textBox4.Text = maLop;
                            textBox5.Text = ngaySinh.ToString("yyyy-MM-dd");
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void Form8_Load(object sender, EventArgs e)
        {
            LoadDuLieuDataG();
            LoadDataFromDatabase();
            textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[1];
                string cellValue = cell.Value.ToString();
                int index = dataGridView1.CurrentRow.Index;
                string a = dataGridView1.Rows[index].Cells[2].Value.ToString();

                TenMonHoc = dataGridView1.Rows[e.RowIndex].Cells["TENMONHOC"].Value.ToString(); //khi bạn chọn một hàng trong DataGridView, hãy cập nhật giá trị của biến MonHoc.
                Form9 f9 = new Form9(this, maSV, a);
          

                f9.Show();

                this.Hide();
            }
        }
        public string maSV
        {
            get { return textBox2.Text; }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _form3.ClearTextBoxes();
            this._form3.Show();
            this.Close();
        }
    }
}
