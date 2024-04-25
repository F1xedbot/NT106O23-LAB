using System.Data.SQLite;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using static LAB3.BAI5_Dashboard;

namespace LAB3
{
    public partial class BAI5_Server : Form
    {
        private string connectionString = @"Data Source=..\..\..\Databases\food.db;Version=3;UseUTF16Encoding=True;";
        private DatabaseHelper dbHelper;

        private Dictionary<int, List<int>> dbIDRecords = new Dictionary<int, List<int>>();
        private Dictionary<string, List<string>> dbTextRecords = new Dictionary<string, List<string>>();

        private TcpListener tcpListener;
        private Dictionary<TcpClient, ClientInfo> clients = new Dictionary<TcpClient, ClientInfo>();
        public BAI5_Server()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private async Task<bool> getClientPrivilege(ClientInfo client)
        {
            // Check if the contributor exists in the NguoiDung table and is an admin
            string query = "SELECT IDNCC FROM NguoiDung WHERE HoVaTen = @contributor AND QuyenHan = 'admin'";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@contributor", client.name);

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        return true;
                    else
                        return false;
                    
                }
            }
        }

        private async Task getDatabaseRecords()
        {
            dbIDRecords.Clear();
            dbTextRecords.Clear();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT MonAn.TenMonAn, NguoiDung.HoVaTen, NguoiDung.IDNCC, MonAn.IDMA " +
                             "FROM MonAn " +
                             "INNER JOIN NguoiDung ON MonAn.IDNCC = NguoiDung.IDNCC";

                await using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string dishName = reader["TenMonAn"].ToString();
                            string contributorName = reader["HoVaTen"].ToString();
                            int dishId = Int32.Parse(reader["IDNCC"].ToString());
                            int contributorId = Int32.Parse(reader["IDMA"].ToString());

                            AddToIDRecords(contributorId, dishId);
                            AddToTextRecords(contributorName, dishName);
                        }
                    }
                }
            }
        }
        private void AddToIDRecords(int key, int value)
        {
            if (!dbIDRecords.ContainsKey(key))
            {
                dbIDRecords.Add(key, new List<int> { value });
            }
            else
            {
                dbIDRecords[key].Add(value);
            }
        }

        private void AddToTextRecords(string key, string value)
        {
            if (!dbTextRecords.ContainsKey(key))
            {
                dbTextRecords.Add(key, new List<string> { value });
            }
            else
            {
                dbTextRecords[key].Add(value);
            }
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

                listBox1.Items.Add("Server is now listening...");

                listBox1.Items.Add("Getting Records From Database ... ");
                await getDatabaseRecords();
                listBox1.Items.Add("Database Records have been updated!");

                //listBox1.Items.Add($"Sample Data: Contributor: Ducvu, Dish name: {dbTextRecords["Ducvu"][0]}");

                while (true)
                {
                    TcpClient client = await tcpListener.AcceptTcpClientAsync();
                    HandleClientAsync(client);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private string encodeJsonData(string filter = "name")
        {
            // Create JsonSerializerOptions with UnsafeRelaxedJsonEscaping
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            };
            if (filter == "name")
                return JsonSerializer.Serialize(dbTextRecords, options);
            else
                return JsonSerializer.Serialize(dbIDRecords, options);
        }

        private Tuple<RecordData, byte[]> returnRandomDataWithFilter(string filter, TcpClient client)
        {
            string clientName = clients[client].name;
            RecordData recordData = null;
            byte[] imageData = null;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Determine the query based on the filter
                string query;
                if (filter.ToLower() == "local")
                {
                    query = "SELECT MonAn.IDMA, MonAn.TenMonAn, NguoiDung.HoVaTen, MonAn.HinhAnh " +
                            "FROM MonAn " +
                            "INNER JOIN NguoiDung ON MonAn.IDNCC = NguoiDung.IDNCC " +
                            "WHERE NguoiDung.HoVaTen = @clientName " +
                            "ORDER BY RANDOM() LIMIT 1";
                }
                else // Assuming "global" filter
                {
                    query = "SELECT MonAn.IDMA, MonAn.TenMonAn, NguoiDung.HoVaTen, MonAn.HinhAnh " +
                            "FROM MonAn " +
                            "INNER JOIN NguoiDung ON MonAn.IDNCC = NguoiDung.IDNCC " +
                            "ORDER BY RANDOM() LIMIT 1";
                }

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    if (filter.ToLower() == "local")
                    {
                        command.Parameters.AddWithValue("@clientName", clientName);
                    }

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            imageData = (byte[])reader["HinhAnh"];

                            // Create a RecordData object with the retrieved data
                            recordData = new RecordData
                            {
                                dishName = reader["TenMonAn"].ToString(),
                                contribName = reader["HoVaTen"].ToString(),
                                imageSize = imageData.Length 
                            };
                        }
                    }
                }
            }

            return new Tuple<RecordData, byte[]>(recordData, imageData);
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            ClientInfo clientInfo = null;
            try
            {
                listBox1.Items.Add($"Server: New Client Connected ({client.Client.RemoteEndPoint as IPEndPoint})");

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
                    // Assuming clients is a Dictionary<TcpClient, ClientInfo> or similar
                    if (!clients.ContainsKey(client))
                    {
                        listBox1.Items.Add("New Client: " + message);
                    }
                    

                    if (message.ToLower() == "quit")
                    {
                        break; // Stop listening to this client
                    }

                    if (message.ToLower() == "check")
                    {
                        byte[] data = Encoding.UTF8.GetBytes($"privilege:{clients[client].admin}");
                        listBox1.Items.Add($"Server: privilege:{clients[client].admin}");
                        // Send JSON data to the client
                        await stream.WriteAsync(data, 0, data.Length);
                    }

                    if (message.ToLower().StartsWith("random"))
                    {
                        Tuple<RecordData, byte[]> randomData = null;
                        string[] parts = message.Split(':');
                        listBox1.Items.Add($"Server: Getting Random Data with flag {parts[1]}");
                        if (parts.Length >= 2)
                            randomData = returnRandomDataWithFilter(filter: parts[1], client: client);

                        // Create JsonSerializerOptions with UnsafeRelaxedJsonEscaping
                        JsonSerializerOptions options = new JsonSerializerOptions
                        {
                            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                        };
                        if (randomData != null && randomData.Item1 != null && randomData.Item2 != null)
                        {
                            string jsonData = JsonSerializer.Serialize(randomData.Item1, options);
                            byte[] data = Encoding.UTF8.GetBytes(jsonData);
                            listBox1.Items.Add($"Server: {jsonData}");
                            await stream.WriteAsync(data, 0, data.Length);

                            await stream.WriteAsync(randomData.Item2, 0, randomData.Item2.Length);
                        }

                    }

                    if (message.ToLower().StartsWith("{\"name\"") && !clients.ContainsKey(client))
                    {
                        try
                        {
                            clientInfo = JsonSerializer.Deserialize<ClientInfo>(message);
                            bool isAdmin = await getClientPrivilege(clientInfo);

                            clientInfo.admin = isAdmin;

                            clients[client] = clientInfo;

                            if (listBox1 != null)
                            {
                                listBox1.Items.Add($"Server: Received client name: {clientInfo.name}");
                            }

                            if (listBox1 != null)
                            {
                                listBox1.Items.Add("Server: Sending back JSON Data");
                            }
                            // Serialize your data to JSON
                            string jsonData = encodeJsonData(filter: "name");
                            byte[] data = Encoding.UTF8.GetBytes(jsonData);
                            // Send JSON data to the client
                            await stream.WriteAsync(data, 0, data.Length);
                        }
                        catch (Exception ex)
                        {
                            // Log or handle the exception
                            Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                        }
                    }
                    if (message.ToLower().StartsWith("{\"dishname\""))
                    {
                        RecordData newRecord = JsonSerializer.Deserialize<RecordData>(message);
                        int imageSize = newRecord.imageSize;
                        listBox1.Items.Add($"Server: Received image size: {imageSize}");

                        // Read the image data
                        byte[] imageBuffer = new byte[imageSize];
                        int totalBytesRead = 0;
                        while (totalBytesRead < imageSize)
                        {
                            bytesRead = await stream.ReadAsync(imageBuffer, totalBytesRead, imageSize - totalBytesRead);
                            if (bytesRead == 0)
                            {
                                // Client disconnected or end of stream reached
                                listBox1.Items.Add("Client disconnected or end of stream reached.");
                                break;
                            }
                            totalBytesRead += bytesRead;
                        }
                        if (totalBytesRead == imageSize)
                        {
                            listBox1.Items.Add("Server: Insert new record");
                            // Assuming dbHelper.InsertMonAnBytes is a method that inserts the image into the database
                            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                            {
                                connection.Open();

                                // Insert the data into the MonAn table
                                dbHelper.InsertMonAnBytes(imageBuffer, newRecord.dishName, newRecord.contribName, connection);
                            }
                            await getDatabaseRecords();
                            // Serialize your data to JSON
                            string jsonData = encodeJsonData(filter: "name");
                            await BroadcastMessageAsync(jsonData);
                        }
                        else
                        {
                            listBox1.Items.Add("Failed to read the complete image data.");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("An error occurred: " + ex.Message);
            }
            finally
            {
                if (clientInfo != null)
                {
                   clients.Remove(client);
                }
                client.Close();
            }
        }
        private async Task BroadcastMessageAsync(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);

            foreach (var client in clients.Keys)
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
