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
        SqlConnection con;
        public Form2()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=DESKTOP-0MNS8CK\SQLEXPRESS;Initial Catalog=QLsinhvien;Integrated Security=True");
        }

        private void btn_ht_Click(object sender, EventArgs e)
        {
            string s = "select *from lop";
            ListViewItem item;
            int i = 0;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(s, con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    i++;
                    item = new ListViewItem(new[] { i.ToString(), rd[0].ToString(), rd[1].ToString(), rd[2].ToString() });
                    listView1.Items.Add(item);
                }
                con.Close();
                MessageBox.Show("Thanh cong");
            }
            catch
            {
                MessageBox.Show("That bai");
            }
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }
    }
}
