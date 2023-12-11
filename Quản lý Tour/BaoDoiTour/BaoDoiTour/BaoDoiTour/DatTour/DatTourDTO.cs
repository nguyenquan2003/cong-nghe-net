using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoDoiTour.DatTour
{
    class DatTourDTO
    {
        public string MaDat { set; get; }

        public string MaKH { set; get; }

        public string MaTour { set; get; }

        public DateTime NgayDat { set; get; }

        public string TinhTrangThanhToan { set; get; }

        public int NguoiLon { set; get; }
            
        public int TreEm { set; get; }
    }
}
