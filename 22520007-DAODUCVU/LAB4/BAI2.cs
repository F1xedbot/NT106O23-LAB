using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB4
{
    public partial class BAI2 : Form
    {
        HttpClient httpClient;
        public BAI2()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                string response = await getHTMLAsync(textBox1.Text, httpClient);
                richTextBox1.Text = response;
            }
        }

        private async Task<string> getHTMLAsync(string szURL, HttpClient client)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(szURL);

                string responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task DownloadHTMLToFileAsync(string szURL, string destinationPath, HttpClient client)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(szURL);

                string responseContent = await response.Content.ReadAsStringAsync();

                // Ensure the destination directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

                // Save the content to a file
                await File.WriteAllTextAsync(destinationPath, responseContent);
                MessageBox.Show($"Successfully downloaded content from {szURL} to {destinationPath}");
            }
            catch (Exception ex)
            {
                // Log or show the exception message
                MessageBox.Show($"An error occurred while downloading content from {szURL}: {ex.Message}");
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if(textBox2.Text.Length > 0 && textBox1.Text.Length > 0)
            {
                await DownloadHTMLToFileAsync(textBox1.Text, textBox2.Text, httpClient);
            }
        }
    }
}
