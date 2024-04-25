using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3
{
    public class TcpClientManager
    {
        public TcpClient tcpClient;
        public NetworkStream ns;

        public event EventHandler<string> ConnectionStatusChanged;
        public event EventHandler<string> DataReceived;

        public bool Connect(string ipAddressString, int port)
        {
            try
            {
                tcpClient = new TcpClient();
                IPAddress ipAddress = IPAddress.Parse(ipAddressString);
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, port);
                tcpClient.Connect(ipEndPoint);

                if (tcpClient != null && tcpClient.Connected)
                {
                    ns = tcpClient.GetStream();
                    ConnectionStatusChanged?.Invoke(this, $"Connected to {ipEndPoint}");
                    // Start receiving data asynchronously
                    ReceiveDataAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                ConnectionStatusChanged?.Invoke(this, $"Error occurred while connecting: {ex.Message}");
                return false;
            }
        }

        public bool Send(string message)
        {
            try
            {
                if (ns != null && ns.CanWrite)
                {
                    string formattedMessage = message.Trim() + "\r\n";
                    byte[] data = Encoding.UTF8.GetBytes(formattedMessage);
                    ns.Write(data, 0, data.Length);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                ConnectionStatusChanged?.Invoke(this, $"Error occurred while sending message: {ex.Message}");
                return false;
            }
        }

        public bool SendBytes(byte[] data)
        {
            try
            {
                if (ns != null && ns.CanWrite) { 
                    ns.Write(data, 0, data.Length);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                ConnectionStatusChanged?.Invoke(this, $"Error occurred while sending message: {ex.Message}");
                return false;
            }
        }

        public void Disconnect()
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes("quit\r\n");
                ns.Write(data, 0, data.Length);
                ns.Close();
                tcpClient.Close();
                ConnectionStatusChanged?.Invoke(this, "Disconnected from the server");
            }
            catch (Exception ex)
            {
                ConnectionStatusChanged?.Invoke(this, $"Error occurred while disconnecting: {ex.Message}");
            }
        }

        public bool IsConnected()
        {
            return tcpClient != null && tcpClient.Connected;
        }

        private async void ReceiveDataAsync()
        {
            try
            {
                byte[] buffer = new byte[2048];
                while (true)
                {
                    int bytesRead = await ns.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        DataReceived?.Invoke(this, receivedData);
                    }
                    else
                    {
                        // If no data is read, it might indicate the connection has been closed by the server.
                        ConnectionStatusChanged?.Invoke(this, "Connection closed by the server");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ConnectionStatusChanged?.Invoke(this, $"Error occurred while receiving data: {ex.Message}");
            }
        }
    }
}
