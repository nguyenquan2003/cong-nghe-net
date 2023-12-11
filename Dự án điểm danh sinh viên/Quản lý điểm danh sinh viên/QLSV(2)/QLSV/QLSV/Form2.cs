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

namespace QLSV
{
    public partial class Form2 : Form
    {
        SqlConnection con;
        private Form1 _form1;
        public Form2(Form1 form1)
        {
            //con = new SqlConnection("Data Source=LAPTOP-65O2D3FN;Initial Catalog=DIEMDANH;Integrated Security=True");

            con = new SqlConnection(@"Data Source=DESKTOP-0MNS8CK\SQLEXPRESS;Initial Catalog=qldiemdanh4ll11;Integrated Security=True");
            InitializeComponent();
            // Sử dụng thuộc tính PasswordChar
            textBox2.PasswordChar = '*';

            // Hoặc sử dụng thuộc tính UseSystemPasswordChar
            textBox2.UseSystemPasswordChar = true;
            _form1 = form1;


        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _form1.Show();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Ban muốn thoat ?", "Thoát", MessageBoxButtons.YesNo);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text; // Mã sinh viên
            string password = textBox2.Text; // Mật khẩu

            // Tạo kết nối đến cơ sở dữ liệu
            con.Open();
            // Tạo câu lệnh SQL để kiểm tra tên người dùng và mật khẩu
            string sql = "SELECT COUNT(*) FROM account WHERE UserName=@username AND Password=@password AND TypeID=1";

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password); // Lưu ý: bạn nên mã hóa mật khẩu trước khi so sánh

                int result = (int)cmd.ExecuteScalar();

                if (result > 0)
                {
                    //MessageBox.Show("Đăng nhập thành công!");
                    Form4 form4 = new Form4(this);
                 
                    form4.Show();
                    this.Hide();
                    
                }
                else
                {
                    MessageBox.Show("Tên người dùng hoặc mật khẩu không chính xác. Vui lòng thử lại.");
                }
            }

            con.Close();

           
        }
        public string Username
        {
            get { return textBox1.Text; }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void ClearTextBoxes()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}