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
using BaoDoiTour.ChiTietTour;
using BaoDoiTour.Controller;
using BaoDoiTour.View;
using System.Net;
using System.IO;

namespace BaoDoiTour.View
{
    public partial class ChiTietTour : Form
    {
        ChiTietTourBUS bllCTT;
        KetNoi kn = new KetNoi();
        string maTour;
        bool checkThemSua = false;
        public ChiTietTour(string ma, string chucNang)
        {
            InitializeComponent();
            bllCTT = new ChiTietTourBUS();
            maTour = ma;
            if (chucNang == "Sửa")
            {
                checkThemSua = false;
            }
            else if (chucNang == "Thêm")
            {
                checkThemSua = true;
                btnSua.Enabled = false;
                btnDat.Enabled = false;
                dtpNgayKetThuc.Value = DateTime.Now;
                dtpNgayKhoiHanh.Value = DateTime.Now;
            }

            txtSoNgay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtSoNgay.ReadOnly = true;
            txtSoNgay.BackColor = System.Drawing.Color.White;
        }

        public void CheckQuyen()
        {
            string quyen = MainLayout.currentUser.Quyen;
            if(quyen.ToUpper() != "ADMIN")
            {
                btnSua.Visible = false;
                btnLuu.Visible = false;
            }   
            else
            {
                btnSua.Visible = true;
                btnLuu.Visible = true;
            }    
        }

        void CloseBox()
        {
            dtpNgayKhoiHanh.Enabled = false;
            dtpNgayKetThuc.Enabled = false;

            txtMaTour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtMaTour.ReadOnly = true;
            txtMaTour.BackColor = System.Drawing.Color.White;

            txtMaNV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtMaNV.ReadOnly = true;
            txtMaNV.BackColor = System.Drawing.Color.White;

            txtNDTour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtNDTour.ReadOnly = true;
            txtNDTour.BackColor = System.Drawing.Color.White;
        }

        void OpenBox()
        {
            dtpNgayKhoiHanh.Enabled = true;
            dtpNgayKetThuc.Enabled = true;

            txtMaTour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtMaTour.ReadOnly = false;

            txtMaNV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtMaNV.ReadOnly = false;

            txtNDTour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtNDTour.ReadOnly = false;
        }

        public bool CheckData()
        {
            if (string.IsNullOrEmpty(txtMaTour.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã Tour.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTour.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Bạn chưa chọn mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNDTour.Text))
            {
                MessageBox.Show("Bạn chưa nhập nội dung tour.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNDTour.Focus();
                return false;
            }

            DateTime khoiHanh = Convert.ToDateTime(dtpNgayKhoiHanh.Value.ToString("yyyy-MM-dd"));
            DateTime ketThuc = Convert.ToDateTime(dtpNgayKetThuc.Value.ToString("yyyy-MM-dd"));
            DateTime hienTai = DateTime.Now;
            int check = TinhNgay(khoiHanh, ketThuc);
            int kh = TinhNgay(hienTai, khoiHanh);
            int kt = TinhNgay(hienTai, ketThuc);

            if (check <= 0)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày khởi hành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (kh < 0)
            {
                MessageBox.Show("Ngày khởi hành phải sau ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (kt < 0)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        public void ShowData()
        {
            CheckQuyen();
            ChiTietTourDTO ctt = new ChiTietTourDTO();
            ctt.MaTour = maTour;
            DataTable dataTable = bllCTT.GetTour(ctt);
            DataGridViewCTT.DataSource = dataTable;
            DataGridViewCTT.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular);
            DataGridViewCTT.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
        }

        private void ChiTietTour_Load(object sender, EventArgs e)
        {
            CheckQuyen();
            txtMaTour.Text = maTour;
            if (checkThemSua == false)
            {
                CloseBox();

                ShowData();

                GetInf(0);
                BaoDoiTour.Tour.Tour_BLL tourbll = new BaoDoiTour.Tour.Tour_BLL();
                string DuongDan = tourbll.LayAnh(maTour);
                string imagePath = "../../Resource/img/tours/" + DuongDan;

                if (System.IO.File.Exists(imagePath))
                {
                    pictureBox.ImageLocation = imagePath;
                }

            }

        }

        private void GetInf(int index)
        {
            if (index >= 0 && index < DataGridViewCTT.Rows.Count)
            {
                txtMaNV.Text = DataGridViewCTT.Rows[index].Cells[0].Value.ToString();
                txtSoNgay.Text = DataGridViewCTT.Rows[index].Cells[2].Value.ToString();
                dtpNgayKhoiHanh.Value = Convert.ToDateTime(DataGridViewCTT.Rows[index].Cells[3].Value.ToString());
                dtpNgayKetThuc.Value = Convert.ToDateTime(DataGridViewCTT.Rows[index].Cells[4].Value.ToString());
                txtNDTour.Text = DataGridViewCTT.Rows[index].Cells[5].Value.ToString();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int TinhNgay(DateTime khoiHanh, DateTime ketThuc)
        {
            TimeSpan duration = ketThuc - khoiHanh;
            return duration.Days;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (checkThemSua == true)
            {
                CheckQuyen();
                btnSua.Enabled = false;
                if (CheckData())
                {
                    DateTime khoiHanh = Convert.ToDateTime(dtpNgayKhoiHanh.Value.ToString("yyyy-MM-dd"));
                    DateTime ketThuc = Convert.ToDateTime(dtpNgayKetThuc.Value.ToString("yyyy-MM-dd"));

                    ChiTietTourDTO ctt = new ChiTietTourDTO();
                    ctt.MaTour = txtMaTour.Text;
                    ctt.MaNV = txtMaNV.Text;
                    ctt.NoiDungTour = txtNDTour.Text;
                    ctt.NgayKhoiHanh = dtpNgayKhoiHanh.Value;
                    ctt.NgayKetThuc = dtpNgayKetThuc.Value;
                    ctt.SoNgay = TinhNgay(khoiHanh, ketThuc);
                    ctt.DuongDan = txtAnh.Text;
                    if (bllCTT.InsertChiTietTour(ctt))
                    {
                        Show();
                        CloseBox();
                        MessageBox.Show("Nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLuu.Enabled = false;
                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtNDTour.Focus();
                    }
                }
            }

            if (checkThemSua == false)
            {
                CheckQuyen();
                if (CheckData())
                {
                    DateTime khoiHanh = Convert.ToDateTime(dtpNgayKhoiHanh.Value.ToString("yyyy-MM-dd"));
                    DateTime ketThuc = Convert.ToDateTime(dtpNgayKetThuc.Value.ToString("yyyy-MM-dd"));

                    ChiTietTourDTO ctt = new ChiTietTourDTO();
                    ctt.MaTour = txtMaTour.Text;
                    ctt.MaNV = txtMaNV.Text;
                    ctt.NoiDungTour = txtNDTour.Text;
                    ctt.NgayKhoiHanh = dtpNgayKhoiHanh.Value;
                    ctt.NgayKetThuc = dtpNgayKetThuc.Value;
                    ctt.SoNgay = TinhNgay(khoiHanh, ketThuc);
                    ctt.DuongDan = txtAnh.Text;
                    if (bllCTT.UpdateChiTietTour(ctt))
                    {
                        Show();
                        CloseBox();
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLuu.Enabled = false;
                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtNDTour.Focus();
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            OpenBox();
            dtpNgayKetThuc.Value = DateTime.Now;
            dtpNgayKhoiHanh.Value = DateTime.Now;
            txtMaNV.Clear();
            txtNDTour.Clear();
            txtSoNgay.Clear();
            txtAnh.Clear();
            btnSua.Enabled = false;
        }

        private void btnDat_Click(object sender, EventArgs e)
        {
            DatTour frm = new DatTour(maTour);
            frm.Show();
        }
    }
}
