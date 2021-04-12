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
using WakeOnLanMonitor.Properties;

namespace WakeOnLanMonitor
{
    public partial class MonitorView : Form
    {
        private readonly MonitorController controller = new MonitorController();

        public MonitorView()
        {
            InitializeComponent();

            //Version und Titel
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            Text = "WakeOnLanMonitor " + v.Major + "." + v.Minor;// + " beta";
            Icon = Resources.Monitor;
        }

        private void MonitorView_Load(object sender, EventArgs e)
        {
            //RadioButtons binden
            rbOwnPort.DataBindings.Add(nameof(RadioButton.Checked), controller, nameof(MonitorController.UseOwnPort), false, DataSourceUpdateMode.OnPropertyChanged);
            rbDefaultPort.DataBindings.Add(nameof(Enabled), controller, nameof(MonitorController.ListeningStopped), false, DataSourceUpdateMode.OnPropertyChanged);
            rbOwnPort.DataBindings.Add(nameof(Enabled), controller, nameof(MonitorController.ListeningStopped), false, DataSourceUpdateMode.OnPropertyChanged);

            //Einstellung Port
            nudPort.DataBindings.Add(nameof(Enabled), controller, nameof(MonitorController.CanChangeOwnPort), false, DataSourceUpdateMode.OnPropertyChanged);
            nudPort.DataBindings.Add(nameof(NumericUpDown.Value), controller, nameof(MonitorController.OwnPortNumber), false, DataSourceUpdateMode.OnPropertyChanged);

            //Buttons Start / Stopp
            btnStart.DataBindings.Add(nameof(Enabled), controller, nameof(MonitorController.ListeningStopped), false, DataSourceUpdateMode.OnPropertyChanged);
            btnStop.DataBindings.Add(nameof(Enabled), controller, nameof(MonitorController.ListeningActive), false, DataSourceUpdateMode.OnPropertyChanged);
            btnStart.Click += (s, ea) => controller.StartMonitor();
            btnStop.Click += (s, ea) => controller.StopMonitor();
            btnClearLog.Click += (s, ea) => lvLog.Items.Clear();

            //Events binden
            controller.ExceptionRaised += (s, ea) => { try { Invoke(new MethodInvoker(delegate { MessageBox.Show(ea.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning); })); } catch { } };
            controller.WakeUpReceived += (s, ea) => { try { Invoke(new MethodInvoker(delegate { AddLogItem(ea.Message); })); } catch { } };

            //Auto-Start-Einstellung - Muss zum Schluss ausgeführt werden!
            cbStartDirect.DataBindings.Add(nameof(CheckBox.Checked), controller, nameof(MonitorController.StartLogOnStartup), false, DataSourceUpdateMode.OnPropertyChanged);
            if (controller.StartLogOnStartup)
                controller.StartMonitor();
        }

        private void AddLogItem(string Message)
        {
            ListViewItem item = new ListViewItem(DateTime.Now.ToLongTimeString());
            item.SubItems.Add(Message);
            lvLog.Items.Add(item);
            item.EnsureVisible();
        }

        private void MonitorView_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.StopMonitor();
        }
    }
}
