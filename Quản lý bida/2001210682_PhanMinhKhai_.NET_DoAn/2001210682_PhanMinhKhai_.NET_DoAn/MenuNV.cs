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
    public partial class MenuNV : Form
    {
        public MenuNV()
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
                command.CommandText = "SELECT mama, tenmonan, dongia FROM danhsachmonan";
                adapter.SelectCommand = command;


                if (table != null)
                {
                    table.Clear();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                    dataGridView1.Columns[0].HeaderText = "Mã món ăn";
                    dataGridView1.Columns[1].HeaderText = "Tên món ăn";
                    dataGridView1.Columns[2].HeaderText = "Đơn giá";
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
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
        }

        public void TimMA(string maMA)
        {
            if (conection != null && conection.State == ConnectionState.Closed)
            {
                conection.Open();
            }

            if (conection != null && conection.State == ConnectionState.Open)
            {
                command = conection.CreateCommand();

                command.CommandText = "SELECT mama, tenmonan, dongia FROM DanhSachMonan Where tenMonAn = @maMA";
                command.Parameters.AddWithValue("@maMA", maMA);
                adapter.SelectCommand = command;
                if (table != null)
                {
                    table.Clear();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                    dataGridView1.Columns[0].HeaderText = "Mã món ăn";
                    dataGridView1.Columns[1].HeaderText = "Tên món ăn";
                    dataGridView1.Columns[2].HeaderText = "Đơn giá";
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
                MessageBox.Show("Món ăn:'" + textBox1.Text + "' không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                loaddulieu();
                textBox1.Clear();

            }
        }

        void loadcbBox()
        {
            adapter = new SqlDataAdapter("select * from DanhSachBan", conection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "DSban");
            comboBox1.DataSource = ds.Tables["DSban"];
            comboBox1.DisplayMember = "soBan";
            comboBox1.ValueMember = "maBan";
        }

        void loadNgay()
        {
            DateTime nt = DateTime.Now;
            string formattedDate = nt.ToString("dddd, dd/MM/yyyy");
            label1.Text = formattedDate;
        }

        private void MenuNV_Load(object sender, EventArgs e)
        {
            conection = new SqlConnection(str);
            conection.Open();
            loaddulieu();
            DTGV();
            loadcbBox();
            loadNgay();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimMA(textBox1.Text);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    int rowIndex = dataGridView1.SelectedRows[0].Index;
            //    string data1 = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            //    string data2 = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            //    string data3 = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();

            //    // Thêm dữ liệu vào ListView
            //    ListViewItem item = new ListViewItem();
            //    item.Text = data1;
            //    item.Text = data2;
            //    item.Text = data3;
            //    listView1.Items.Add(item);
            //}

            if (e.RowIndex >= 0) // Đảm bảo double click không xảy ra trên tiêu đề cột
            {
                // Lấy dữ liệu từ hàng đã double click trong DataGridView1
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                // Tạo một hàng mới cho DataGridView2 và sao chép dữ liệu từ DataGridView1
                DataGridViewRow newRow = new DataGridViewRow();
                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    newRow.Cells.Add(new DataGridViewTextBoxCell { Value = cell.Value });
                }
                // Thêm hàng mới vào DataGridView2
                dataGridView2.Rows.Add(newRow);
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo double click không xảy ra trên tiêu đề cột
            {
                // Lấy hàng đã double click trong DataGridView2
                DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];
                // Xóa hàng đã double click khỏi DataGridView2
                dataGridView2.Rows.Remove(selectedRow);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
                int rowIndex = dataGridView1.SelectedRows[0].Index;
            string data1 = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            string data2 = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            string data3 = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            try
            {
                // Sử dụng tham số và câu lệnh SQL
                command = conection.CreateCommand();
                command.CommandText = "INSERT INTO chitiethoadon VALUES(@maHD, @maban, @maMA, @tenMonAn, @dongia)";

                // Thêm tham số và gán giá trị từ chuỗi đã được định dạng
                command.Parameters.AddWithValue("@maHD", data1);
                command.Parameters.AddWithValue("@tenMonAn", data2);
                command.Parameters.AddWithValue("@dongia", data3);
                command.Parameters.AddWithValue("@maban", comboBox1.Text);

                // Sử dụng ExecuteNonQuery để thực hiện truy vấn
                command.ExecuteNonQuery();

                loaddulieu();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi!!!" + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
              
            }

        }

    }
}
