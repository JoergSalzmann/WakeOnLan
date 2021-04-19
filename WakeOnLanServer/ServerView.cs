using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WakeOnLanServer.Properties;

namespace WakeOnLanServer
{
    public partial class ServerView : Form
    {
        private readonly ServerController controller = new ServerController();

        public ServerView()
        {
            InitializeComponent();

            //Version und Titel
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            Text = "WakeOnLanServer " + v.Major + "." + v.Minor + " RC 3";
            Icon = Resources.WOL;
        }

        private void ServerView_Load(object sender, EventArgs e)
        {
            //Port für Client
            rbOwnServerPort.DataBindings.Add(nameof(RadioButton.Checked), controller, nameof(ServerController.UseOwnServerPort), false, DataSourceUpdateMode.OnPropertyChanged);
            rbDefaultServerPort.DataBindings.Add(nameof(Enabled), controller, nameof(ServerController.ListeningStopped), false, DataSourceUpdateMode.OnPropertyChanged);
            rbOwnServerPort.DataBindings.Add(nameof(Enabled), controller, nameof(ServerController.ListeningStopped), false, DataSourceUpdateMode.OnPropertyChanged);
            nudServerPort.DataBindings.Add(nameof(Enabled), controller, nameof(ServerController.CanChangeServerPort), false, DataSourceUpdateMode.OnPropertyChanged);
            nudServerPort.DataBindings.Add(nameof(NumericUpDown.Value), controller, nameof(ServerController.OwnServerPortNumber), false, DataSourceUpdateMode.OnPropertyChanged);

            //Port für WakeUp
            rbOwnWakeUpPort.DataBindings.Add(nameof(RadioButton.Checked), controller, nameof(ServerController.UseOwnWakeUpPort), false, DataSourceUpdateMode.OnPropertyChanged);
            rbDefaultWakeUpPort.DataBindings.Add(nameof(Enabled), controller, nameof(ServerController.ListeningStopped), false, DataSourceUpdateMode.OnPropertyChanged);
            rbOwnWakeUpPort.DataBindings.Add(nameof(Enabled), controller, nameof(ServerController.ListeningStopped), false, DataSourceUpdateMode.OnPropertyChanged);
            nudWakeUpPort.DataBindings.Add(nameof(Enabled), controller, nameof(ServerController.CanChangeWakeUpPort), false, DataSourceUpdateMode.OnPropertyChanged);
            nudWakeUpPort.DataBindings.Add(nameof(NumericUpDown.Value), controller, nameof(ServerController.OwnWakeUpPortNumber), false, DataSourceUpdateMode.OnPropertyChanged);

            //Debug, Start, Stopp
            cbLogDebugInfo.DataBindings.Add(nameof(CheckBox.Checked), controller, nameof(ServerController.LogDebugInformation), false, DataSourceUpdateMode.OnPropertyChanged);
            btnStart.DataBindings.Add(nameof(Enabled), controller, nameof(ServerController.ListeningStopped), false, DataSourceUpdateMode.OnPropertyChanged);
            btnStop.DataBindings.Add(nameof(Enabled), controller, nameof(ServerController.ListeningActive), false, DataSourceUpdateMode.OnPropertyChanged);
            btnStart.Click += (s, ea) => controller.StartListening();
            btnStop.Click += (s, ea) => controller.StopListening();
            btnClearLog.Click += (s, ea) => lvLog.Items.Clear();

            //Events binden
            controller.ExceptionRaised += (s, ea) => { try { Invoke(new MethodInvoker(delegate { MessageBox.Show(ea.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning); })); } catch { } };
            controller.NewMessage += (s, ea) => { try { Invoke(new MethodInvoker(delegate { AddLogItem(ea.Message); })); } catch { } };

            //Auto-Start-Einstellung - Muss zum Schluss ausgeführt werden!
            cbAutoStart.DataBindings.Add(nameof(CheckBox.Checked), controller, nameof(ServerController.StartServerOnStartup), false, DataSourceUpdateMode.OnPropertyChanged);
            if (controller.StartServerOnStartup)
                controller.StartListening();
        }

        private void AddLogItem(string Message)
        {
            ListViewItem item = new ListViewItem(DateTime.Now.ToLongTimeString());
            item.SubItems.Add(Message);
            lvLog.Items.Add(item);
            item.EnsureVisible();
        }

        private void ServerView_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.StopListening();
        }
    }
}
