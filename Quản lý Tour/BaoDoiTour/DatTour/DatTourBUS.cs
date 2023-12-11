using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoDoiTour.DatTour
{
    class DatTourBUS
    {
        DatTourDAO dalDT;

        public DatTourBUS()
        {
            dalDT = new DatTourDAO();
        }

        public bool InsertDatTour(DatTourDTO dt)
        {
            return dalDT.InsertDatTour(dt);
        }
    }
}
