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
    public partial class QLNV : Form
    {
        public QLNV()
        {
            InitializeComponent();
        }

        SqlConnection conection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-V315BI4;Initial Catalog=QL_bida;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        //SqlConnection conection;
        //SqlCommand command;
        //string str = DataHolder.str;
        //SqlDataAdapter adapter = new SqlDataAdapter();
        //DataTable table = new DataTable();  

        void loaddulieu()
        {
            if (conection != null && conection.State == ConnectionState.Closed)
            {
                conection.Open();
            }

            if (conection != null && conection.State == ConnectionState.Open)
            {
                command = conection.CreateCommand();
                command.CommandText = "SELECT * FROM nhanvien";
                adapter.SelectCommand = command;


                if (table != null)
                {
                    table.Clear();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                    dataGridView1.Columns[0].HeaderText = "Mã nhân viên";
                    dataGridView1.Columns[1].HeaderText = "Họ và tên";
                    dataGridView1.Columns[2].HeaderText = "Giới tính";
                    dataGridView1.Columns[3].HeaderText = "Ngày sinh";
                    dataGridView1.Columns[4].HeaderText = "CCCD";
                    dataGridView1.Columns[5].HeaderText = "Số ĐT";
                    dataGridView1.Columns[6].HeaderText = "Quê Quán";
                    dataGridView1.Columns[7].HeaderText = "Địa chỉ";
                    dataGridView1.Columns[8].HeaderText = "Chức vụ";
                }
                else
                {

                }
            }
            else
            {

            }
        }

        public void TimNV(string maNV)
        {
            if (conection != null && conection.State == ConnectionState.Closed)
            {
                conection.Open();
            }

            if (conection != null && conection.State == ConnectionState.Open)
            {
                command = conection.CreateCommand();

                command.CommandText = "SELECT * FROM nhanvien Where maNV = @maNV";
                command.Parameters.AddWithValue("@maNV", maNV);
                adapter.SelectCommand = command;
                if (table != null)
                {
                    table.Clear();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                    dataGridView1.Columns[0].HeaderText = "Mã nhân viên";
                    dataGridView1.Columns[1].HeaderText = "Họ và tên";
                    dataGridView1.Columns[2].HeaderText = "Giới tính";
                    dataGridView1.Columns[3].HeaderText = "Ngày sinh";
                    dataGridView1.Columns[4].HeaderText = "CCCD";
                    dataGridView1.Columns[5].HeaderText = "Số ĐT";
                    dataGridView1.Columns[6].HeaderText = "Quê Quán";
                    dataGridView1.Columns[7].HeaderText = "Địa chỉ";
                    dataGridView1.Columns[8].HeaderText = "Chức vụ";
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
                MessageBox.Show("Nhân viên:'" + textBox4.Text + "' không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                refresh();
                textBox4.Clear();

            }
        }

        private void QLNV_Load(object sender, EventArgs e)
        {
            button6.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox1.Enabled = false;
            textBox7.Enabled = false;
            dateTimePicker1.Enabled = false;
            textBox8.Enabled = false;
            textBox2.Enabled = false;
            textBox9.Enabled = false;
            textBox3.Enabled = false;
            conection = new SqlConnection(str);
            conection.Open();
            loaddulieu();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                int i;
                i = dataGridView1.CurrentRow.Index;
                textBox1.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                textBox3.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
                textBox5.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                textBox6.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
                textBox7.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                textBox8.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
                textBox9.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TimNV(textBox4.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemNV themnv = new ThemNV();
            themnv.ShowDialog();
        }

        public DataGridView GetDataGridView()
        {
            return dataGridView1;
        }

        void refresh()
        {
            textBox5.Clear();
            textBox6.Clear();
            textBox1.Clear();
            textBox7.Clear();
            dateTimePicker1.Text = DateTime.Now.ToString();
            textBox8.Clear();
            textBox2.Clear();
            textBox9.Clear();
            textBox3.Clear();
            loaddulieu();
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


                    string maNV = textBox5.Text;
                    command.CommandText = "DELETE FROM nhanvien WHERE manv = @manv_ql";
                    command.Parameters.AddWithValue("@manv_ql", maNV);
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

        private void button5_Click(object sender, EventArgs e)
        {
            textBox6.Enabled = true;
            textBox1.Enabled = true;
            textBox7.Enabled = true;
            dateTimePicker1.Enabled = true;
            textBox8.Enabled = true;
            textBox2.Enabled = true;
            textBox9.Enabled = true;
            textBox3.Enabled = true;
            button6.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            command.CommandText = "UPDATE NHANVIEN SET hoTen = @tenNV, ngaySinh = @ngaySinh, gioiTinh = @gioiTinh, CCCD = @cccd, queQuan = @queQuan, diaChi = @diachi, sdt = @sdt, chucvu = @chucvu WHERE maNV = @maNv";

            command.Parameters.AddWithValue("@tenNV", textBox1.Text);
            command.Parameters.AddWithValue("@ngaySinh", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@gioiTinh", textBox7.Text);
            command.Parameters.AddWithValue("@cccd", textBox2.Text);
            command.Parameters.AddWithValue("@queQuan", textBox8.Text);
            command.Parameters.AddWithValue("@diachi", textBox9.Text);
            command.Parameters.AddWithValue("@sdt", textBox3.Text);
            command.Parameters.AddWithValue("@chucvu", textBox6.Text);
            command.Parameters.AddWithValue("@maNv", textBox5.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Dữ liệu đã được sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox1.Enabled = false;
            textBox7.Enabled = false;
            dateTimePicker1.Enabled = false;
            textBox8.Enabled = false;
            textBox2.Enabled = false;
            textBox9.Enabled = false;
            textBox3.Enabled = false;
            button6.Enabled = false;
        }
    }
}
