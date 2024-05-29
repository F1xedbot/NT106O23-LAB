using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
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
using static LAB4.BAI7_Register;

namespace LAB4
{
    public partial class BAI7_Add : Form
    {
        private readonly string[] _authToken;
        public BAI7_Add(string[] authToken)
        {
            InitializeComponent();
            _authToken = authToken;
        }

        public class DishModel
        {
            public string ten_mon_an { get; set; }
            public int gia { get; set; }
            public string mo_ta { get; set; }
            public string hinh_anh { get; set; }
            public string dia_chi { get; set; }
        }

        public async Task<string> AddNewDish(string url, DishModel payload)
        {
            using (HttpClient client = new HttpClient())
            {
                // Set the Authorization header
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_authToken[1], _authToken[0]);

                var jsonPayload = JsonConvert.SerializeObject(payload);

                // Create a new content instance with the JSON payload
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                // Make the POST request
                HttpResponseMessage response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    // Return the response content as a string
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception($"API request failed with status code: {(int)response.StatusCode}");
                }
            }
        }

        private async void addBtn_Click(object sender, EventArgs e)
        {
            // Check if any of the required fields are empty
            if (string.IsNullOrWhiteSpace(addName.Text) ||
                string.IsNullOrWhiteSpace(addPrice.Text) ||
                string.IsNullOrWhiteSpace(addDesc.Text) ||
                string.IsNullOrWhiteSpace(addImgUrl.Text) ||
                string.IsNullOrWhiteSpace(addAddress.Text))
            {
                MessageBox.Show("Hãy điền vào tất cả các trường");
                return; // Stop execution if any required field is missing
            }

            int newPrice;
            bool isValid = int.TryParse(addPrice.Text, out newPrice);


            if (isValid)
            {
                var newDish = new DishModel
                {
                    ten_mon_an = addName.Text,
                    gia = newPrice,
                    mo_ta = addDesc.Text,
                    hinh_anh = addImgUrl.Text,
                    dia_chi = addAddress.Text,
                };

                string response = await AddNewDish("https://nt106.uitiot.vn/api/v1/monan/add", newDish);
                MessageBox.Show("Thêm món thành công");
            }
            else
            {
                MessageBox.Show("Please enter a valid number for the price.");
            }
        }
    }
}
