using System.Net;
using System.Security.Policy;

namespace LAB4
{
    public partial class BAI1 : Form
    {
        public BAI1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                string responseString = await getHTMLAsync(textBox1.Text);
                if (responseString != null)
                {
                    richTextBox1.Text = responseString;
                }
                else
                {
                    richTextBox1.Text = "Internal Server Error";
                }
            }
            else
            {
                MessageBox.Show("Input string must be a valid URL", "Warning");
            }
        }

        private async Task<string> getHTMLAsync(string szURL)
        {
            HttpClient httpClient = new HttpClient();

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(szURL);

                string responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            } catch (Exception ex)
            {
                return null;
            }
        }
    }
}
