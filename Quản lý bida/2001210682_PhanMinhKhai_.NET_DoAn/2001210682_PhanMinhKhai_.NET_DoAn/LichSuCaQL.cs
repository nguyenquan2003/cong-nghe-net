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
    public partial class LichSuCaQL : Form
    {
        public LichSuCaQL()
        {
            InitializeComponent();
        }

        SqlConnection conection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-V315BI4;Initial Catalog=QL_bida;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddulieu()
        {
            if (conection != null && conection.State == ConnectionState.Closed)
            {
                conection.Open();
            }

            if (conection != null && conection.State == ConnectionState.Open)
            {
                command = conection.CreateCommand();
                command.CommandText = "SELECT maHD ,maNV, maBan, tenKH, ngayHD, tongTien FROM HoaDon";
                adapter.SelectCommand = command;


                if (table != null)
                {
                    table.Clear();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                    dataGridView1.Columns[0].HeaderText = "Mã hóa đơn";
                    dataGridView1.Columns[1].HeaderText = "Mã nhân viên";
                    dataGridView1.Columns[2].HeaderText = "Mã bàn";
                    dataGridView1.Columns[3].HeaderText = "Tên khách hàng";
                    dataGridView1.Columns[4].HeaderText = "Ngày hóa đơn";
                    dataGridView1.Columns[5].HeaderText = "Tổng tiền";
                }
                else
                {

                }
            }
            else
            {

            }
        }

        void DTGV()
        {
            dataGridView1.Columns[0].Width = 140;
            dataGridView1.Columns[1].Width = 145;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 150;

        }

        void TimNV(DateTime tuNgay, DateTime Denngay)
        {
            if (conection != null && conection.State == ConnectionState.Closed)
            {
                conection.Open();
            }

            if (conection != null && conection.State == ConnectionState.Open)
            {
                command = conection.CreateCommand();
                command.CommandText = "SELECT * FROM HoaDon WHERE ngayHD BETWEEN @FromDate AND @ToDate";
                command.Parameters.AddWithValue("@FromDate", tuNgay);
                command.Parameters.AddWithValue("@ToDate", Denngay);
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
                MessageBox.Show("Không có hóa đơn nào !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                loaddulieu();

            }
        }

        void refresh()
        {
            loaddulieu();
        }

        private void LichSuCaQL_Load(object sender, EventArgs e)
        {
            conection = new SqlConnection(str);
            conection.Open();
            loaddulieu();
            DTGV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimNV(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refresh();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
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
}
