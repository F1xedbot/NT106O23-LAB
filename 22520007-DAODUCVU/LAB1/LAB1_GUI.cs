using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class LAB1_GUI : Form
    {
        public LAB1_GUI()
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

        private void button10_Click(object sender, EventArgs e)
        {
            // Iterate through all open forms
            foreach (Form form in Application.OpenForms)
            {
                // Skip the current form to avoid closing it
                if (form != this)
                {
                    // Close the form
                    form.Close();
                }
            }
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

        private void button8_Click(object sender, EventArgs e)
        {
            BAI8 bai8 = new BAI8();
            bai8.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BAI7 bai7 = new BAI7();
            bai7.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            BAI3_1 bai3_1 = new BAI3_1();
            bai3_1.Show();
        }
    }
}
