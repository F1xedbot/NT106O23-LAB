using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3
{
    public partial class BAI4_Dashboard : Form
    {
        public BAI4_Dashboard()
        {
            InitializeComponent();
        }

        public class Theater
        {
            public string T { get; set; } // Shortened property name for TheaterName
            public List<Seat> S { get; set; } // Shortened property name for Seats
        }

        public class Seat
        {
            public string S { get; set; } // Shortened property name for SeatNumber
            public bool O { get; set; } // Shortened property name for Occupied
            public int St { get; set; } // Shortened property name for State
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BAI4_Server bai4_Server = new BAI4_Server();
            bai4_Server.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BAI4_Client bai4Client = new BAI4_Client();
            bai4Client.Show();
        }
    }
}
