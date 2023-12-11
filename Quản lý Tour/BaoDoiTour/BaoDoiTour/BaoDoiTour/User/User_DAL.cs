using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaoDoiTour.Controller;
using System.Data;
using System.Windows.Forms;
using BaoDoiTour.Model;
using System.Data.SqlClient;

namespace BaoDoiTour.User
{
    class User_DAL
    {
        KetNoi kn = new KetNoi();

        public string getMa(tbl_User user, bool type)
        {
            try
            {
                string table = type ? "NhanVien" : "KhachHang";
                string col = type ? "MaNV" : "MaKH";
                string sqlStr = "SELECT " + col + " FROM " + table + " WHERE Email = '" + user.Email + "' AND MatKhau = '" + user.MatKhau + "'";
                string Ma;
                SqlDataReader reader = kn.getDataReader(sqlStr);
                if (reader.Read())
                {
                    Ma = reader.GetString(0);
                    return Ma;
                }
                return "Fail";
            }
            finally
            {
                if (kn.Connect.State == ConnectionState.Open)
                    kn.close();
            }
        }

        public string phQuyen(tbl_User user, bool type)
        {
            try
            {
                string table = type ? "NhanVien" : "KhachHang";
                string sqlStr = "SELECT Quyen FROM " + table + " WHERE Email = '" + user.Email + "' AND MatKhau = '" + user.MatKhau + "'";
                string Quyen;
                SqlDataReader reader = kn.getDataReader(sqlStr);
                if (reader.Read())
                {
                    Quyen = reader.GetString(0);
                    return Quyen;
                }
                return "Fail";
            }
            finally
            {
                if (kn.Connect.State == ConnectionState.Open)
                    kn.close();
            }
        }
    }
}
