using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3
{
    public partial class BAI3_Server : Form
    {
        private TcpListener tcpListener;

        public BAI3_Server()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tcpListener == null)
                {
                    IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                    IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 8080);
                    tcpListener = new TcpListener(ipEndPoint);
                    tcpListener.Start();
                }

                MessageBox.Show("Server is now listening...");

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

        private async Task HandleClientAsync(TcpClient client)
        {
            try
            {
                listBox1.Items.Add("New Client Connected");

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
                    listBox1.Items.Add(message);

                    if (message.ToLower() == "quit")
                    {
                        break; // Stop listening to this client
                    }
                }

                client.Close();
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("An error occurred: " + ex.Message);
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
