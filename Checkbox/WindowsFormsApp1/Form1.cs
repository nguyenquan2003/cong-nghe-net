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

        private void checkBox1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Click");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("CheckedChanged");
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("CheckStateChanged");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;;
            string Q = checkBox1.CheckState == CheckState.Checked ? "là" : checkBox1.CheckState == CheckState.Unchecked ?
            "không phải" : "phải cũng không phải là";
            string showString = string.Format("Chào bạn {0}, bạn {1} Q!", name, Q);
            MessageBox.Show(showString);
            
        }
    }
}
