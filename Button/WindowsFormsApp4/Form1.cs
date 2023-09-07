using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        int i = 0;
        void add_button()
        {
            Random rand = new Random();
            /*tạo ngẫu nhiên tùy vị trí từ 0-100
            Button btn = new Button()
            { Text = i.ToString(), Location = new Point(rand.Next(0, 100), rand.Next(0, 100)) };*/

            //tạo ngẫu nhiên với tùy vị trí
            Button btn = new Button()
            { Text = i.ToString(), Location = new Point(rand.Next(0, this.Size.Width), rand.Next(0, this.Size.Width)) };
            btn.Click += btn_Click;
            this.Controls.Add(btn);
            i++;
        }
        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            MessageBox.Show(btn.Text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            add_button();
        }
    }
}