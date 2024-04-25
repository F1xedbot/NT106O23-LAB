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
    public partial class BAI5_Dashboard : Form
    {
        public BAI5_Dashboard()
        {
            InitializeComponent();
            DatabaseHelper dbHelper = new DatabaseHelper();
            dbHelper.DatabaseInitialize();
        }

        public class ClientInfo
        {
            public string name { get; set; }
            public bool admin { get; set; }
        }

        public class RecordData
        {
            public string dishName { get; set; }
            public string contribName { get; set; }
            public int imageSize { get; set; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BAI5_Server bai5Server = new BAI5_Server();
            bai5Server.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BAI5_Client bai5client = new BAI5_Client();
            bai5client.Show();
        }
    }
}
