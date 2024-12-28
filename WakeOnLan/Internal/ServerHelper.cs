using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WakeOnLan
{
    internal class ServerHelper
    {
        private readonly Socket socket = null;

        internal ServerHelper(Socket socket)
        {
            this.socket = socket;

            Thread th = new Thread(new ThreadStart(delegate
            {
                try
                {
                    // Empfangspuffer
                    MemoryStream mem = new MemoryStream();
                    byte[] buffer = new byte[ClientServerProperties.BufferSize];
                    int TimeOut = 0;
                    OnDeubgMessage(socket.RemoteEndPoint + " - waiting for data");

                    while (TimeOut < (ClientServerProperties.TimeOut / ClientServerProperties.SleepTimeServer))
                    {
                        mem.Seek(0, SeekOrigin.Begin);
                        mem.SetLength(0);
                        while (socket.Available > 0)
                        {
                            int bytesRead = socket.Receive(buffer, buffer.Length, SocketFlags.None);
                            if (bytesRead <= 0) continue;
                            mem.Write(buffer, 0, bytesRead);
                        }
                        if (mem.Length > 0)
                        {
                            if (mem.Length == 4)
                                if (Encoding.ASCII.GetString(mem.ToArray(), 0, 4) == "quit")
                                {
                                    break;
                                }
                            OnDeubgMessage(socket.RemoteEndPoint + " - new data received");
                            OnDataReceived(this, new SerializeData().DeserializeC(mem.ToArray()));
                            mem.Seek(0, SeekOrigin.Begin);
                            mem.SetLength(0);
                            TimeOut = 0;
                        }
                        else
                        {
                            TimeOut++;
                            Thread.Sleep(ClientServerProperties.SleepTimeServer);
                        }
                    }
                }
                catch (Exception ex) { OnExceptionRaised("Fehler bei der Kommunikation mit dem Client:\n" + ex.Message); }
                finally
                {
                    OnConnectionClosed();
                    socket.Close();
                    socket = null;
                }
            }));

            th.Start();
        }

        public void Send(ServerToClient Data)
        {
            socket.Send(new SerializeData().Serialize(Data));
            OnDeubgMessage(socket.RemoteEndPoint + " - answer was send");
        }

        internal event EventHandler<StringEventArgs> DeubgMessage;
        protected virtual void OnDeubgMessage(string Message)
        {
            DeubgMessage?.Invoke(this, new StringEventArgs(Message));
        }

        public event EventHandler<StringEventArgs> ExceptionRaised;
        protected virtual void OnExceptionRaised(string Message)
        {
            ExceptionRaised?.Invoke(this, new StringEventArgs(Message));
        }

        internal event EventHandler<ReceiveEventArgs> DataReceived;
        protected virtual void OnDataReceived(ServerHelper client, ClientToServer data)
        {
            DataReceived?.Invoke(this, new ReceiveEventArgs(client, data));
        }

        internal event EventHandler ConnectionClosed;
        protected virtual void OnConnectionClosed()
        {
            ConnectionClosed?.Invoke(this, EventArgs.Empty);
        }
    }

}
