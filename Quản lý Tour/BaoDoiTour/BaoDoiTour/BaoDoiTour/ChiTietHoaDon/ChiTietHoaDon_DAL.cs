using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BaoDoiTour.Controller;

namespace BaoDoiTour.ChiTietHoaDon
{
    class ChiTietHoaDon_DAL
    {
        KetNoi dataCon;
        SqlDataAdapter sqlDA;
        SqlCommand cmd;

        public ChiTietHoaDon_DAL()
        {
            dataCon = new KetNoi();
        }

        public DataTable GetAllCTHoaDon()
        {
            string sql = "SELECT * FROM ChiTietHoaDon";
            SqlConnection con = dataCon.Connect;
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        public bool InsertCTHoaDon(tbl_ChiTietHoaDon cthd)
        {
            string sql = "INSERT INTO ChiTietHoaDon(MaHD, MaTour, NgayThanhToan, TongTien) VALUES (@MaHD, @MaTour, @NgayThanhToan, @TongTien)";
            SqlConnection con = dataCon.Connect;
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaHD", SqlDbType.Char).Value = cthd.MaHD;
                cmd.Parameters.Add("@MaTour", SqlDbType.Char).Value = cthd.MaTour;
                cmd.Parameters.Add("@NgayThanhToan", SqlDbType.DateTime).Value = cthd.NgayThanhToan.ToString("yyyy-MM-dd");
                cmd.Parameters.Add("@TongTien", SqlDbType.Int).Value = cthd.TongTien;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool UpdateCTHoaDon(tbl_ChiTietHoaDon cthd)
        {
            string sql = "UPDATE ChiTietHoaDon SET MaTour = @MaTour, NgayThanhToan = @NgayThanhToan, TongTien = @TongTien WHERE MaHD = @MaHD";
            SqlConnection con = dataCon.Connect;
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaHD", SqlDbType.Char).Value = cthd.MaHD;
                cmd.Parameters.Add("@MaTour", SqlDbType.Char).Value = cthd.MaTour;
                cmd.Parameters.Add("@NgayThanhToan", SqlDbType.DateTime).Value = cthd.NgayThanhToan.ToString("yyyy-MM-dd");
                cmd.Parameters.Add("@TongTien", SqlDbType.Int).Value = cthd.TongTien;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteCTHoaDon(tbl_ChiTietHoaDon cthd)
        {
            string sql = "DELETE ChiTietHoaDon WHERE MaHD = @MaHD";
            SqlConnection con = dataCon.Connect;
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaHD", SqlDbType.Char).Value = cthd.MaHD;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public int GetSLCTHD()
        {
            string sql = "SELECT COUNT(MaHD) +1 FROM ChiTietHoaDon";
            SqlConnection con = dataCon.Connect;

            cmd = new SqlCommand(sql, con);
            con.Open();
            int IDNV = (int)cmd.ExecuteScalar();
            con.Close();

            return IDNV;
        }
    }
}
