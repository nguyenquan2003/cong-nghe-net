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
    public partial class MenuQL : Form
    {
        public MenuQL()
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
                //command.CommandText = "SELECT * FROM danhsachmonan";
                adapter.SelectCommand = command;


                if (table != null)
                {
                    table.Clear();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                    dataGridView1.Columns[0].HeaderText = "Mã món ăn";
                    dataGridView1.Columns[1].HeaderText = "Tên món ăn";
                    dataGridView1.Columns[2].HeaderText = "Đơn giá";
                    //dataGridView1.Columns[3].HeaderText = "Đơn giá";
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
        private void MenuQL_Load(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            conection = new SqlConnection(str);
            conection.Open();
            loaddulieu();
            DTGV();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            using (var transaction = conection.BeginTransaction())
            {
                try
                {
                    command = conection.CreateCommand();
                    command.Transaction = transaction;


                    string maMA = textBox2.Text;
                    command.CommandText = "DELETE FROM danhsachmonan WHERE maMA = @maMA_ql";
                    command.Parameters.AddWithValue("@maMA_ql", maMA);
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

        public void refresh()
        {
            textBox1.Clear();
            loaddulieu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            refresh();
        }

        public DataGridView GetDataGridView()
        {
            return dataGridView1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThemMenu themnv = new ThemMenu();
            themnv.ShowDialog();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                int i;
                i = dataGridView1.CurrentRow.Index;
                textBox2.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                textBox4.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                //textBox5.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            command.CommandText = "UPDATE DanhSachMonan SET tenMonAn = @tenMA, dongia = @dongia where maMA = @maMA";

            command.Parameters.AddWithValue("@tenMA", textBox4.Text);
            command.Parameters.AddWithValue("@dongia", textBox3.Text);
            command.Parameters.AddWithValue("@maMA", textBox2.Text);

            command.ExecuteNonQuery();
            MessageBox.Show("Dữ liệu đã được sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TimMA(textBox1.Text);
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
                refresh();
                textBox1.Clear();

            }
        }
    }
}
