using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using QL_BanVeXe;

namespace QLVe_XuatVe
{
    public partial class frm_QuanLyVe : Form
    {
        DBConnect db = new DBConnect();
        DataTable dt_QLVe = new DataTable();
        DataTable dt_DS = new DataTable();
        public frm_QuanLyVe()
        {
            InitializeComponent();
            
        }
        //------------------------------------------------------------------------------------------------------------------
        //Tạo 1 dataTable mới.
        



        //Thêm dữ liệu vào DataTable.
        //dt.Rows.Add(maVe, maNV, maLT, maXe, tenKH, soDT, viTriGhe, soLuong, ngayDat, gioKH, ngayKH, trangThaiTT, ghiChu);
        //-------------------------------------------------------------------------------------------------------------------
        private void load_dgv_DSVe()
        {

            string sql = "select CTVEXE.MaVe, VEXE.MaNV, TUYENXE.MaTuyen, Xe.BienSo, KHACHHANG.HoTenKH, CTVEXE.SDTKH, CTVEXE.TenGhe, CTVEXE.SoLuong, CTVEXE.NgayDatVe, CHUYENXE.GioDi, CHUYENXE.NgayKH, CTVEXE.GhiChu,CHUYENXE.MaChuyen from VEXE inner join CTVEXE on VEXE.MaVe=CTVEXE.MaVe inner join CHUYENXE on VEXE.MaChuyen=CHUYENXE.MaChuyen inner join KHACHHANG on KHACHHANG.SDTKH=CTVEXE.SDTKH inner join TUYENXE on TUYENXE.MaTuyen=CHUYENXE.MaTuyen inner join XE on XE.BienSo=CHUYENXE.BienSo WHERE CTVEXE.MaVe LIKE N'%" + txt_TimKiem.Text.Trim()+ "%'";
            DataTable dt_DS = db.GetDataTable(sql);
            
            dgv_DSVe.DataSource = dt_DS;
            dgv_DSVe.Columns["MACHUYEN"].Visible = false;
            DataBingding(dt_DS);
            
        }
        public void load_cbo_MaTuyen()
        {
            string sql = "select * from TUYENXE";
            DataTable dt_TuyenXe = db.GetDataTable(sql);
            //sử dụng dt_Lop làm nguồn cho cbo_lop
            cbo_MaTuyen.DataSource = dt_TuyenXe;
            cbo_MaTuyen.DisplayMember = "TenTuyen";
            cbo_MaTuyen.ValueMember = "MaTuyen";
        }
        public void load_cbo_BienSo()
        {
            string sql = "select * from XE";
            DataTable dt_Xe = db.GetDataTable(sql);
            //sử dụng dt_Lop làm nguồn cho cbo_lop
            cbo_BienSo.DataSource = dt_Xe;
            cbo_BienSo.DisplayMember = "MaLoai";
            cbo_BienSo.ValueMember = "BienSo";
        }
        public void load_cbo_GioDi()
        {
            string sql = "select * from CHUYENXE";
            DataTable dt_GioDi = db.GetDataTable(sql);
            
            //Chuyển định dạng dữ liệu của cột GioDi từ kiểu Time sang kiểu String
            //dt_GioDi.Columns["GioDi"].DataType = typeof(string);
            //dt_GioDi.Columns["GioDi"].Expression = "ToString('HH:mm')";

            //Sử dụng dt_Lop làm nguồn cho cbo_lop
            cbo_GioDi.DataSource = dt_GioDi;
            cbo_GioDi.DisplayMember = "GioDi";
            cbo_GioDi.ValueMember = "GioDi";
        }
        public void load_cbo_NgayKH()
        {
            string sql = "select * from CHUYENXE";
            DataTable dt_NgayKH = db.GetDataTable(sql);

            //Chuyển định dạng dữ liệu của cột NgayKH từ kiểu Date sang kiểu String
            //dt_NgayKH.Columns["NgayKH"].DataType = typeof(string);
            //dt_NgayKH.Columns["NgayKH"].Expression = "ToString('dd/MM/yyyy')";

            //Sử dụng dt_Lop làm nguồn cho cbo_lop
            cbo_NgayKH.DataSource = dt_NgayKH;
            cbo_NgayKH.DisplayMember = "NgayKH";
            cbo_NgayKH.ValueMember = "NgayKH";
        }
        public void load_cbo_MaNV()
        {
            string sql = "select * from NHANVIEN";
            DataTable dt_MaNV = db.GetDataTable(sql);

            cboMaNV.DataSource = dt_MaNV;
            cboMaNV.DisplayMember = "TenNV";
            cboMaNV.ValueMember = "MaNV";
        }
        private void dgv_DSVe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row < 0 || row >= dgv_DSVe.Rows.Count)
            {
                MessageBox.Show("Chỉ mục hàng không hợp lệ.");
                return;
            }

            string maVe = dgv_DSVe.Rows[row].Cells[0].Value.ToString();
            string maNV = dgv_DSVe.Rows[row].Cells[1].Value.ToString();
            string maTuyen = dgv_DSVe.Rows[row].Cells[2].Value.ToString();
            string bienSo = dgv_DSVe.Rows[row].Cells[3].Value.ToString();
            string hoTenKH = dgv_DSVe.Rows[row].Cells[4].Value.ToString();
            string sDTKH = dgv_DSVe.Rows[row].Cells[5].Value.ToString();
            string tenGhe = dgv_DSVe.Rows[row].Cells[6].Value.ToString();
            int soLuong = int.Parse(dgv_DSVe.Rows[row].Cells[7].Value.ToString());
            DateTime ngayDatVe = (DateTime)dgv_DSVe.Rows[row].Cells[8].Value;
            // Convert 'GioDi' from 'time' to 'string' in a suitable format
            string gioDi = ((TimeSpan)dgv_DSVe.Rows[row].Cells[9].Value).ToString(@"hh\:mm");
            DateTime ngayKH = (DateTime)dgv_DSVe.Rows[row].Cells[10].Value;
            string ghiChu = dgv_DSVe.Rows[row].Cells[11].Value.ToString();

            txt_MaVe.Text = maVe.ToString();
            cboMaNV.Text = maNV;
            cbo_MaTuyen.SelectedValue = maTuyen;
            cbo_BienSo.SelectedValue = bienSo;
            txt_HoTenKH.Text = hoTenKH;
            txt_SDTKH.Text=sDTKH.ToString();
            txt_TenGhe.Text = tenGhe;
            txt_SoLuong.Text=soLuong.ToString();
            txt_NgayDatVe.Text= ngayDatVe.Date.ToString();
            cbo_NgayKH.SelectedValue = ngayKH.Date;
            cbo_GioDi.SelectedValue = gioDi;
            
            txt_GhiChu.Text = ghiChu;
            
           
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            if(dgv_DSVe.Rows.Count == 0)
            {
                MessageBox.Show("Không có dòng dữ liệu nào để cập nhật");
                return;
            }    
            boolcontrols(true);
            
        }

        

        public void DataBingding(DataTable pDT)
        {
            txt_MaVe.DataBindings.Clear();
            cboMaNV.DataBindings.Clear();
            cbo_MaTuyen.DataBindings.Clear();
            cbo_BienSo.DataBindings.Clear();
            txt_HoTenKH.DataBindings.Clear();
            txt_SDTKH.DataBindings.Clear();
            txt_TenGhe.DataBindings.Clear();
            txt_SoLuong.DataBindings.Clear();
            txt_NgayDatVe.DataBindings.Clear();
            cbo_GioDi.DataBindings.Clear();
            cbo_NgayKH.DataBindings.Clear();
            txt_GhiChu.DataBindings.Clear();
            
            txt_MaVe.DataBindings.Add("Text", pDT, "maVe");
            cboMaNV.DataBindings.Add("Text", pDT, "maNV");
            cbo_MaTuyen.DataBindings.Add("SelectedValue", pDT, "maTuyen");
            cbo_BienSo.DataBindings.Add("SelectedValue", pDT, "bienSo");
            txt_HoTenKH.DataBindings.Add("Text", pDT,"hoTenKH");
            txt_SDTKH.DataBindings.Add("Text", pDT,"sDTKH");
            txt_TenGhe.DataBindings.Add("Text", pDT,"tenGhe");
            txt_SoLuong.DataBindings.Add("Text", pDT,"soLuong");
            txt_NgayDatVe.DataBindings.Add("Text", pDT,"ngayDatVe");
            cbo_GioDi.DataBindings.Add("SelectedValue", pDT,"gioDi");
            cbo_NgayKH.DataBindings.Add("SelectedValue", pDT,"ngayKH");
            txt_GhiChu.DataBindings.Add("Text", pDT, "ghiChu");
            
        }

        private void frm_QuanLyVe_Load(object sender, EventArgs e)
        {
            load_dgv_DSVe();
            load_cbo_MaTuyen();
            load_cbo_BienSo();
            load_cbo_GioDi();
            load_cbo_NgayKH();
            load_cbo_MaNV();
            boolcontrols(false);
            txt_MaVe.Enabled = false;
            txt_SDTKH.Enabled = false;
        }
        private void boolcontrols (Boolean iss)
        {

            cboMaNV.Enabled = iss;
            cbo_MaTuyen.Enabled = iss;
            cbo_BienSo.Enabled = iss;
            txt_HoTenKH.Enabled = iss;
            txt_TenGhe.Enabled = iss;
            txt_SoLuong.Enabled = iss;
            txt_NgayDatVe.Enabled = iss;
            cbo_GioDi.Enabled = iss;
            cbo_NgayKH.Enabled = iss;
            txt_GhiChu.Enabled = iss;
            btn_Luu.Enabled = iss;
            btn_Huy.Enabled = iss;
            btn_CapNhat.Enabled = !iss;
            btn_Xoa.Enabled = !iss;
            btn_HienThiDS.Enabled = !iss;
        }
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dgv_DSVe.Rows.Count == 0)
            {
                MessageBox.Show("Không có dòng dữ liệu nào để xóa");
                return;
            }
            DialogResult dr = MessageBox.Show("Có chắc chắn xóa dòng dữ liệu này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                DataGridViewRow row = this.dgv_DSVe.Rows[dgv_DSVe.CurrentCell.RowIndex];
               
                string machuyen = row.Cells["MACHUYEN"].Value.ToString();

                string sql = "DELETE CTVEXE WHERE SDTKH = '"+txt_SDTKH.Text.Trim()+"'";
                sql += " DELETE VEXE WHERE MaVe = '"+txt_MaVe.Text.Trim()+"'";
                db.getNonQuery(sql);
                MessageBox.Show("Xóa thành công");
                string sqlupdate = "UPDATE CHUYENXE SET GHETRONG = GHETRONG + " + txt_SoLuong.Text.Trim() + " WHERE MACHUYEN = '"+ machuyen + "'";
                db.getNonQuery(sqlupdate);
                load_dgv_DSVe();
                load_cbo_MaTuyen();
                load_cbo_BienSo();
                load_cbo_GioDi();
                load_cbo_NgayKH();
                load_cbo_MaNV();
                boolcontrols(false);
                txt_MaVe.Enabled = false;
                txt_SDTKH.Enabled = false;
            }
            else
                return;
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            load_dgv_DSVe();
            load_cbo_MaTuyen();
            load_cbo_BienSo();
            load_cbo_GioDi();
            load_cbo_NgayKH();
            load_cbo_MaNV();
            boolcontrols(false);
            txt_MaVe.Enabled = false;
            txt_SDTKH.Enabled = false;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            string maVe = txt_MaVe.Text;
            string maNV = cboMaNV.SelectedValue.ToString();
            string maTuyen = (string)cbo_MaTuyen.SelectedValue;
            string bienSo = (string)cbo_BienSo.SelectedValue;
            string hoTenKH = txt_HoTenKH.Text;
            string sDTKH = txt_SDTKH.Text;
            string tenGhe = txt_TenGhe.Text;
            int soLuong = int.Parse(txt_SoLuong.Text);
            string ngayDatVe = txt_NgayDatVe.Value.ToString("yyyyMMdd");
            DateTime ngayKH = (DateTime)cbo_NgayKH.SelectedValue;
            string gioDi = ((TimeSpan)cbo_GioDi.SelectedValue).ToString();
            string ghiChu = txt_GhiChu.Text;
            string banggia = "select BangGia FROM TuyenXe WHERE MaTuyen = '"+ maTuyen + "'";
            DataTable dtbanggia = db.GetDataTable(banggia);
            banggia = dtbanggia.Rows[0][0].ToString();

            string sql = "UPDATE VEXE set MaNV = '"+maNV+"' WHERE MaVe = '" + maVe + "'";
            sql += " UPDATE CTVEXE SET  ThanhTien = "+soLuong+" * "+banggia+",  SoLuong = "+ soLuong + ", NgayDatVe = '"+ ngayDatVe + "', GhiChu = N'"+txt_GhiChu.Text+"', TenGhe = N'"+txt_TenGhe.Text+"' WHERE MaVe = '" + maVe + "' AND SDTKH = '"+sDTKH+"'";

            try
            {
                db.getNonQuery(sql);
                MessageBox.Show("Cập nhật thành công");
                load_dgv_DSVe();
                load_cbo_MaTuyen();
                load_cbo_BienSo();
                load_cbo_GioDi();
                load_cbo_NgayKH();
                load_cbo_MaNV();
                boolcontrols(false);
                txt_MaVe.Enabled = false;
                txt_SDTKH.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại");
                return;
            }
        }

        private void btn_HienThiDS_Click(object sender, EventArgs e)
        {
            load_dgv_DSVe();
            load_cbo_MaTuyen();
            load_cbo_BienSo();
            load_cbo_GioDi();
            load_cbo_NgayKH();
            boolcontrols(false);
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            load_dgv_DSVe();
        }
    }
}
