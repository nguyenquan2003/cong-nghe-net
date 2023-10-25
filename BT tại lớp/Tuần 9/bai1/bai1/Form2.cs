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

namespace bai1
{
    public partial class Form2 : Form
    {
        SqlConnection cn;
        public Form2()
        {
            InitializeComponent();
            cn = new SqlConnection(@"Data Source=DESKTOP-0MNS8CK\SQLEXPRESS;Initial Catalog=QLsinhvien;Integrated Security=True");
        }

        private void btn_them_Click(object sender, EventArgs e)
        {

        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {

        }

        void load_lophoc()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select malop,tenlop,k.makhoa from khoa k, lop l where k.makhoa= l.makhoa",cn);
            da.Fill(ds, "lop_khoa"); // lay data tu db va dat vao   dataset
            dataGridView1.DataSource = ds.Tables["lop_khoa"]; // gan nguon du lieu 
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            load_lophoc();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
