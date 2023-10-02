using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn.Text = "Hello Word";
            btn.AutoSize = true;
            panel1.Controls.Add(btn);

            Random rand = new Random();
            btn.Location = new Point(rand.Next(0, panel1.Size.Width), rand.Next(0, panel1.Size.Height));
            panel1.Controls.Add(btn);
            flowLayoutPanel1.Controls.Add(btn);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Enabled = !panel1.Enabled;
        }
    }
}
