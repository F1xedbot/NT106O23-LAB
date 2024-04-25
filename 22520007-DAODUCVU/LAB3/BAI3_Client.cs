using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3
{
    public partial class BAI3_Client : Form
    {
        private TcpClientManager tcpClientManager;
        public BAI3_Client()
        {
            InitializeComponent();
            tcpClientManager = new TcpClientManager();
            tcpClientManager.ConnectionStatusChanged += HandleConnectionStatusChanged;
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            if (!tcpClientManager.IsConnected())
            {
                if (tcpClientManager.Connect("127.0.0.1", 8080))
                {
                    connectBtn.Enabled = false;
                    sendBtn.Enabled = true;
                    disconnectBtn.Enabled = true;
                }
            }
        }
        private void sendBtn_Click(object sender, EventArgs e)
        {
            if (!tcpClientManager.Send(richTextBox1.Text))
            {
                MessageBox.Show("Please enter a message to send.", "Error");
            }
        }

        private void disconnectBtn_Click(object sender, EventArgs e)
        {
            tcpClientManager.Disconnect();
            connectBtn.Enabled = true;
            sendBtn.Enabled = false;
            disconnectBtn.Enabled = false;
        }
        private void HandleConnectionStatusChanged(object sender, string message)
        {
            MessageBox.Show(message);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            tcpClientManager?.Disconnect();
        }
    }
}
