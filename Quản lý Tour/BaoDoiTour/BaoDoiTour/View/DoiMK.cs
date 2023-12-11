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
    public partial class DoiMK : Form
    {
        public DoiMK()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            BaoDoiTour.Controller.KetNoi kn = new BaoDoiTour.Controller.KetNoi();
            try
            {
                string table;
                if(MainLayout.currentUser.Quyen.ToUpper() == "ADMIN" || MainLayout.currentUser.Quyen.ToUpper() == "NV")
                {
                    table = "NhanVien";
                }
                else
                {
                    table = "KhachHang";
                }
                BaoDoiTour.Controller.CommonFunction fc = new BaoDoiTour.Controller.CommonFunction();
                if (txtOldMK.Text.Trim() == MainLayout.currentUser.MatKhau && fc.ktraDkyPassword(txtNewMK.Text.Trim()) && txtNewMKagain.Text.Trim() == txtNewMK.Text.Trim())
                {
                    string sqlStr = "UPDATE "+ table + " SET MatKhau = '" + txtNewMK.Text.Trim() + "' WHERE Email = '" + MainLayout.currentUser.Email + "';";
                    int nonQuery = kn.getNonQuery(sqlStr);
                    if (nonQuery >= 1)
                    {
                        MessageBox.Show("Sửa thành công !");
                    }
                }
            }
            finally
            {
                if (kn.Connect.State == ConnectionState.Open)
                    kn.close();
            }
        }

        private void txtOldMK_Leave(object sender, EventArgs e)
        {
            if(txtOldMK.Text.Trim() != MainLayout.currentUser.MatKhau)
            {
                errorProvider1.SetError((Control)sender, "Mật khẩu chưa khớp mật khẩu cũ");
            }else
            {
                errorProvider1.SetError((Control)sender, "");
            }
        }

        private void txtNewMK_Leave(object sender, EventArgs e)
        {
            BaoDoiTour.Controller.CommonFunction fc = new BaoDoiTour.Controller.CommonFunction();
            if (!fc.ktraDkyPassword(txtNewMK.Text.Trim()))
            {
                errorProvider1.SetError((Control)sender, "Mật khẩu phải có ít nhất 6 kí tự trở lên");
            }
            else
            {
                errorProvider1.SetError((Control)sender, "");
            }
        }

        private void txtNewMKagain_Leave(object sender, EventArgs e)
        {
            if(txtNewMKagain.Text.Trim() != txtNewMK.Text.Trim())
            {
                errorProvider1.SetError((Control)sender, "Nhập lại mật khẩu chưa khớp");
            }
            else
            {
                errorProvider1.SetError((Control)sender, "");
            }
        }
    }
}
