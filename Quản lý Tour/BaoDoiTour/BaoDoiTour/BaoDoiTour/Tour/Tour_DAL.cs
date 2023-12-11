using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BaoDoiTour.Controller;

namespace BaoDoiTour.Tour
{
    class Tour_DAL
    {
        KetNoi dataCon;
        SqlDataAdapter sqlDA;
        SqlCommand cmd;

        public Tour_DAL()
        {
            dataCon = new KetNoi();
        }

        public string LayAnh(string maTour)
        {
            try
            {
                if (dataCon.Connect.State == ConnectionState.Closed)
                    dataCon.open();
                string DuongDan = "";
                string sqlCmd = "SELECT DuongDan From ChiTietTour WHERE MaTour = '"+ maTour +"'";
                SqlDataReader reader = dataCon.getDataReader(sqlCmd);
                if (reader.Read())
                {
                    DuongDan = reader.GetString(0);
                }
                return DuongDan;
            }
            finally
            {
                if (dataCon.Connect.State == ConnectionState.Open)
                    dataCon.close();
            }
        }

        public tbl_Tour GetTour(string maTour)
        {
            tbl_Tour tour = new tbl_Tour();
            string sqlCmd = "SELECT * FROM Tour Where MaTour = '" + maTour + "'";
            SqlDataReader reader = dataCon.getDataReader(sqlCmd);
            if (reader.Read())
            {
                tour.MaTour = reader["MaTour"].ToString();
                tour.TenTour = reader["TenTour"].ToString();
                tour.MieuTa = reader["MieuTa"].ToString();
                tour.Gia = Int32.Parse(reader["Gia"].ToString());
                tour.DiaDiem = reader["DiaDiem"].ToString();
            }
            return tour;
        }

        public DataTable GetAllTour()
        {
            try
            {
                string sql = "SELECT * FROM Tour";
                sqlDA = new SqlDataAdapter(sql, dataCon.Connect);
                if(dataCon.Connect.State == ConnectionState.Closed)
                    dataCon.open();
                DataTable dataTable = dataCon.getTableData(sql);
                return dataTable;
            }
            finally
            {
                dataCon.close();
            }
        }

        public DataTable Search(tbl_Tour tour)
        {
            string sql = "SELECT * FROM Tour WHERE DiaDiem LIKE N'%" + tour.DiaDiem + "%'";
            SqlConnection con = dataCon.Connect;
            DataTable dataTable = dataCon.getTableData(sql);
            con.Open();
            sqlDA.Update(dataTable);
            con.Close();
            return dataTable;
        }

        public bool InsertTour(tbl_Tour tour)
        {
            string sql = "INSERT INTO Tour(MaTour, TenTour, MieuTa, Gia, DiaDiem) VALUES (@MaTour, @TenTour, @MieuTa, @Gia, @DiaDiem)";
            SqlConnection con = dataCon.Connect;
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaTour", SqlDbType.Char).Value = tour.MaTour;
                cmd.Parameters.Add("@TenTour", SqlDbType.NVarChar).Value = tour.TenTour;
                cmd.Parameters.Add("@MieuTa", SqlDbType.NVarChar).Value = tour.MieuTa;
                cmd.Parameters.Add("@Gia", SqlDbType.Int).Value = tour.Gia;
                cmd.Parameters.Add("@DiaDiem", SqlDbType.NVarChar).Value = tour.DiaDiem;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool UpdateTour(tbl_Tour tour)
        {
            string sql = "UPDATE Tour SET TenTour = @TenTour, MieuTa = @MieuTa, Gia = @Gia, DiaDiem = @DiaDiem WHERE MaTour = @MaTour";
            SqlConnection con = dataCon.Connect;
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaTour", SqlDbType.Char).Value = tour.MaTour;
                cmd.Parameters.Add("@TenTour", SqlDbType.NVarChar).Value = tour.TenTour;
                cmd.Parameters.Add("@MieuTa", SqlDbType.NVarChar).Value = tour.MieuTa;
                cmd.Parameters.Add("@Gia", SqlDbType.Int).Value = tour.Gia;
                cmd.Parameters.Add("@DiaDiem", SqlDbType.NVarChar).Value = tour.DiaDiem;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteTour(tbl_Tour tour)
        {
            string sql = "DELETE Tour WHERE MaTour = @MaTour";
            SqlConnection con = dataCon.Connect;
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaTour", SqlDbType.Char).Value = tour.MaTour;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public int GetSLTour()
        {
            string sql = "SELECT COUNT(MaTour) +1 FROM Tour";
            SqlConnection con = dataCon.Connect;

            cmd = new SqlCommand(sql, con);
            con.Open();
            int IDNV = (int)cmd.ExecuteScalar();
            con.Close();

            return IDNV;
        }
    }
}
