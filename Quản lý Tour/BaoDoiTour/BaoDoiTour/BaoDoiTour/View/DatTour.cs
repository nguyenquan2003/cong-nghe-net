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
using BaoDoiTour.DatTour;
using BaoDoiTour.Controller;
using BaoDoiTour.View;

namespace BaoDoiTour.View
{
    public partial class DatTour : Form
    {
        DatTourBUS bllCTT;
        KetNoi kn = new KetNoi();
        string maTour;
        public DatTour(string s)
        {
            InitializeComponent();
            bllCTT = new DatTourBUS();
            maTour = s;
        }

        private void DatTour_Load(object sender, EventArgs e)
        {
            txtMaTour.Enabled = false;
            txtMaDat.Enabled = false;
            txtMaKH.Enabled = false;
            dtpNgayDat.Enabled = false;

            txtMaTour.Text = maTour;
            string sqlCmd = "SELECT dbo.GenerateDatTourCode()";
            using (SqlDataReader reader = kn.getDataReader(sqlCmd))
            {
                if (reader.Read())
                {
                    string maNVMoi = reader.GetString(0);
                    txtMaDat.Text = maNVMoi;
                }
            }
            string user = MainLayout.currentUser.MaUser;
            txtMaKH.Text = user;
            dtpNgayDat.Value = DateTime.Now;
        }

        public bool CheckData()
        {
            if (string.IsNullOrEmpty(txtNguoiLon.Text))
            {
                MessageBox.Show("Bạn chưa nhập số người lớn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNguoiLon.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtTreEm.Text))
            {
                MessageBox.Show("Bạn chưa nhập số trẻ em.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTreEm.Focus();
                return false;
            }

            return true;
        }

        private void btnDat_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                DatTourDTO dt = new DatTourDTO();
                dt.MaDat = txtMaDat.Text;
                dt.MaKH = txtMaKH.Text;
                dt.MaTour = txtMaTour.Text;
                dt.NgayDat = dtpNgayDat.Value;
                dt.TinhTrangThanhToan = "Chưa thanh toán";
                dt.NguoiLon = int.Parse(txtNguoiLon.Text);
                dt.TreEm = int.Parse(txtTreEm.Text);
                if (bllCTT.InsertDatTour(dt))
                {
                    MessageBox.Show("Nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void txtNguoiLon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTreEm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
