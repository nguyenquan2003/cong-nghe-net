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

namespace _2001210682_PhanMinhKhai_.NET_DoAn
{
    public partial class DanhSachBan : Form
    {
        public DanhSachBan()
        {
            InitializeComponent();
        }

        SqlConnection conection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-V315BI4;Initial Catalog=QL_bida;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        private SqlConnection connection;

        private void loaddulieu123()
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                string query = "select soban, trangthai from danhsachban";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string SoBan = reader["soban"].ToString();
                            string TrangThai = reader["trangthai"].ToString();

                            Button banButton = new Button();
                            banButton.Size = new Size(100, 100);
                            Label banLabel = new Label();
                            banButton.Text = "Bàn" + SoBan + "\n" + TrangThai;

                            if (TrangThai == "Đang trống")
                            {
                                banButton.BackColor = Color.FromArgb(255, 144, 238, 144);
                            }
                            else if (TrangThai == "Đã đặt trước")
                            {
                                banButton.BackColor = Color.FromArgb(255, 255, 192, 128);
                            }
                            else
                            {
                                banButton.BackColor = Color.LightCoral;
                            }

                            banButton.Click += new EventHandler(banButton_Click);
                            flowLayoutPanel1.Controls.Add(banButton);
                        }
                    }
                }
            }
        }

        private void DanhSachBan_Load(object sender, EventArgs e)
        {
            DateTime nt = DateTime.Now;
            string formattedDate = nt.ToString("dddd, dd/MM/yyyy");
            label1.Text = formattedDate;
            conection = new SqlConnection(str);
            conection.Open();
            loaddulieu123();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            loaddulieu123();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ThemBan themban = new ThemBan();
            themban.ShowDialog();

            if (themban.DialogResult == DialogResult.OK)
            {
                loaddulieu123();
            }
        }

        public FlowLayoutPanel GetDataGridView()
        {
            return flowLayoutPanel1;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // Get the selected bill information
                string maHoaDon = listView1.SelectedItems[0].SubItems[1].Text;
                string maBan = listView1.SelectedItems[0].SubItems[2].Text;
                string ngayDat = listView1.SelectedItems[0].SubItems[3].Text;
                string tongTien = listView1.SelectedItems[0].SubItems[4].Text;

                // Display the bill information in a message box
                MessageBox.Show(string.Format("Mã hóa đơn: {0}\nMã bàn: {1}\nNgày đặt: {2}\nTổng tiền: {3}", maHoaDon, maBan, ngayDat, tongTien));
            }
        }

        private void banButton_Click(object sender, EventArgs e)
        {
            Button banButton = (Button)sender;
            string soban = banButton.Text.Split('\n')[0];
            string sql = "select * from hoadon where soban = '" + soban + "'";

            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    listView1.Items.Clear();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            listView1.Items.Add("Mã hóa đơn: " + reader["mahoadon"].ToString());
                            listView1.Items.Add("Mã bàn: " + reader["soban"].ToString());
                            listView1.Items.Add("Ngày đặt: " + reader["ngaydat"].ToString());
                            listView1.Items.Add("Tổng tiền: " + reader["tongtien"].ToString());

                        }
                    }
                    else
                    {
                        listView1.Items.Add("Không tồn tại bill");
                    }
                }
            }
        }
    }
}