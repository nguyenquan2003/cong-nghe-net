using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV
{
    public partial class DATASQL : Form
    {
        SqlConnection connection;       
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public DATASQL()
        {
            InitializeComponent();
        }

        private void bt_load_Click(object sender, EventArgs e)
        {
           
            string thuMucChuaUngDung = AppDomain.CurrentDomain.BaseDirectory;


           
            try
            {
                // Ghép đường dẫn đích sử dụng Path.Combine
                string dich = Path.Combine(thuMucChuaUngDung, "BAOCAO.rdlc");
                File.Copy(report.Text + "\\BAOCAO.rdlc", dich, true);
                string dich_1 = Path.Combine(thuMucChuaUngDung, "BAOCAO_1.rdlc");
                File.Copy(report.Text + "\\BAOCAO_1.rdlc", dich_1, true);
                string dich_2 = Path.Combine(thuMucChuaUngDung, "BAOCAO_2.rdlc");
                File.Copy(report.Text + "\\BAOCAO_2.rdlc", dich_2, true);
                this.Hide();
                
                DataHolder.str = data_sql.Text;
                SqlConnection connection = new SqlConnection(DataHolder.str);
                connection.Open();
                MessageBox.Show("Kết nối thành công!!", "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dangnhap dangnhap = new dangnhap();            
                dangnhap.Show();
            }
            catch
            {
                MessageBox.Show("Lỗi link data sql hoặc link reports, vui lòng kiểm tra lại!!!","Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                return;
            }
        }

        private void bt_thoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát không ?", "Thông báo ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void bt_load_MouseEnter(object sender, EventArgs e)
        {
            bt_load.BackColor = Color.LightSteelBlue;
        }

        private void bt_load_MouseLeave(object sender, EventArgs e)
        {
            Color myColor = Color.White;
            bt_load.BackColor = myColor;
        }

        private void bt_thoat_MouseEnter(object sender, EventArgs e)
        {
            bt_thoat.BackColor = Color.LightSteelBlue;
        }

        private void bt_thoat_MouseLeave(object sender, EventArgs e)
        {
            Color myColor = Color.White;
            bt_thoat.BackColor = myColor;
        }
    }
}
