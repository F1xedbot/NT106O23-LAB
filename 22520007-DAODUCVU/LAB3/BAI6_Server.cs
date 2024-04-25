using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LAB3.BAI5_Dashboard;
using static LAB3.BAI6_Dashboard;

namespace LAB3
{
    public partial class BAI6_Server : Form
    {
        public BAI6_Server()
        {
            InitializeComponent();
        }

        private TcpListener tcpListener;
        private Dictionary<TcpClient, ClientInfo> clients = new Dictionary<TcpClient, ClientInfo>();
        private List<PublicMessage> messageHistory = new List<PublicMessage>();
        private List<string> participants = new List<string>();

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

        private string encodeJsonData(object data)
        {
            // Create JsonSerializerOptions with UnsafeRelaxedJsonEscaping
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            };
            return JsonSerializer.Serialize(data, options);
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
                        participants.Remove(clients[client].name);
                        await BroadcastMessageAsync(encodeJsonData(participants));
                        listBox1.Items.Add($"Server: Participants list updated");
                        break; // Client disconnected
                    }

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                    // Assuming clients is a Dictionary<TcpClient, ClientInfo> or similar
                    if (!clients.ContainsKey(client))
                    {
                        listBox1.Items.Add("New Client: " + message);
                    } else
                    {
                        listBox1.Items.Add($"Client {clients[client].name}: {message}");
                    }


                    if (message.ToLower() == "quit")
                    {
                        participants.Remove(clients[client].name);
                        await BroadcastMessageAsync(encodeJsonData(participants));
                        listBox1.Items.Add($"Server: Participants list updated");
                        break; // Stop listening to this client
                    }


                    if (message.ToLower().StartsWith("{\"name\"") && !clients.ContainsKey(client))
                    {
                        try
                        {
                            clientInfo = JsonSerializer.Deserialize<ClientInfo>(message);

                            clients[client] = clientInfo;

                            if (listBox1 != null)
                            {
                                listBox1.Items.Add($"Server: Received client name: {clientInfo.name}");
                                participants.Add(clientInfo.name);

                                await BroadcastMessageAsync(encodeJsonData(participants));
                                listBox1.Items.Add($"Server: Participants list updated");
                            }
                        }
                        catch (Exception ex)
                        {
                            // Log or handle the exception
                            Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                        }
                    }
                    if (message.ToLower().StartsWith("{\"message\"")){
                        PublicMessage newMessage = JsonSerializer.Deserialize<PublicMessage>(message);
                        messageHistory.Add(newMessage);
                        if (message != null) {
                            await BroadcastMessageAsync(message);
                        }
                    }

                    if (message.ToLower().StartsWith("{\"target\""))
                    {
                        PrivateMessage newMessage = JsonSerializer.Deserialize<PrivateMessage>(message);
                        if (message != null)
                        {
                            await BroadcastMessageAsyncPrivate(newMessage.from, newMessage.target, message);
                        }
                    }
                    if (message.ToLower().StartsWith("{\"filename\""))
                    {
                        PrivateFile newFile = JsonSerializer.Deserialize<PrivateFile>(message);
                        if (message != null)
                        {
                            listBox1.Items.Add($"Server: Received file size: {newFile.filesize}");

                            // Read the file data
                            byte[] fileBuffer = new byte[newFile.filesize];
                            int totalBytesRead = 0;
                            while (totalBytesRead < newFile.filesize)
                            {
                                bytesRead = await stream.ReadAsync(fileBuffer, totalBytesRead, newFile.filesize - totalBytesRead);
                                if (bytesRead == 0)
                                {
                                    // Client disconnected or end of stream reached
                                    listBox1.Items.Add("Client disconnected or end of stream reached.");
                                    break;
                                }
                                totalBytesRead += bytesRead;
                            }
                            if (totalBytesRead == newFile.filesize)
                            {
                                await BroadcastMessageAsyncPrivate(newFile.from, newFile.target, message);
                                await BroadcastFileAsyncPrivate(newFile.from, newFile.target, fileBuffer);
                            }
                            else
                            {
                                listBox1.Items.Add("Failed to read the complete image data.");
                            }
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

        private async Task BroadcastFileAsyncPrivate(string from, string target, byte[] data)
        {
            foreach (var client in clients.Keys)
            {
                if (clients[client].name == from || clients[client].name == target)
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
        }

        private async Task BroadcastMessageAsyncPrivate(string from, string target, string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);

            foreach (var client in  clients.Keys)
            {
                if (clients[client].name == from || clients[client].name == target)
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
