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
    public partial class Form3 : Form
    {
        SqlConnection cn;
        SqlDataAdapter da_khoa;
        DataSet ds_khoa;
        DataColumn[] key=new DataColumn[1];
        public Form3()
        {
            InitializeComponent();
            cn = new SqlConnection(@"Data Source=DESKTOP-0MNS8CK\SQLEXPRESS;Initial Catalog=QLsinhvien;Integrated Security=True");
            string strSelect = "select * from Khoa";
            da_khoa = new SqlDataAdapter(strSelect, cn);
            ds_khoa = new DataSet();
            da_khoa.Fill(ds_khoa, "Khoa");
            //them khoa chinh
            key[0] = ds_khoa.Tables["Khoa"].Columns[0];
            ds_khoa.Tables["Khoa"].PrimaryKey = key;
        }

        void Databingding (DataTable PDT)
        {
        txtMakhoa.DataBindings.Clear();
        txtTenkhoa.DataBindings.Clear();
        //lien ket du lieu tren textbox voi truong du lieu tuong ung trong dataTable
        txtMakhoa.DataBindings.Add("Text", pDT, "Makhoa");
        txtTenkhoa.DataBindings.Add("Text", pDT, "Tenkhoa");
        }
        void load_grid()
        {
        dataGridView1.DataSource= ds_khoa.Tables[0];
        Databingding(ds_khoa.Tables[0]);
        }
    }
}
