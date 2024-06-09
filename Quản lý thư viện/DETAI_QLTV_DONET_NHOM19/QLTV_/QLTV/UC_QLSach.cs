using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV
{
    public partial class UC_QLSach : UserControl
    {
        public event EventHandler Button1Clicked;
        public event EventHandler FORMSACH;
        public event EventHandler FORMTACGIA;
        public event EventHandler FORMTHELOAI;
        SACH sach = new SACH();
        TacGia tacgia = new TacGia();
        TheLoai theloai = new TheLoai();
        public UC_QLSach()
        {
            InitializeComponent();

            bt_qls.ImageAlign = ContentAlignment.MiddleLeft; // Đặt hình ảnh bên trái nút
            bt_qls.Padding = new Padding(10, 0, 0, 0); // Đặt khoảng cách bên trái hình ảnh

            bt_tg.ImageAlign = ContentAlignment.MiddleLeft; 
            bt_tg.Padding = new Padding(20, 0, 0, 0); 

            bt_tl.ImageAlign = ContentAlignment.MiddleLeft; 
            bt_tl.Padding = new Padding(10, 0, 0, 0); 

            bt_nxb.ImageAlign = ContentAlignment.MiddleLeft; 
            bt_nxb.Padding = new Padding(10, 0, 0, 0);

            sach.Cloed += FROMCLOED;
            tacgia.Cloed1 += FROMCLOED1;
            theloai.Cloed2 += FROMCLOED2;
            
        }

        private void UC_QLSach_Load(object sender, EventArgs e)
        {
            
        }
        public bool QuayLaiUCQLSach { get; set; }

        //SÁCH
        private void FROMCLOED(object sender, EventArgs e)
        {
            if (FORMSACH != null)
            {
                FORMSACH(this, EventArgs.Empty);
            }

         }
        private void bt_qls_Click(object sender, EventArgs e)
        {
            if (Button1Clicked != null)
            {
                Button1Clicked(this, EventArgs.Empty);
            }

            sach.Show();  
        }

        //TÁC GIẢ
        private void FROMCLOED1(object sender, EventArgs e)
        {
            if (FORMTACGIA != null)
            {
                FORMTACGIA(this, EventArgs.Empty);
            }

        }
        private void bt_tg_Click(object sender, EventArgs e)
        {
            if (Button1Clicked != null)
            {
                Button1Clicked(this, EventArgs.Empty);
            }

            tacgia.Show();
        }


        //THỂ LOẠI
        private void FROMCLOED2(object sender, EventArgs e)
        {
            if (FORMTHELOAI != null)
            {
                FORMTHELOAI(this, EventArgs.Empty);
            }

        }
        private void bt_tl_Click(object sender, EventArgs e)
        {
            if (Button1Clicked != null)
            {
                Button1Clicked(this, EventArgs.Empty);
            }

            theloai.Show();  
        }

        private void bt_nxb_Click(object sender, EventArgs e)
        {
            
        }

        private void anh1_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }




        public object QuayLaiUCQLSACH { get; set; }


    }
}
