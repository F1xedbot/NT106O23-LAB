using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static LAB3.BAI5_Dashboard;

namespace LAB3
{
    public partial class BAI5_Client : Form
    {
        public BAI5_Client()
        {
            InitializeComponent();
            listView1.View = View.Details;
        }

        private TcpClientManager tcpClientManager;
        private Dictionary<int, List<int>> dbIDRecords = new Dictionary<int, List<int>>();
        private Dictionary<string, List<string>> dbTextRecords = new Dictionary<string, List<string>>();

        private ClientInfo clientInfo = new ClientInfo();

        private string selectedImageFile = "";
        private TaskCompletionSource<bool> privilegeCheckCompletionSource;
        private RecordData record = new RecordData();

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BAI5_Client_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("Dish Name", 150); // Add a column for dish name
            listView1.Columns.Add("Contributor", 150); // Add a column for contributor
        }

        private void populateListView()
        {
            listView1.Items.Clear();
            foreach (string contrib in dbTextRecords.Keys)
            {
                foreach (string dishName in dbTextRecords[contrib])
                {
                    // Create a ListViewItem and add dish name and contributor name as sub-items
                    ListViewItem item = new ListViewItem(dishName);
                    item.SubItems.Add(contrib);

                    // Add the ListViewItem to the ListView
                    listView1.Items.Add(item);
                }
            }
        }

        private void HandleDataReceived(object sender, string receivedData)
        {
            if (receivedData.ToLower().StartsWith("{\"dishname\"")) {
                RecordData newRecord =  JsonSerializer.Deserialize<RecordData>(receivedData);
                int imageSize = newRecord.imageSize;
                byte[] imageBuffer = new byte[imageSize];
                int totalBytesRead = 0;
                while (totalBytesRead < imageSize)
                {
                    int byteRead = tcpClientManager.ns.Read(imageBuffer, totalBytesRead, imageSize - totalBytesRead);
                    if(byteRead == 0)
                    {
                        break;
                    }
                    totalBytesRead += byteRead;
                }
                if (totalBytesRead == imageSize)
                {
                    BAI5_Dialog bai5_dialog = new BAI5_Dialog(newRecord.dishName, newRecord.contribName, imageBuffer); ;
                    bai5_dialog.Show();
                }
 
            }

            // If the received message contains JSON data, deserialize it
            else if (receivedData.StartsWith("{"))
            {
                try
                {
                    dbTextRecords = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(receivedData);
                    populateListView();
                }
                catch (JsonException ex)
                {
                    MessageBox.Show("Error deserializing JSON data: " + ex.Message);
                }
            }

            if (receivedData.StartsWith("privilege"))
            {
                string[] parts = receivedData.Split(':');
                if (parts.Length >= 2)
                {
                    bool privilege;
                    if (bool.TryParse(parts[1], out privilege))
                    {
                        Console.WriteLine($"Privilege: {privilege}");
                        clientInfo.admin = privilege;

                        // Signal that the privilege check is complete
                        privilegeCheckCompletionSource?.TrySetResult(privilege);
                    }
                    else
                    {
                        Console.WriteLine("Invalid boolean value.");
                        // Optionally signal that the privilege check failed
                        privilegeCheckCompletionSource?.TrySetException(new InvalidOperationException("Invalid boolean value."));
                    }
                }

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

        private string encodeJsonData(string filter = "record")
        {
            // Create JsonSerializerOptions with UnsafeRelaxedJsonEscaping
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            };
            if (filter == "record")
                return JsonSerializer.Serialize(record, options);
            else return JsonSerializer.Serialize(clientInfo, options);
        }
        private bool setClientInfo()
        {
            if (string.IsNullOrEmpty(contribInput.Text) || contribInput.Text.Length < 2 || int.TryParse(contribInput.Text, out _))
            {
                MessageBox.Show("Name not specified, is invalid, or is a number", "Error");
                return false;
            }
            clientInfo.name = contribInput.Text;
            clientInfo.admin = false;
            return true;
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
                    string jsonData = encodeJsonData(filter: "database");
                    tcpClientManager.Send(jsonData);
                }
            }
        }

        private bool checkContributeData()
        {
            if (string.IsNullOrEmpty(dishInput.Text) || string.IsNullOrEmpty(selectedImageFile))
            {
                MessageBox.Show("Cannot add insufficient data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private async void addBtn_Click(object sender, EventArgs e)
        {
            // Create a new TaskCompletionSource to signal when the privilege check is complete
            privilegeCheckCompletionSource = new TaskCompletionSource<bool>();

            tcpClientManager?.Send("check");

            // Wait for the privilege check to complete
            try
            {
                bool privilege = await privilegeCheckCompletionSource.Task;
                if (!privilege)
                {
                    MessageBox.Show("Contributor is not an admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during privilege check: {ex.Message}", "Error");

                return;
            }

            if (!checkContributeData())
                return;

            record.contribName = contribInput.Text;
            record.dishName = dishInput.Text;
            byte[] imageData = File.ReadAllBytes(selectedImageFile);
            record.imageSize = imageData.Length;

            string jsonData = encodeJsonData(filter: "record");
            tcpClientManager.Send(jsonData); // Send the meatadata with the size first

            // Then send the image data
            tcpClientManager.SendBytes(imageData);
        }

        private void chooseImgBtn_Click(object sender, EventArgs e)
        {
            // Open file dialog to choose image file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose Image File";
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif)|*.jpg;*.jpeg;*.png;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                selectedImageFile = openFileDialog.FileName;

                // Get the filename without the relative path
                string fileName = Path.GetFileName(selectedImageFile);

                // Now you can use 'selectedImageFile' to access the full path,
                // and 'fileName' to access the filename without the path.

                chooseImgBtn.Text = fileName;
            }
        }

        private void pickBtn_Click(object sender, EventArgs e)
        {
            tcpClientManager.Send("random:local");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            tcpClientManager.Send("random:global");
        }
    }
}
