using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi4_Bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (lstLeft.SelectedItem != null)
            {
                lstRight.Items.Add(lstLeft.SelectedItem);
                lstLeft.Items.Remove(lstLeft.SelectedItem);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lstRight.SelectedItem != null)
            {
                lstLeft.Items.Add(lstRight.SelectedItem);
                lstRight.Items.Remove(lstRight.SelectedItem);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Chuyển giá trị items bên trái sang phải
            lstRight.Items.AddRange(lstLeft.Items);
            // Xóa giá trị bên trái
            lstLeft.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Chuyển giá trị items bên trái sang phải
            lstLeft.Items.AddRange(lstRight.Items);
            // Xóa giá trị bên trái
            lstRight.Items.Clear();
        }
    }
}
