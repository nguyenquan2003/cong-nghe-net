using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BaoDoiTour.ChiTietHoaDon
{
    class ChiTietHoaDon_BLL
    {
        ChiTietHoaDon_DAL dalCTHD;
        public ChiTietHoaDon_BLL()
        {
            dalCTHD = new ChiTietHoaDon_DAL();
        }

        public DataTable GetAllCTHoaDon()
        {
            return dalCTHD.GetAllCTHoaDon();
        }

        public bool InsertCTHoaDon(tbl_ChiTietHoaDon cthd)
        {
            return dalCTHD.InsertCTHoaDon(cthd);
        }

        public bool UpdateCTHoaDon(tbl_ChiTietHoaDon cthd)
        {
            return dalCTHD.UpdateCTHoaDon(cthd);
        }

        public bool DeleteCTHoaDon(tbl_ChiTietHoaDon cthd)
        {
            return dalCTHD.DeleteCTHoaDon(cthd);
        }

        public int GetSLHD()
        {
            return dalCTHD.GetSLCTHD();
        }
    }
}
