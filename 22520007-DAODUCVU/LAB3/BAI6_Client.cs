using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LAB3.BAI5_Dashboard;
using static LAB3.BAI6_Dashboard;

namespace LAB3
{
    public partial class BAI6_Client : Form
    {
        public BAI6_Client()
        {
            InitializeComponent();
        }

        private TcpClientManager tcpClientManager;
        public ClientInfo clientInfo = new ClientInfo();
        private List<string> participants = new List<string>();
        private Dictionary<string, List<PrivateMessage>> privateMessages = new Dictionary<string, List<PrivateMessage>>();
        private Dictionary<string, BAI6_Private> openPrivateWindows = new Dictionary<string, BAI6_Private>();
        private Dictionary<string, byte[]> attachments = new Dictionary<string, byte[]>();

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox2.SelectedIndex;
            if (index != -1 && listBox2.Items[index].ToString() != clientInfo.name)
            {
                string target = listBox2.Items[index].ToString();

                // Close the previously opened private window if it exists
                if (openPrivateWindows.ContainsKey(target) && !openPrivateWindows[target].IsDisposed)
                {
                    openPrivateWindows[target].Close();
                    openPrivateWindows.Remove(target);
                }

                if (!privateMessages.ContainsKey(target))
                    privateMessages[target] = new List<PrivateMessage>();
                BAI6_Private bai6_Private = new BAI6_Private(this, target, privateMessages[target], attachments);
                bai6_Private.Show();
                openPrivateWindows[target] = bai6_Private;
            }
        }

        public void sendPrivateMessage(PrivateMessage message)
        {
            tcpClientManager.Send(encodeJsonData(message));
        }

        public void sendPrivateFile(PrivateFile file, byte[] fileData)
        {
            tcpClientManager.Send(encodeJsonData(file));
            tcpClientManager.SendBytes(fileData);
        }

        public void updatePrivateMessageDict(string target, List<PrivateMessage> messages)
        {
            privateMessages[target] = messages;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tcpClientManager = new TcpClientManager();
            tcpClientManager.ConnectionStatusChanged += HandleConnectionStatusChanged;
            tcpClientManager.DataReceived += HandleDataReceived;

            if (!setClientInfo())
                return;

            if (!tcpClientManager.IsConnected())
            {
                if (tcpClientManager.Connect("127.0.0.1", 8080))
                {
                    connectBtn.Enabled = false;
                    disconnectBtn.Enabled = true;
                    listBox1.Items.Clear();
                    listBox1.Items.Add("You joined the group.");
                    tcpClientManager.Send(encodeJsonData(clientInfo));
                }
            }
        }

        private void LoadPrivateMessage(string key, PrivateMessage msg)
        {

            // Check if the dictionary already contains a key for the target's name
            if (!privateMessages.ContainsKey(key))
            {
                // If not, create a new list and add the new private message to it
                privateMessages[key] = new List<PrivateMessage> { msg };
            }
            else
            {
                // If the key exists, add the new private message to the existing list
                privateMessages[key].Add(msg);
            }

            if (openPrivateWindows.ContainsKey(key) && openPrivateWindows[key].Visible)
            {
                openPrivateWindows[key].UpdateMessageHistory(privateMessages[key]);
                openPrivateWindows[key].LoadMessageHistory();
            }
        }

        private void LoadPrivateFile(string key, PrivateFile metadata, byte[] fileData)
        {
            PrivateMessage fileMessage = new PrivateMessage
            {
                from = metadata.from,
                target = metadata.target,
                message = metadata.filename
            };
            LoadPrivateMessage(key, fileMessage);
            attachments[metadata.filename] = fileData;
            if (openPrivateWindows.ContainsKey(key))
            {
                openPrivateWindows[key].UpdateFileHistory(attachments);
            }
        }

        private void HandleDataReceived(object sender, string receivedData)
        {
            if (receivedData.ToLower().StartsWith("{\"message\""))
            {
                PublicMessage newMessage = JsonSerializer.Deserialize<PublicMessage>(receivedData);
                if (newMessage.name == clientInfo.name)
                    listBox1.Items.Add($"Me: {newMessage.message}");
                else
                    listBox1.Items.Add($"{newMessage.name}: {newMessage.message}");
            }
            if (receivedData.ToLower().StartsWith("{\"target\""))
            {
                PrivateMessage newPrivateMessage = JsonSerializer.Deserialize<PrivateMessage>(receivedData);

                // Check if the message is for the current user
                if (clientInfo.name == newPrivateMessage.target)
                {
                    LoadPrivateMessage(newPrivateMessage.from, newPrivateMessage);

                } else
                {
                    LoadPrivateMessage(newPrivateMessage.target, newPrivateMessage);
                }
            }
            if (receivedData.ToLower().StartsWith("{\"filename\""))
            {
                PrivateFile newFile = JsonSerializer.Deserialize<PrivateFile>(receivedData);
                int fileSize = newFile.filesize;
                byte[] fileBuffer = new byte[fileSize];
                int totalBytesRead = 0;
                while (totalBytesRead < fileSize)
                {
                    int byteRead = tcpClientManager.ns.Read(fileBuffer, totalBytesRead, fileSize - totalBytesRead);
                    if (byteRead == 0)
                    {
                        break;
                    }
                    totalBytesRead += byteRead;
                }
                if (totalBytesRead == fileSize)
                {
                    // Check if the message is for the current user
                    if (clientInfo.name == newFile.target)
                    {
                        LoadPrivateFile(newFile.from, newFile, fileBuffer);
                    }
                    else
                    {
                        LoadPrivateFile(newFile.target, newFile, fileBuffer);
                    }
                }
            }
            if (receivedData.ToLower().StartsWith("["))
            {
                // Deserialize the received data
                List<string> updatedParticipants = JsonSerializer.Deserialize<List<string>>(receivedData);

                // Find participants who have joined
                // var joinedParticipants = updatedParticipants.Except(participants).ToList();
                // foreach (string name in joinedParticipants)
                // {
                //    listBox1.Items.Add($"{name} joined the group.");
                // }

                // Find participants who have left
                var leftParticipants = participants.Except(updatedParticipants).ToList();
                foreach (string name in leftParticipants)
                {
                    listBox1.Items.Add($"{name} left the group.");
                }

                // Update the current list with the updated list
                participants = updatedParticipants;
                populateParticipantsView();
            }
        }

        private void populateParticipantsView()
        {
            listBox2.Items.Clear();
            foreach (string participant in participants)
            {
                listBox2.Items.Add(participant);
            }
        }

        private void HandleConnectionStatusChanged(object sender, string message)
        {
            Console.WriteLine(message);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            tcpClientManager?.Disconnect();
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

        private bool setClientInfo()
        {
            if (string.IsNullOrEmpty(nameInput.Text) || nameInput.Text.Length < 2 || int.TryParse(nameInput.Text, out _))
            {
                MessageBox.Show("Name not specified, is invalid, or is a number", "Error");
                return false;
            }
            clientInfo.name = nameInput.Text;
            clientInfo.admin = false;
            return true;
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(messageInput.Text))
            {
                MessageBox.Show("Can't send empty message", "Warning");
                return;
            }

            PublicMessage newMessage = new PublicMessage();
            newMessage.message = messageInput.Text;
            newMessage.name = clientInfo.name;
            string jsonData = encodeJsonData(newMessage);
            tcpClientManager.Send(jsonData);
            messageInput.Clear();
        }

        private void disconnectBtn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("You left the group.");
            tcpClientManager?.Disconnect();
            connectBtn.Enabled = true;
            disconnectBtn.Enabled = false;
        }
    }
}
