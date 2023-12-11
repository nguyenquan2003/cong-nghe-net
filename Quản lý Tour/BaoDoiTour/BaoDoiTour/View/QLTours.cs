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
using BaoDoiTour.Tour;
using BaoDoiTour.ChiTietTour;

namespace BaoDoiTour.View
{
    public partial class QLTours : UserControl
    {
        Tour_BLL bllTour;
        ChiTietTourBUS bllCTT;
        public QLTours()
        {
            InitializeComponent();
            bllTour = new Tour_BLL();
            bllCTT = new ChiTietTourBUS();
            string quyen = MainLayout.currentUser.Quyen;
            if (quyen.ToUpper() == "ADMIN")
            {
                tabControl1.SelectedTab = tabPage2;
            }
            else
            {
                tabControl1.SelectedTab = tabPage1;
            }
        }

        public void ShowAllTour()
        {
            DataTable dataTable = bllTour.GetAllTour();
            DataGridViewTour.DataSource = dataTable;
            DataGridViewTour.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular);
            DataGridViewTour.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
        }

        public bool CheckDataTour()
        {
            if (string.IsNullOrEmpty(txtMaTour.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã Tour.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTour.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenTour.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên Tour.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenTour.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMieuTa.Text))
            {
                MessageBox.Show("Bạn chưa nhập miêu tả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMieuTa.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtGia.Text))
            {
                MessageBox.Show("Bạn chưa nhập giá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGia.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtDiaDiem.Text))
            {
                MessageBox.Show("Bạn chưa nhập địa điểm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaDiem.Focus();
                return false;
            }
            return true;
        }

        void OpenBox()
        {
            txtTenTour.Enabled = true;
            txtMieuTa.Enabled = true;
            txtGia.Enabled = true;
            txtDiaDiem.Enabled = true;
        }

        void CloseBox()
        {
            txtTenTour.Enabled = false;
            txtMieuTa.Enabled = false;
            txtGia.Enabled = false;
            txtDiaDiem.Enabled = false;
        }

        void ResetBox()
        {
            txtTenTour.Clear();
            txtMieuTa.Clear();
            txtGia.Clear();
            txtDiaDiem.Clear();
        }

        bool checkThemSua = false;

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetBox();
            string MaTour;
            if (bllTour.GetSLTour() < 10)
                MaTour = "T00" + bllTour.GetSLTour().ToString();
            else
                MaTour = "T0" + bllTour.GetSLTour().ToString();
            txtMaTour.Text = MaTour;
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

                if (CheckDataTour())
                {
                    tbl_Tour tour = new tbl_Tour();
                    tour.MaTour = txtMaTour.Text;
                    tour.TenTour = txtTenTour.Text;
                    tour.MieuTa = txtMieuTa.Text;
                    tour.Gia = int.Parse(txtGia.Text);
                    tour.DiaDiem = txtDiaDiem.Text;
                    if (bllTour.InsertTour(tour))
                    {
                        ShowAllTour();
                        CloseBox();
                        MessageBox.Show("Nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLuu.Enabled = false;
                        btnThem.Enabled = true;

                        ChiTietTour frm = new ChiTietTour(txtMaTour.Text, "Thêm");
                        frm.Show();
                    }

                    else
                    {
                        MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtTenTour.Focus();
                    }
                }
            }

            if (checkThemSua == false)
            {
                if (CheckDataTour())
                {
                    tbl_Tour tour = new tbl_Tour();
                    tour.MaTour = txtMaTour.Text;
                    tour.TenTour = txtTenTour.Text;
                    tour.MieuTa = txtMieuTa.Text;
                    tour.Gia = int.Parse(txtGia.Text);
                    tour.DiaDiem = txtDiaDiem.Text;
                    if (bllTour.UpdateTour(tour))
                    {
                        ShowAllTour();
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CloseBox();
                        btnLuu.Enabled = false;
                        btnThem.Enabled = true;
                        btnSua.Enabled = false;
                    }

                    else
                    {
                        MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtTenTour.Focus();
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            OpenBox();
            txtMaTour.Enabled = false;
            checkThemSua = false;
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnTroVe.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaTour.Text == "")
            {
                MessageBox.Show("Chưa chọn tour", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            else
            {
                if (MessageBox.Show("Bạn có muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    tbl_Tour tour = new tbl_Tour();
                    tour.MaTour = txtMaTour.Text;
                    ChiTietTourDTO ctt = new ChiTietTourDTO();
                    ctt.MaTour = txtMaTour.Text;
                    if(bllCTT.DeleteChiTietTour(ctt)) 
                    {
                        if (bllTour.DeleteTour(tour))
                        {
                            ShowAllTour();
                            ResetBox();
                            btnSua.Enabled = false;
                            btnXoa.Enabled = false;
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ShowAllTour();
                        }
                        else
                            MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                        MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        private void QLTours_Load(object sender, EventArgs e)
        {
            ShowAllTour();
            CloseBox();
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnTroVe.Enabled = false;
        }

        private void DataGridViewTour_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                CloseBox();

                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnXoa.Enabled = true;
                txtMaTour.Text = DataGridViewTour.Rows[index].Cells[0].Value.ToString();
                txtTenTour.Text = DataGridViewTour.Rows[index].Cells[1].Value.ToString();
                txtMieuTa.Text = DataGridViewTour.Rows[index].Cells[2].Value.ToString();
                txtGia.Text = DataGridViewTour.Rows[index].Cells[3].Value.ToString();
                txtDiaDiem.Text = DataGridViewTour.Rows[index].Cells[4].Value.ToString();
            }

            ChiTietTour frm = new ChiTietTour(txtMaTour.Text, "Sửa");
            frm.Show();
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DataGridViewTour.DataSource = null;
            DataGridViewTour.Rows.Clear();
            DataGridViewTour.Columns.Clear();
            tbl_Tour tour = new tbl_Tour();
            tour.DiaDiem = txtDD.Text;
            DataTable dataTable = bllTour.Search(tour);
            DataGridViewTour.DataSource = dataTable;
            DataGridViewTour.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular);
            DataGridViewTour.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
        }

    }
}
