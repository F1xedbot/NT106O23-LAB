using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace LAB4
{
    public partial class BAI6 : Form
    {
        public BAI6()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public async Task<string> GetUserProfileAsync(string url, string tokenType, string accessToken)
        {
            using (HttpClient client = new HttpClient())
            {
                // Đặt token vào header Authorization
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);

                // Thực hiện yêu cầu GET
                HttpResponseMessage response = await client.GetAsync(url);

                // Kiểm tra xem yêu cầu có thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    // Đọc nội dung response
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Hiển thị thông tin user lên giao diện
                    ShowUserProfile(responseBody);
                   
                    return "Lấy thông tin user thành công.";
                }
                else
                {
                    return "Lỗi khi lấy thông tin user.";
                }
            }
        }

        private void ShowUserProfile(string userProfileJson)
        {
            // Deserialize the JSON string into a dynamic object
            dynamic userProfile = JsonConvert.DeserializeObject(userProfileJson);

            richTextBox1.Clear();

            // Iterate through the properties of the dynamic object
            foreach (var property in userProfile)
            {
                // Append the property name and value to the RichTextBox
                richTextBox1.AppendText($"{property.Name}: {property.Value}\n");
            }

            // Ensure the RichTextBox is visible and scrollable if necessary
            richTextBox1.Visible = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <= 0)
            {
                MessageBox.Show("Vui lòng nhập url để request", "Error ❌");
                return;
            }
            else if (textBox2.Text.Length <= 0 || textBox3.Text.Length <= 0)
            {
                MessageBox.Show("Vui lòng không để trống trường tokenType hoặc accessToken", "Error ❌");
                return;
            }
            string url = textBox1.Text;
            string tokenType = textBox2.Text;
            string accessToken = textBox3.Text;

            string result = await GetUserProfileAsync(url, tokenType, accessToken);

            MessageBox.Show(result);
        }
    }
}
