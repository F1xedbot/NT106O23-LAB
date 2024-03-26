using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2
{
    public partial class BAI6_1 : Form
    {
        public BAI6_1(string tenMonAn, string hoVaTen, byte[] imageData)
        {
            InitializeComponent();

            // Set the data to the appropriate controls
            textBox1.Text = tenMonAn;
            textBox2.Text = hoVaTen;

            // Convert the BLOB data to a MemoryStream
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                // Set the PictureBox image to the BLOB data
                pictureBox1.Image = Image.FromStream(ms);

                // Set the SizeMode of PictureBox to Zoom
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
