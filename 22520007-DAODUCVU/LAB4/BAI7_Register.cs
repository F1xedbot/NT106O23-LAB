using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB4
{
    public partial class BAI7_Register : Form
    {
        public BAI7_Register()
        {
            InitializeComponent();
            comboBoxLanguage.Items.Add("vn");
            comboBoxLanguage.Items.Add("en");
        }

        public class UserSignupModel
        {
            public string username { get; set; }
            public string email { get; set; }
            public string password { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public int sex { get; set; } // Assuming sex is represented as an integer (0 for female, 1 for male, etc.)
            public string birthday { get; set; }
            public string language { get; set; }
            public string phone { get; set; }
        }

        private async void regBtn_Click(object sender, EventArgs e)
        {
            // Check if any of the required fields are empty
            if (string.IsNullOrWhiteSpace(regUsername.Text) ||
                string.IsNullOrWhiteSpace(regEmail.Text) ||
                string.IsNullOrWhiteSpace(regPassword.Text) ||
                string.IsNullOrWhiteSpace(regFirstname.Text) ||
                string.IsNullOrWhiteSpace(regLastname.Text) ||
                comboBoxLanguage.SelectedIndex == -1 ||
                (!radioMale.Checked && !radioFemale.Checked))
            {
                MessageBox.Show("Hãy điền vào tất cả các trường");
                return; // Stop execution if any required field is missing
            }

            // Basic validation for email format
            if (!Regex.IsMatch(regEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Định dạng email không hợp lệ");
                return; // Stop execution if the email is not valid
            }

            // Minimum length requirement for password
            if (regPassword.Text.Length < 6)
            {
                MessageBox.Show("Password phải chứ ít nhất 6 ký tự");
                return; // Stop execution if the password is too short
            }


            // Phone number validation (simple check, adjust according to your requirements)
            if (!Regex.IsMatch(regPhone.Text, @"^\d{10}$")) // Example for a 10-digit phone number
            {
                MessageBox.Show("Định dạng số điện thoại không hợp lệ");
                return; // Stop execution if the phone number format is incorrect
            }

            string formattedDateString = dateTimePicker1.Value.ToString("yyyy-MM-dd");
          
            var user = new UserSignupModel
            {
                username = regUsername.Text,
                email = regEmail.Text,
                password = regPassword.Text,
                first_name = regFirstname.Text,
                last_name = regLastname.Text,
                sex = radioFemale.Checked ? 1 : 0,
                birthday = formattedDateString,
                language = comboBoxLanguage.Text,
                phone = regPhone.Text
            };

            await RegisterUserAsync(user);
        }

        public async Task RegisterUserAsync(UserSignupModel user)
        {
            // Serialize the user model to JSON
            string jsonContent = JsonConvert.SerializeObject(user);

            MessageBox.Show(jsonContent);

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://nt106.uitiot.vn"); // Set the base address of the API
                client.DefaultRequestHeaders.Accept.Clear(); // Clear existing headers
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // Accept JSON

                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("/api/v1/user/signup", content);

                if (response.IsSuccessStatusCode)
                {
                    // Read the response content
                    string responseContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Registration successful\n{responseContent}");
                }
                else
                {
                    MessageBox.Show("Registration failed", response.StatusCode.ToString());
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
