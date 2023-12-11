using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaoDoiTour.Controller;
using System.Data.SqlClient;
using BaoDoiTour.KhachHang;

namespace BaoDoiTour.View
{
    public partial class QLKHang : UserControl
    {
        KetNoi kn = new KetNoi();
        KhachHang_BLL kh_bll = new KhachHang_BLL();
        bool checkSua = false;
        public QLKHang()
        {
            InitializeComponent();
        }

        private void openSaveBtn()
        {
            btnLuu.Enabled = true;
            btnTroVe.Enabled = true;
        }

        private void closeSaveBtn()
        {
            btnLuu.Enabled = false;
            btnTroVe.Enabled = false;
        }

        //Load danh sách khách hàng
        private void LoadDgvKhachHang()
        {
            dgvKhachHang.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dgvKhachHang.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular);

            // Load bảng khách hàg
            dgvKhachHang.DataSource = kh_bll.LayDSKhachHang();
        }

        private bool IsValidData()
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text.Trim()) ||
                string.IsNullOrWhiteSpace(txtTenKH.Text.Trim()) ||
                string.IsNullOrWhiteSpace(txtSdtKH.Text.Trim()) ||
                string.IsNullOrWhiteSpace(txtEmailKH.Text.Trim()) ||
                string.IsNullOrWhiteSpace(txtMatKhau.Text.Trim()))
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

            //Kiểm tra tích điểm
            if (!int.TryParse(txtTichDiemKH.Text.Trim(), out _))
            {
                MessageBox.Show("Số điện thoại phải là số.");
                return false;
            }

            // Kiểm tra định dạng email hợp lệ
            if (!IsValidEmail(txtEmailKH.Text.Trim()))
            {
                MessageBox.Show("Email không hợp lệ.");
                return false;
            }

            // Kiểm tra mật khẩu có đủ độ dài
            if (txtMatKhau.Text.Trim().Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 kí tự.");
                return false;
            }
            // Các kiểm tra khác tùy thuộc vào yêu cầu của bạn
            return true; // Trả về true nếu tất cả điều kiện hợp lệ
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        private void QLKHang_Load(object sender, EventArgs e)
        {
            khoaControls();
            LoadDgvKhachHang();
        }

        private void moKhoaControls()
        {
            txtMaKH.ReadOnly = true;
            txtTenKH.Enabled = true;
            dptNgaySinhKH.Enabled = true;
            cboGTinhKH.Enabled = true;
            txtSdtKH.Enabled = true;
            txtEmailKH.Enabled = true;
            txtMatKhau.Enabled = true;
            txtDiaChiKH.Enabled = true;
            txtTichDiemKH.Enabled = true;
        }

        private void khoaControls()
        {
            txtMaKH.ReadOnly = true;
            txtTenKH.Enabled = false;
            dptNgaySinhKH.Enabled = false;
            cboGTinhKH.Enabled = false;
            txtSdtKH.Enabled = false;
            txtEmailKH.Enabled = false;
            txtMatKhau.Enabled = false;
            txtDiaChiKH.Enabled = false;
            txtTichDiemKH.Enabled = false;
        }

        private void resetControls()
        {
            checkSua = false;
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            dptNgaySinhKH.Value = DateTime.Now;
            cboGTinhKH.Text = "";
            txtSdtKH.Text = "";
            txtEmailKH.Text = "";
            txtMatKhau.Text = "";
            txtDiaChiKH.Text = "";
            txtTichDiemKH.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                resetControls();
                moKhoaControls();
                openSaveBtn();
                string sqlCmd = "SELECT dbo.GenerateKhachHangCode()";
                using (SqlDataReader reader = kn.getDataReader(sqlCmd))
                {
                    if (reader.Read())
                    {
                        string maKhachHangMoi = reader.GetString(0);
                        txtMaKH.Text = maKhachHangMoi;
                    }
                }
            }
            finally
            {
                if (kn.Connect.State == ConnectionState.Open)
                    kn.close();
            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                tbl_KhachHang khachHang = new tbl_KhachHang
                {
                    MaKH = txtMaKH.Text.Trim(),
                    TenKH = txtTenKH.Text.Trim(),
                    NgaySinh = dptNgaySinhKH.Value,
                    GioiTinh = cboGTinhKH.Text.Trim(),
                    SoDT = txtSdtKH.Text.Trim(),
                    Email = txtEmailKH.Text.Trim(),
                    MatKhau = txtMatKhau.Text.Trim(),
                    DiaChi = txtDiaChiKH.Text.Trim(),
                    TichDiem = Int32.Parse(txtTichDiemKH.Text.Trim())
                };
                if (checkSua)
                {
                    if (kh_bll.SuaKhachHang(khachHang) == 1)
                    {
                        MessageBox.Show("Sửa thành công", "Thông báo thêm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại", "Thông báo thêm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (kh_bll.ThemKhachHang(khachHang) == 1)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo thêm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại", "Thông báo thêm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                resetControls();
                LoadDgvKhachHang();
                khoaControls();
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                closeSaveBtn();
            }
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn hủy thao tác?", "Thông báo hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                khoaControls();
                resetControls();
                closeSaveBtn();
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            openSaveBtn();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            resetControls();
            khoaControls();
            int index = e.RowIndex;
            txtMaKH.Text = dgvKhachHang.Rows[index].Cells[0].Value.ToString();
            txtTenKH.Text = dgvKhachHang.Rows[index].Cells[1].Value.ToString();
            dptNgaySinhKH.Value = Convert.ToDateTime(dgvKhachHang.Rows[index].Cells[2].Value.ToString());
            cboGTinhKH.Text = dgvKhachHang.Rows[index].Cells[3].Value.ToString();
            txtSdtKH.Text = dgvKhachHang.Rows[index].Cells[4].Value.ToString();
            txtEmailKH.Text = dgvKhachHang.Rows[index].Cells[5].Value.ToString();
            txtMatKhau.Text = dgvKhachHang.Rows[index].Cells[6].Value.ToString();
            txtDiaChiKH.Text = dgvKhachHang.Rows[index].Cells[7].Value.ToString();
            txtTichDiemKH.Text = dgvKhachHang.Rows[index].Cells[8].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            moKhoaControls();
            openSaveBtn();
            checkSua = true;
        }

        private void txtSdtKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTichDiemKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                closeSaveBtn();
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                if (MessageBox.Show("Bạn có chắc muốn xóa tour này?", "Thông báo xóa tour", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int idx = dgvKhachHang.SelectedRows[0].Index;
                    string maTour = dgvKhachHang.Rows[idx].Cells[0].Value.ToString();
                    string query = "DELETE FROM KhachHang WHERE MaKH = '" + maTour + "'";
                    if (kn.getNonQuery(query) == 1)
                    {
                        MessageBox.Show("Xóa thành công !");
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại !");
                    }
                    LoadDgvKhachHang();
                    resetControls();
                    khoaControls();
                }
            }
            finally
            {
                if (kn.Connect.State == ConnectionState.Open)
                    kn.close();
            }
        }
    }
}
