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
using BaoDoiTour.HoaDon;
using BaoDoiTour.ChiTietHoaDon;
using BaoDoiTour.Controller;

namespace BaoDoiTour.View
{
    public partial class QLHDon : UserControl
    {
        HoaDon_BLL bllHDon;
        ChiTietHoaDon_BLL bllCTHDon;
        KetNoi kn = new KetNoi();
        public QLHDon()
        {
            InitializeComponent();
            bllHDon = new HoaDon_BLL();
            bllCTHDon = new ChiTietHoaDon_BLL();

            dtpNgayThanhToan.Enabled = false;
            dtpNgayThanhToan.Value = DateTime.Now;
            DataGridViewHoaDon.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular);
            DataGridViewHoaDon.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
        }

        public void ShowAllHoaDon()
        {
            DataTable dataTable = bllHDon.GetAllHoaDon();
            DataGridViewHoaDon.DataSource = dataTable;
        }

        public bool CheckDataHD()
        {
            if (string.IsNullOrEmpty(txtMaHDon.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHDon.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTinhTrang.Text))
            {
                MessageBox.Show("Bạn chưa nhập tình trạng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTinhTrang.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMaTour.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã tour.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTinhTrang.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTongTien.Text))
            {
                MessageBox.Show("Bạn chưa nhập tổng tiền.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTinhTrang.Focus();
                return false;
            }
            return true;
        }

        void OpenBox()
        {
            txtMaKH.Enabled = true;
            txtTinhTrang.Enabled = true;
            txtMaTour.Enabled = true;
            txtTongTien.Enabled = true;
        }

        void CloseBox()
        {
            txtMaTour.Enabled = false;
            txtTongTien.Enabled = false;
        }

        void ResetBox()
        {
            txtMaKH.Clear();
            txtTinhTrang.Clear();
            txtMaTour.Clear();
            txtTongTien.Clear();
        }

        bool checkThemSua = false;

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetBox();
            string MaHDon;
            if (bllHDon.GetSLHD() < 10)
                MaHDon = "NV00" + bllHDon.GetSLHD().ToString();
            else
                MaHDon = "NV0" + bllHDon.GetSLHD().ToString();
            txtMaHDon.Text = MaHDon;
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

                if (CheckDataHD())
                {
                    tbl_HoaDon hd = new tbl_HoaDon();
                    tbl_ChiTietHoaDon cthd = new tbl_ChiTietHoaDon();
                    hd.MaHD = txtMaHDon.Text;
                    hd.MaKH = txtMaKH.Text;
                    hd.TinhTrang = txtTinhTrang.Text;
                    cthd.MaHD = txtMaHDon.Text;
                    cthd.MaTour = txtMaTour.Text;
                    cthd.NgayThanhToan = dtpNgayThanhToan.Value;
                    cthd.TongTien = int.Parse(txtTongTien.Text);
                    if (bllHDon.InsertHoaDon(hd) && bllCTHDon.InsertCTHoaDon(cthd))
                    {
                        ShowAllHoaDon();
                        CloseBox();
                        MessageBox.Show("Nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLuu.Enabled = false;
                        btnThem.Enabled = true;
                    }

                    else
                    {
                        MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtMaKH.Focus();
                    }
                }
            }

            if (checkThemSua == false)
            {
                if (CheckDataHD())
                {
                    tbl_HoaDon hd = new tbl_HoaDon();
                    tbl_ChiTietHoaDon cthd = new tbl_ChiTietHoaDon();
                    hd.MaHD = txtMaHDon.Text;
                    hd.MaKH = txtMaKH.Text;
                    hd.TinhTrang = txtTinhTrang.Text;
                    cthd.MaHD = txtMaHDon.Text;
                    cthd.MaTour = txtMaTour.Text;
                    cthd.NgayThanhToan = dtpNgayThanhToan.Value;
                    cthd.TongTien = int.Parse(txtTongTien.Text);
                    if (bllHDon.UpdateHoaDon(hd) && bllCTHDon.UpdateCTHoaDon(cthd))
                    {
                        ShowAllHoaDon();
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CloseBox();
                        btnLuu.Enabled = false;
                        btnThem.Enabled = true;
                        btnSua.Enabled = false;
                    }

                    else
                    {
                        MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtMaKH.Focus();
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            OpenBox();
            txtMaHDon.ReadOnly = true;
            checkThemSua = false;
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnTroVe.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaHDon.Text == "")
            {
                MessageBox.Show("Chưa chọn nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            else
            {
                if (MessageBox.Show("Bạn có muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    tbl_HoaDon hd = new tbl_HoaDon();
                    tbl_ChiTietHoaDon cthd = new tbl_ChiTietHoaDon();
                    hd.MaHD = txtMaHDon.Text;
                    cthd.MaHD = txtMaHDon.Text;
                    if (bllHDon.DeleteHoaDon(hd) && bllCTHDon.DeleteCTHoaDon(cthd))
                    {
                        ShowAllHoaDon();
                        ResetBox();
                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ShowAllHoaDon();
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

        private void QLHDon_Load(object sender, EventArgs e)
        {
            if (MainLayout.currentUser.Quyen.ToUpper() == "KH")
            {
                string query = "SELECT * FROM HoaDon WHERE MaKH = '"+ MainLayout.currentUser.MaUser.Trim() +"'";
                btnThem.Visible = false;
                btnLuu.Visible = false;
                btnXoa.Visible = false;
                btnSua.Visible = false;
                btnTroVe.Visible = false;
                LoadDuLieuSauKhiLoc(query);
            }
            else
            {
                ShowAllHoaDon();
            }
            CloseBox();
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnTroVe.Enabled = false;
        }

        private void DataGridViewHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                CloseBox();

                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnXoa.Enabled = true;
                txtMaHDon.Text = DataGridViewHoaDon.Rows[index].Cells[0].Value.ToString();
                txtMaKH.Text = DataGridViewHoaDon.Rows[index].Cells[1].Value.ToString();
                txtTinhTrang.Text = DataGridViewHoaDon.Rows[index].Cells[2].Value.ToString();
            }
            string maHD = DataGridViewHoaDon.Rows[index].Cells[0].Value.ToString();

            DataTable dataTable = new DataTable();
            try
            {
                // Tạo câu truy vấn SQL để lấy dữ liệu chi tiết hóa đơn dựa vào mã hóa đơn
                string sqlQuery = "SELECT * FROM ChiTietHoaDon WHERE MaHD = '" + maHD.Trim() + "'";
                dataTable = kn.getTableData(sqlQuery);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    rptChiTietHDon baocao = new rptChiTietHDon();
                    baocao.SetDataSource(dataTable);
                    InRPTChiTietHoaDon f = new InRPTChiTietHoaDon();
                    f.rptVChiTietHoaDon.ReportSource = baocao;
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            finally
            {
                // Đóng kết nối sau khi hoàn thành công việc
                kn.close();
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị từ DateTimePicker
                DateTime startDate = dateTimePickkerStartDate.Value;
                DateTime endDate = dateTimhePickerEndDate.Value;

                // Sử dụng giá trị lấy từ DateTimePicker trong câu truy vấn
                string sqlCmd = $"EXEC GetHoaDonByDateRange '{startDate.ToString("yyyy-MM-dd")}', '{endDate.ToString("yyyy-MM-dd")}';";

                SqlDataReader reader = kn.getDataReader(sqlCmd);
                List<string> ds = new List<string>();

                while (reader.Read())
                {
                    ds.Add(reader.GetString(0));
                }

                // Tạo DataTable để lưu thông tin chi tiết của hóa đơn
                DataTable dataTable = new DataTable();

                // Thêm cột vào DataTable (tùy thuộc vào cấu trúc bảng HoaDon)
                dataTable.Columns.Add("MaHD", typeof(string));
                dataTable.Columns.Add("MaKH", typeof(string));
                dataTable.Columns.Add("TinhTrang", typeof(string));

                // Load thông tin chi tiết của từng hóa đơn vào DataTable
                foreach (string maHoaDon in ds)
                {
                    using (SqlCommand command = new SqlCommand("SELECT * FROM HoaDon WHERE MaHD = @MaHD", kn.Connect))
                    {
                        command.Parameters.AddWithValue("@MaHD", maHoaDon);
                        kn.close();
                        kn.open();
                        using (reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Thêm dòng mới vào DataTable
                                DataRow row = dataTable.NewRow();
                                row["MaHD"] = reader["MaHD"].ToString();
                                row["MaKH"] = reader["MaKH"].ToString();
                                row["TinhTrang"] = reader["TinhTrang"].ToString();
                                dataTable.Rows.Add(row);
                            }
                        }
                    }
                }
                // Gán DataTable làm DataSource cho DataGridView
                DataGridViewHoaDon.DataSource = dataTable;
            }
            finally
            {
                if (kn.Connect.State == ConnectionState.Open)
                    kn.close();
            }
        }

        private void LoadDuLieuSauKhiLoc(string query)
        {
            try
            {
                DataTable dataTable = kn.getTableData(query);

                DataGridViewHoaDon.AutoGenerateColumns = true;

                DataGridViewHoaDon.DataSource = dataTable;
            }
            finally
            {
                if (kn.Connect.State == ConnectionState.Open)
                    kn.close();
            }
        }

        private void btnLoc1_Click(object sender, EventArgs e)
        {
            string maHD = txtMaHDon.Text;
            string maKH = txtMaKH.Text;
            string tinhTrang = txtTinhTrang.Text;

            string query = "SELECT * FROM HoaDon WHERE 1 = 1";

            if (!string.IsNullOrEmpty(maHD))
            {
                query += $" AND MaHD = '{maHD}'";
            }

            if (!string.IsNullOrEmpty(maKH))
            {
                query += $" AND MaKH = '{maKH}'";
            }

            if (!string.IsNullOrEmpty(tinhTrang))
            {
                query += $" AND TinhTrang = N'{tinhTrang}'";
            }

            LoadDuLieuSauKhiLoc(query);
        }
    }
}
