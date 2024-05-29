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
using Newtonsoft.Json.Linq;

namespace LAB4
{
    public partial class BAI5 : Form
    {
        public BAI5()
        {
            InitializeComponent();
        }
        public async Task PostLoginAsync(string url, string username, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                // Thiết lập nội dung type cho request
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

                // Tạo form-data từ username và password
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password)
                });

                // Thực hiện yêu cầu POST
                HttpResponseMessage response = await client.PostAsync(url, content);


                // Đọc nội dung response
                string responseBody = await response.Content.ReadAsStringAsync();

                // Parse JSON để lấy access_token và token_type
                JObject jsonResponse = JObject.Parse(responseBody);

                // Kiểm tra xem yêu cầu có thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    string accessToken = jsonResponse["access_token"].ToString();
                    string tokenType = jsonResponse["token_type"].ToString();
                    richTextBox1.Clear();
                    richTextBox1.AppendText(tokenType + "\n");
                    richTextBox1.AppendText(accessToken + "\n\n");
                    richTextBox1.AppendText("Đăng nhập thành công");
                }
                else
                {
                    richTextBox1.Clear();
                    // Nếu đăng nhập không thành công, đọc thông tin lỗi từ trường "detail"
                    string detail = jsonResponse["detail"].ToString();
                    richTextBox1.AppendText(detail);
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <= 0)
            {
                MessageBox.Show("Vui lòng nhập url để request", "Error ❌");
                return;
            } else if (textBox2.Text.Length <= 0 || textBox3.Text.Length <= 0)
            {
                MessageBox.Show("Vui lòng không để trống trường username hoặc password", "Error ❌");
                return;
            }
            string url = textBox1.Text;
            string username = textBox2.Text;
            string password = textBox3.Text;
            await PostLoginAsync(url, username, password);
        }
    }

}
