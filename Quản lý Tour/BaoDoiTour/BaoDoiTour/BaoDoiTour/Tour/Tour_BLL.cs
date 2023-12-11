using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BaoDoiTour.Tour
{
    class Tour_BLL
    {
        Tour_DAL dalTour;
        public Tour_BLL()
        {
            dalTour = new Tour_DAL();
        }

        public tbl_Tour GetTour(string maTour)
        {
            return dalTour.GetTour(maTour);
        }

        public string LayAnh(string maTour)
        {
            return dalTour.LayAnh(maTour);
        }

        public DataTable GetAllTour()
        {
            return dalTour.GetAllTour();
        }

        public DataTable Search(tbl_Tour tour)
        {
            return dalTour.Search(tour);
        }

        public bool InsertTour(tbl_Tour tour)
        {
            return dalTour.InsertTour(tour);
        }

        public bool UpdateTour(tbl_Tour tour)
        {
            return dalTour.UpdateTour(tour);
        }

        public bool DeleteTour(tbl_Tour tour)
        {
            return dalTour.DeleteTour(tour);
        }

        public int GetSLTour()
        {
            return dalTour.GetSLTour();
        }
    }
}
