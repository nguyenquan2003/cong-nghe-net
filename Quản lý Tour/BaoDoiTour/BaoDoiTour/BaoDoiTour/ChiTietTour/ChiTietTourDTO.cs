using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoDoiTour.ChiTietTour
{
    class ChiTietTourDTO
    {
        public string MaNV { set; get; }

        public string MaTour { set; get; }

        public int SoNgay { set; get; }

        public DateTime NgayKhoiHanh { set; get; }

        public DateTime NgayKetThuc { set; get; }

        public string NoiDungTour { set; get; }

        public string DuongDan { set; get; }
    }
}
