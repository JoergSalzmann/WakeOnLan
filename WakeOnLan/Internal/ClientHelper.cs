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

        public ClientHelper(string Address, int port)
        {
            try
            {
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(Address), port);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ep);
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

        public int Send(ClientToServer data)
        {
            if (socket == null) return 0;
            if (data == null) return 0;

            byte[] bData = new SerializeData().Serialize(data);
            if (bData.Length <= 0) return 0;

            return socket.Send(bData);
        }

        public ServerToClient Receive()
        {
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
                    return new SerializeData().DeserializeS(mem.ToArray());
                }
                else
                {
                    cnt++;
                }
            }
            return null;
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
