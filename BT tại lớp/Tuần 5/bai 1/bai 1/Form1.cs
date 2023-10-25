using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            //DateTime now = new DateTime();
            //label1.Text = now.ToString();

            DateTime now = new DateTime();
            label1.Text = DateTime.Now.ToString("HH:mm:ss tt");// HH la gio theo 24h, tt la chi buoi sang
            label2.Left += 20;
            if (label2.Left > this.Width)
                label2.Left = 10;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            label2.Left += 20;
            if (label2.Left > this.Width)
            {
                label2.Left = 10;
                label2.ForeColor = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
