using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaoDoiTour.Model;
namespace BaoDoiTour.User
{
    class User_BLL
    {
        User_DAL dalUser;
        public User_BLL()
        {
            dalUser = new User_DAL();
        }

        public string phQuyen(tbl_User user, bool type)
        {
            return dalUser.phQuyen(user, type);
        }

        public string getMa(tbl_User user, bool type)
        {
            return dalUser.getMa(user, type);
        }
    }
}
