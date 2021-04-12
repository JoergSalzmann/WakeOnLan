using System;
using System.Threading;
using WakeOnLan;
using WakeOnLanClient.Properties;

namespace WakeOnLanClient
{
    public class ClientController
    {
        private readonly Client client = new Client();
        private readonly string ProgrammName;

        public ClientController(string ProgrammName)
        {
            this.ProgrammName = ProgrammName;
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

        public string ServerIpAddress
        {
            get { return Settings.Default.ServerIpAddress; }
            set { Settings.Default.ServerIpAddress = value; Settings.Default.Save(); }
        }

        public string MacAddress
        {
            get { return Settings.Default.MacAddress; }
            set { Settings.Default.MacAddress = value; Settings.Default.Save(); }
        }

        public bool WakeUpLocalOnStartup
        {
            get { return Settings.Default.WakeUpLocalOnStartup; }
            set
            {
                Settings.Default.WakeUpLocalOnStartup = value;
                if (value) WakeUpByServerOnStartup = false;
                Settings.Default.Save();
            }
        }

        public bool WakeUpByServerOnStartup
        {
            get { return Settings.Default.WakeUpByServerOnStartup; }
            set
            {
                Settings.Default.WakeUpByServerOnStartup = value;
                if (value) WakeUpLocalOnStartup = false;
                Settings.Default.Save();
            }
        }

        public bool AutoCloseAfterWakeUp
        {
            get { return Settings.Default.AutoCloseAfterWakeUp; }
            set { Settings.Default.AutoCloseAfterWakeUp = value; Settings.Default.Save(); }
        }

        public void WakeUpOnStartup()
        {
            if (WakeUpLocalOnStartup)
                WakeUpLocal();
            else if (WakeUpByServerOnStartup)
                WakeUpByServer();
        }

        public void WakeUpLocal()
        {
            Thread th = new Thread(new ThreadStart(delegate
            {
                bool Success = false;
                string Result;

                if (UseOwnWakeUpPort)
                    Success = client.WakeUpLocal(MacAddress, OwnWakeUpPortNumber, out Result);
                else Success = client.WakeUpLocal(MacAddress, out Result);

                OnNewMessage(Result);
                if (Success && AutoCloseAfterWakeUp)
                    OnCloseProgramm();
            }));
            th.Start();
        }

        public void WakeUpByServer()
        {
            Thread th = new Thread(new ThreadStart(delegate
            {
                bool Success = false;
                string Result;
                OnNewMessage("Verbindungsaufbau zum Server mit der IP-Adresse: " + ServerIpAddress);

                if (UseOwnServerPort)
                    Success = client.WakeUpByServer(ServerIpAddress, MacAddress, ProgrammName, OwnServerPortNumber, out Result);
                else Success = client.WakeUpByServer(ServerIpAddress, MacAddress, ProgrammName, out Result);

                OnNewMessage(Result);
                if (Success && AutoCloseAfterWakeUp)
                    OnCloseProgramm();
            }));
            th.Start();
        }

        public event EventHandler<StringEventArgs> NewMessage;
        protected virtual void OnNewMessage(string Message)
        {
            NewMessage?.Invoke(this, new StringEventArgs(Message));
        }

        public event EventHandler CloseProgramm;
        protected virtual void OnCloseProgramm()
        {
            CloseProgramm?.Invoke(this, EventArgs.Empty);
        }
    }
}
