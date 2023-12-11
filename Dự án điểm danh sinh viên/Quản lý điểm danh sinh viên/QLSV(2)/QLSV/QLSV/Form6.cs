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
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
//using Microsoft.Office.Interop.Excel;

namespace QLSV
{
    public partial class Form6 : Form
    {
        SqlConnection con;
        Form2 f2;
        Form4 f4;

        public string MaLopMH { get; set; }
        //string constr = "Data Source=LAPTOP-65O2D3FN;Initial Catalog=DIEMDANH;Integrated Security=True";
        string constr = "Data Source=DESKTOP-0MNS8CK\\SQLEXPRESS;Initial Catalog=qldiemdanh4ll11;Integrated Security=True";
        public Form6(Form4 f4)
        {
            //con = new SqlConnection("Data Source=LAPTOP-65O2D3FN;Initial Catalog=DIEMDANH;Integrated Security=True");
            con = new SqlConnection(@"Data Source=DESKTOP-0MNS8CK\SQLEXPRESS;Initial Catalog=qldiemdanh4ll11;Integrated Security=True");
            InitializeComponent();
            this.f4 = f4; // Khởi tạo _form4
        }
        void load_cbo()
        {
            SqlConnection connection = new SqlConnection(constr);
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT DISTINCT Ngay FROM DIEMDANH where MaLopMH= @MaLopMH", connection);
            command.Parameters.AddWithValue("@MaLopMH", MaLopMH);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cbo_ngay.Items.Add(reader.GetDateTime(0).ToString("yyyy-MM-dd"));
            }
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            load_cbo();
            tengiangvien();
            load_txt_diachi();
            load_txt_tenmh();
            txt_malop.Text = MaLopMH;
            txt_malop.Enabled = false;
            button1.Enabled = false;
            dataGridView1.Hide();
            btn_in.Enabled = false;
            dataGridView1.AllowUserToAddRows = false;
            //label16.Hide();
            //label17.Hide();
            hiendien.Hide();
            vang.Hide();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    if (dataGridView1.Columns[i] is DataGridViewCheckBoxColumn && i != e.ColumnIndex)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[i].Value = false;
                    }
                }
            }
        }
        void load_txt_tenmh()
        {
            string query = "select TenMH, mh.MaMH from dbo.LOPMONHOC lopmh join dbo.MONHOC mh on lopmh.MaMH= mh.MaMH where MaLopMH= @MaLopMH ";
            try
            {
                using (SqlConnection connection = new SqlConnection(constr))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm giá trị cho tham số @Username
                        command.Parameters.AddWithValue("@MaLopMH", MaLopMH);

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Lấy giá trị từ cột "ColumnName"
                                string value = reader.GetString(reader.GetOrdinal("TenMH"));

                                // Hiển thị kết quả trên TextBox
                                textBox4.Text = value;
                                textBox4.Enabled = false;
                            }
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void cbo_ngay_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            // Lấy ngày được chọn từ ComboBox
            string selectedDate = cbo_ngay.SelectedItem.ToString();

            // Kết nối với cơ sở dữ liệu
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                dataGridView1.Show();
                // Tạo câu lệnh SQL để tải lại dữ liệu
                //DISTINCT
                string loadQuery = "SELECT  dd.MaSV,sv.HoTenSV, VangCoPhep, VangKhongPhep, GhiChu FROM DIEMDANH dd, SINHVIEN sv where Ngay=@selectedDate and MaLopMH = @MaLopMH and dd.MaSV= sv.MaSV";

                using (SqlCommand cmd = new SqlCommand(loadQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@selectedDate", selectedDate);
                    cmd.Parameters.AddWithValue("@MaLopMH", MaLopMH);


                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    // Tạo một DataTable để chứa dữ liệu
                    DataTable dt = new DataTable();

                    // Đổ dữ liệu vào DataTable
                    da.Fill(dt);

                    // Đặt DataTable làm nguồn dữ liệu cho DataGridView
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = dt;

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
                    // hien thi hiendien, vang
                    sinhvienvang();
                    sinhvienhiendien();

                    // Cập nhật DataGridView
                    dataGridView1.Refresh();
                }

                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            hiendien.Show();
            vang.Show();

            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    // Kiểm tra xem dòng hiện tại có dữ liệu hay không
                    if (row.Cells["MaSV"].Value != null)
                    {
                        string selectedDate = cbo_ngay.SelectedItem?.ToString();
                        string MaSV = row.Cells["MaSV"].Value.ToString();
                        bool VangCoPhep = (bool)row.Cells["VangCoPhep"].Value;
                        bool VangKhongPhep = (bool)row.Cells["VangKhongPhep"].Value;
                        string notes = row.Cells["GhiChu"].Value.ToString();

                        string query = "UPDATE DIEMDANH SET VangCoPhep = @VangCoPhep, VangKhongPhep = @VangKhongPhep, GhiChu = @Notes WHERE MaSV = @MaSV AND MaLopMH = @MaLopMH AND Ngay = @selectedDate";
                        ;
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@MaSV", MaSV);
                            command.Parameters.AddWithValue("@MaLopMH", MaLopMH);
                            command.Parameters.AddWithValue("@selectedDate", selectedDate);
                            command.Parameters.AddWithValue("@VangCoPhep", VangCoPhep);
                            command.Parameters.AddWithValue("@VangKhongPhep", VangKhongPhep);
                            command.Parameters.AddWithValue("@Notes", notes);
                            command.ExecuteNonQuery();
                        }
                    }
                }

                connection.Close();
            }

            // Thông báo lưu thành công
            MessageBox.Show("Dữ liệu đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btn_in.Enabled = true;
            sinhvienvang();
            sinhvienhiendien();
        }

        void tengiangvien()
        {
            string query = "select HoTenGV from GIANGVIEN, LOPMONHOC WHERE LOPMONHOC.MaGV=GIANGVIEN.MaGV AND MaLopMH=@MaLopMH";
            try
            {
                using (SqlConnection connection = new SqlConnection(constr))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm giá trị cho tham số @Username
                        command.Parameters.AddWithValue("@MaLopMH", MaLopMH);

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Lấy giá trị từ cột "HoTenGV"
                                string value = reader.GetString(reader.GetOrdinal("HoTenGV"));

                                // Hiển thị kết quả trên TextBox
                                txt_tenGV.Text = value;
                                txt_tenGV.Enabled = false;
                            }
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        void load_txt_diachi()
        {
            // Câu truy vấn SQL
            string query = "select distinct DiaChi from PHONGHOC p , SUDUNGPHONGHOC sd, MONHOC mh where p.MaPhongHoc= sd.MaPhongHoc and MaLopMH= @MaLopMH ";
            try
            {
                using (SqlConnection connection = new SqlConnection(constr))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm giá trị cho tham số @Username
                        command.Parameters.AddWithValue("@MaLopMH", MaLopMH);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Lấy giá trị từ cột "ColumnName"
                                string value = reader.GetString(reader.GetOrdinal("DiaChi"));

                                // Hiển thị kết quả trên TextBox
                                textBox3.Text = value;
                                textBox3.Enabled = false;
                            }
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        void sinhvienvang()
        {
            string query = "select count(*) from DIEMDANH where (VangCoPhep= 1 or VangKhongPhep= 1 )and Ngay= @selectedDate and MaLopMH= @MaLopMH";
            try
            {
                using (SqlConnection connection = new SqlConnection(constr))
                {
                    connection.Open();
                   
                    string selectedDate = cbo_ngay.SelectedItem?.ToString();
                  
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@selectedDate", selectedDate);
                        command.Parameters.AddWithValue("@MaLopMH", MaLopMH);
                        int count = (int)command.ExecuteScalar();
                        vang.Text = count.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        void sinhvienhiendien()
        {
            string query = "select count(*) from DIEMDANH where (VangCoPhep= 0 AND VangKhongPhep= 0 )and Ngay= @selectedDate and MaLopMH= @MaLopMH";
            try
            {
                using (SqlConnection connection = new SqlConnection(constr))
                {
                    connection.Open();

                    string selectedDate = cbo_ngay.SelectedItem?.ToString();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@selectedDate", selectedDate);
                        command.Parameters.AddWithValue("@MaLopMH", MaLopMH);
                        int count = (int)command.ExecuteScalar();
                        hiendien.Text = count.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            f4.Show(); // Hiển thị lại Form4 khi Form5 đóng
            this.Close();
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            //f4.Show(); // Hiển thị lại Form4 khi Form5 đóng
            //this.Close();

        }

        private void ExportDataToExcel()
        {
            // Tạo một ứng dụng Excel mới
            Excel.Application excelApp = new Excel.Application();

            // Tạo một Workbook mới
            Excel._Workbook workbook = excelApp.Workbooks.Add(Type.Missing);

            // Tạo một Worksheet mới và đặt nó làm Worksheet đầu tiên
            Excel._Worksheet worksheet = workbook.Sheets["Sheet1"];

            // Thêm dữ liệu từ TextBox và Label vào Worksheet

            //int startRow = dataGridView1.Rows.Count + 1;
            int startRow = 2;
            string[] headers = { "Tên giảng viên", "Ngày điểm danh", "Mã lớp", "Địa chỉ", "Tên môn", "Hiện diện", "Vắng" };
            string[] values = { txt_tenGV.Text, cbo_ngay.SelectedItem.ToString(), txt_malop.Text, textBox3.Text, textBox4.Text, hiendien.Text, vang.Text };

            for (int i = 0; i < headers.Length; i++)
            {
                worksheet.Cells[startRow, 2] = headers[i];
                worksheet.Cells[startRow++, 3] = values[i];
            }

            // Đặt tiêu đề cho các cột trong Worksheet
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[11, i] = dataGridView1.Columns[i - 1].HeaderText;
            }

            // Điền dữ liệu vào các ô trong Worksheet
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    // Kiểm tra xem giá trị của ô có phải là 'true' hay 'false'
                    if (dataGridView1.Rows[i].Cells[j].Value is bool)
                    {
                        worksheet.Cells[i + 12, j + 1] = (bool)dataGridView1.Rows[i].Cells[j].Value ? "[x]" : "";
                    }
                    else
                    {
                        // Nếu không, giữ nguyên giá trị
                        worksheet.Cells[i + 12, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }

            // Đóng Workbook và ứng dụng Excel
            workbook.Close();
            excelApp.Quit();
        }
        private void btn_in_Click(object sender, EventArgs e)
    {
        ExportDataToExcel();
    }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            load_txt_diachi();
        }
    }
}
