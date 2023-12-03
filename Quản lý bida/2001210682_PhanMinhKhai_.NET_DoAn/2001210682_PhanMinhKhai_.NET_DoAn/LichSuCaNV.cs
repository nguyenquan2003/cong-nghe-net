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
    public partial class LichSuCaNV : Form
    {
        public LichSuCaNV()
        {
            InitializeComponent();
        }

        SqlConnection conection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-V315BI4;Initial Catalog=QL_bida;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        string maNV = DATANV.Data_maNV;
        void loaddulieu()
        {
            if (conection != null && conection.State == ConnectionState.Closed)
            {
                conection.Open();
            }

            if (conection != null && conection.State == ConnectionState.Open)
            {
                command = conection.CreateCommand();

                command.CommandText = "SELECT maHD,maban,tenKH,tongtien,ngayHD FROM HoaDon WHERE maNV = @maNV";
                command.Parameters.AddWithValue("@maNV", maNV);
                adapter.SelectCommand = command;
                if (table != null)
                {
                    table.Clear();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                    dataGridView1.Columns[0].HeaderText = "Mã hóa đơn";
                    dataGridView1.Columns[1].HeaderText = "mã bàn";
                    dataGridView1.Columns[2].HeaderText = "Tên khách hàng";
                    dataGridView1.Columns[3].HeaderText = "Tổng tiền";
                    dataGridView1.Columns[4].HeaderText = "Ngày";
                }
                else
                {

                }
            }
        }

        void DTGV()
        {
            dataGridView1.Columns[0].Width = 170;
            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[2].Width = 170;
            dataGridView1.Columns[3].Width = 190;
            dataGridView1.Columns[4].Width = 185;
        }

        void TimKH(string tenKH)
        {
            if (conection != null && conection.State == ConnectionState.Closed)
            {
                conection.Open();
            }

            if (conection != null && conection.State == ConnectionState.Open)
            {
                command = conection.CreateCommand();

                command.CommandText = "SELECT maHD,soban,tenKH,tongtien,ngayHD FROM HoaDon WHERE tenKH = @tenKH";
                command.Parameters.AddWithValue("@tenKH", tenKH);
                adapter.SelectCommand = command;
                if (table != null)
                {
                    table.Clear();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
                else
                {

                }
            }
            if (dataGridView1.Rows.Count > 1)
            {
                //MessageBox.Show("Đã tìm thấy nhân viên có mã: " + textBox4.Text);
                return;
            }

            else
            {
                MessageBox.Show("Không có khách hàng tên:'" + textBox1.Text + "' không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                loaddulieu();
                textBox1.Clear();

            }
        }

        private void LichSuCaNV_Load(object sender, EventArgs e)
        {
            conection = new SqlConnection(str);
            conection.Open();
            loaddulieu();
            DTGV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimKH(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loaddulieu();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy giá trị của cột đầu tiên trong hàng được chọn
            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

            if (selectedRow.Cells.Count > 0)
            {
                object firstCellValue = selectedRow.Cells[0].Value;
                // Chuyển đổi giá trị sang kiểu string
                string stringValue = (firstCellValue != null) ? firstCellValue.ToString() : "";
                // Hiển thị giá trị trong MessageBox
                DATAHD.Data_maHD = stringValue;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChiTietHoaDon cthd = new ChiTietHoaDon();
            cthd.ShowDialog();
        }
    }

    public static class DATAHD
    {
        public static string Data_maHD { get; set; }
    }
}
