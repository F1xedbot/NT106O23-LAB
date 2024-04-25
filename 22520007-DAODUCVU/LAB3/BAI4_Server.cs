using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LAB3.BAI4_Dashboard;
using static System.Windows.Forms.Design.AxImporter;

namespace LAB3
{
    public partial class BAI4_Server : Form
    {
        public BAI4_Server()
        {
            InitializeComponent();
        }


        private TcpListener tcpListener;
        private Theater[] cinemaData = new Theater[0];
        private string dataDirectory = @"../../../Data/";

        private List<TcpClient> clients = new List<TcpClient>();

        private void BAI4_Server_Load(object sender, EventArgs e)
        {
            // Load data from JSON file to DataGridView
            LoadDataFromJson();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tcpListener == null)
                {
                    IPAddress ipAddress = IPAddress.Any;
                    IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 8080);
                    tcpListener = new TcpListener(ipEndPoint);
                    tcpListener.Start();
                }

                MessageBox.Show("Server is now listening...");

                while (true)
                {
                    TcpClient client = await tcpListener.AcceptTcpClientAsync();
                    clients.Add(client);
                    HandleClientAsync(client);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            try
            {
                listBox1.Items.Add("Server: New Client Connected");

                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[2048];

                while (true)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        break; // Client disconnected
                    }

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                    listBox1.Items.Add("Client: " + message);

                    if (message.ToLower() == "quit")
                    {
                        break; // Stop listening to this client
                    }

                    if (message.ToLower() == "get")
                    {
                        listBox1.Items.Add("Server: Sending back JSON Data");
                        // Serialize your data to JSON

                        string jsonData = encodeJsonData();

                        byte[] data = Encoding.UTF8.GetBytes(jsonData);

                        // Send JSON data to the client
                        await stream.WriteAsync(data, 0, data.Length);
                    }

                    if (message.ToLower().StartsWith("update"))
                    {
                        // Split the received string to separate the "update" keyword from the JSON content
                        string[] parts = message.Split(new[] { "update " }, StringSplitOptions.None);

                        // The second part contains the JSON content
                        string jsonContent = parts[1];

                        UpdateDataJson(jsonContent);

                        listBox1.Items.Add("Server: Sending updated JSON Data");

                        string jsonData = encodeJsonData();

                        await BroadcastMessageAsync(jsonData);

                    }

                }
                clients.Remove(client);
                client.Close();
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("An error occurred: " + ex.Message);
            }
        }

        private async Task BroadcastMessageAsync(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);

            foreach (var client in clients)
            {
                try
                {
                    NetworkStream stream = client.GetStream();
                    await stream.WriteAsync(data, 0, data.Length);
                }
                catch (Exception ex)
                {
                    listBox1.Items.Add("An error occurred while broadcasting: " + ex.Message);
                }
            }
        }

        private string encodeJsonData()
        {
            // Create JsonSerializerOptions with UnsafeRelaxedJsonEscaping
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            };

            // Serialize your data to JSON with specified options
            string jsonData = JsonSerializer.Serialize(cinemaData, options);

            return jsonData;
        }

        private void UpdateDataJson(string jsonContent)
        {
            // Parse the JSON content into a JsonDocument
            JsonDocument doc = JsonDocument.Parse(jsonContent);

            // Extract the T value
            string tValue = doc.RootElement.GetProperty("T").GetString();

            // Extract the S array and convert it to a HashSet for faster lookups
            HashSet<string> selectedSeats = new HashSet<string>(
                doc.RootElement.GetProperty("S").EnumerateArray().Select(seatElement => seatElement.GetString())
            );

            foreach (Theater theater in cinemaData)
            {
                if (theater.T == tValue)
                {
                    foreach (Seat seat in theater.S)
                    {
                        if (selectedSeats.Contains(seat.S))
                        {
                            seat.O = true;
                        }
                    }
                }
            }
        }

        private void LoadDataFromJson()
        {
            try
            {
                // Read JSON data from file
                string jsonData = File.ReadAllText(dataDirectory + "cinema_data.json");

                // Parse JSON and deserialize to array of Theater objects
                cinemaData = JsonSerializer.Deserialize<Theater[]>(jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data from JSON file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            try
            {
                tcpListener?.Stop();
                tcpListener?.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while closing the connection: " + ex.Message, "Error");
            }
        }

    }
}
