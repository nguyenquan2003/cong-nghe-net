using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV
{
    public partial class DangKy : Form
    {
        private UC_DangKy myUserControl;
        public DangKy()
        {
            InitializeComponent();
            myUserControl = new UC_DangKy();
            myUserControl.Dock = DockStyle.Fill; // Đảm bảo UserControl lấp đầy Panel
            myUserControl.Visible = false;
            pennodangky.Controls.Add(myUserControl);
            myUserControl.UserControlExit += YourUserControl_UserControlExit;
        }

        private void DangKy_Load(object sender, EventArgs e)
        {     
            myUserControl.Visible = true;
        }
        private void YourUserControl_UserControlExit(object sender, EventArgs e)
        {
            // Xử lý khi UserControl thông báo muốn thoát
            Close(); // Đóng Form
        }
        private void DangKy_FormClosing(object sender, FormClosingEventArgs e)
        {
            dangnhap dn = new dangnhap();
            dn.Show();
            return;
        }
    }
}
