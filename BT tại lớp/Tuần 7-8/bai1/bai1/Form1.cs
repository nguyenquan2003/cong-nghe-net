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
         SqlConnection con;
        public Form1()
        {
            InitializeComponent();
            //con = new SqlConnection("Data Source=@'DESKTOP-0MNS8CK\SQLEXPRESS';Initial Catalog=QLsinhvien;Integrated Security=True");
             con = new SqlConnection(@"Data Source=DESKTOP-0MNS8CK\SQLEXPRESS;Initial Catalog=QLsinhvien;Integrated Security=True");
        }

        //bool KT_MaKhoa(string ma)
        //{
        //    try
        //    {
        //        con.Open();

        //        string selectString = "select count(*) from khoa where makhoa= '"+ma+"'";
        //        //SqlCommand cmd = new SqlCommand(selectString, con);
        //        //int count = (int)cmd.ExecuteScalar();

        //        //con.Close();
        //        //if (count >= 1)
        //        //    return false;
        //        //return true;

        //        DataTable tb = new DataTable();
        //        SqlDataAdapter adap = new SqlDataAdapter(selectString, con);
        //        adap.Fill(tb);
        //        if (tb.Rows.Count > 0)
        //            return false;
        //        return true;

        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        bool KT_MaKhoa(string ma)
        {
            try
            {
                con.Open();

                string selectString = "select count(*) from khoa where makhoa='" + ma + "'";
                SqlCommand cmd = new SqlCommand(selectString, con);
                int count = (int)cmd.ExecuteScalar();

                con.Close();
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
            //if(txt_ma.Text.Trim().Length != 0){
            //    try{
            //        if(con.State == ConnectionState.Closed)
            //            con.Open();
            //        string sql= string.Format("insert into khoa values('{0}',N'{1}')",txt_ma.Text,txt_ten.Text);
            //        SqlCommand cmd= new SqlCommand(sql,con);
            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //        MessageBox.Show("Them thanh cong");
            //    }
            //    catch(Exception ex){
            //        MessageBox.Show(ex.ToString());
            //    }
            //}
            //else{
            //    MessageBox.Show("Ban chua nhap lieu.");
            //}

            try
            {
                if (txt_ma.Text.Trim().Length == 0 || txt_ten.Text.Trim().Length == 0)
                {
                    MessageBox.Show("ma khoa hoc hoa ten khoa hoc chua nhap du lieu", "Thong bao");
                    return;
                }
                string sql = string.Format("insert into khoa values('{0}',N'{1}')", txt_ma.Text, txt_ten.Text);
                string s =  txt_ma.Text;
                if (KT_MaKhoa(s) == true)
                {
                    con.Open();
                    string insertString;
                    insertString = "insert into khoa values(' " + txt_ma.Text + " ',N' " + txt_ten.Text + " ')";
                    SqlCommand cmd = new SqlCommand(insertString, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Thanh cong");
                }
                else
                {
                    MessageBox.Show("Trung ma khoa");
                }
            }
            catch(Exception ex){
                MessageBox.Show(ex.ToString());
            }
        }

        private void txt_ma_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sql = string.Format("select *from khoa");
            DataTable tb = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(tb);
            cbo_khoa.DataSource = tb;
            cbo_khoa.DisplayMember = "tenkhoa";
            cbo_khoa.ValueMember = "makhoa";
        }
    }
}
