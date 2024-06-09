using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLTV
{
    public partial class GiaoDienNV : Form
    {
        private Timer textAnimationTimer;
        private string textToAnimate = "              HỆ THỐNG QUẢN LÝ THƯ VIỆN ĐẠI HỌC CÔNG THƯƠNG              ";
        private int currentPosition = 0;

        SqlConnection connection;
        string str = DataHolder.str;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        private UC_DocGia myUserControl;
        public GiaoDienNV()
        {
            InitializeComponent();
            InitializeTextAnimation();
            bt_trangchu.ImageAlign = ContentAlignment.MiddleLeft; // Đặt hình ảnh bên trái nút
            bt_trangchu.Padding = new Padding(10, 0, 0, 0); // Đặt khoảng cách bên trái hình ảnh
            bt_lapphieumuon.ImageAlign = ContentAlignment.MiddleLeft;
            bt_lapphieumuon.Padding = new Padding(10, 0, 0, 0);
            bt_lapphieutra.ImageAlign = ContentAlignment.MiddleLeft;
            bt_lapphieutra.Padding = new Padding(10, 0, 0, 0);
            bt_dsquahan.ImageAlign = ContentAlignment.MiddleLeft;
            bt_dsquahan.Padding = new Padding(10, 0, 0, 0);
            bt_docgia.ImageAlign = ContentAlignment.MiddleLeft;
            bt_docgia.Padding = new Padding(10, 0, 0, 0);
            bt_dangxuat.ImageAlign = ContentAlignment.MiddleLeft;
            bt_dangxuat.Padding = new Padding(10, 0, 0, 0);


            //Tạo 1 UC mới = UC_DocGia, thêm nó vào panelright và cho ẩn nó đi     
            myUserControl = new UC_DocGia();
            myUserControl.Dock = DockStyle.Fill; // Đảm bảo UserControl lấp đầy Panel
            myUserControl.Visible = false;
            pnl_right.Controls.Add(myUserControl);
        }

        private void InitializeTextAnimation()
        {
            textAnimationTimer = new Timer();
            textAnimationTimer.Interval = 100; // Thời gian cập nhật (ms)
            textAnimationTimer.Tick += TextAnimationTimer_Tick;
            textAnimationTimer.Start();
        }

        private void TextAnimationTimer_Tick(object sender, EventArgs e)
        {
            if (currentPosition < textToAnimate.Length)
            {
                // Cập nhật vị trí của văn bản
                string displayedText = textToAnimate.Substring(currentPosition) + textToAnimate.Substring(0, currentPosition);
                lb_tieude.Text = displayedText;

                // Cập nhật màu sắc dựa trên thời gian
                double time = (DateTime.Now - DateTime.MinValue).TotalSeconds;
                int red = (int)(Math.Sin(time) * 127 + 128);
                int green = (int)(Math.Sin(time + 2) * 127 + 128);
                int blue = (int)(Math.Sin(time + 4) * 127 + 128);

                lb_tieude.ForeColor = Color.FromArgb(red, green, blue);

                // Di chuyển vị trí
                currentPosition++;
                if (currentPosition >= textToAnimate.Length)
                {
                    currentPosition = 0;
                }
            }
        }

        private void bt_trangchu_Click(object sender, EventArgs e)
        {
            myUserControl.Visible = false;

            lb_tieude.Visible = true;
            pictureBox1.Visible = true;
            
        }
        

        public static bool QuayLaiForm1 = false;
        private void bt_lapphieumuon_Click(object sender, EventArgs e)
        {
            QuayLaiForm1 = true;
            PhieuMuonSach x = new PhieuMuonSach();
            this.Hide();
            x.Show();
        }

        private void bt_lapphieutra_Click(object sender, EventArgs e)
        {
            QuayLaiForm1 = true;
            PhieuTraSach x = new PhieuTraSach();
            this.Hide();
            x.Show();
        }

        private void bt_dsquahan_Click(object sender, EventArgs e)
        {
            QuayLaiForm1 = true;
            DanhSachQuaHan x = new DanhSachQuaHan();
            this.Hide();
            x.Show();
        }

        private void bt_docgia_Click(object sender, EventArgs e)
        {
            // Ẩn tất cả các UserControl trong Panel
            pictureBox1.Visible = false;
            lb_tieude.Visible = false;


            // Hiển thị UserControl và các control bên trong
            myUserControl.Visible = true;
        }

        private void bt_dangxuat_Click(object sender, EventArgs e)
        {
            QuayLaiForm1 = true;
            dangnhap dn = new dangnhap();
            this.Hide();
            dn.Show();
        }


        private void bt_trangchu_Paint(object sender, PaintEventArgs e)
        {
            Button button = (Button)sender;
            Rectangle leftLine = new Rectangle(0, 0, 4, button.Height); // Tạo hình dạng cho đường bên trái

            if (button.ClientRectangle.Contains(button.PointToClient(Cursor.Position)))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Teal), leftLine);
            }
        }

        private void bt_lapphieumuon_Paint(object sender, PaintEventArgs e)
        {
            Button button = (Button)sender;
            Rectangle leftLine = new Rectangle(0, 0, 4, button.Height); // Tạo hình dạng cho đường bên trái

            if (button.ClientRectangle.Contains(button.PointToClient(Cursor.Position)))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Teal), leftLine);
            }
        }

        private void bt_lapphieutra_Paint(object sender, PaintEventArgs e)
        {
            Button button = (Button)sender;
            Rectangle leftLine = new Rectangle(0, 0, 4, button.Height); // Tạo hình dạng cho đường bên trái

            if (button.ClientRectangle.Contains(button.PointToClient(Cursor.Position)))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Teal), leftLine);
            }
        }

        private void bt_dsquahan_Paint(object sender, PaintEventArgs e)
        {
            Button button = (Button)sender;
            Rectangle leftLine = new Rectangle(0, 0, 4, button.Height); // Tạo hình dạng cho đường bên trái

            if (button.ClientRectangle.Contains(button.PointToClient(Cursor.Position)))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Teal), leftLine);
            }
        }

        private void bt_docgia_Paint(object sender, PaintEventArgs e)
        {
            Button button = (Button)sender;
            Rectangle leftLine = new Rectangle(0, 0, 4, button.Height); // Tạo hình dạng cho đường bên trái

            if (button.ClientRectangle.Contains(button.PointToClient(Cursor.Position)))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Teal), leftLine);
            }
        }

        private void bt_dangxuat_Paint(object sender, PaintEventArgs e)
        {
            Button button = (Button)sender;
            Rectangle leftLine = new Rectangle(0, 0, 4, button.Height); // Tạo hình dạng cho đường bên trái

            if (button.ClientRectangle.Contains(button.PointToClient(Cursor.Position)))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Teal), leftLine);
            }
        }

        public string LayTenNhanVien(string maQL)
        {
            string ten = "";

            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT TenQuanLy FROM QuanLy WHERE MaQuanLy = @maQL", connection))
                {
                    command.Parameters.AddWithValue("@maQL", maQL);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ten = reader["TenQuanLy"].ToString();
                        }
                    }
                }
            }

            return ten;
        }
        public string LayChucVu(string maQL)
        {
            string ten = "";

            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT VaiTro FROM QuanLy WHERE MaQuanLy = @maQL", connection))
                {
                    command.Parameters.AddWithValue("@maQL", maQL);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ten = reader["VaiTro"].ToString();
                        }
                    }
                }
            }

            return ten;
        }





        private void GiaoDienNV_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            lb_chaonv.Text = "Xin chào: " + LayTenNhanVien(LOGIN.check);
            lb_nhanvien.Text = LayChucVu(LOGIN.check).ToUpper();
            ptb_nv1.ImageLocation = @"..\\..\\image\\NHANVIEN\\" + LOGIN.check + ".jpg";
            ptb_nv2.ImageLocation = @"..\\..\\image\\NHANVIEN\\" + LOGIN.check + ".jpg";
        }
        

        private void lb_tieude_Click(object sender, EventArgs e)
        {

        }
        
     

        
    }
}
