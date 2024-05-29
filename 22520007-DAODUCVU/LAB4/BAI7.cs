using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB4
{
    public partial class BAI7 : Form
    {

        private BAI7_Login _loginForm;
        private dynamic _userProfile;
        private dynamic _currentData;
        private string[] _authToken;
        private int maxPageSize = 5;

        private bool isAuthenticated = false;
        public BAI7()
        {
            InitializeComponent();
            _userProfile = null;
            // Subscribe to the event
            checkUserAuthenticated();
        }

        private void HandleTokenData(string[] data)
        {
            if (data.Length == 0)
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
            else
            {
                MessageBox.Show("Đăng nhập thành công");
                _loginForm.Close();

                // Use Task.Run to execute the async call without blocking the UI thread
                Task.Run(async () =>
                {
                    try
                    {
                        // Call GetUserProfileAsync and pass the required parameters
                        string userProfileJson = await GetUserProfileAsync("https://nt106.uitiot.vn/api/v1/user/me", data[1], data[0]);

                        // Deserialize the JSON string into a dynamic object
                        dynamic userProfile = JsonConvert.DeserializeObject(userProfileJson);


                        // Invoke the UI update on the main thread
                        Invoke(new Action(() =>
                        {
                            _userProfile = userProfile;
                            _authToken = data;
                            populateDataFromProfile(userProfile);
                        }));
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions that might occur during the async call
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                });
            }
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
                    return responseBody;
                }
            }
            return "";
        }

        private async void FetchData(string url, int pageNumber, int pageSize, FlowLayoutPanel panel)
        {
            try
            {
                // Replace this URL with your actual API endpoint
                string apiUrl = $"{url}?current={pageNumber}&pageSize={pageSize}";
                string jsonResponse = await GetApiContentAsync(apiUrl, _authToken[1], _authToken[0], pageNumber, pageSize);

                // Deserialize the JSON response and update your UI
                dynamic data = JsonConvert.DeserializeObject(jsonResponse);
                _currentData = data;

                UpdateDishListUI(data, panel);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to fetch data: {ex.Message}");
            }
        }

        public async Task<string> FetchRandomData(string url, string id)
        {
            using (HttpClient client = new HttpClient())
            {
                // Đặt token vào header Authorization
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_authToken[1], _authToken[0]);

                // Thực hiện yêu cầu GET
                HttpResponseMessage response = await client.GetAsync($"{url}/{id}");

                // Kiểm tra xem yêu cầu có thành công hay không
                if (response.IsSuccessStatusCode)
                {
                    // Đọc nội dung response
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
            }
            return "";
        }

        private async Task<string> GetApiContentAsync(string url, string tokenType, string accessToken, int pageNumber, int pageSize)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);

                // Create a new content instance with the JSON payload
                var content = new StringContent(JsonConvert.SerializeObject(new { current = pageNumber, pageSize }), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception($"API request failed with status code: {(int)response.StatusCode}");
                }
            }
        }

        private void UpdateDishListUI(dynamic data, FlowLayoutPanel panel)
        {
            panel.Controls.Clear();
            foreach (var dishData in data.data)
            {
                BAI7_Pick dishItem = new BAI7_Pick();
                dishItem.ImageUrl = dishData.hinh_anh;
                dishItem.DishName = dishData.ten_mon_an;
                dishItem.DishPrice = dishData.gia;
                dishItem.DishAddress = dishData.dia_chi;
                dishItem.DishContrib = dishData.nguoi_dong_gop;

                panel.Controls.Add(dishItem);
            }

            var paginationData = data.pagination;
            int currentPage = paginationData.current;
            int pageSize = paginationData.pageSize;
            int totalPages = paginationData.total;

            comboBoxPageSize.Items.Clear();
            comboBoxPageNum.Items.Clear();

            // Populate pageSize ComboBox
            for (int i = 1; i <= maxPageSize; i++)
            {
                comboBoxPageSize.Items.Add(i);
            }

            for (int i = 1; i <= totalPages; i++)
            {
                comboBoxPageNum.Items.Add(i);
            }
        }

        private void checkUserAuthenticated()
        {
            if (!isAuthenticated)
            {
                labelStatus.Text = "Unauthenticated";
                labelStatus.ForeColor = Color.DarkRed;
                logoutLabel.Visible = false;
                _loginForm = new BAI7_Login();
                _loginForm.SendToken += HandleTokenData;
                _loginForm.Show();
            }
        }

        private void populateDataFromProfile(dynamic profile)
        {
            labelStatus.Text = "Welcome, " + profile.username;
            labelStatus.ForeColor = Color.Green;
            logoutLabel.Visible = true;
            FetchData("https://nt106.uitiot.vn/api/v1/monan/all", 1, 5, flowLayoutPanel1);
        }

        private void logoutLabel_Click(object sender, EventArgs e)
        {
            // Reset the authentication state
            isAuthenticated = false;

            // Clear the user profile data
            _userProfile = null;

            // Update the UI to reflect that the user is logged out
            labelStatus.Text = "Unauthenticated";
            labelStatus.ForeColor = Color.DarkRed;
            logoutLabel.Visible = false;

            // Optionally, invalidate session tokens/cookies here if needed

            // Refresh the UI to apply the changes
            this.Refresh();

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();
            checkUserAuthenticated();
        }

        private void UpdatePaginationData(int pageNumber, int pageSize)
        {

            if (pageNumber < 0 || pageSize < 0)
                return;

            if (tabControl1.SelectedIndex == 0)
            {
                FetchData("https://nt106.uitiot.vn/api/v1/monan/all", pageNumber + 1, pageSize + 1, flowLayoutPanel1);
                return;
            }
            if (tabControl1.SelectedIndex == 1)
            {
                FetchData("https://nt106.uitiot.vn/api/v1/monan/my-dishes", pageNumber + 1, pageSize + 1, flowLayoutPanel2);
                return;
            }
        }

        private void comboBoxPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePaginationData(comboBoxPageNum.SelectedIndex, comboBoxPageSize.SelectedIndex);
        }

        private void comboBoxPageNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePaginationData(comboBoxPageNum.SelectedIndex, comboBoxPageSize.SelectedIndex);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePaginationData(comboBoxPageNum.SelectedIndex, comboBoxPageSize.SelectedIndex);
        }

        private async void randDishBtn_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            dynamic dishData = _currentData.data;

            if (dishData != null && dishData.Count > 0)
            {
                int randomIndex = rnd.Next(dishData.Count); // Generate a random index
                string randomDishId = dishData[randomIndex].id; // Get the ID of the dish at the random index
                string jsonResponse = await FetchRandomData("https://nt106.uitiot.vn/api/v1/monan", randomDishId);
                dynamic data = JsonConvert.DeserializeObject(jsonResponse);

                BAI7_Pick dishItem = new BAI7_Pick();
                dishItem.ImageUrl = data.hinh_anh;
                dishItem.DishName = data.ten_mon_an;
                dishItem.DishPrice = data.gia;
                dishItem.DishAddress = data.dia_chi;
                dishItem.DishContrib = data.nguoi_dong_gop;

                BAI7_Randpick randomPick = new BAI7_Randpick(dishItem);
                randomPick.Show();
            }
            else
            {
                MessageBox.Show("No dishes found.");
            }
        }

        private void addDishBtn_Click(object sender, EventArgs e)
        {
            BAI7_Add addForm = new BAI7_Add(_authToken);
            addForm.Show();
        }
    }
}
