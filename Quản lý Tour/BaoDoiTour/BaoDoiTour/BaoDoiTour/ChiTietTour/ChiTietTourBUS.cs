using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BaoDoiTour.ChiTietTour
{
    class ChiTietTourBUS
    {
        ChiTietTourDAO dalCTT;
        public ChiTietTourBUS()
        {
            dalCTT = new ChiTietTourDAO();
        }

        public bool InsertChiTietTour(ChiTietTourDTO ctt)
        {
            return dalCTT.InsertChiTietTour(ctt);
        }

        public bool UpdateChiTietTour(ChiTietTourDTO ctt)
        {
            return dalCTT.UpdateChiTietTour(ctt);
        }

        public bool DeleteChiTietTour(ChiTietTourDTO ctt)
        {
            return dalCTT.DeleteChiTietTour(ctt);
        }

        public DataTable GetTour(ChiTietTourDTO ctt)
        {
            return dalCTT.GetTour(ctt);
        }
    }
}
