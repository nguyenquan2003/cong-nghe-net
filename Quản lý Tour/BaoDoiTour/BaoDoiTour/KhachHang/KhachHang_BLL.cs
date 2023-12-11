using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoDoiTour.KhachHang
{
    class KhachHang_BLL
    {
        KhachHang_DAL kh_dal = new KhachHang_DAL();

        public List<tbl_KhachHang> LayDSKhachHang()
        {
            return kh_dal.LayDSKhachHang();
        }

        public int ThemKhachHang(tbl_KhachHang khachHang)
        {
            return kh_dal.ThemKhachHang(khachHang);
        }

        public int SuaKhachHang(tbl_KhachHang khachHang)
        {
            return kh_dal.SuaKhachHang(khachHang);
        }
    }
}
