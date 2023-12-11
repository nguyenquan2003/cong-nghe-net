using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BaoDoiTour.Controller;

namespace BaoDoiTour.HoaDon
{
    class HoaDon_DAL
    {
        KetNoi dataCon;
        SqlDataAdapter sqlDA;
        SqlCommand cmd;

        public HoaDon_DAL()
        {
            dataCon = new KetNoi();
        }

        public DataTable GetAllHoaDon()
        {
            string sql = "SELECT * FROM HoaDon";
            SqlConnection con = dataCon.Connect;
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        public bool InsertHoaDon(tbl_HoaDon hd)
        {
            string sql = "INSERT INTO HoaDon(MaHD, MaKH, TinhTrang) VALUES (@MaND, @MaKH, @TinhTrang)";
            SqlConnection con = dataCon.Connect;
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaND", SqlDbType.Char).Value = hd.MaHD;
                cmd.Parameters.Add("@MaKH", SqlDbType.Char).Value = hd.MaKH;
                cmd.Parameters.Add("@TinhTrang", SqlDbType.NVarChar).Value = hd.TinhTrang;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool UpdateHoaDon(tbl_HoaDon hd)
        {
            string sql = "UPDATE HoaDon SET MaKH = @MaKH, TinhTrang = @TinhTrang WHERE MaHD = @MaHD";
            SqlConnection con = dataCon.Connect;
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaHD", SqlDbType.Char).Value = hd.MaHD;
                cmd.Parameters.Add("@MaKH", SqlDbType.Char).Value = hd.MaKH;
                cmd.Parameters.Add("@TinhTrang", SqlDbType.NVarChar).Value = hd.TinhTrang;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteHoaDon(tbl_HoaDon hd)
        {
            string sql = "DELETE HoaDon WHERE MaHD = @MaHD";
            SqlConnection con = dataCon.Connect;
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaHD", SqlDbType.Char).Value = hd.MaHD;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public int GetSLHD()
        {
            string sql = "SELECT COUNT(MaHD) +1 FROM HoaDon";
            SqlConnection con = dataCon.Connect;

            cmd = new SqlCommand(sql, con);
            con.Open();
            int IDNV = (int)cmd.ExecuteScalar();
            con.Close();

            return IDNV;
        }
    }
}
