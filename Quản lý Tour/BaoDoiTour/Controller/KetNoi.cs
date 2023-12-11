using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace BaoDoiTour.Controller
{
    class KetNoi
    {
        SqlConnection connect;
        DataSet dataSet = new DataSet();
        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        string sqlStr = "Data Source=Adonis; Initial Catalog=QL_DULICH; User ID=sa; Password=123";
        public SqlConnection Connect
        {
            get { return connect; }
            set { connect = value; }
        }

        public KetNoi()
        {
            connect = new SqlConnection(sqlStr);
        }
        public KetNoi(string strcn)
        {
            connect = new SqlConnection(strcn);
        }

        public void open()
        {
            if (connect.State == ConnectionState.Closed)
                connect.Open();
        }
        public void close()
        {
            if (connect.State == ConnectionState.Open)
                connect.Close();
        }
        public int getNonQuery(string sql)
        {
            if (connect.State == ConnectionState.Closed)
                open();
            SqlCommand cmd = new SqlCommand(sql, connect);
            int kq = cmd.ExecuteNonQuery();
            close();
            return kq;
        }
        public SqlDataReader getDataReader(string sql)
        {
            if (connect.State == ConnectionState.Open)
                close();
            if (connect.State == ConnectionState.Closed)
                open();
            SqlCommand cmd = new SqlCommand(sql, connect);
            SqlDataReader rd = cmd.ExecuteReader();
            //close();
            return rd;
        }

        public object getScalar(string sql)
        {
            open();
            SqlCommand cmd = new SqlCommand(sql, connect);
            object kq = cmd.ExecuteScalar();
            close();
            return kq;
        }

        public DataTable getTableData(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, connect);
            da.Fill(dt);
            return dt;
        }

        public int updateDatabase(string sql, DataTable dt)
        {
            SqlDataAdapter da_lop = new SqlDataAdapter(sql, connect);
            SqlCommandBuilder cb = new SqlCommandBuilder(da_lop);
            int kq = da_lop.Update(dt);
            return kq;
        }
    }
}
