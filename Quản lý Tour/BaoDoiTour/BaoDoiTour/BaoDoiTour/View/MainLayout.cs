using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaoDoiTour.Model;
using BaoDoiTour.User;

namespace BaoDoiTour.View
{
    public partial class MainLayout : Form
    {
        public static tbl_User currentUser { get; private set; }
        public MainLayout(tbl_User User)
        {
            currentUser = User;
            InitializeComponent();

            btnSetting.Click += BtnSetting_Click;

            menuItemDoiMatKhau.Click += MenuItemDoiMatKhau_Click;
            menuItemDoiMauNen.Click += MenuItemDoiMauNen_Click;
        }

        private void MenuItemDoiMatKhau_Click(object sender, EventArgs e)
        {
            DoiMK doimk = new DoiMK();
            doimk.ShowDialog();
        }

        private void MenuItemDoiMauNen_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color selectedColor = colorDialog1.Color;

                leftMenuPanel.BackColor = selectedColor;
                foreach (Control control in leftMenuPanel.Controls)
                {
                    if (control is Guna.UI2.WinForms.Guna2Button gunaButton)
                    {
                        gunaButton.FillColor = selectedColor;
                    }
                }
            }
        }

        private void BtnSetting_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(btnSetting, new Point(0, -btnSetting.Height));
        }

        public void animationMenuBtn(Control control)
        {
            leftPanelBtn.Top = control.Top;
            leftPanelBtn.Height = control.Height;
        }

        public void changeTab(Control control)
        {
            control.BringToFront();
        }

        private void MainLayout_Load(object sender, EventArgs e)
        {
            animationMenuBtn(btnMainPage);
            changeTab(mainPageTab1);
            if (currentUser.Quyen.ToUpper() == "ADMIN")
            {
                btnKHPage.Enabled = true;
                btnNvPage.Enabled = true;
                btnHoaDonPage.Enabled = true;
                btnTourPage.Enabled = true;
            }
            else if (currentUser.Quyen.ToUpper() == "NV")
            {
                btnNvPage.Enabled = false;
            }else if (currentUser.Quyen.ToUpper() == "KH")
            {
                btnKHPage.Enabled = false;
                btnNvPage.Enabled = false;
            }
        }

        private void btnMainPage_Click(object sender, EventArgs e)
        {
            animationMenuBtn((Control)sender);
            changeTab(mainPageTab1);
        }

        private void btnTourPage_Click(object sender, EventArgs e)
        {
            animationMenuBtn((Control)sender);
            changeTab(qlTours1);
        }

        private void btnHoaDonPage_Click(object sender, EventArgs e)
        {
            animationMenuBtn((Control)sender);
            changeTab(qlhDon1);
        }

        private void btnKHPage_Click(object sender, EventArgs e)
        {
            animationMenuBtn((Control)sender);
            changeTab(qlkHang1);
        }

        private void btnNvPage_Click(object sender, EventArgs e)
        {
            animationMenuBtn((Control)sender);
            changeTab(qlnv1);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }
    }
}
