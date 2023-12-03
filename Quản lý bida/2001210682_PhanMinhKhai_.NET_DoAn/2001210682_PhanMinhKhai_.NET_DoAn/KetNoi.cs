using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace _2001210682_PhanMinhKhai_.NET_DoAn
{
    public class conectionSV
    {

        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable table;

        public conectionSV()
        {
            string connectionString = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=QL_bida;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter();
            table = new DataTable();
        }
    }

    class Ketnoi
    {
        public SqlConnection con = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=QL_bida;Integrated Security=True");
    }
}
