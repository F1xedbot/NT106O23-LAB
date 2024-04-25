using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3
{
    public partial class LAB3_GUI : Form
    {
        public LAB3_GUI()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BAI1_Dashboard bai1_Dashboard = new BAI1_Dashboard();
            bai1_Dashboard.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BAI2 bai2 = new BAI2();
            bai2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BAI3_Dashboard bai3_Dashboard = new BAI3_Dashboard();
            bai3_Dashboard.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BAI4_Dashboard bai4_Dashboard = new BAI4_Dashboard();
            bai4_Dashboard.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BAI5_Dashboard bai5_Dashboard = new BAI5_Dashboard();
            bai5_Dashboard.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Iterate through all open forms
            foreach (Form form in Application.OpenForms)
            {
                // Check if the form is not the current form
                if (!form.Equals(this))
                {
                    // Close the form
                    form.Close();
                    Thread.Sleep(250);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BAI6_Dashboard bai6_dashboard = new BAI6_Dashboard();
            bai6_dashboard.Show();
        }
    }
}
