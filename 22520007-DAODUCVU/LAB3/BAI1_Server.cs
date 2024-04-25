using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LAB3
{
    public partial class BAI1_Server : Form
    {
        public BAI1_Server()
        {
            InitializeComponent();
        }

        private class ConnectionParams
        {
            public string Host { get; set; }
            public string Port { get; set; }
        }

        private UdpClient udpListener;
        private ConnectionParams connectionParams;

        private void BAI1_Server_Load(object sender, EventArgs e)
        {
            // Handle InvalidOperationException
            // CheckForIllegalCrossThreadCalls = false;
            listView1.View = View.Details;
            listView1.Columns.Add("", -2);
        }

        private bool CheckConnectionParams()
        {
            return !string.IsNullOrEmpty(portText.Text) && !string.IsNullOrEmpty(ipText.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckConnectionParams())
            {
                connectionParams = new ConnectionParams
                {
                    Host = ipText.Text,
                    Port = portText.Text
                };

                MessageBox.Show($"UDP server started listening on port {connectionParams.Port}.");

                Thread thdUDPServer = new Thread(new ThreadStart(serverThread));
                thdUDPServer.Start();
            }
            else
            {
                MessageBox.Show("Port or IP Remote host is not defined !", "Error");
            }
        }

        private void serverThread()
        {
            udpListener = new UdpClient(int.Parse(connectionParams.Port));
            try
            {
                while (true)
                {
                    IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    byte[] receiveBytes = udpListener.Receive(ref remoteIpEndPoint);
                    string returnData = Encoding.UTF8.GetString(receiveBytes);
                    string ipAddress = remoteIpEndPoint.Address.ToString();
                    string message = ipAddress + ": " + returnData.ToString();

                    // Invoke the UI update operation to add an item to the ListView
                    Invoke((MethodInvoker)delegate
                    {
                        listView1.Items.Add(message);
                    });
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show("An error occurred while receiving UDP messages: " + ex.Message);
            }
            finally
            {
                udpListener.Close();
            }
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            udpListener?.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            udpListener?.Close();
            this.Close();
        }
    }
}
