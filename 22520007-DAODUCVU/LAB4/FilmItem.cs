using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB4
{
    public partial class FilmItem : UserControl
    {
        public FilmItem()
        {
            InitializeComponent();
            label2.MouseEnter += (sender, e) =>
            {
                label2.Cursor = Cursors.Hand;
            };

            label2.MouseLeave += (sender, e) =>
            {
                label2.Cursor = Cursors.Default;
            };

            label2.MouseDown += (sender, e) =>
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(label2.Text) { UseShellExecute = true });
            };

            label2.AccessibleRole = AccessibleRole.Link;
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

        public string FilmTitle
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public string FilmDescription
        {
            get { return label2.Text; }
            set { label2.Text = value; }
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
