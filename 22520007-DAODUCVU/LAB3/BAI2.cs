using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LAB3
{
    public partial class BAI2 : Form
    {
        public BAI2()
        {
            InitializeComponent();
        }

        private Socket listenerSocket;
        private Socket clientSocket;

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Server is now listening...");

            Thread serverThread = new Thread(new ThreadStart(StartSafeThread));
            serverThread.Start();
        }

        private void BAI2_Load(object sender, EventArgs e)
        {
            // Handle InvalidOperationException
            // CheckForIllegalCrossThreadCalls = false;
        }

        void StartSafeThread()
        {
            try
            {
                byte[] buffer = new byte[1024];
                int bytesReceived;
                listenerSocket = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp
                );

                IPEndPoint ipepServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
                listenerSocket.Bind(ipepServer);
                listenerSocket.Listen(-1);

                clientSocket = listenerSocket.Accept();

                // Invoke UI update to add item to ListBox
                Invoke((MethodInvoker)delegate
                {
                    listBox1.Items.Add("New Client Connected");
                });

                StringBuilder receivedText = new StringBuilder();

                while (clientSocket.Connected)
                {
                    bytesReceived = clientSocket.Receive(buffer);
                    receivedText.Append(Encoding.ASCII.GetString(buffer, 0, bytesReceived));

                    // Check if the received text contains a newline character
                    int newlineIndex;
                    while ((newlineIndex = receivedText.ToString().IndexOf('\n')) != -1)
                    {
                        string completeMessage = receivedText.ToString(0, newlineIndex);
                        // Invoke UI update to add item to ListBox
                        Invoke((MethodInvoker)delegate
                        {
                            listBox1.Items.Add(completeMessage);
                        });
                        receivedText.Remove(0, newlineIndex + 1);
                    }
                }
                clientSocket?.Close();
                listenerSocket?.Close();
            }
            catch (SocketException ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            try
            {
                clientSocket?.Close();
                listenerSocket?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while closing the connection: " + ex.Message, "Error");
            }
        }
    }
}
