using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QL_BanVeXe
{
    internal class DBConnect
    {
        SqlConnection conn;

        public SqlConnection Conn { get => conn; set => conn = value; }

        SqlDataAdapter da;

        //string strConnect = "Data source=A109PC14; initial catalog=QLHANGHOA; User ID=sa;password=123";
        //string strConnect = "Data source =LAPTOP-VIF8A7VH; initial catalog = QL_BANVEXE; integrated Security=True";
        string strConnect =@"Data Source=DESKTOP-PSKCDQJ\\SQLEXPRESS Initial Catalog=QLBV;Integrated Security=True;Encrypt=False";


        public DBConnect()
        {
            conn=new SqlConnection(strConnect);
        }

        public void Open()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }

        public void Close()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        public int getNonQuery(string sql)
        {
            Open();
            SqlCommand cmd = new SqlCommand(sql,conn);
            int kq= cmd.ExecuteNonQuery();
            Close();
            return kq;
        }

        public SqlDataReader getDataReader(string sql)
        {
            Open();
            SqlCommand cmd = new SqlCommand(sql,conn);
            SqlDataReader rd= cmd.ExecuteReader();
            return rd;
        }

        public object getScalar(string sql)
        {
            Open();
            SqlCommand cmd=new SqlCommand(sql,conn);
            object kq= cmd.ExecuteScalar();
            Close();
            return kq;
        }

        public DataTable GetDataTable(string sql)
        {
             DataTable dt= new DataTable();
            da=new SqlDataAdapter(sql,conn);
            da.Fill(dt);
            return dt;
        }

        public int updateDatabase(string sql, DataTable dt)
        {
            da=new SqlDataAdapter(sql,conn);
            SqlCommandBuilder cB = new SqlCommandBuilder(da);
            int kq = da.Update(dt);
            return kq;
        }

        public bool CheckPrimaryKeyExist(string tableName, string primaryKeyColumn, string primaryKeyValue)
        {
            string sql = $"SELECT COUNT(*) FROM {tableName} WHERE {primaryKeyColumn} = '{primaryKeyValue}'";
            int count = (int)getScalar(sql);
            return count > 0;
        }

    }
}
