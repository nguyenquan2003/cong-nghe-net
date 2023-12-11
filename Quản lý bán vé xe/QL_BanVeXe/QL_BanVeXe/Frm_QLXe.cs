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
using QL_BanVeXe;

namespace QuanLyXe
{
    public partial class Frm_QLXe : Form
    {
        DBConnect db = new DBConnect();
        DataTable dtXe;
        
        public Frm_QLXe()
        {
            InitializeComponent();
            string sql = "select * from XE";
            dtXe = db.GetDataTable(sql);
            DataColumn[] key = new DataColumn[1];
            key[0] = dtXe.Columns[0];
            dtXe.PrimaryKey = key;
        }
        private void DataBinding(DataTable pDT)
        {
            txt_MaXe.DataBindings.Clear();
            cbo_LoaiXe.DataBindings.Clear();
            txt_SoGhe.DataBindings.Clear();


            txt_MaXe.DataBindings.Add("Text", pDT, "BienSo");
            cbo_LoaiXe.DataBindings.Add("SelectedValue", pDT, "MaLoai");
            txt_SoGhe.DataBindings.Add("Text", pDT, "SoGhe");
        }

        private void load_dgvDanhSachXe()
        {
            dataGridView1.DataSource = dtXe;
            DataBinding(dtXe);
        }
        private void load_cboLoaiXe()
        {
            DataTable dt_LoaiXe = new DataTable();
            string sql = "select * from LOAIXE";
            dt_LoaiXe = db.GetDataTable(sql);
            cbo_LoaiXe.DataSource = dt_LoaiXe;
            cbo_LoaiXe.DisplayMember = "MaLoai";
            cbo_LoaiXe.ValueMember = "MaLoai";
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {

            DataRow row = dtXe.NewRow();
            row["BienSo"] = txt_MaXe.Text;
            row["SoGhe"] = txt_SoGhe.Text;
            row["MaLoai"] = cbo_LoaiXe.SelectedValue.ToString(); 

            dtXe.Rows.Add(row);
            string sql = "select * from XE";
            int kq = db.updateDatabase(sql, dtXe);
            if (kq > 0)
                MessageBox.Show("Thêm thành công!!!");
            else
                MessageBox.Show("Thêm thất bại !!");


        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            dtXe.PrimaryKey = new DataColumn[] { dtXe.Columns["BienSo"] };
            DataRow dr = dtXe.Rows.Find(txt_MaXe.Text);
            if (dr != null)
                dr.Delete();
            string sql = "select * from XE";
            int kq = db.updateDatabase(sql, dtXe);
            if (kq > 0)
                MessageBox.Show("Xóa thành công!");
            else
                MessageBox.Show("Xóa không thành công!!!");
           
        }
  

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            string maXe = txt_MaXe.Text;
            string loaiXe = cbo_LoaiXe.SelectedValue.ToString();
            string soGhe = txt_SoGhe.Text;
            string updateSQL = "UPDATE XE SET BienSo  ='" + maXe + "',  SoGhe ='" + soGhe + "', MaLoai = '" + loaiXe + "'" + "WHERE BienSo = '" + maXe + "'";
            int result = db.getNonQuery(updateSQL);
            if (result > 0)
                MessageBox.Show("Cập nhật thành công!");
            else
                MessageBox.Show("Cập nhật không thành công!!!");

        }

        private void btn_Hienthi_Click(object sender, EventArgs e)
        {
            string sql = "select * from XE";
            dtXe = db.GetDataTable(sql);
            dataGridView1.DataSource = dtXe;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            load_dgvDanhSachXe();
            load_cboLoaiXe();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            txt_MaXe.Clear();
            cbo_LoaiXe.SelectedIndex = -1;
            txt_SoGhe.Clear();  
            txt_MaXe.Focus();
           
        }
    }
}
