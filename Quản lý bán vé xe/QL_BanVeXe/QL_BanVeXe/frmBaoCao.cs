using Microsoft.Reporting.WinForms;
using QLVe_XuatVe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_BanVeXe;

namespace DoAnCuoiKy
{
    public partial class frmBaoCao : Form
    {
        DBConnect db = new DBConnect();
        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            load_cbo_NgayKH();
            load_cbo_BienSo();
            load_cbo_MaTuyen();
            
        }
        public void load_cbo_NgayKH()
        {
            string sql = "select MaTuyen as NgayKH into #tmp from CHUYENXE where 1 = 0";
            sql += " insert into #tmp SELECT '' ";
            sql += " INSERT INTO #tmp select distinct(NgayKH) from CHUYENXE";
            sql += " SELECT * FROM #tmp";
            DataTable dt_NgayKH = db.GetDataTable(sql);

            cbo_NgayKH.DataSource = dt_NgayKH;
            cbo_NgayKH.DisplayMember = "NgayKH";
            cbo_NgayKH.ValueMember = "NgayKH";
        }
        public void load_cbo_BienSo()
        {
            string sql = "select MaLoai,BienSo into #tmp from XE where 1 = 0";
            sql += " insert into #tmp SELECT '','' ";
            sql += " INSERT INTO #tmp select DISTINCT MaLoai,BienSo from XE";
            sql += " SELECT * FROM #tmp";

            DataTable dt_Xe = db.GetDataTable(sql);
            cbo_BienSo.DataSource = dt_Xe;
            cbo_BienSo.DisplayMember = "BienSo";
            cbo_BienSo.ValueMember = "BienSo";
        }
        public void load_cbo_MaTuyen()
        {
            string sql = "select MaTuyen,TenTuyen into #tmp from TUYENXE where 1 = 0";
            sql += " insert into #tmp SELECT '','' ";
            sql += " INSERT INTO #tmp select MaTuyen,TenTuyen from TUYENXE";
            sql += " SELECT * FROM #tmp";

            DataTable dt_TuyenXe = db.GetDataTable(sql);
 
            cbo_MaTuyen.DataSource = dt_TuyenXe;
            cbo_MaTuyen.DisplayMember = "TenTuyen";
            cbo_MaTuyen.ValueMember = "MaTuyen";
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            string sql = "select CTVEXE.MaVe, VEXE.MaNV, TUYENXE.MaTuyen, Xe.BienSo, KHACHHANG.HoTenKH, CTVEXE.SDTKH, CTVEXE.TenGhe, CTVEXE.SoLuong, CTVEXE.NgayDatVe, CHUYENXE.GioDi, CHUYENXE.NgayKH, CTVEXE.GhiChu,ThanhTien from VEXE inner join CTVEXE on VEXE.MaVe=CTVEXE.MaVe inner join CHUYENXE on VEXE.MaChuyen=CHUYENXE.MaChuyen inner join KHACHHANG on KHACHHANG.SDTKH=CTVEXE.SDTKH inner join TUYENXE on TUYENXE.MaTuyen=CHUYENXE.MaTuyen inner join XE on XE.BienSo=CHUYENXE.BienSo WHERE 1 = 1";
            if(cbo_MaTuyen.Text.Trim() != "")
            {
                sql += " AND TUYENXE.MaTuyen = N'" + cbo_MaTuyen.SelectedValue.ToString()+"'";
            }
            if (cbo_BienSo.Text.Trim() != "")
            {
                sql += " AND Xe.BienSo = N'" + cbo_BienSo.SelectedValue.ToString()+"'";
            }
            if (cbo_NgayKH.Text.Trim() != "")
            {
                sql += " AND CHUYENXE.NgayKH = '" + cbo_NgayKH.SelectedValue.ToString()+"'";
            }
            DataTable dt = new DataTable();
            dt = db.GetDataTable(sql);

            string sql1 = "select SUM(ThanhTien) from VEXE inner join CTVEXE on VEXE.MaVe=CTVEXE.MaVe inner join CHUYENXE on VEXE.MaChuyen=CHUYENXE.MaChuyen inner join KHACHHANG on KHACHHANG.SDTKH=CTVEXE.SDTKH inner join TUYENXE on TUYENXE.MaTuyen=CHUYENXE.MaTuyen inner join XE on XE.BienSo=CHUYENXE.BienSo WHERE 1 = 1";
            if (cbo_MaTuyen.Text.Trim() != "")
            {
                sql1 += " AND TUYENXE.MaTuyen = N'" + cbo_MaTuyen.SelectedValue.ToString() + "'";
            }
            if (cbo_BienSo.Text.Trim() != "")
            {
                sql1 += " AND Xe.BienSo = N'" + cbo_BienSo.SelectedValue.ToString() + "'";
            }
            if (cbo_NgayKH.Text.Trim() != "")
            {
                sql1 += " AND CHUYENXE.NgayKH = '" + cbo_NgayKH.SelectedValue.ToString() + "'";
            }
            DataTable dt1 = new DataTable();
            dt1 = db.GetDataTable(sql1);

            //reportViewer1.LocalReport.ReportEmbeddedResource = "QL_BanVeXe.rptBaoCao.rdlc";
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("tongtien", dt1.Rows[0][0].ToString(), true);
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
