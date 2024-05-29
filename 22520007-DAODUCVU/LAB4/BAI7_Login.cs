using Newtonsoft.Json.Linq;
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

namespace LAB4
{
    public partial class BAI7_Login : Form
    {
        // Define the event
        public event Action<string[]> SendToken;
        public BAI7_Login()
        {
            InitializeComponent();
        }

        private async void logBtn_Click(object sender, EventArgs e)
        {
            if (logUsername.Text.Length <= 0 || logPassword.Text.Length <= 0)
            {
                MessageBox.Show("Không được để trống tên người dùng hoặc password", "Warning");
                return;
            }

            string[] Token = new string[] { };

            Token = await PostLoginAsync("https://nt106.uitiot.vn/auth/token", logUsername.Text, logPassword.Text);

            SendToken?.Invoke(Token);

        }

        public async Task<String[]> PostLoginAsync(string url, string username, string password)
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
                    return new String[] { accessToken, tokenType };
                }
                else
                {
                    // Nếu đăng nhập không thành công, đọc thông tin lỗi từ trường "detail"
                    string detail = jsonResponse["detail"].ToString();
                    MessageBox.Show(detail);
                    return new String[] { };
                }
            }
        }

        private void labelSignup_Click(object sender, EventArgs e)
        {
            BAI7_Register registerPage = new BAI7_Register();
            registerPage.Show();
        }
    }
}
