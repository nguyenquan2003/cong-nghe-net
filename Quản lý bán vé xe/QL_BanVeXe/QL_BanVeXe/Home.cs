using DoAnCuoiKy;
using LogIn_SignIn;
using QLVe_XuatVe;
using QuanLyLoTrinh;
using QuanLyXe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace QL_BanVeXe
{
    public partial class QLBVX : Form
    {
        List<Label> labels = new List<Label>();
        DBConnect db = new DBConnect();
        public QLBVX()
        {
            InitializeComponent();
            toolStripButton1.Text = "Quản lí \n tài khoản";
            toolStripButton2.Text = "Đăng xuất";
            toolStripButton3.Text = "Thoát \n chương trình";
            toolStripButton4.Text = "Quản lí vé";
            toolStripButton5.Text = "Quản lí \n lộ trình";
            toolStripButton6.Text = "Quản lí xe";
            toolStripButton7.Text = "Bán vé";
            toolStripButton8.Text = "Xuất vé";
            toolStripButton9.Text = "Quản lí \nchuyến đi";

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            pnl_BanVe.Visible = true;
            load_cboTuyenXe();
        }

        private void clearControl()
        {
            txt_TenKH.Clear();
            txt_TenGhe.Clear();
            txt_thanhTien.Clear();
            txt_ghiChu.Clear();
            txt_SoLuong.Clear();
            txt_sdtKH.Clear();
        }
        private void lbl_seatB1_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            string tenGhe = lbl.Text;
            bool isSeatBooked = CheckSeatBooked(tenGhe);
            if (lbl.BackColor == Color.Yellow)
                MessageBox.Show("Vé đã bán! Bạn hãy chọn ghế khác. ");

            if (isSeatBooked)
            {
                MessageBox.Show("Ghế đã đặt! Vui lòng chọn ghế khác.");
            }
            else
            {
                if (lbl.BackColor == Color.FromArgb(128, 128, 255))
                {
                    lbl.BackColor = Color.FromArgb(192, 192, 255);
                    labels.Remove(lbl);
                }
                else
                {
                    lbl.BackColor = Color.FromArgb(128, 128, 255);
                    labels.Add(lbl);

                }
                HienThiThongTin_SoLuongGhe();

            }
        }

        private void HienThiThongTin_SoLuongGhe()
        {
            txt_TenGhe.Text = "";
            foreach (Label label in labels)
            {
                txt_TenGhe.Text += label.Text + " ";
            }
            txt_SoLuong.Text = labels.Count.ToString();
        }
        public void load_cboTuyenXe()
        {
            string sql = "select * from TUYENXE";
            DataTable dt_tuyenxe = db.GetDataTable(sql);
            cbo_Tuyenxe.DataSource = dt_tuyenxe;
            cbo_Tuyenxe.DisplayMember = "TenTuyen";
            cbo_Tuyenxe.ValueMember = "MaTuyen";
        }
        private void LoadComboBoxXe()
        {
            string maTuyen = cbo_Tuyenxe.SelectedValue.ToString();
            DateTime ngayKhoiHanh = dateTimePicker1.Value;
            string formattedDate = ngayKhoiHanh.ToString("yyyy-MM-dd");
            string gioDi = cbo_gioDi.SelectedValue.ToString();

            string sql = $"SELECT DISTINCT BienSo FROM CHUYENXE WHERE MaTuyen = '{maTuyen}' AND NgayKH = '{formattedDate}' AND GioDi = '{gioDi}'";
            DataTable dtXe = db.GetDataTable(sql);

            if (dtXe.Rows.Count > 0)
            {
                string bienSoXe = dtXe.Rows[0]["BienSo"].ToString();
                txt_Xe.Text = bienSoXe;
            }
            else
            {
                txt_Xe.Text = "No available Xe";
            }
            HienThiGheTrong();
        }
        public void HienThiGheTrong()
        {
            string maTuyen = cbo_Tuyenxe.SelectedValue.ToString();
            DateTime ngayKhoiHanh = dateTimePicker1.Value;
            string formattedDate = ngayKhoiHanh.ToString("yyyy-MM-dd");
            string gioDi = cbo_gioDi.SelectedValue.ToString();
            string bienSoXe = txt_Xe.Text.ToString();

            int soLuongGheTrong = GetGheTrong(maTuyen, gioDi, bienSoXe, formattedDate);

            txt_soGheTrong.Text = soLuongGheTrong.ToString();
        }
        public int GetGheTrong(string maTuyen, string GioDi, string BienSo, string NgayKH)
        {
            string sql = $"SELECT GheTrong FROM CHUYENXE WHERE BienSo='{BienSo}' AND MaTuyen ='{maTuyen}' AND GioDi='{GioDi}'AND NgayKH='{NgayKH}'";
            object result = db.getScalar(sql);

            if (result == null || result == DBNull.Value)
            {
                MessageBox.Show("Không có xe này");
            }

            return Convert.ToInt32(result);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;
            if (!Ktr_CXeTonTai(selectedDate))
            {
                MessageBox.Show("Không có chuyến xe cho ngày đã chọn.");
            }
            else
            {
                LoadComboBoxGioDi();
            }
        }
        private bool Ktr_CXeTonTai(DateTime selectedDate)
        {
            string ngaykhoihanh = selectedDate.ToString("yyyy-MM-dd");
            string sql = $"SELECT COUNT(*) FROM CHUYENXE WHERE NgayKH = '{ngaykhoihanh}'";
            int count = (int)db.getScalar(sql);
            return count > 0;
        }

        private void LoadComboBoxGioDi()
        {
            string maTuyen = cbo_Tuyenxe.SelectedValue.ToString();
            DateTime ngayKhoiHanh = dateTimePicker1.Value;
            string formattedDate = ngayKhoiHanh.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            string sql = $"SELECT DISTINCT GioDi FROM CHUYENXE WHERE MaTuyen = '{maTuyen}' AND NgayKH = '{formattedDate}'";

            DataTable dtGioKhoiHanh = db.GetDataTable(sql);

            cbo_gioDi.DataSource = dtGioKhoiHanh;
            cbo_gioDi.DisplayMember = "GioDi";
            cbo_gioDi.ValueMember = "GioDi";
            LoadComboBoxXe();
        }
        private double LayGiaVe(string maTuyen)
        {
            string sql = $"SELECT BangGia FROM TUYENXE WHERE MaTuyen = '{maTuyen}'";
            object result = db.getScalar(sql);

            if (result == null || result == DBNull.Value)
            {
                MessageBox.Show("Không có thông tin giá vé cho chuyến đi đã chọn.");
                return 0;
            }

            return Convert.ToDouble(result);
        }

        private void HienThiGiaVe()
        {
            if (int.TryParse(txt_SoLuong.Text, out int soLuong))
            {
                string maTuyen = cbo_Tuyenxe.SelectedValue.ToString();

                double giaVe = LayGiaVe(maTuyen);
                double thanhTien = giaVe * soLuong;
                // Hiển thị giá vé lên TextBox
                txt_thanhTien.Text = thanhTien.ToString("");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            HienThiGiaVe();
        }

        private string LayMaChuyen()
        {
            string maTuyen = cbo_Tuyenxe.SelectedValue.ToString();
            DateTime ngayKhoiHanh = dateTimePicker1.Value;
            string formattedDate = ngayKhoiHanh.ToString("yyyy-MM-dd");
            string gioDi = cbo_gioDi.SelectedValue.ToString();
            string bienSoXe = txt_Xe.Text.ToString();

            string sql = $"SELECT MaChuyen FROM CHUYENXE WHERE MaTuyen = '{maTuyen}' AND GioDi = '{gioDi}' AND BienSo = '{bienSoXe}' AND NgayKH = '{formattedDate}'";
            object result = db.getScalar(sql);

            if (result == null || result == DBNull.Value)
            {
                MessageBox.Show("Không có mã chuyến cho chuyến đi đã chọn.");
                return "";
            }

            return result.ToString();
        }
        private string LayMaNhanVien()
        {
            return "AD15092015001";
        }
        private void ThemVe()
        {
            string maChuyen = LayMaChuyen();
            string maNhanVien = LayMaNhanVien();

            if (maChuyen == "" || maNhanVien == "")
            {
                MessageBox.Show("Không thể thêm vé do thiếu thông tin.");
                return;
            }

            if (int.TryParse(txt_SoLuong.Text, out int soLuong))
            {
                for (int i = 0; i < soLuong; i++)
                {
                    string maVe = TaoMaVe();
                    if (db.CheckPrimaryKeyExist("VEXE", "MaVe", maVe))
                    {
                        MessageBox.Show($"Mã vé {maVe} đã tồn tại. Vui lòng tạo mã vé khác.");
                    }
                    else
                    {
                        string sqlVe = $"INSERT INTO VEXE(MaVe, MaChuyen, MaNV) VALUES('{maVe}', '{maChuyen}', '{maNhanVien}')";
                        int rowsAffectedVe = db.getNonQuery(sqlVe);

                        // Kiểm tra và thông báo kết quả thêm vé
                        if (rowsAffectedVe > 0)
                        {
                            MessageBox.Show("Thêm vé thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm vé. Vui lòng thử lại.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số lượng vé hợp lệ.");
            }
        }

        private string TaoMaVe()
        {
            string maVe = dateTimePicker1.Value.ToString("ddMMyyyy") + (GetSoLuongVe() + 1).ToString("000");
            return maVe;
        }

        private int GetSoLuongVe()
        {
            string sql = "SELECT COUNT(*) FROM VEXE";
            object result = db.getScalar(sql);

            if (result == null || result == DBNull.Value)
            {
                return 0;
            }

            return Convert.ToInt32(result);
        }

        private void btn_themCTVe_Click(object sender, EventArgs e)
        {
            ThemThongTinKhachHang(txt_sdtKH.Text, txt_TenKH.Text);
            string maChuyen = LayMaChuyen();
            string maNhanVien = LayMaNhanVien();
            string maVe = TaoMaVe();
            txt_MaVe.Text = maVe;
            if (db.CheckPrimaryKeyExist("VEXE", "MaVe", maVe))
            {
                MessageBox.Show($"Mã vé {maVe} đã tồn tại. Vui lòng tạo mã vé khác.");
            }

            string sqlThemVe = $"INSERT INTO VEXE(MaVe, MaChuyen, MaNV) VALUES('{maVe}', '{maChuyen}', '{maNhanVien}')";
            db.getNonQuery(sqlThemVe);

            DataTable dt_ctvxe = new DataTable();
            string sql = "select * from CTVEXE";
            dt_ctvxe = db.GetDataTable(sql);
            DataRow row = dt_ctvxe.NewRow();
            row["MaVe"] = txt_MaVe.Text;
            row["SDTKH"] = txt_sdtKH.Text;
            row["Soluong"] = txt_SoLuong.Text;
            row["ThanhTien"] = txt_thanhTien.Text;
            row["Ghichu"] = txt_ghiChu.Text;
            row["TenGhe"] = txt_TenGhe.Text;
            row["NgayDatVe"] = DateTime.Now.ToString();

            dt_ctvxe.Rows.Add(row);
            string sql2 = "select * from CTVEXE";
            int kq = db.updateDatabase(sql2, dt_ctvxe);
            if (kq > 0)
            {
                MessageBox.Show("Thêm thành công!");
                CapNhatSoGheTrong();
                clearControl();
            }
            else
                MessageBox.Show("Thêm không thành công!!!");
            foreach (Label lbl in labels)
            {
                lbl.BackColor = Color.Yellow;
            }
        }
        private void ThemThongTinKhachHang(string sdt, string tenKhachHang)
        {
            if (!KiemTraKhachHangTonTai(sdt))
            {
                string sqlThemKhachHang = $"INSERT INTO KhachHang(SDTKH, HoTenTenKH) VALUES('{sdt}', '{tenKhachHang}')";
                int rowsAffected=db.getNonQuery(sqlThemKhachHang);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Đây là khách hàng mới! Đã lưu lại thông tin khách hàng thành công1");
                }
                else
                {
                    MessageBox.Show("Không thể thêm thông tin khách hàng. Vui lòng thử lại.");
                }
            }
        }

        private bool KiemTraKhachHangTonTai(string sdt)
        {
            string sql = $"SELECT COUNT(*) FROM KhachHang WHERE SDTKH = '{sdt}'";
            int count = (int)db.getScalar(sql);

            return count > 0;
        }
        private void CapNhatSoGheTrong()
        {
            if (int.TryParse(txt_SoLuong.Text, out int soLuong))
            {
                string maTuyen = cbo_Tuyenxe.SelectedValue.ToString();
                DateTime ngayKhoiHanh = dateTimePicker1.Value;
                string formattedDate = ngayKhoiHanh.ToString("yyyy-MM-dd");
                string gioDi = cbo_gioDi.SelectedValue.ToString();
                string bienSoXe = txt_Xe.Text.ToString();

                int soLuongGheTrong = GetGheTrong(maTuyen, gioDi, bienSoXe, formattedDate);
                // Giảm số ghế trống theo số lượng vé đã thêm
                soLuongGheTrong -= soLuong;

                // Cập nhật số ghế trống lên TextBox
                txt_soGheTrong.Text = soLuongGheTrong.ToString();
                UpdateSoGheTrong(maTuyen, gioDi, bienSoXe, formattedDate, soLuongGheTrong);
            }
        }
        private void UpdateSoGheTrong(string maTuyen, string gioDi, string bienSoXe, string ngayKhoiHanh, int soLuongGheTrong)
        {
            string sqlUpdate = $"UPDATE CHUYENXE SET GheTrong = {soLuongGheTrong} WHERE MaTuyen = '{maTuyen}' AND GioDi = '{gioDi}' AND BienSo = '{bienSoXe}' AND NgayKH = '{ngayKhoiHanh}'";

            int rowsAffected = db.getNonQuery(sqlUpdate);

            if (rowsAffected > 0)
            {
                MessageBox.Show("Cập nhật số ghế trống thành công!");
            }
            else
            {
                MessageBox.Show("Không thể cập nhật số ghế trống. Vui lòng thử lại.");
            }
        }

        private bool CheckSeatBooked(string tenGhe)
        {

            string sql = $"SELECT COUNT(*) FROM CTVEXE WHERE TenGhe = '{tenGhe}'";
            int count = (int)db.getScalar(sql);

            return count > 0;
        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Frm_QLXe frm_QLXe = new Frm_QLXe();
            frm_QLXe.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            frm_QLLTrinh frm_QL_LTrinh = new frm_QLLTrinh();
            frm_QL_LTrinh.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            frm_QuanLyVe frm_QLVe = new frm_QuanLyVe();
            frm_QLVe.ShowDialog();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            frmBaoCao frm_XuatVe=new frmBaoCao();
            frm_XuatVe.ShowDialog();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            frm_QLChuyenDi frm_QLChuyen= new frm_QLChuyenDi();
            frm_QLChuyen.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmQLNV frm_qlnv = new frmQLNV();
            frm_qlnv.ShowDialog();
        }

    }
}
