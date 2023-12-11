using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanVeXe
{
    public partial class frm_QLChuyenDi : Form
    {
        DBConnect db = new DBConnect();
        DataTable dt_Chuyen = new DataTable();
        public frm_QLChuyenDi()
        {
            InitializeComponent();
            string sql = "select * from CHUYENXE";
            dt_Chuyen = db.GetDataTable(sql);
            DataColumn[] key = new DataColumn[1];
            key[0] = dt_Chuyen.Columns[0];
            dt_Chuyen.PrimaryKey = key;
        }
        private void frm_QLChuyenDi_Load(object sender, EventArgs e)
        {
            load_dgvDSChuyenDi();
            load_cboTaiXe();
            load_cboTuyen();
            load_cboXe();
            DisplayAvailableSeats();
        }
        private void DataBinding(DataTable pDT)
        {
            txt_MaLoTrinh.DataBindings.Clear();
            cbo_LTrinh.DataBindings.Clear();
            cbo_Xe.DataBindings.Clear();
            cbo_MaTaiXe.DataBindings.Clear();
            txt_Giodi.DataBindings.Clear();
            txt_Gioden.DataBindings.Clear();
            txt_SLGheTrong.DataBindings.Clear();
            dateTimePicker1.DataBindings.Clear();


            txt_MaLoTrinh.DataBindings.Add("Text", pDT, "MaChuyen");
            cbo_LTrinh.DataBindings.Add("SelectedValue", pDT, "MaTuyen");
            txt_Giodi.DataBindings.Add("Text", pDT, "GioDi");
            txt_Gioden.DataBindings.Add("Text", pDT, "GioDen");
            cbo_MaTaiXe.DataBindings.Add("SelectedValue", pDT, "MaTaiXe");
            cbo_Xe.DataBindings.Add("SelectedValue", pDT, "BienSo");
            txt_SLGheTrong.DataBindings.Add("Text", pDT, "GheTrong");
            dateTimePicker1.DataBindings.Add("Value", pDT, "NgayKH");
        }

        private void load_cboXe()
        {
            DataTable dt_Xe = new DataTable();
            string sql = "select * from XE";
            dt_Xe = db.GetDataTable(sql);
            cbo_Xe.DataSource = dt_Xe;
            cbo_Xe.DisplayMember = "BienSo";
            cbo_Xe.ValueMember = "BienSo";
        }
        public void load_cboTaiXe()
        {

            DataTable dt_TaiXe = new DataTable();
            string sql = "select * from TAIXE";
            dt_TaiXe = db.GetDataTable(sql);
            cbo_MaTaiXe.DataSource = dt_TaiXe;
            cbo_MaTaiXe.DisplayMember = "TenTaiXe";
            cbo_MaTaiXe.ValueMember = "MaTaiXe";
        }
        private void load_cboTuyen()
        {
            DataTable dt_Tuyen = new DataTable();
            string sql = "select * from TUYENXE";
            dt_Tuyen = db.GetDataTable(sql);
            cbo_LTrinh.DataSource = dt_Tuyen;
            cbo_LTrinh.DisplayMember = "TenTuyen";
            cbo_LTrinh.ValueMember = "MaTuyen";
        }

        private void load_dgvDSChuyenDi()
        {
            dgv_Chuyen.DataSource = dt_Chuyen;
            DataBinding(dt_Chuyen);
        }
        private string SinhMaChuyenXe()
        {
            string maTuyen = cbo_LTrinh.SelectedValue.ToString();
            DateTime ngayKhoiHanh = dateTimePicker1.Value;
            string formattedDate = ngayKhoiHanh.ToString("ddMMyyyy");
            string sql = $"SELECT COUNT(*) FROM CHUYENXE WHERE NgayKH = '{ngayKhoiHanh.ToString("yyyy-MM-dd")}'";
            int count = (int)db.getScalar(sql);
            string chuyenXeCode = $"{maTuyen}{formattedDate}{(count + 1).ToString("000")}";
            return chuyenXeCode;
        }
        private void DisplayAvailableSeats()
        {
            if (cbo_Xe.SelectedValue == null) { return; }
            else
            {
                string bienSoXe = cbo_Xe.SelectedValue.ToString();
                string sql = $"SELECT SoGhe FROM XE WHERE BienSo = '{bienSoXe}'";
                object result = db.getScalar(sql);
                int availableSeats = Convert.ToInt32(result);
                txt_SLGheTrong.Text = availableSeats.ToString();
            }
        }
        private void cbo_Xe_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayAvailableSeats();
        }



        private void btn_HienThi_Click(object sender, EventArgs e)
        {

            string sql = "select * from CHUYENXE";
            dt_Chuyen = db.GetDataTable(sql);
            dgv_Chuyen.DataSource = dt_Chuyen;
        }

        //private void btn_Lưu_Click(object sender, EventArgs e)
        //{
        //    string sql = "select * from CHUYENXE";
        //    int kq = db.updateDatabase(sql, dt_Chuyen);
        //    if (kq > 0)
        //        MessageBox.Show("Thêm thành công!!!");
        //    else
        //        MessageBox.Show("Thêm thất bại !!");
        //}

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            txt_MaLoTrinh.Clear();
            txt_Giodi.Clear();
            txt_Gioden.Clear();
            txt_SLGheTrong.Clear();
            txt_Giodi.Focus();
            cbo_MaTaiXe.SelectedIndex = -1;
            cbo_LTrinh.SelectedIndex = -1;
            cbo_Xe.SelectedIndex = -1;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            string maChuyen = SinhMaChuyenXe();
            DataRow row = dt_Chuyen.NewRow();
            row["BienSo"] = cbo_Xe.SelectedValue.ToString();
            row["GheTrong"] = txt_SLGheTrong.Text;
            row["MaTuyen"] = cbo_LTrinh.SelectedValue.ToString();
            row["MaChuyen"] = maChuyen;
            row["GioDi"] = txt_Giodi.Text;
            row["GioDen"] = txt_Gioden.Text;
            row["MaTaiXe"] = cbo_MaTaiXe.SelectedValue.ToString();
            row["NgayKH"] = dateTimePicker1.Value.ToString();

            dt_Chuyen.Rows.Add(row);
            string sql = "select * from CHUYENXE";
            int kq = db.updateDatabase(sql, dt_Chuyen);
            if (kq > 0)
                MessageBox.Show("Thêm thành công!!!");
            else
                MessageBox.Show("Thêm thất bại !!");
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DataRow dr = dt_Chuyen.Rows.Find(txt_MaLoTrinh.Text);
            if (dr != null)
                dr.Delete();
            string sql = "select * from CHUYENXE";
            int kq = db.updateDatabase(sql, dt_Chuyen);
            if (kq > 0)
                MessageBox.Show("Xóa thành công!");
            else
                MessageBox.Show("Xóa thất bại!");
        }

    }
}
