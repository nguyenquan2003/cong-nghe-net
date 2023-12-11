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
using BaoDoiTour.NhanVien;
using BaoDoiTour.View;
using BaoDoiTour.Controller;

namespace BaoDoiTour.View
{
    public partial class QLNV : UserControl
    {
        NhanVien_BLL bllNV;
        KetNoi kn = new KetNoi();
        
        public QLNV()
        {
            InitializeComponent();
            bllNV = new NhanVien_BLL();
        }

        public void ShowAllNhanVien()
        {
            DataTable dataTable = bllNV.GetAllNhanVien();
            DataGridViewNhanVien.DataSource = dataTable;
            DataGridViewNhanVien.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular);
            DataGridViewNhanVien.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
        }

        public bool CheckDataNV()
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoTen.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
                return false;
            }

            if ((DateTime.Now.Year - dtpNgaySinh.Value.Year) < 18)
            {
                MessageBox.Show("Chưa đủ 18 tuổi!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Bạn chưa nhập Email.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return false;
            }

            if (cboChucVu.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chọn chức vụ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboChucVu.Focus();
                return false;
            }
            return true;
        }

        void OpenBox()
        {
            txtHoTen.Enabled = true;
            dtpNgaySinh.Enabled = true;
            txtSDT.Enabled = true;
            txtEmail.Enabled = true;
            cboChucVu.Enabled = true;
        }

        void CloseBox()
        {
            txtHoTen.Enabled = false;
            dtpNgaySinh.Enabled = false;
            txtSDT.Enabled = false;
            txtEmail.Enabled = false;
            cboChucVu.Enabled = false;
        }

        void ResetBox()
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            txtSDT.Clear();
            txtEmail.Clear();
            cboChucVu.SelectedIndex = -1;
        }

        bool checkThemSua = false;

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetBox();
            string sqlCmd = "SELECT dbo.GenerateEmployeeCode()";
            using (SqlDataReader reader = kn.getDataReader(sqlCmd))
            {
                if (reader.Read())
                {
                    string maNVMoi = reader.GetString(0);
                    txtMaNV.Text = maNVMoi;
                }
            }
            OpenBox();
            checkThemSua = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnTroVe.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (checkThemSua == true)
            {

                if (CheckDataNV())
                {
                    tbl_NhanVien nv = new tbl_NhanVien();
                    nv.MaNV = txtMaNV.Text;
                    nv.TenNV = txtHoTen.Text;
                    nv.NgaySinh = dtpNgaySinh.Value;
                    nv.SDT = txtSDT.Text;
                    nv.Email = txtEmail.Text;
                    nv.ChucVu = cboChucVu.SelectedItem.ToString();
                    if (bllNV.InsertNhanVien(nv))
                    {
                        ShowAllNhanVien();
                        CloseBox();
                        MessageBox.Show("Nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLuu.Enabled = false;
                        btnThem.Enabled = true;
                    }

                    else
                    {
                        MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtHoTen.Focus();
                    }
                }
            }

            if (checkThemSua == false)
            {
                if (CheckDataNV())
                {
                    tbl_NhanVien nv = new tbl_NhanVien();
                    nv.MaNV = txtMaNV.Text;
                    nv.TenNV = txtHoTen.Text;
                    nv.NgaySinh = dtpNgaySinh.Value;
                    nv.SDT = txtSDT.Text;
                    nv.Email = txtEmail.Text;
                    nv.ChucVu = cboChucVu.SelectedItem.ToString();
                    if (bllNV.UpdateNhanVien(nv))
                    {
                        ShowAllNhanVien();
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CloseBox();
                        btnLuu.Enabled = false;
                        btnThem.Enabled = true;
                        btnSua.Enabled = false;
                    }

                    else
                    {
                        MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtHoTen.Focus();
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            OpenBox();
            txtMaNV.ReadOnly = true;
            checkThemSua = false;
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnTroVe.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Chưa chọn nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            else
            {
                if (MessageBox.Show("Bạn có muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    tbl_NhanVien nv = new tbl_NhanVien();
                    nv.MaNV = txtMaNV.Text;
                    if (bllNV.DeleteNhanVien(nv))
                    {
                        ShowAllNhanVien();
                        ResetBox();
                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ShowAllNhanVien();
                    }

                    else
                        MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác??", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ResetBox();
                CloseBox();
                btnThem.Enabled = true;
                btnLuu.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnTroVe.Enabled = false;
            }
        }

        private void QLNV_Load(object sender, EventArgs e)
        {
            ShowAllNhanVien();
            CloseBox();
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnTroVe.Enabled = false;
        }

        private void DataGridViewNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboChucVu.SelectedItem = "";
            int index = e.RowIndex;
            if (index >= 0)
            {
                CloseBox();

                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnXoa.Enabled = true;
                txtMaNV.Text = DataGridViewNhanVien.Rows[index].Cells[0].Value.ToString();
                txtHoTen.Text = DataGridViewNhanVien.Rows[index].Cells[1].Value.ToString();
                txtEmail.Text = DataGridViewNhanVien.Rows[index].Cells[2].Value.ToString();
                txtSDT.Text = DataGridViewNhanVien.Rows[index].Cells[3].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(DataGridViewNhanVien.Rows[index].Cells[4].Value.ToString());
                cboChucVu.SelectedItem = DataGridViewNhanVien.Rows[index].Cells[5].Value.ToString();
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
