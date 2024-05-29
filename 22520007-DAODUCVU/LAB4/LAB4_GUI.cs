using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB4
{
    public partial class LAB4_GUI : Form
    {
        public LAB4_GUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BAI1 bai1 = new BAI1();
            bai1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BAI2 bai2 = new BAI2();
            bai2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BAI3 bai3 = new BAI3();
            bai3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BAI4 bai4 = new BAI4();
            bai4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BAI5 bai5 = new BAI5();
            bai5.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BAI6 bai6 = new BAI6();
            bai6.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BAI7 bai7 = new BAI7();
            bai7.Show();
        }
    }
}
