using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WakeOnLan
{
    public class Server
    {
        private readonly ConcurrentDictionary<int, ServerHelper> Clients = new ConcurrentDictionary<int, ServerHelper>();
        private Thread thread;
        private bool Listen = false;
        private int connectionID = 0;

        internal bool IsAlive
        {
            get { return thread != null && thread.IsAlive; }
        }

        public bool IsListening
        {
            get { return IsAlive && Listen; }
        }

        public void Start()
        {
            Start(null, null);
        }

        public void Start(int? ServerPort, int? WakeUpPort)
        {
            if (!ServerPort.HasValue)
                ServerPort = Ports.Server;

            if (!WakeUpPort.HasValue)
                WakeUpPort = Ports.WakeUp;

            Start(ServerPort.Value, WakeUpPort.Value);
        }

        private void Start(int ServerPort, int WakeUpPort)
        {
            if (IsAlive) return;

            //Port prüfen
            if (!Check.CheckPortInUserPortRange(ServerPort, out string Result))
            {
                OnExceptionRaised(Result);
                return;
            }

            if (!Check.CheckPortInUserPortRange(WakeUpPort, out Result))
            {
                OnExceptionRaised(Result);
                return;
            }

            //Thread inisitlisieren
            Listen = true;
            thread = new Thread(new ThreadStart(delegate { ListenThread(ServerPort, WakeUpPort); }));

            //Thread starten
            thread.Start();
            OnListenChanged(true);
        }

        public void Stop()
        {
            Listen = false;
        }

        private void ListenThread(int ServerPort, int WakeUpPort)
        {
            TcpListener listener = null;

            try
            {
                //Listener initialisieren
                listener = new TcpListener(IPAddress.Any, ServerPort);
                listener.Start();
                OnDebugMessage("Server started, listening on port: " + ServerPort);

                while (Listen)
                {
                    //Solange Clients akzeptieren, bis das angegebene Maximum erreicht ist
                    if (Clients.Count < ClientServerProperties.MaxClients)
                    {
                        if (listener.Pending())
                            NewClient(listener, WakeUpPort);
                        else Thread.Sleep(ClientServerProperties.SleepTimeServer);
                    }
                    else Thread.Sleep(1000);
                }
            }
            catch (Exception ex) { OnExceptionRaised("Fehler im Server:\n" + ex.Message); }
            finally
            {
                //Listener beenden
                if (listener != null)
                    try { listener.Stop(); }
                    catch { }

                Listen = false;
                OnListenChanged(false);
                OnDebugMessage("Server stopped");
            }
        }

        private void NewClient(TcpListener listener, int WakeUpPort)
        {
            //Zeitmessung starten
            Stopwatch sw = new Stopwatch();
            sw.Start();

            //Socket akzeptieren
            Socket newSocket = listener.AcceptSocket();
            if (newSocket == null) return;

            //Connection-ID
            int id = connectionID++;
            
            // Instanz der serverseitigen Verwaltungsklasse erzeugen
            ServerHelper newConnection = new ServerHelper(newSocket);
            newConnection.DeubgMessage += (s, ea) => OnDebugMessage(ea.Message);
            newConnection.DataReceived += (s, ea) => NewDataFromClient(WakeUpPort, ea, newSocket);
            newConnection.ExceptionRaised += (s, ea) => OnExceptionRaised(ea.Message);
            newConnection.ConnectionClosed += (s, ea) =>
            {
                //Client entfernen
                Clients.TryRemove(id, out _);
                OnDebugMessage(newSocket.RemoteEndPoint + " - connection closed (Clients: " + Clients.Count + ")");

                //Zeitmessung stoppen und ausgeben
                sw.Stop();
                OnDebugMessage(newSocket.RemoteEndPoint + " - time connected: " + sw.ElapsedMilliseconds.ToString() + " ms");
            };

            //Client hinzufügen
            Clients.TryAdd(id, newConnection);
            OnDebugMessage(newSocket.RemoteEndPoint + " - connected (Clients: " + Clients.Count + ")");
        }

        private void NewDataFromClient(int WakeUpPort, ReceiveEventArgs ea, Socket socket)
        {
            try
            {
                //Daten vom Client auswerten
                ClientToServer receive = ea.Data;
                OnRequestFromClient("Anfrage von: " + socket.RemoteEndPoint.ToString() + GetClientInformationString(receive));

                //PC aufwecken
                ServerToClient answer = new ServerToClient();
                answer.WakeUpSuccess = WakeUp.SendMagicPacket(receive.MacAddress, WakeUpPort, out answer.Result);
                ea.Client.Send(answer);

                //Erfolg melden
                if (answer.WakeUpSuccess)
                    OnWakeUpSuccess(answer.Result, BitConverter.ToString(receive.MacAddress));
            }
            catch (Exception ex) { OnExceptionRaised("Fehler bei der Kommunikation mit dem Client:\n" + ex.Message); }
        }

        private string GetClientInformationString(ClientToServer receive)
        {
            string ret = string.Empty;

            //Client-Informationen hinzufügen, sofern angegeben
            if (!string.IsNullOrWhiteSpace(receive.UserDomainName))
                ret += " - " + receive.UserDomainName;
            if (!string.IsNullOrWhiteSpace(receive.UserName))
                ret += " - " + receive.UserName;
            if (!string.IsNullOrWhiteSpace(receive.ClientProgramName))
                ret += " - " + receive.ClientProgramName;

            //MAC-Adresse anhängen und alles zurück geben
            ret += " - " + BitConverter.ToString(receive.MacAddress);
            return ret;
        }

        public event EventHandler<BoolEventArgs> ListenChanged;
        protected virtual void OnListenChanged(bool Active)
        {
            ListenChanged?.Invoke(this, new BoolEventArgs(Active));
        }

        public event EventHandler<StringEventArgs> DebugMessage;
        protected virtual void OnDebugMessage(string Message)
        {
            DebugMessage?.Invoke(this, new StringEventArgs(Message));
        }

        public event EventHandler<StringEventArgs> ExceptionRaised;
        protected virtual void OnExceptionRaised(string Message)
        {
            ExceptionRaised?.Invoke(this, new StringEventArgs(Message));
        }

        public event EventHandler<StringEventArgs> RequestFromClient;
        protected virtual void OnRequestFromClient(string Message)
        {
            RequestFromClient?.Invoke(this, new StringEventArgs(Message));
        }

        public event EventHandler<StringEventArgs> WakeUpSucces;
        public event EventHandler<StringEventArgs> WakeUpSuccessMAC;
        protected virtual void OnWakeUpSuccess(string Message, string MacAddress)
        {
            WakeUpSucces?.Invoke(this, new StringEventArgs(Message));
            WakeUpSuccessMAC?.Invoke(this, new StringEventArgs(MacAddress));
        }
    }
}
