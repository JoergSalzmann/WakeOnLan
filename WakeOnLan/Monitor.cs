using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WakeOnLan
{
    public class Monitor
    {
        private Thread thread;
        private bool Listen = false;

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
            Start(Ports.WakeUp);
        }

        public void Start(int Port)
        {
            if (IsAlive) return;

            //Port prüfen
            if (!Check.CheckPortInUserPortRange(Port, out string Result))
            {
                OnExceptionRaised(Result);
                return;
            }

            //Thread initialisieren
            Listen = true;
            thread = new Thread(new ThreadStart(delegate { ListenThread(Port); }));
            
            //Thread starten
            thread.Start();
            OnListenChanged(true);
        }

        public void Stop()
        {
            Listen = false;
        }

        private void ListenThread(int Port)
        {
            UdpClient listener = null;
            IPEndPoint groupEP;

            try
            {
                //Listener initialisieren
                listener = new UdpClient(Port);
                groupEP = new IPEndPoint(IPAddress.Any, Port);

                while (Listen)
                {
                    //Keine neuen Daten
                    if (listener.Available == 0)
                    {
                        //alle 500ms wieder probieren
                        Thread.Sleep(500);
                        continue;
                    }

                    //Daten empfangen
                    byte[] bytes = listener.Receive(ref groupEP);

                    //Magic-Packet muss 102 Byte lang sein
                    if (bytes.Length != 102) continue;

                    //Die ersten 6 Byte müssen FF sein
                    for (int i = 0; i < 6; i++)
                        if (bytes[i] != 0xFF)
                            continue;

                    //Erfolg ausgeben
                    OnWakeUpReceived("Der Befehl zum Aufwachen wurde empfangen für die MAC-Adresse: " + BitConverter.ToString(bytes, 6, 6));
                }
            }
            catch (Exception ex) { OnExceptionRaised("Fehler beim Empfangen des Befehls zum Aufwachen:\n" + ex.Message); }
            finally
            {
                if (listener != null)
                {
                    //Listener beenden
                    try { listener.Close(); }
                    catch { }
                    listener.Dispose();
                }
             
                Listen = false;
                OnListenChanged(false);
            }
        }

        public event EventHandler<BoolEventArgs> ListenChanged;
        protected virtual void OnListenChanged(bool Active)
        {
            ListenChanged?.Invoke(this, new BoolEventArgs(Active));
        }

        public event EventHandler<StringEventArgs> ExceptionRaised;
        protected virtual void OnExceptionRaised(string Message)
        {
            ExceptionRaised?.Invoke(this, new StringEventArgs(Message));
        }

        public event EventHandler<StringEventArgs> WakeUpReceived;
        protected virtual void OnWakeUpReceived(string Message)
        {
            WakeUpReceived?.Invoke(this, new StringEventArgs(Message));
        }
    }
}
