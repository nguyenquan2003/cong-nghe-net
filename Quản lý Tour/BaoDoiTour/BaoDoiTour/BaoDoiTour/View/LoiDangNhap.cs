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
    public partial class LoiDangNhap : Form
    {
        private int countdown = 45;
        public LoiDangNhap()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (countdown > 0)
            {
                countdown--;
                label2.Text = "Bạn còn phải đợi: " + countdown + " giây";
            }
            else
            {
                timer1.Stop(); // Dừng Timer khi hết thời gian
                label2.Text = "Hết giờ bạn có thể nhấn nút trở về";
                btnBack.Visible = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void LoiDangNhap_Load(object sender, EventArgs e)
        {
            countdown = 45;
            timer1.Start();
        }
    }
}
