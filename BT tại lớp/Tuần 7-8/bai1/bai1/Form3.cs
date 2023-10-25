using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string s = "select hoten, ngaysinh,tenmh, diem  from sinhvien  sv, monhoc  mh,diem d where d.masv = sv.masv and d.mamh= mh.mamh ";
        }
    }
}
