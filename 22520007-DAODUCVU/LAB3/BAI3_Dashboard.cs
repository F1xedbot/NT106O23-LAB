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
    public partial class BAI3_Dashboard : Form
    {
        public BAI3_Dashboard()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BAI3_Server bai3_Server = new BAI3_Server();
            bai3_Server.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BAI3_Client bai3_Client = new BAI3_Client();
            bai3_Client.Show();
        }
    }
}
