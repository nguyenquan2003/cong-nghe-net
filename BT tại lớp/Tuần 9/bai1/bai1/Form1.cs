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
    public partial class Form1 : Form
    {
        SqlConnection cn;
        public Form1()
        {
            InitializeComponent();
            cn = new SqlConnection(@"Data Source=DESKTOP-0MNS8CK\SQLEXPRESS;Initial Catalog=QLsinhvien;Integrated Security=True");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            load_cbo();
            
        }

        void load_cbo()
        {
            DataSet ds = new DataSet();
            string strselect = "select *from khoa";
            SqlDataAdapter da = new SqlDataAdapter(strselect, cn);
            da.Fill(ds, "khoa");
            cbo_khoa.DataSource = ds.Tables[0];
            cbo_khoa.DisplayMember = "tenkhoa";
            cbo_khoa.ValueMember = "makhoa";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool KT_MaKhoa(string sql)
        {
            try
            {
               
                SqlCommand cmd = new SqlCommand(sql, cn);
                int count = (int)cmd.ExecuteScalar();

           //     cn.Close();
                if (count >= 1)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                using (cn)
                {
                    cn.Open();
                    

                    if (txt_ma.Text.Trim().Length == 0 || txt_ten.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("ma lop hoc hoa ten lop hoc chua nhap du lieu", "Thong bao");
                        return;
                    }
                    string s = "select count(*) from lop where malop='" + txt_ma.Text + "'";
                    if (KT_MaKhoa(s) == true)
                    {
                        string sql = "insert into lop values(@ma, @ten, @khoa)";
                        SqlCommand cmd = new SqlCommand(sql, cn);
                        cmd.Parameters.AddWithValue("@ma", txt_ma.Text);
                        cmd.Parameters.AddWithValue("@ten", txt_ten.Text);
                        cmd.Parameters.AddWithValue("@khoa", cbo_khoa.SelectedValue.ToString());

                 
                        
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thanh cong");
                    }
                    else
                    {
                        MessageBox.Show("Trung ma lop");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (txt_ma.Text.Trim().Length != 0)
            {
                try
                {
                    if (cn.State == ConnectionState.Closed)
                        cn.Open();
                    string sql = string.Format("delete from lop where malop= '{0}'", txt_ma.Text);
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("xoa thanh cong");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Ban chua nhap");
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (txt_ma.Text.Trim().Length != 0)
            {
                try
                {
                    if (cn.State == ConnectionState.Closed)
                        cn.Open();
                    string sql = string.Format("update lop set tenlop= N'{0}' where malop='{1}'", txt_ten.Text, txt_ma.Text);
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Cap nhat thanh cong");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Ban chua nhap");
            }
        }


        //void load_lopHoc()
        //{
        //    DataSet ds = new DataSet();
        //    string strselect = "select malop,tenlop,k.makhoa from khoa k, lop l where k.makhoa= l.makhoa";
        //    SqlDataAdapter da = new SqlDataAdapter(strselect, cn);

        //}


    }
}
