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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLSV
{
    public partial class Form4 : Form
    {
        SqlConnection con;
        private Form2 _form2;
        private Form4 _form4;
        public Form4(Form2 form2)
        {
            //con = new SqlConnection("Data Source=LAPTOP-65O2D3FN;Initial Catalog=DIEMDANH;Integrated Security=True");
            con = new SqlConnection(@"Data Source=DESKTOP-0MNS8CK\SQLEXPRESS;Initial Catalog=qldiemdanh4ll11;Integrated Security=True");
            InitializeComponent();
            _form2 = form2;

        }

        private void Form4_Load(object sender, EventArgs e)
        {

            // combobox lop
            string maGiangVien = _form2.Username;

            string sql1 = "SELECT LOPMONHOC.MaLopMH FROM LOPMONHOC WHERE LOPMONHOC.MaGV = @maGiangVien";
            SqlCommand command3 = new SqlCommand(sql1, con);
            command3.Parameters.AddWithValue("@maGiangVien", maGiangVien);

            SqlDataAdapter adap_lop = new SqlDataAdapter(command3);
            DataTable td1 = new DataTable();
            adap_lop.Fill(td1);

            // Tạo một hàng mới trong DataTable
            DataRow newRow = td1.NewRow();
            newRow["MaLopMH"] = "Tat ca cac lop";

            // Thêm hàng mới vào DataTable
            td1.Rows.InsertAt(newRow, 0); // Thêm vào vị trí đầu tiên

            cbo_lop.DataSource = td1;
            cbo_lop.DisplayMember = "TenLopMH";
            cbo_lop.ValueMember = "MaLopMH";

            cbo_lop.SelectedIndex = -1;

            string hoTenGiangVien;


            string sql2 = "SELECT HoTenGV FROM GiangVien WHERE MaGV = @maGiangVien";
            SqlCommand command2 = new SqlCommand(sql2, con);
            command2.Parameters.AddWithValue("@maGiangVien", maGiangVien);




            string sql = string.Format("SELECT MONHOC.TenMH FROM LOPMONHOC INNER JOIN MONHOC ON LOPMONHOC.MaMH = MONHOC.MaMH WHERE LOPMONHOC.MaGV = @maGiangVien");
            SqlCommand command = new SqlCommand(sql, con);
            command.Parameters.AddWithValue("@maGiangVien", maGiangVien);
            SqlDataAdapter adap = new SqlDataAdapter(command);
            DataTable td = new DataTable();
            adap.Fill(td);
            DataRow newRow1 = td.NewRow();

            newRow1["TenMH"] = "Tat ca cac mon";
            td.Rows.InsertAt(newRow1, 0);

            comboBox3.DataSource = td;
            //comboBox3.DisplayMember = "TenMH";
            comboBox3.ValueMember = "TenMH";
            // Đặt giá trị mặc định của ComboBox3 thành rỗng
            comboBox3.SelectedIndex = -1;



            string queryString = @"
            SELECT MONHOC.TenMH, LOPMONHOC.MaLopMH
            FROM LOPMONHOC
            INNER JOIN MONHOC ON LOPMONHOC.MaMH = MONHOC.MaMH
            WHERE LOPMONHOC.MaGV =@maGiangVien ";
            int i = 0;
            try
            {
                con.Open();
                
                hoTenGiangVien = (string)command2.ExecuteScalar();
                toolStripMenuItem1.Text = hoTenGiangVien;
                
                SqlCommand command1 = new SqlCommand(queryString, con);
                command1.Parameters.AddWithValue("@maGiangVien", maGiangVien);
                SqlDataReader reader = command1.ExecuteReader();
                while (reader.Read())
                {
                    i++;
                    // Create a new ListViewItem
                    ListViewItem item = new ListViewItem(i.ToString()); // STT
                                                                        // Add subitems for the additional columns
                    item.SubItems.Add(reader[1].ToString()); // MaLopMonHoc
                    item.SubItems.Add(reader[0].ToString()); // TenMonHoc
                                                             // Add the item to the ListView
                    listView1.Items.Add(item);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            // chon dong 
            listView1.FullRowSelect = true;
        }
        private bool isUpdating = false;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isUpdating)
            {
                isUpdating = true;
                comboBox3.SelectedIndex = -1;
                isUpdating = false;
            }
            string maGiangVien = _form2.Username;
            string selectedValue = cbo_lop.SelectedValue == null ? string.Empty : cbo_lop.SelectedValue.ToString();

            // Kiểm tra xem liệu "Tất cả các lớp" có được chọn không
            bool isAllClassesSelected = selectedValue == "Tat ca cac lop";

            // Tạo câu truy vấn SQL mới dựa trên giá trị đã chọn
            string queryString = @"
             SELECT  MONHOC.TenMH, LOPMONHOC.MaLopMH
            FROM LOPMONHOC
            INNER JOIN MONHOC ON LOPMONHOC.MaMH = MONHOC.MaMH
            WHERE LOPMONHOC.MaGV =@maGiangVien ";

            // Nếu không phải "Tất cả các lớp" được chọn, thêm điều kiện vào câu truy vấn
            if (!isAllClassesSelected)
            {
                queryString += " AND LopMonHoc.MaLopMH = @selectedValue";
            }

            // Cập nhật SqlCommand với câu truy vấn mới và tham số mới
            SqlCommand command1 = new SqlCommand(queryString, con);
            command1.Parameters.AddWithValue("@maGiangVien", maGiangVien);

            if (!isAllClassesSelected)
            {
                command1.Parameters.AddWithValue("@selectedValue", selectedValue);
            }

            // Thực hiện câu truy vấn và cập nhật ListView
            try
            {
                con.Open();
                SqlDataReader reader = command1.ExecuteReader();
                listView1.Items.Clear(); // Xóa tất cả các mục hiện tại trong ListView

                int i = 0;
                while (reader.Read())
                {
                    i++;
                    // Create a new ListViewItem
                    ListViewItem item = new ListViewItem(i.ToString()); // STT
                                                                        // Add subitems for the additional columns
                    item.SubItems.Add(reader[1].ToString()); // MaLopMonHoc
                    item.SubItems.Add(reader[0].ToString()); // TenMonHoc

                    // Add the item to the ListView
                    listView1.Items.Add(item);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isUpdating)
            {
                isUpdating = true;
                cbo_lop.SelectedIndex = -1;
                isUpdating = false;
            }
            string maGiangVien = _form2.Username;
            string selectedValue = comboBox3.SelectedValue == null ? string.Empty : comboBox3.SelectedValue.ToString();
            // Kiểm tra xem liệu "Tất cả các môn" có được chọn không
            bool isAllClassesSelected = selectedValue == "Tat ca cac mon";
            string queryString1 = @"
             SELECT  MONHOC.TenMH, LOPMONHOC.MaLopMH
            FROM LOPMONHOC
            INNER JOIN MONHOC ON LOPMONHOC.MaMH = MONHOC.MaMH
            WHERE LOPMONHOC.MaGV =@maGiangVien ";
            // Nếu không phải "Tất cả các môn" được chọn, thêm điều kiện vào câu truy vấn
            if (!isAllClassesSelected)
            {
                queryString1 += " AND MONHOC.TenMH = @selectedValue"; // Sửa ở đây
            }
            SqlCommand command1 = new SqlCommand(queryString1, con);
            command1.Parameters.AddWithValue("@maGiangVien", maGiangVien);

            if (!isAllClassesSelected)
            {
                command1.Parameters.AddWithValue("@selectedValue", selectedValue);
            }

            // Thực hiện câu truy vấn và cập nhật ListView
            try
            {
                con.Open();
                SqlDataReader reader = command1.ExecuteReader();
                listView1.Items.Clear(); // Xóa tất cả các mục hiện tại trong ListView

                int i = 0;
                while (reader.Read())
                {
                    i++;
                    // Create a new ListViewItem
                    ListViewItem item = new ListViewItem(i.ToString()); // STT
                                                                        // Add subitems for the additional columns
                    item.SubItems.Add(reader[1].ToString()); // MaLopMonHoc
                    item.SubItems.Add(reader[0].ToString()); // TenMonHoc

                    // Add the item to the ListView
                    listView1.Items.Add(item);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void thôngTinCaNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string maGiangVien = _form2.Username;
            Form5 f = new Form5(this, maGiangVien);
            f.Show();
            this.Hide();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                var rectangle = listView1.GetItemRect(i);
                if (rectangle.Contains(e.Location))
                {
                    // Lấy mã lớp môn học từ dòng được chọn
                    string maLopMH = listView1.Items[i].SubItems[1].Text;

                    // Tạo một instance của Form6
                    Form6 form6 = new Form6(this);

                    // Truyền mã lớp môn học vào thuộc tính MaLopMH của Form6
                    form6.MaLopMH = maLopMH;
                    // Hiển thị Form6
                    form6.Show();
                    this.Hide();
                    //MessageBox.Show("Mã lớp môn học là: " + maLopMH);
                    return;
                }
            }
        }
        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                var rectangle = listView1.GetItemRect(i);
                if (rectangle.Contains(e.Location))
                {
                    // Lấy mã lớp môn học từ dòng được chọn
                    string maLopMH = listView1.Items[i].SubItems[1].Text;

                    // Tạo một instance của Form6
                    Form6 form6 = new Form6(this);

                    // Truyền mã lớp môn học vào thuộc tính MaLopMH của Form6
                    form6.MaLopMH = maLopMH;
                    // Hiển thị Form6
                    this.Hide();
                    form6.Show();
                    //MessageBox.Show("Mã lớp môn học là: " + maLopMH);
                    return;
                }
            }
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void đôiMâtKhâuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string maGiangVien = _form2.Username;
            //Form5 f = new Form5(this, maGiangVien);
            //f.Show();
            //this.Hide();

            this.Hide();
            Form7 f7 = new Form7(_form2.Username,this);
            f7.Show();
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            // Mở form đăng nhập
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void listView1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string maGiangVien = _form2.Username;
            Form5 f = new Form5(this, maGiangVien);
            f.Show();
            this.Hide();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 f7 = new Form7(_form2.Username, this);
            f7.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
            // Mở form đăng nhập
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
