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

namespace QuanLyLoTrinh
{
    public partial class frm_QLLTrinh : Form
    {
        private DBConnect db = new DBConnect();
        private DataTable dtLoTrinh = new DataTable();
        public frm_QLLTrinh()
        {
            InitializeComponent();
            string sql = "select * from TUYENXE";
            dtLoTrinh = db.GetDataTable(sql);
            DataColumn[] key = new DataColumn[1];
            key[0] = dtLoTrinh.Columns[0];
            dtLoTrinh.PrimaryKey = key;
        }
        private void DataBinding(DataTable pDT)
        {
            txt_MaLoTrinh.DataBindings.Clear();
            txt_TenLoTrinh.DataBindings.Clear();
            txt_GiaVe.DataBindings.Clear();
            txt_Diemdi.DataBindings.Clear();
            txt_Diemden.DataBindings.Clear();


            txt_MaLoTrinh.DataBindings.Add("Text", pDT, "MaTuyen");
            txt_TenLoTrinh.DataBindings.Add("Text", pDT, "TenTuyen");
            txt_Diemdi.DataBindings.Add("Text", pDT, "DiemDi");
            txt_Diemden.DataBindings.Add("Text", pDT, "DiemDen");
            txt_GiaVe.DataBindings.Add("Text", pDT, "BangGia");
        }
        private void load_dgvDanhSachLoTrinh()
        {
            DataGridViewLoTrinh.DataSource = dtLoTrinh;
            //DataGridViewRow row = DataGridViewLoTrinh.Rows[DataGridViewLoTrinh.Rows.Count - 1];
            DataBinding(dtLoTrinh);
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {

            // Thêm lộ trình mới
            string maLoTrinh = txt_MaLoTrinh.Text;
            string tenLoTrinh = txt_TenLoTrinh.Text;
            // Thêm các giá trị khác tương ứng
            int giaVe = int.Parse(txt_GiaVe.Text);
            string diemDi = txt_Diemdi.Text;
            string diemDen = txt_Diemden.Text;

            DataRow row = dtLoTrinh.NewRow();
            row["MaTuyen"] = txt_MaLoTrinh.Text;
            row["TenTuyen"] = txt_TenLoTrinh.Text;
            row["DiemDi"] = txt_Diemdi.Text;
            row["DiemDen"] = txt_Diemden.Text;
            row["BangGia"] = int.Parse(txt_GiaVe.Text);

            dtLoTrinh.Rows.Add(row);
            string sql = "select * from TUYENXE";
            int kq = db.updateDatabase(sql, dtLoTrinh);
            if (kq > 0)
                MessageBox.Show("Thêm thành công!!!");
            else
                MessageBox.Show("Thêm thất bại !!");
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            string maLoTrinh = txt_MaLoTrinh.Text;
            string tenLoTrinh = txt_TenLoTrinh.Text;
            int giaVe = int.Parse(txt_GiaVe.Text);
            string diemDi = txt_Diemdi.Text;
            string diemDen = txt_Diemden.Text;
            string updateSQL = "UPDATE TUYENXE SET MaTuyen ='" + maLoTrinh + "', TenTuyen ='" + tenLoTrinh + "' ,DiemDi ='" + diemDi + "',DiemDen ='" + diemDen + "', BangGia = '" + giaVe +"'" + "WHERE MaTuyen ='" + maLoTrinh + "'";
            int result = db.getNonQuery(updateSQL);
            if (result > 0)
                MessageBox.Show("Cập nhật thành công!");
            else
                MessageBox.Show("Cập nhật không thành công!!!");

        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            // Xóa lộ trình
            dtLoTrinh.PrimaryKey = new DataColumn[] { dtLoTrinh.Columns["MaTuyen"] };
            DataRow dr = dtLoTrinh.Rows.Find(txt_MaLoTrinh.Text);
            if (dr != null)
                dr.Delete();
            string sql = "select * from TUYENXE";
            int kq = db.updateDatabase(sql, dtLoTrinh);
            if (kq > 0)
                MessageBox.Show("Xóa thành công!");
            else
                MessageBox.Show("Xóa không thành công!!!");
        }

        private void btn_HienThi_Click(object sender, EventArgs e)
        {
            string sql = "select * from TUYENXE";
            dtLoTrinh = db.GetDataTable(sql);
            DataGridViewLoTrinh.DataSource = dtLoTrinh;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            load_dgvDanhSachLoTrinh();
            //btn_Huy_Click(sender, e);
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            txt_MaLoTrinh.Clear();
            txt_TenLoTrinh.Clear();
            txt_GiaVe.Clear();
            txt_Diemdi.Clear();
            txt_Diemden.Clear();
            txt_MaLoTrinh.Focus();

        }

    }
}
