using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BaoDoiTour.HoaDon
{
    class HoaDon_BLL
    {
        HoaDon_DAL dalHD;
        public HoaDon_BLL()
        {
            dalHD = new HoaDon_DAL();
        }

        public DataTable GetAllHoaDon()
        {
            return dalHD.GetAllHoaDon();
        }

        public bool InsertHoaDon(tbl_HoaDon hd)
        {
            return dalHD.InsertHoaDon(hd);
        }

        public bool UpdateHoaDon(tbl_HoaDon hd)
        {
            return dalHD.UpdateHoaDon(hd);
        }

        public bool DeleteHoaDon(tbl_HoaDon hd)
        {
            return dalHD.DeleteHoaDon(hd);
        }

        public int GetSLHD()
        {
            return dalHD.GetSLHD();
        }
    }
}
