using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BaoDoiTour.NhanVien
{
    class NhanVien_BLL
    {
        NhanVien_DAL dalNV;
        public NhanVien_BLL()
        {
            dalNV = new NhanVien_DAL();
        }

        public DataTable GetAllNhanVien()
        {
            return dalNV.GetAllNhanVien();
        }

        public bool InsertNhanVien(tbl_NhanVien nv)
        {
            return dalNV.InsertNhanVien(nv);
        }

        public bool UpdateNhanVien(tbl_NhanVien nv)
        {
            return dalNV.UpdateNhanVien(nv);
        }

        public bool DeleteNhanVien(tbl_NhanVien nv)
        {
            return dalNV.DeleteNhanVien(nv);
        }

        public int GetSLNV()
        {
            return dalNV.GetSLNV();
        }
    }
}
