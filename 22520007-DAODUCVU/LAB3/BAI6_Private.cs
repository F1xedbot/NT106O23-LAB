using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static LAB3.BAI6_Dashboard;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace LAB3
{
    public partial class BAI6_Private : Form
    {
        private string target;
        private string from;

        private List<PrivateMessage> messages;
        private BAI6_Client callForm;

        private Dictionary<string, byte[]> attachments = new Dictionary<string, byte[]>();
        private string newFilename;
        private string newFileExtension;

        public BAI6_Private(BAI6_Client parent, string targetName, List<PrivateMessage> previousMessages, Dictionary<string, byte[]> attachments)
        {
            InitializeComponent();
            Text = targetName;
            target = targetName;
            from = parent.clientInfo.name;
            callForm = parent;
            UpdateMessageHistory(previousMessages);
            UpdateFileHistory(attachments);
            LoadMessageHistory();
        }

        public void UpdateMessageHistory(List<PrivateMessage> newMessages)
        {
            messages = newMessages;
        }

        public void UpdateFileHistory(Dictionary<string, byte[]> newAttachments)
        {
            attachments = newAttachments;
        }

        public void LoadMessageHistory()
        {
            listBox1.Items.Clear();
            foreach (PrivateMessage m in messages)
            {
                // Check if the message is from the target user
                if (m.target != target)
                    listBox1.Items.Add($"{m.from}: {m.message}");
                else
                    listBox1.Items.Add($"Me: {m.message}");
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(newFilename))
            {
                // Check if the message input is empty
                if (string.IsNullOrEmpty(privateMessageInput.Text))
                {
                    MessageBox.Show("Can't send empty message", "Warning");
                    return;
                }

                // Create a new private message
                PrivateMessage newMessage = new PrivateMessage
                {
                    target = target,
                    from = from,
                    message = privateMessageInput.Text
                };

                privateMessageInput.Clear();
                // Send the private message
                callForm.sendPrivateMessage(newMessage);
            }
            else if (!string.IsNullOrEmpty(newFilename))
            {
                PrivateFile newPrivateFile = new PrivateFile
                {
                    target = target,
                    from = from,
                    filename = newFilename,
                    filesize = attachments[newFilename].Length,
                    extension = newFileExtension,
                };
                callForm.sendPrivateFile(newPrivateFile, attachments[newFilename]);
                newFilename = "";
                newFileExtension = "";
                attachmentLabel.Text = "Attached File: ";
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            // Update the private message dictionary in the parent form
            callForm.updatePrivateMessageDict(target, messages);
        }

        private void attachBtn_Click(object sender, EventArgs e)
        {
            // Open file dialog to choose image file
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Choose File",
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                string selectedFilePath = openFileDialog.FileName;
                string fileExtension = Path.GetExtension(selectedFilePath).ToLower();
                // Get the filename without the relative path
                newFilename = Path.GetFileName(selectedFilePath);
                newFileExtension = fileExtension;

                // Collection of valid extensions
                var validExtensions = new HashSet<string> { ".jpg", ".jpeg", ".png", ".gif", ".txt" };

                // Check if the file extension is valid
                if (validExtensions.Contains(fileExtension))
                {
                    // Read the file bytes
                    byte[] bytes = File.ReadAllBytes(selectedFilePath);
                    // Update the attachments dictionary
                    attachments[newFilename] = bytes;

                    // Update the label
                    attachmentLabel.Text = $"Attached File: {newFilename}";
                }
                else
                {
                    // Optionally, show a message if the file type is not supported
                    MessageBox.Show("Unsupported file type. Please select an image or text file.", "File Type Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IsImageExtension(string extension)
        {
            return extension == ".jpg" || extension == ".png" || extension == ".gif" || extension == ".jpeg";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
            {
                int index = listBox1.SelectedIndex;
                string key = messages[index].message;
                if (attachments.ContainsKey(key))
                {
                    string extension = Path.GetExtension(key);
                    bool isImage = IsImageExtension(extension);
                    BAI6_Dialog diaglog = new BAI6_Dialog(isImage, attachments[key]);
                    diaglog.ShowDialog();
                }
            }
        }
    }
}