using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WakeOnLan
{
    internal class ClientHelper
    {
        private Socket socket = null;
        private readonly string Address;
        private readonly int port;

        public ClientHelper(string Address, int port)
        {
            this.Address = Address;
            this.port = port;
        }

        public async Task<int> SendAsync(object data)
        {
            if (socket == null) await ConnectAsync();
            if (data == null) return 0;

            byte[] bData = new SerializeData().Serialize(data);
            if (bData.Length <= 0) return 0;

            return socket.Send(bData);
        }

        public async Task<object> ReceiveAsync()
        {
            if (socket == null) await ConnectAsync();

            int cnt = 0;
            MemoryStream mem = new MemoryStream();
            byte[] buffer = new byte[ClientServerProperties.BufferSize];
            while (cnt < (ClientServerProperties.TimeOut / ClientServerProperties.SleepTimeClient))
            {
                while (socket.Available > 0)
                {
                    int bytesRead = socket.Receive(buffer, buffer.Length, SocketFlags.None);
                    if (bytesRead <= 0) continue;
                    mem.Write(buffer, 0, bytesRead);
                }
                Thread.Sleep(ClientServerProperties.SleepTimeClient);
                if (mem.Length > 0 && socket.Available == 0)
                {
                    return new SerializeData().Deserialize(mem.ToArray());
                }
                else
                {
                    cnt++;
                }
            }
            return null;
        }

        private async Task ConnectAsync()
        {
            try
            {
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(Address), port);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                await socket.ConnectAsync(ep);
            }
            catch (SecurityException ex)
            {
                throw new Exception("Fehler beim Aufbauen der Verbindung zum Server, prüfen Sie die Firewall- und Sicherheitseinstellungen", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Fehler beim Aufbauen der Verbindung zum Server", ex);
            }
        }

        public void Close()
        {
            if (socket == null) return;
            socket.Send(Encoding.ASCII.GetBytes("quit"));
            socket.Close();
            socket = null;
        }
    }
}
