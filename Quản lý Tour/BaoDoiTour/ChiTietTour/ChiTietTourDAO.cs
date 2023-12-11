using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using BaoDoiTour.Controller;
using System.Net;
using System.IO;

namespace BaoDoiTour.ChiTietTour
{
    class ChiTietTourDAO
    {
        KetNoi dataCon;
        SqlDataAdapter sqlDA;
        SqlCommand cmd;

        public ChiTietTourDAO()
        {
            dataCon = new KetNoi();
        }

        public byte[] GetPhoto(ChiTietTourDTO ctt)
        {
            string sql = "SELECT DuongDan FROM HinhAnh WHERE MaTour = '" + ctt.MaTour + "'";
            SqlConnection con = dataCon.Connect;
            SqlDataReader reader;
            con.Open();
            cmd = new SqlCommand(sql, con);
            reader = cmd.ExecuteReader();
            byte[] img;
            reader.Read();
            img = ((byte[])reader[0]);
            con.Close();
            return img;
        }

        public DataTable GetTour(ChiTietTourDTO ctt)
        {
            try
            {
                string sql = "SELECT * FROM ChiTietTour WHERE ChiTietTour.MaTour = '" + ctt.MaTour + "'";
                sqlDA = new SqlDataAdapter(sql, dataCon.Connect);
                if (dataCon.Connect.State == ConnectionState.Closed)
                    dataCon.open();
                DataTable dataTable = dataCon.getTableData(sql);
                return dataTable;
            }
            finally
            {
                dataCon.close();
            }
        }

        public bool InsertChiTietTour(ChiTietTourDTO ctt)
        {
            string sql = "INSERT INTO ChiTietTour(MaNV, MaTour, SoNgay, NgayKhoiHanh, NgayKetThuc, NoiDungTour, DuongDan) VALUES (@MaNV, @MaTour, @SoNgay, @NgayKhoiHanh, @NgayKetThuc, @NoiDungTour, @DuongDan)";
            SqlConnection con = dataCon.Connect;
            try
            {
                cmd = new SqlCommand(sql, con);
                if (dataCon.Connect.State != ConnectionState.Open)
                    con.Open();
                cmd.Parameters.Add("@MaNV", SqlDbType.Char).Value = ctt.MaNV;
                cmd.Parameters.Add("@MaTour", SqlDbType.Char).Value = ctt.MaTour;
                cmd.Parameters.Add("@SoNgay", SqlDbType.Int).Value = ctt.SoNgay;
                cmd.Parameters.Add("@NgayKhoiHanh", SqlDbType.DateTime).Value = ctt.NgayKhoiHanh.ToString("yyyy-MM-dd");
                cmd.Parameters.Add("@NgayKetThuc", SqlDbType.DateTime).Value = ctt.NgayKetThuc.ToString("yyyy-MM-dd");
                cmd.Parameters.Add("@NoiDungTour", SqlDbType.NVarChar).Value = ctt.NoiDungTour;
                cmd.Parameters.Add("@DuongDan", SqlDbType.Text).Value = ctt.DuongDan;
                cmd.ExecuteNonQuery();
                if (dataCon.Connect.State == ConnectionState.Open)
                    con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool UpdateChiTietTour(ChiTietTourDTO ctt)
        {
            string sql = "UPDATE ChiTietTour SET MaNV = @MaNV, SoNgay = @SoNgay, NgayKhoiHanh = @NgayKhoiHanh, NgayKetThuc = @NgayKetThuc, NoiDungTour = @NoiDungTour, DuongDan = @DuongDan WHERE MaTour = @MaTour";
            SqlConnection con = dataCon.Connect;
            try
            {
                cmd = new SqlCommand(sql, con);
                if (dataCon.Connect.State != ConnectionState.Open)
                    con.Open();
                cmd.Parameters.Add("@MaNV", SqlDbType.Char).Value = ctt.MaNV;
                cmd.Parameters.Add("@MaTour", SqlDbType.Char).Value = ctt.MaTour;
                cmd.Parameters.Add("@SoNgay", SqlDbType.Int).Value = ctt.SoNgay;
                cmd.Parameters.Add("@NgayKhoiHanh", SqlDbType.DateTime).Value = ctt.NgayKhoiHanh;
                cmd.Parameters.Add("@NgayKetThuc", SqlDbType.DateTime).Value = ctt.NgayKetThuc;
                cmd.Parameters.Add("@NoiDungTour", SqlDbType.NVarChar).Value = ctt.NoiDungTour;
                cmd.Parameters.Add("@DuongDan", SqlDbType.Text).Value = ctt.DuongDan;
                cmd.ExecuteNonQuery();
                if (dataCon.Connect.State == ConnectionState.Open)
                    con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteChiTietTour(ChiTietTourDTO ctt)
        {
            string sql = "DELETE ChiTietTour WHERE MaTour = @MaTour";
            SqlConnection con = dataCon.Connect;
            try
            {
                cmd = new SqlCommand(sql, con);
                if (dataCon.Connect.State != ConnectionState.Open)
                    con.Open();
                cmd.Parameters.Add("@MaTour", SqlDbType.Char).Value = ctt.MaTour;
                cmd.ExecuteNonQuery();
                if (dataCon.Connect.State == ConnectionState.Open)
                    con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
