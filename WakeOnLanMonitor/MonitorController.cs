using WakeOnLanMonitor.Properties;
using WakeOnLan;
using System.ComponentModel;
using System;

namespace WakeOnLanMonitor
{
    public class MonitorController : INotifyPropertyChanged
    {
        private readonly Monitor monitor = new Monitor();
        private static readonly System.Windows.Forms.WindowsFormsSynchronizationContext sync = new System.Windows.Forms.WindowsFormsSynchronizationContext();

        public MonitorController()
        {
            monitor.ExceptionRaised += (s, ea) => OnExceptionRaised(ea);
            monitor.ListenChanged += (s, ea) => sync.Post(OnPropertyChanged, nameof(ListeningActive));
            monitor.WakeUpReceived += (s, ea) => OnWakeUpReceived(ea);
        }

        public bool UseOwnPort
        {
            get { return Settings.Default.UseOwnPort; }
            set { Settings.Default.UseOwnPort = value; Settings.Default.Save(); }
        }

        public int OwnPortNumber
        {
            get { return Settings.Default.OwnPortNumber; }
            set { Settings.Default.OwnPortNumber = value; Settings.Default.Save(); }
        }

        public bool CanChangeOwnPort
        {
            get { return UseOwnPort && ListeningStopped; }
        }

        public bool StartLogOnStartup
        {
            get { return Settings.Default.StartLogOnStartup; }
            set { Settings.Default.StartLogOnStartup = value; Settings.Default.Save(); }
        }

        public bool ListeningStopped
        {
            get { return !monitor.IsListening; }
        }

        public bool ListeningActive
        {
            get { return monitor.IsListening; }
        }

        public void StartMonitor()
        {
            if (UseOwnPort)
                monitor.Start(OwnPortNumber);
            else monitor.Start();
        }

        public void StopMonitor()
        {
            monitor.Stop();
        }

        public event EventHandler<StringEventArgs> ExceptionRaised;
        protected virtual void OnExceptionRaised(StringEventArgs ea)
        {
            ExceptionRaised?.Invoke(this, ea);
        }

        public event EventHandler<StringEventArgs> WakeUpReceived;
        protected virtual void OnWakeUpReceived(StringEventArgs ea)
        {
            WakeUpReceived?.Invoke(this, ea);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(object PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName.ToString()));
        }
    }
}
