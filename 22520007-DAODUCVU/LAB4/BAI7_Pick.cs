using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB4
{
    public partial class BAI7_Pick : UserControl
    {
        public BAI7_Pick()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private string _imageUrl;
        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                _imageUrl = value;
                LoadImageAsync();
            }
        }

        public string DishName
        {
            get { return labelName.Text; }
            set { labelName.Text = value; }
        }

        public string DishPrice
        {
            get { return labelPrice.Text; }
            set { labelPrice.Text = value; }
        }

        public string DishAddress
        {
            get { return labelAddress.Text; }
            set { labelAddress.Text = value; }
        }

        public string DishContrib
        {
            get { return labelContrib.Text; }
            set { labelContrib.Text = value; }
        }


        private async void LoadImageAsync()
        {
            if (!string.IsNullOrEmpty(_imageUrl))
            {
                try
                {
                    using (var client = new WebClient())
                    {
                        var imageBytes = await client.DownloadDataTaskAsync(_imageUrl);
                        using (var ms = new MemoryStream(imageBytes))
                        {
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception if the image download fails
                    Console.WriteLine($"Error loading image: {ex.Message}");
                }
            }
        }
    }
}
