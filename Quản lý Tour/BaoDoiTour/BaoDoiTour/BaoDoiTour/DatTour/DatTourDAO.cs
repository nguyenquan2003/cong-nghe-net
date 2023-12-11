using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using BaoDoiTour.Controller;

namespace BaoDoiTour.DatTour
{
    class DatTourDAO
    {
        KetNoi dataCon;
        SqlDataAdapter sqlDA;
        SqlCommand cmd;

        public DatTourDAO()
        {
            dataCon = new KetNoi();
        }

        public bool InsertDatTour(DatTourDTO dt)
        {
            string sql = "INSERT INTO DatTour(MaDat, MaKH, MaTour, NgayDat, TinhTrangThanhToan, NguoiLon, TreEm) VALUES (@MaDat, @MaKH, @MaTour, @NgayDat, @TinhTrangThanhToan, @NguoiLon, @TreEm)";
            SqlConnection con = dataCon.Connect;
            try
            {
                cmd = new SqlCommand(sql, con);
                if (dataCon.Connect.State != ConnectionState.Open)
                    con.Open();
                cmd.Parameters.Add("@MaDat", SqlDbType.Char).Value = dt.MaDat;
                cmd.Parameters.Add("@MaKH", SqlDbType.Char).Value = dt.MaKH;
                cmd.Parameters.Add("@MaTour", SqlDbType.Char).Value = dt.MaTour;
                cmd.Parameters.Add("@NgayDat", SqlDbType.DateTime).Value = dt.NgayDat.ToString("yyyy-MM-dd");
                cmd.Parameters.Add("@TinhTrangThanhToan", SqlDbType.NVarChar).Value = dt.TinhTrangThanhToan;
                cmd.Parameters.Add("@NguoiLon", SqlDbType.Int).Value = dt.NguoiLon;
                cmd.Parameters.Add("@TreEm", SqlDbType.Int).Value = dt.TreEm;
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
