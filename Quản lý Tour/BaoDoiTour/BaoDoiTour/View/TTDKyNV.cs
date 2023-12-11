using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaoDoiTour.User;
using BaoDoiTour.KhachHang;
using BaoDoiTour.Controller;
using System.Data.SqlClient;

namespace BaoDoiTour.View
{
    public partial class TTDKyNV : Form
    {
        public static tbl_User currentKH { get; private set; }
        KetNoi kn = new KetNoi();

        public TTDKyNV(tbl_User kh)
        {
            currentKH = kh;
            InitializeComponent();
        }

        private bool IsValidData()
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text.Trim()) ||
                string.IsNullOrWhiteSpace(txtTenKH.Text.Trim()) ||
                string.IsNullOrWhiteSpace(txtSdtKH.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa điền đầy đủ thông tin !");
                return false; // Trả về false nếu có ít nhất một trường không hợp lệ
            }

            // Kiểm tra ngày sinh có đủ 18 tuổi hay không
            DateTime ngaySinh = dptNgaySinhKH.Value;
            DateTime ngayHienTai = DateTime.Now;
            int tuoi = ngayHienTai.Year - ngaySinh.Year;

            if (ngayHienTai < ngaySinh.AddYears(tuoi))
            {
                tuoi--;
            }

            if (tuoi < 18)
            {
                MessageBox.Show("Khách hàng phải đủ 18 tuổi trở lên.");
                return false;
            }

            // Kiểm tra số điện thoại có phải là số hay không
            if (!int.TryParse(txtSdtKH.Text.Trim(), out _))
            {
                MessageBox.Show("Số điện thoại phải là số.");
                return false;
            }
            return true; // Trả về true nếu tất cả điều kiện hợp lệ
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            btnTroVe.Enabled = true;
            string sqlCmd = "SELECT dbo.GenerateKhachHangCode()";
            string maKhachHangMoi;
            using (SqlDataReader reader = kn.getDataReader(sqlCmd))
            {
                if (reader.Read())
                {
                    maKhachHangMoi = reader.GetString(0);
                    txtMaKH.Text = maKhachHangMoi;
                }
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidData())
                {
                    btnTroVe.Enabled = false;
                    tbl_KhachHang kh = new tbl_KhachHang
                    {
                        MaKH = txtMaKH.Text.Trim(),
                        TenKH = txtTenKH.Text.Trim(),
                        NgaySinh = dptNgaySinhKH.Value,
                        GioiTinh = cboGTinhKH.SelectedItem.ToString(),
                        SoDT = txtSdtKH.Text.Trim(),
                        Email = currentKH.Email,
                        MatKhau = currentKH.MatKhau,
                        DiaChi = txtDiaChiKH.Text.Trim(),
                        TichDiem = 0,
                        Quyen = currentKH.Quyen.Trim()
                    };
                    KhachHang_BLL kh_bll = new KhachHang_BLL();
                    if (kh_bll.ThemKhachHang(kh) > 0)
                    {
                        MessageBox.Show("Đăng ký thành công !");
                        this.Close();
                    }
                }
            }
            finally
            {
                if (kn.Connect.State == ConnectionState.Open)
                    kn.close();
            }
        }

        private void resetControls()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            dptNgaySinhKH.Value = DateTime.Now;
            cboGTinhKH.Text = "";
            txtSdtKH.Text = "";
            txtDiaChiKH.Text = "";
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            resetControls();
            btnLuu.Enabled = false;
            btnTroVe.Enabled = false;
        }

        private void txtSdtKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
