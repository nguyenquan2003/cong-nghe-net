using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BaoDoiTour.Controller
{
    public class CommonFunction
    {
        int dodaimk = 6;
        public bool ktraEmail(string str)
        {
            string pattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";
            return Regex.IsMatch(str, pattern);
        }

        public bool ktraDkyPassword(string str)
        {
            if (str.Length < dodaimk)
            {
                return false;
            }
            return true;
        }
    }
}
