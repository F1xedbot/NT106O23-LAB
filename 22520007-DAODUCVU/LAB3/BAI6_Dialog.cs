using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3
{
    public partial class BAI6_Dialog : Form
    {
        public BAI6_Dialog(bool filter, byte[] fileData)
        {
            InitializeComponent();

            if (filter)
            {
                ShowImageData(fileData);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                richTextBox1.Visible = false;
                pictureBox1.Visible = true;
            } else
            {
                ShowTextData(fileData);
                pictureBox1.Visible = false;
                richTextBox1.Visible = true;
            }
        }

        private void ShowImageData(byte[] data)
        {
            try
            {
                // Convert byte array to image
                using (MemoryStream ms = new MemoryStream(data))
                {
                    Image image = Image.FromStream(ms);
                    pictureBox1.Image = image;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ShowTextData(byte[] data)
        {
            try
            {
                // Convert byte array to text
                string content = Encoding.UTF8.GetString(data);
                richTextBox1.Text = content;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying text: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
