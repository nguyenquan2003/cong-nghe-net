using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace QLTV
{
    public partial class GiaoDienAD : Form
    {
        private UC_DocGia myUserControl;
        public UC_QLSach myUserControl1;
        private UC_MuonTraSach myUserControl2;
        private UC_ThongKe myUserControl4;
        private Timer textAnimationTimer;
        private string textToAnimate = "                     HỆ THỐNG QUẢN LÝ THƯ VIỆN ĐẠI HỌC CÔNG THƯƠNG                     ";
        private int currentPosition = 0;
        public GiaoDienAD()
        {
            InitializeComponent();
            InitializeTextAnimation();

            //Chỉnh ảnh của button qua bên phải 1 xíu
            bt_trangchu.ImageAlign = ContentAlignment.MiddleLeft; // Đặt hình ảnh bên trái nút
            bt_trangchu.Padding = new Padding(10, 0, 0, 0); // Đặt khoảng cách bên trái hình ảnh
            bt_quanlysach.ImageAlign = ContentAlignment.MiddleLeft;
            bt_quanlysach.Padding = new Padding(10, 0, 0, 0);
            bt_docgia.ImageAlign = ContentAlignment.MiddleLeft;
            bt_docgia.Padding = new Padding(10, 0, 0, 0);
            bt_muontrasach.ImageAlign = ContentAlignment.MiddleLeft;
            bt_muontrasach.Padding = new Padding(10, 0, 0, 0);
            bt_nhanvien.ImageAlign = ContentAlignment.MiddleLeft;
            bt_nhanvien.Padding = new Padding(10, 0, 0, 0);
            bt_baocao.ImageAlign = ContentAlignment.MiddleLeft;
            bt_baocao.Padding = new Padding(10, 0, 0, 0);
            bt_dangxuat.ImageAlign = ContentAlignment.MiddleLeft;
            bt_dangxuat.Padding = new Padding(10, 0, 0, 0);



            //Tạo 1 UC mới = UC_DocGia, thêm nó vào panelright và cho ẩn nó đi     
            myUserControl = new UC_DocGia();
            myUserControl.Dock = DockStyle.Fill; // Đảm bảo UserControl lấp đầy Panel
            myUserControl.Visible = false;
            pnl_right.Controls.Add(myUserControl);

            //Tạo 1 UC mới = UC_QLSach, thêm nó vào panelright và cho ẩn nó đi 
            myUserControl1 = new UC_QLSach();
            myUserControl1.Dock = DockStyle.Fill; // Đảm bảo UserControl lấp đầy Panel
            myUserControl1.Visible = false;
            pnl_right.Controls.Add(myUserControl1);

            //Tạo 1 UC mới = UC_MuonTraSach, thêm nó vào panelright và cho ẩn nó đi 
            myUserControl2 = new UC_MuonTraSach();
            myUserControl2.Dock = DockStyle.Fill; // Đảm bảo UserControl lấp đầy Panel
            myUserControl2.Visible = false;
            pnl_right.Controls.Add(myUserControl2);

            //Tạo 1 UC mới = UC_ThongKe, thêm nó vào panelright và cho ẩn nó đi 
            myUserControl4 = new UC_ThongKe();
            myUserControl4.Dock = DockStyle.Fill; // Đảm bảo UserControl lấp đầy Panel
            myUserControl4.Visible = false;
            pnl_right.Controls.Add(myUserControl4);

            myUserControl1.Button1Clicked += UC_QLSach_Button1Clicked;
            myUserControl1.FORMSACH += SACH_FORMLOSING;
            myUserControl1.FORMTACGIA += TacGia_FORMLOSING;
            myUserControl1.FORMTHELOAI += TheLoai_FORMLOSING;

            myUserControl2.Button1Clicked += UC_QLSach_Button1Clicked;
            myUserControl2.FORMMUONSACH += PhieuMuonSach_FORMLOSING;
            myUserControl2.FORMTRASACH += PhieuTraSach_FORMLOSING;
            myUserControl2.FORMDSQUAHAN += DanhSachQuaHan_FORMLOSING;

            
            
        }

        //Quay lại Form GiaoDienAD mà ngay chỗ Quản Lý Sách
        private void UC_QLSach_Button1Clicked(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void SACH_FORMLOSING(object sender, EventArgs e)
        {
            this.Show();
        }

        //Quay lại Form GiaoDienAD mà ngay chỗ Tác Giả
        private void TacGia_FORMLOSING(object sender, EventArgs e)
        {
            this.Show();
        }

        //Quay lại Form GiaoDienAD mà ngay chỗ Thể Loại
        private void TheLoai_FORMLOSING(object sender, EventArgs e)
        {
            this.Show();
        }

        //Quay lại Form GiaoDienAD mà ngay chỗ Mượn Sách
        private void PhieuMuonSach_FORMLOSING(object sender, EventArgs e)
        {
            this.Show();
        }

        //Quay lại Form GiaoDienAD mà ngay chỗ Trả Sách
        private void PhieuTraSach_FORMLOSING(object sender, EventArgs e)
        {
            this.Show();
        }

        //Quay lại Form GiaoDienAD mà ngay chỗ Danh Sách Quá Hạn
        private void DanhSachQuaHan_FORMLOSING(object sender, EventArgs e)
        {
            this.Show();
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
            lb_tieude.Visible = true;
            pictureBox1.Visible = true;
            myUserControl.Visible = false;
            myUserControl1.Visible = false;
            myUserControl2.Visible = false;
            myUserControl4.Visible = false;
        }

        private void bt_docgia_Click(object sender, EventArgs e)
        {
            // Ẩn tất cả các UserControl trong Panel
            pictureBox1.Visible = false;
            lb_tieude.Visible = false;
            myUserControl.Visible = false;
            myUserControl2.Visible = false;
            myUserControl4.Visible = false;

            // Hiển thị UserControl và các control bên trong
            myUserControl.Visible = true;
        }

        private void bt_quanlysach_Click(object sender, EventArgs e)
        {
            // Ẩn tất cả các UserControl trong Panel
            lb_tieude.Visible = false;
            pictureBox1.Visible = false;
            myUserControl.Visible = false;
            myUserControl2.Visible = false;
            myUserControl4.Visible = false;

            // Hiển thị UserControl và các control bên trong
            myUserControl1.Visible = true;
        }

        private void bt_muontrasach_Click(object sender, EventArgs e)
        {
            // Ẩn tất cả các UserControl trong Panel
            lb_tieude.Visible = false;
            pictureBox1.Visible = false;
            myUserControl.Visible = false;
            myUserControl1.Visible = false;
            myUserControl4.Visible = false;

            // Hiển thị UserControl và các control bên trong
            myUserControl2.Visible = true;
        }

        private void bt_nhanvien_Click(object sender, EventArgs e)
        {
            // Ẩn tất cả các UserControl trong Panel
            lb_tieude.Visible = false;
            pictureBox1.Visible = false;
            myUserControl.Visible = false;
            myUserControl1.Visible = false;
            myUserControl2.Visible = false;
            myUserControl4.Visible = false;
            // Truy cập đến Form chứa UserControl UC_QLSach
            Form parentForm = this.FindForm();

            // Lấy thể hiện của Form GiaoDienAD
            GiaoDienAD gdad = parentForm as GiaoDienAD;

            if (gdad != null)
            {
                // Ẩn Form GiaoDienAD
                gdad.Hide();

                // Hiển thị Form QuanLyNhanVien
                QuanLyNhanVien qlnv = new QuanLyNhanVien();
                qlnv.Show();
                qlnv = null;
                return;
            }
        }

        private void bt_baocao_Click(object sender, EventArgs e)
        {
            // Ẩn tất cả các UserControl trong Panel
            lb_tieude.Visible = false;
            pictureBox1.Visible = false;
            myUserControl.Visible = false;
            myUserControl1.Visible = false;
            myUserControl2.Visible = false;

            // Hiển thị UserControl và các control bên trong
            myUserControl4.Visible = true;
        }


        // Vẽ đường bên trái với màu Teal khi di chuột vào bt_trangchu
        private void bt_trangchu_Paint(object sender, PaintEventArgs e)
        {
            Button button = (Button)sender;
            Rectangle leftLine = new Rectangle(0, 0, 4, button.Height); // Tạo hình dạng cho đường bên trái

            if (button.ClientRectangle.Contains(button.PointToClient(Cursor.Position)))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Teal), leftLine);
            }
        }

        // Vẽ đường bên trái với màu Teal khi di chuột vào bt_quanlysach
        private void bt_quanlysach_Paint(object sender, PaintEventArgs e)
        {
            Button button = (Button)sender;
            Rectangle leftLine = new Rectangle(0, 0, 4, button.Height); // Tạo hình dạng cho đường bên trái

            if (button.ClientRectangle.Contains(button.PointToClient(Cursor.Position)))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Teal), leftLine);
            }
        }

        // Vẽ đường bên trái với màu Teal khi di chuột vào bt_docgia
        private void bt_docgia_Paint(object sender, PaintEventArgs e)
        {
            Button button = (Button)sender;
            Rectangle leftLine = new Rectangle(0, 0, 4, button.Height); // Tạo hình dạng cho đường bên trái

            if (button.ClientRectangle.Contains(button.PointToClient(Cursor.Position)))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Teal), leftLine);
            }
        }

        // Vẽ đường bên trái với màu Teal khi di chuột vào bt_muontrasach
        private void bt_muontrasach_Paint(object sender, PaintEventArgs e)
        {
            Button button = (Button)sender;
            Rectangle leftLine = new Rectangle(0, 0, 4, button.Height); // Tạo hình dạng cho đường bên trái

            if (button.ClientRectangle.Contains(button.PointToClient(Cursor.Position)))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Teal), leftLine);
            }
        }

        // Vẽ đường bên trái với màu Teal khi di chuột vào bt_nhanvien
        private void bt_nhanvien_Paint(object sender, PaintEventArgs e)
        {
            Button button = (Button)sender;
            Rectangle leftLine = new Rectangle(0, 0, 4, button.Height); // Tạo hình dạng cho đường bên trái

            if (button.ClientRectangle.Contains(button.PointToClient(Cursor.Position)))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Teal), leftLine);
            }
        }

        // Vẽ đường bên trái với màu Teal khi di chuột vào bt_baocao
        private void bt_baocao_Paint(object sender, PaintEventArgs e)
        {
            Button button = (Button)sender;
            Rectangle leftLine = new Rectangle(0, 0, 4, button.Height); // Tạo hình dạng cho đường bên trái

            if (button.ClientRectangle.Contains(button.PointToClient(Cursor.Position)))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Teal), leftLine);
            }
        }

        // Vẽ đường bên trái với màu Teal khi di chuột vào bt_dangxuat
        private void bt_dangxuat_Paint(object sender, PaintEventArgs e)
        {
            Button button = (Button)sender;
            Rectangle leftLine = new Rectangle(0, 0, 4, button.Height); // Tạo hình dạng cho đường bên trái

            if (button.ClientRectangle.Contains(button.PointToClient(Cursor.Position)))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Teal), leftLine);
            }
        }

        private void bt_dangxuat_Click(object sender, EventArgs e)
        {
            this.Close();
            dangnhap dn = new dangnhap();
            dn.Show();
            return;
        }

        private void panelGD_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GiaoDienAD_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        
        }

        

        


        
   
     

        




        






   
    }
}
