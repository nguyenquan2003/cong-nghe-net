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
    public partial class KhachHang : Form
    {
        public KhachHang()
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
                command.CommandText = "SELECT * FROM khachhang";
                adapter.SelectCommand = command;


                if (table != null)
                {
                    table.Clear();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                    dataGridView1.Columns[0].HeaderText = "Mã khách hàng";
                    dataGridView1.Columns[1].HeaderText = "Họ và tên";
                    dataGridView1.Columns[2].HeaderText = "Số điện thoại";
                    dataGridView1.Columns[3].HeaderText = "Email";
                }
                else
                {

                }
            }
            else
            {

            }
        }

        public void TimKH(string maKH)
        {
            if (conection != null && conection.State == ConnectionState.Closed)
            {
                conection.Open();
            }

            if (conection != null && conection.State == ConnectionState.Open)
            {
                command = conection.CreateCommand();

                command.CommandText = "SELECT * FROM khachhang Where maKH = @maKH";
                command.Parameters.AddWithValue("@maKH", maKH);
                adapter.SelectCommand = command;
                if (table != null)
                {
                    table.Clear();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                    dataGridView1.Columns[0].HeaderText = "Mã khách hàng";
                    dataGridView1.Columns[1].HeaderText = "Họ và tên";
                    dataGridView1.Columns[2].HeaderText = "Số điện thoại";
                    dataGridView1.Columns[3].HeaderText = "Email";
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
                MessageBox.Show("Khách hàng:'"+textBox4.Text+"' không tồn tại" , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //RefreshDataGridView();
                textBox4.Clear();

            }
        }

        public void refresh()
        {

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox4.Clear();
            loaddulieu();
        }

        void DTGV()
        {
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 180;
            dataGridView1.Columns[2].Width = 107;
            dataGridView1.Columns[3].Width = 200;
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox5.Enabled = false;
            conection = new SqlConnection(str);
            conection.Open();
            loaddulieu();
            DTGV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimKH(textBox4.Text);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.RowCount > 0)
            {
                int i;
                i = dataGridView1.CurrentRow.Index;
                textBox1.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                textBox5.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ThemKH themkh = new ThemKH();
            themkh.ShowDialog();
        }

        internal DataGridView GetDataGridView()
        {
            return dataGridView1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var transaction = conection.BeginTransaction())
            {
                try
                {
                    command = conection.CreateCommand();
                    command.Transaction = transaction;


                    string maKH = textBox5.Text;
                    command.CommandText = "DELETE FROM khachhang WHERE makh = @makh_ql";
                    command.Parameters.AddWithValue("@makh_ql", maKH);
                    int rowsAffectedTL = command.ExecuteNonQuery();
                    // Nếu cả bốn hành động xóa thành công, commit transaction
                    if (rowsAffectedTL >= 0)
                    {
                        transaction.Commit();
                        MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        //loaddulieu();
                    }
                    else
                    {
                        // Hành động xóa không thành công, rollback transaction
                        transaction.Rollback();
                        MessageBox.Show("Không thể xóa dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi và rollback transaction nếu có lỗi xảy ra
                    transaction.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
