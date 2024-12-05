using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WakeOnLanClient.Properties;

namespace WakeOnLanClient
{
    public partial class ClientView : Form
    {
        private readonly ClientController controller;

        public ClientView()
        {
            InitializeComponent();

            //Version und Titel
            Version v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            Text = "WakeOnLanClient " + v.Major + "." + v.Minor; // + " RC 3";
            Icon = Resources.Wecker;
            controller = new ClientController(Text);
        }

        private void ClientView_Load(object sender, EventArgs e)
        {
            //Lokales Aufwecken
            rbOwnWakeUpPort.DataBindings.Add(nameof(RadioButton.Checked), controller, nameof(ClientController.UseOwnWakeUpPort), false, DataSourceUpdateMode.OnPropertyChanged);
            nudWakeUpPort.DataBindings.Add(nameof(Enabled), controller, nameof(ClientController.UseOwnWakeUpPort), false, DataSourceUpdateMode.OnPropertyChanged);
            nudWakeUpPort.DataBindings.Add(nameof(NumericUpDown.Value), controller, nameof(ClientController.OwnWakeUpPortNumber), false, DataSourceUpdateMode.OnPropertyChanged);
            cbWakeUpLocalOnStartup.DataBindings.Add(nameof(CheckBox.Checked), controller, nameof(ClientController.WakeUpLocalOnStartup), false, DataSourceUpdateMode.OnPropertyChanged);

            //Aufwecken durch Server
            rbOwnServerPort.DataBindings.Add(nameof(RadioButton.Checked), controller, nameof(ClientController.UseOwnServerPort), false, DataSourceUpdateMode.OnPropertyChanged);
            nudServerPort.DataBindings.Add(nameof(Enabled), controller, nameof(ClientController.UseOwnServerPort), false, DataSourceUpdateMode.OnPropertyChanged);
            nudServerPort.DataBindings.Add(nameof(NumericUpDown.Value), controller, nameof(ClientController.OwnServerPortNumber), false, DataSourceUpdateMode.OnPropertyChanged);
            tbServerIpAddress.DataBindings.Add(nameof(Text), controller, nameof(ClientController.ServerIpAddress), false, DataSourceUpdateMode.OnPropertyChanged);
            cbWakeUpByServerOnStartup.DataBindings.Add(nameof(CheckBox.Checked), controller, nameof(ClientController.WakeUpByServerOnStartup), false, DataSourceUpdateMode.OnPropertyChanged);

            //MAC-Adresse und Buttons
            tbMacAddress.DataBindings.Add(nameof(Text), controller, nameof(ClientController.MacAddress), false, DataSourceUpdateMode.OnPropertyChanged);
            cbAutoCloseAfterWakeUp.DataBindings.Add(nameof(CheckBox.Checked), controller, nameof(ClientController.AutoCloseAfterWakeUp), false, DataSourceUpdateMode.OnPropertyChanged);
            btnWakeUpLocal.Click += (s, ea) => controller.WakeUpLocalAsync();
            btnWakeUpByServer.Click += (s, ea) => controller.WakeUpByServerAsync();
            btnClearLog.Click += (s, ea) => lvLog.Items.Clear();

            //Meldungen
            controller.NewMessage += (s, ea) => { try { Invoke(new MethodInvoker(delegate { AddLog(ea.Message); })); } catch { } };
            controller.CloseProgramm += (s, ea) => { try { Invoke(new MethodInvoker(delegate { CloseProgramm(); })); } catch { } };

            //Automatisches Aufwecken bei Programmstart
            controller.WakeUpOnStartup();
        }

        private void AddLog(string Message)
        {
            ListViewItem item = new ListViewItem(DateTime.Now.ToLongTimeString());
            item.SubItems.Add(Message);
            lvLog.Items.Add(item);
            item.EnsureVisible();
        }

        private void CloseProgramm()
        {
            if (MessageBox.Show("Die Anwendung wird nun beendet", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Close();
        }
    }
}
