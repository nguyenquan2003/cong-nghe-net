using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaoDoiTour.Controller;
using System.Data.SqlClient;
using System.Data;

namespace BaoDoiTour.KhachHang
{
    class KhachHang_DAL
    {
        KetNoi dataCon;
        public KhachHang_DAL()
        {
            dataCon = new KetNoi();
        }

        public int SuaKhachHang(tbl_KhachHang khachHang)
        {
            string query = "UPDATE KhachHang SET TenKH = @TenKH, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, " +
                           "SoDT = @SoDT, Email = @Email, MatKhau = @MatKhau, DiaChi = @DiaChi, TichDiem = @TichDiem " +
                           "WHERE MaKH = @MaKH";
            using (SqlCommand command = new SqlCommand(query, dataCon.Connect))
            {
                command.Parameters.AddWithValue("@MaKH", khachHang.MaKH);
                command.Parameters.AddWithValue("@TenKH", khachHang.TenKH);
                command.Parameters.AddWithValue("@NgaySinh", khachHang.NgaySinh);
                command.Parameters.AddWithValue("@GioiTinh", khachHang.GioiTinh);
                command.Parameters.AddWithValue("@SoDT", khachHang.SoDT);
                command.Parameters.AddWithValue("@Email", khachHang.Email);
                command.Parameters.AddWithValue("@MatKhau", khachHang.MatKhau);
                command.Parameters.AddWithValue("@DiaChi", khachHang.DiaChi);
                command.Parameters.AddWithValue("@TichDiem", khachHang.TichDiem);

                return command.ExecuteNonQuery();
            }
        }


        public int ThemKhachHang(tbl_KhachHang khachHang)
        {
            try
            {
                if (dataCon.Connect.State == ConnectionState.Closed)
                    dataCon.open();
                string query = "INSERT INTO KhachHang (MaKH, TenKH, NgaySinh, GioiTinh, SoDT, Email, MatKhau, DiaChi, TichDiem) " +
                               "VALUES (@MaKH, @TenKH, @NgaySinh, @GioiTinh, @SoDT, @Email, @MatKhau, @DiaChi, @TichDiem)";
                using (SqlCommand command = new SqlCommand(query, dataCon.Connect))
                {
                    command.Parameters.AddWithValue("@MaKH", khachHang.MaKH);
                    command.Parameters.AddWithValue("@TenKH", khachHang.TenKH);
                    command.Parameters.AddWithValue("@NgaySinh", khachHang.NgaySinh);
                    command.Parameters.AddWithValue("@GioiTinh", khachHang.GioiTinh);
                    command.Parameters.AddWithValue("@SoDT", khachHang.SoDT);
                    command.Parameters.AddWithValue("@Email", khachHang.Email);
                    command.Parameters.AddWithValue("@MatKhau", khachHang.MatKhau);
                    command.Parameters.AddWithValue("@DiaChi", khachHang.DiaChi);
                    command.Parameters.AddWithValue("@TichDiem", khachHang.TichDiem);

                    return command.ExecuteNonQuery();
                }
            }
            finally
            {
                if (dataCon.Connect.State == ConnectionState.Open)
                    dataCon.close();
            }
        }

        public List<tbl_KhachHang> LayDSKhachHang()
        {
            List<tbl_KhachHang> ds = new List<tbl_KhachHang>();

            string sqlCmd = "SELECT * FROM KhachHang";
            SqlDataReader reader = dataCon.getDataReader(sqlCmd);
            while (reader.Read())
            {
                tbl_KhachHang kh = new tbl_KhachHang();
                kh.MaKH = reader["MaKH"].ToString();
                kh.TenKH = reader["TenKH"].ToString();
                kh.NgaySinh = DateTime.Parse(reader["NgaySinh"].ToString());
                kh.GioiTinh = reader["GioiTinh"].ToString();
                kh.SoDT = reader["SoDT"].ToString();
                kh.Email = reader["Email"].ToString();
                kh.MatKhau = reader["MatKhau"].ToString();
                kh.DiaChi = reader["DiaChi"].ToString();
                kh.TichDiem = Int32.Parse(reader["TichDiem"].ToString());
                ds.Add(kh);
            }
            return ds;
        }
    }
}
