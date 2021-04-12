using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WakeOnLan;
using WakeOnLanServer.Properties;

namespace WakeOnLanServer
{
    public class ServerController : INotifyPropertyChanged
    {
        private readonly Server server = new Server();
        private static readonly System.Windows.Forms.WindowsFormsSynchronizationContext sync = new System.Windows.Forms.WindowsFormsSynchronizationContext();

        public ServerController()
        {
            server.DebugMessage += (s, ea) => { if (LogDebugInformation) OnNewMessage(ea); };
            server.ExceptionRaised += (s, ea) => OnExceptionRaised(ea);
            server.ListenChanged += (s, ea) => sync.Post(OnPropertyChanged, nameof(ListeningActive));
            server.RequestFromClient += (s, ea) => OnNewMessage(ea);
            server.WakeUpSucces += (s, ea) => OnNewMessage(ea);
            //server.WakeUpSuccessMAC += (s, ea) => OnNewMessage(ea);
        }

        public bool UseOwnWakeUpPort
        {
            get { return Settings.Default.UseOwnWakeUpPort; }
            set { Settings.Default.UseOwnWakeUpPort = value; Settings.Default.Save(); }
        }

        public int OwnWakeUpPortNumber
        {
            get { return Settings.Default.OwnWakeUpPortNumber; }
            set { Settings.Default.OwnWakeUpPortNumber = value; Settings.Default.Save(); }
        }

        public bool CanChangeWakeUpPort
        {
            get { return UseOwnWakeUpPort && ListeningStopped; }
        }

        public bool UseOwnServerPort
        {
            get { return Settings.Default.UseOwnServerPort; }
            set { Settings.Default.UseOwnServerPort = value; Settings.Default.Save(); }
        }

        public int OwnServerPortNumber
        {
            get { return Settings.Default.OwnServerPortNumber; }
            set { Settings.Default.OwnServerPortNumber = value; Settings.Default.Save(); }
        }

        public bool CanChangeServerPort
        {
            get { return UseOwnServerPort && ListeningStopped; }
        }

        public bool LogDebugInformation
        {
            get { return Settings.Default.LogDebugInformation; }
            set { Settings.Default.LogDebugInformation = value; Settings.Default.Save(); }
        }

        public bool StartServerOnStartup
        {
            get { return Settings.Default.StartServerOnStartup; }
            set { Settings.Default.StartServerOnStartup = value; Settings.Default.Save(); }
        }

        public bool ListeningStopped
        {
            get { return !server.IsListening; }
        }

        public bool ListeningActive
        {
            get { return server.IsListening; }
        }

        public void StartListening()
        {
            if (UseOwnServerPort && UseOwnWakeUpPort)
                server.Start(OwnServerPortNumber, OwnWakeUpPortNumber);
            else if (UseOwnServerPort)
                server.Start(OwnServerPortNumber, null);
            else if (UseOwnWakeUpPort)
                server.Start(null, OwnWakeUpPortNumber);
            else server.Start();
        }

        public void StopListening()
        {
            server.Stop();
        }

        public event EventHandler<StringEventArgs> ExceptionRaised;
        protected virtual void OnExceptionRaised(StringEventArgs ea)
        {
            ExceptionRaised?.Invoke(this, ea);
        }

        public event EventHandler<StringEventArgs> NewMessage;
        protected virtual void OnNewMessage(StringEventArgs ea)
        {
            NewMessage?.Invoke(this, ea);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(object PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName.ToString()));
        }
    }
}
