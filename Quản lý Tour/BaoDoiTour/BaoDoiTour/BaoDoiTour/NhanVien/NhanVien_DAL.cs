using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BaoDoiTour.Controller;

namespace BaoDoiTour.NhanVien
{
    class NhanVien_DAL
    {   
        KetNoi dataCon;
        SqlDataAdapter sqlDA;
        SqlCommand cmd;

        public NhanVien_DAL()
        {
            dataCon = new KetNoi();
        }

        public DataTable GetAllNhanVien()
        {
            string sql = "SELECT * FROM NHANVIEN";
            SqlConnection con = dataCon.Connect;
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        public bool InsertNhanVien(tbl_NhanVien nv)
        {
            string sql = "INSERT INTO NhanVien(MaNV, TenNV, Email, SDT, NgaySinh, ChucVu) VALUES (@MaNV, @TenNV, @Email, @SDT, @NgaySinh, @ChucVu)";
            SqlConnection con = dataCon.Connect;
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaNV", SqlDbType.Char).Value = nv.MaNV;
                cmd.Parameters.Add("@TenNV", SqlDbType.NVarChar).Value = nv.TenNV;
                cmd.Parameters.Add("@Email", SqlDbType.Char).Value = nv.Email;
                cmd.Parameters.Add("@SDT", SqlDbType.Char).Value = nv.SDT;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = nv.NgaySinh.ToString("yyyy-MM-dd");
                cmd.Parameters.Add("@ChucVu", SqlDbType.NVarChar).Value = nv.ChucVu;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool UpdateNhanVien(tbl_NhanVien nv)
        {
            string sql = "UPDATE NhanVien SET TenNV = @TenNV, Email = @Email, SDT = @SDT, NgaySinh = @NgaySinh, ChucVu = @ChucVu WHERE MaNV = @MaNV";
            SqlConnection con = dataCon.Connect;
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaNV", SqlDbType.Char).Value = nv.MaNV;
                cmd.Parameters.Add("@TenNV", SqlDbType.NVarChar).Value = nv.TenNV;
                cmd.Parameters.Add("@Email", SqlDbType.Char).Value = nv.Email;
                cmd.Parameters.Add("@SDT", SqlDbType.Char).Value = nv.SDT;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = nv.NgaySinh;
                cmd.Parameters.Add("@ChucVu", SqlDbType.NVarChar).Value = nv.ChucVu;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteNhanVien(tbl_NhanVien nv)
        {
            string sql = "DELETE NhanVien WHERE MaNV = @MaNV";
            SqlConnection con = dataCon.Connect;
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaNV", SqlDbType.Char).Value = nv.MaNV;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public int GetSLNV()
        {
            string sql = "SELECT COUNT(MANV) +1 FROM NHANVIEN";
            SqlConnection con = dataCon.Connect;

            cmd = new SqlCommand(sql, con);
            con.Open();
            int IDNV = (int)cmd.ExecuteScalar();
            con.Close();

            return IDNV;
        }
    }
}
