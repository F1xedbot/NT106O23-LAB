using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace LAB3
{
    public partial class BAI1_Client : Form
    {
        public BAI1_Client()
        {
            InitializeComponent();
        }

        private class ConnectionParams
        {
            public string Host { get; set; }
            public string Port { get; set; }
        }

        private void SendUDPData(ConnectionParams parameters, string message)
        {
            UdpClient udpClient = new UdpClient();
            Byte[] sendBytes = Encoding.UTF8.GetBytes(message); // Use UTF-8 encoding
            udpClient.Send(sendBytes, sendBytes.Length, parameters.Host, Int32.Parse(parameters.Port));
        }

        private bool CheckConnectionParams()
        {
            return !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckConnectionParams())
            {
                ConnectionParams parameters = new ConnectionParams
                {
                    Host = textBox1.Text,
                    Port = textBox2.Text
                };

                string message = richTextBox1.Text;
                SendUDPData(parameters, message);
            }
            else
            {
                MessageBox.Show("Port or IP Remote host is not defined !", "Error");
            }
        }
    }
}
