using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3
{
    public partial class BAI6_Dashboard : Form
    {
        public BAI6_Dashboard()
        {
            InitializeComponent();
        }

        public class PublicMessage
        { 
            public string message { get; set; }
            public string name { get; set; }
        }

        public class PrivateMessage
        {
            public string target { get; set; }
            public string from { get; set; }
            public string message { get; set; }
        }

        public class PrivateFile
        {
            public string filename { get; set; }
            public int filesize { get; set; }
            public string extension { get; set; }
            public string from { get; set; }
            public string target { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BAI6_Client bai6_Client = new BAI6_Client();
            bai6_Client.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BAI6_Server bai6_Server = new BAI6_Server();
            bai6_Server.Show();
        }
    }
}
