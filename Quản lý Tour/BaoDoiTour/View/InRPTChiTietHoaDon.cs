using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaoDoiTour.View
{
    public partial class InRPTChiTietHoaDon : Form
    {

        public InRPTChiTietHoaDon()
        {
            InitializeComponent();
        }

        private void rptVHoaDon_Load(object sender, EventArgs e)
        {
            rptChiTietHDon rpt = new rptChiTietHDon();
        }
    }
}
