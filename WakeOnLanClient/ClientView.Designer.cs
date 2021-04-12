namespace WakeOnLanClient
{
    partial class ClientView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbLocal = new System.Windows.Forms.GroupBox();
            this.nudWakeUpPort = new System.Windows.Forms.NumericUpDown();
            this.rbOwnWakeUpPort = new System.Windows.Forms.RadioButton();
            this.rbDefaultWakeUpPort = new System.Windows.Forms.RadioButton();
            this.gbServer = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbServerIpAddress = new System.Windows.Forms.TextBox();
            this.nudServerPort = new System.Windows.Forms.NumericUpDown();
            this.rbDefaultServerPort = new System.Windows.Forms.RadioButton();
            this.rbOwnServerPort = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbMac = new System.Windows.Forms.GroupBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnWakeUpByServer = new System.Windows.Forms.Button();
            this.btnWakeUpLocal = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMacAddress = new System.Windows.Forms.TextBox();
            this.lvLog = new System.Windows.Forms.ListView();
            this.colTimestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEvent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbWakeUpByServerOnStartup = new System.Windows.Forms.CheckBox();
            this.cbWakeUpLocalOnStartup = new System.Windows.Forms.CheckBox();
            this.cbAutoCloseAfterWakeUp = new System.Windows.Forms.CheckBox();
            this.gbLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWakeUpPort)).BeginInit();
            this.gbServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudServerPort)).BeginInit();
            this.panel1.SuspendLayout();
            this.gbMac.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLocal
            // 
            this.gbLocal.Controls.Add(this.cbWakeUpLocalOnStartup);
            this.gbLocal.Controls.Add(this.nudWakeUpPort);
            this.gbLocal.Controls.Add(this.rbOwnWakeUpPort);
            this.gbLocal.Controls.Add(this.rbDefaultWakeUpPort);
            this.gbLocal.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbLocal.Location = new System.Drawing.Point(0, 0);
            this.gbLocal.Name = "gbLocal";
            this.gbLocal.Size = new System.Drawing.Size(382, 164);
            this.gbLocal.TabIndex = 0;
            this.gbLocal.TabStop = false;
            this.gbLocal.Text = "Lokales Aufwecken";
            // 
            // nudWakeUpPort
            // 
            this.nudWakeUpPort.Location = new System.Drawing.Point(260, 64);
            this.nudWakeUpPort.Margin = new System.Windows.Forms.Padding(5);
            this.nudWakeUpPort.Maximum = new decimal(new int[] {
            49151,
            0,
            0,
            0});
            this.nudWakeUpPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudWakeUpPort.Name = "nudWakeUpPort";
            this.nudWakeUpPort.Size = new System.Drawing.Size(106, 26);
            this.nudWakeUpPort.TabIndex = 6;
            this.nudWakeUpPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudWakeUpPort.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // rbOwnWakeUpPort
            // 
            this.rbOwnWakeUpPort.AutoSize = true;
            this.rbOwnWakeUpPort.Location = new System.Drawing.Point(8, 64);
            this.rbOwnWakeUpPort.Margin = new System.Windows.Forms.Padding(5);
            this.rbOwnWakeUpPort.Name = "rbOwnWakeUpPort";
            this.rbOwnWakeUpPort.Size = new System.Drawing.Size(211, 24);
            this.rbOwnWakeUpPort.TabIndex = 5;
            this.rbOwnWakeUpPort.Text = "Eigenen Port festlegen";
            this.rbOwnWakeUpPort.UseVisualStyleBackColor = true;
            // 
            // rbDefaultWakeUpPort
            // 
            this.rbDefaultWakeUpPort.AutoSize = true;
            this.rbDefaultWakeUpPort.Checked = true;
            this.rbDefaultWakeUpPort.Location = new System.Drawing.Point(8, 30);
            this.rbDefaultWakeUpPort.Margin = new System.Windows.Forms.Padding(5);
            this.rbDefaultWakeUpPort.Name = "rbDefaultWakeUpPort";
            this.rbDefaultWakeUpPort.Size = new System.Drawing.Size(231, 24);
            this.rbDefaultWakeUpPort.TabIndex = 4;
            this.rbDefaultWakeUpPort.TabStop = true;
            this.rbDefaultWakeUpPort.Text = "Standard-Port verwenden";
            this.rbDefaultWakeUpPort.UseVisualStyleBackColor = true;
            // 
            // gbServer
            // 
            this.gbServer.Controls.Add(this.cbWakeUpByServerOnStartup);
            this.gbServer.Controls.Add(this.label1);
            this.gbServer.Controls.Add(this.tbServerIpAddress);
            this.gbServer.Controls.Add(this.nudServerPort);
            this.gbServer.Controls.Add(this.rbDefaultServerPort);
            this.gbServer.Controls.Add(this.rbOwnServerPort);
            this.gbServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbServer.Location = new System.Drawing.Point(382, 0);
            this.gbServer.Name = "gbServer";
            this.gbServer.Size = new System.Drawing.Size(382, 164);
            this.gbServer.TabIndex = 1;
            this.gbServer.TabStop = false;
            this.gbServer.Text = "Aufwecken durch Server";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Server-IP-Adresse:";
            // 
            // tbServerIpAddress
            // 
            this.tbServerIpAddress.Location = new System.Drawing.Point(180, 98);
            this.tbServerIpAddress.Name = "tbServerIpAddress";
            this.tbServerIpAddress.Size = new System.Drawing.Size(188, 26);
            this.tbServerIpAddress.TabIndex = 10;
            // 
            // nudServerPort
            // 
            this.nudServerPort.Location = new System.Drawing.Point(260, 64);
            this.nudServerPort.Margin = new System.Windows.Forms.Padding(5);
            this.nudServerPort.Maximum = new decimal(new int[] {
            49151,
            0,
            0,
            0});
            this.nudServerPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudServerPort.Name = "nudServerPort";
            this.nudServerPort.Size = new System.Drawing.Size(106, 26);
            this.nudServerPort.TabIndex = 9;
            this.nudServerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudServerPort.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // rbDefaultServerPort
            // 
            this.rbDefaultServerPort.AutoSize = true;
            this.rbDefaultServerPort.Checked = true;
            this.rbDefaultServerPort.Location = new System.Drawing.Point(8, 30);
            this.rbDefaultServerPort.Margin = new System.Windows.Forms.Padding(5);
            this.rbDefaultServerPort.Name = "rbDefaultServerPort";
            this.rbDefaultServerPort.Size = new System.Drawing.Size(231, 24);
            this.rbDefaultServerPort.TabIndex = 7;
            this.rbDefaultServerPort.TabStop = true;
            this.rbDefaultServerPort.Text = "Standard-Port verwenden";
            this.rbDefaultServerPort.UseVisualStyleBackColor = true;
            // 
            // rbOwnServerPort
            // 
            this.rbOwnServerPort.AutoSize = true;
            this.rbOwnServerPort.Location = new System.Drawing.Point(8, 64);
            this.rbOwnServerPort.Margin = new System.Windows.Forms.Padding(5);
            this.rbOwnServerPort.Name = "rbOwnServerPort";
            this.rbOwnServerPort.Size = new System.Drawing.Size(211, 24);
            this.rbOwnServerPort.TabIndex = 8;
            this.rbOwnServerPort.Text = "Eigenen Port festlegen";
            this.rbOwnServerPort.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbServer);
            this.panel1.Controls.Add(this.gbLocal);
            this.panel1.Controls.Add(this.gbMac);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(764, 255);
            this.panel1.TabIndex = 3;
            // 
            // gbMac
            // 
            this.gbMac.Controls.Add(this.cbAutoCloseAfterWakeUp);
            this.gbMac.Controls.Add(this.btnClearLog);
            this.gbMac.Controls.Add(this.btnWakeUpByServer);
            this.gbMac.Controls.Add(this.btnWakeUpLocal);
            this.gbMac.Controls.Add(this.label2);
            this.gbMac.Controls.Add(this.tbMacAddress);
            this.gbMac.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbMac.Location = new System.Drawing.Point(0, 164);
            this.gbMac.Name = "gbMac";
            this.gbMac.Size = new System.Drawing.Size(764, 91);
            this.gbMac.TabIndex = 4;
            this.gbMac.TabStop = false;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(658, 20);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(92, 60);
            this.btnClearLog.TabIndex = 16;
            this.btnClearLog.Text = "Log löschen";
            this.btnClearLog.UseVisualStyleBackColor = true;
            // 
            // btnWakeUpByServer
            // 
            this.btnWakeUpByServer.Location = new System.Drawing.Point(522, 20);
            this.btnWakeUpByServer.Name = "btnWakeUpByServer";
            this.btnWakeUpByServer.Size = new System.Drawing.Size(130, 60);
            this.btnWakeUpByServer.TabIndex = 15;
            this.btnWakeUpByServer.Text = "Aufwecken durch Server";
            this.btnWakeUpByServer.UseVisualStyleBackColor = true;
            // 
            // btnWakeUpLocal
            // 
            this.btnWakeUpLocal.Location = new System.Drawing.Point(386, 20);
            this.btnWakeUpLocal.Name = "btnWakeUpLocal";
            this.btnWakeUpLocal.Size = new System.Drawing.Size(130, 60);
            this.btnWakeUpLocal.TabIndex = 14;
            this.btnWakeUpLocal.Text = "Lokal aufwecken";
            this.btnWakeUpLocal.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "MAC-Adresse:";
            // 
            // tbMacAddress
            // 
            this.tbMacAddress.Location = new System.Drawing.Point(154, 20);
            this.tbMacAddress.Name = "tbMacAddress";
            this.tbMacAddress.Size = new System.Drawing.Size(212, 26);
            this.tbMacAddress.TabIndex = 12;
            // 
            // lvLog
            // 
            this.lvLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTimestamp,
            this.colEvent});
            this.lvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvLog.FullRowSelect = true;
            this.lvLog.GridLines = true;
            this.lvLog.HideSelection = false;
            this.lvLog.Location = new System.Drawing.Point(10, 265);
            this.lvLog.Name = "lvLog";
            this.lvLog.Size = new System.Drawing.Size(764, 186);
            this.lvLog.TabIndex = 4;
            this.lvLog.UseCompatibleStateImageBehavior = false;
            this.lvLog.View = System.Windows.Forms.View.Details;
            // 
            // colTimestamp
            // 
            this.colTimestamp.Text = "Uhrzeit";
            this.colTimestamp.Width = 70;
            // 
            // colEvent
            // 
            this.colEvent.Text = "Ereigniss";
            this.colEvent.Width = 650;
            // 
            // cbWakeUpByServerOnStartup
            // 
            this.cbWakeUpByServerOnStartup.AutoSize = true;
            this.cbWakeUpByServerOnStartup.Location = new System.Drawing.Point(8, 130);
            this.cbWakeUpByServerOnStartup.Name = "cbWakeUpByServerOnStartup";
            this.cbWakeUpByServerOnStartup.Size = new System.Drawing.Size(320, 24);
            this.cbWakeUpByServerOnStartup.TabIndex = 12;
            this.cbWakeUpByServerOnStartup.Text = "Bei Programmstart sofort aufwecken";
            this.cbWakeUpByServerOnStartup.UseVisualStyleBackColor = true;
            // 
            // cbWakeUpLocalOnStartup
            // 
            this.cbWakeUpLocalOnStartup.AutoSize = true;
            this.cbWakeUpLocalOnStartup.Location = new System.Drawing.Point(8, 130);
            this.cbWakeUpLocalOnStartup.Name = "cbWakeUpLocalOnStartup";
            this.cbWakeUpLocalOnStartup.Size = new System.Drawing.Size(320, 24);
            this.cbWakeUpLocalOnStartup.TabIndex = 13;
            this.cbWakeUpLocalOnStartup.Text = "Bei Programmstart sofort aufwecken";
            this.cbWakeUpLocalOnStartup.UseVisualStyleBackColor = true;
            // 
            // cbAutoCloseAfterWakeUp
            // 
            this.cbAutoCloseAfterWakeUp.AutoSize = true;
            this.cbAutoCloseAfterWakeUp.Location = new System.Drawing.Point(8, 56);
            this.cbAutoCloseAfterWakeUp.Name = "cbAutoCloseAfterWakeUp";
            this.cbAutoCloseAfterWakeUp.Size = new System.Drawing.Size(323, 24);
            this.cbAutoCloseAfterWakeUp.TabIndex = 17;
            this.cbAutoCloseAfterWakeUp.Text = "Nach Aufwecken Programm beenden";
            this.cbAutoCloseAfterWakeUp.UseVisualStyleBackColor = true;
            // 
            // ClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.lvLog);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "ClientView";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClientView";
            this.Load += new System.EventHandler(this.ClientView_Load);
            this.gbLocal.ResumeLayout(false);
            this.gbLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWakeUpPort)).EndInit();
            this.gbServer.ResumeLayout(false);
            this.gbServer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudServerPort)).EndInit();
            this.panel1.ResumeLayout(false);
            this.gbMac.ResumeLayout(false);
            this.gbMac.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLocal;
        private System.Windows.Forms.GroupBox gbServer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown nudWakeUpPort;
        private System.Windows.Forms.RadioButton rbOwnWakeUpPort;
        private System.Windows.Forms.RadioButton rbDefaultWakeUpPort;
        private System.Windows.Forms.TextBox tbServerIpAddress;
        private System.Windows.Forms.NumericUpDown nudServerPort;
        private System.Windows.Forms.RadioButton rbDefaultServerPort;
        private System.Windows.Forms.RadioButton rbOwnServerPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbMac;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMacAddress;
        private System.Windows.Forms.Button btnWakeUpByServer;
        private System.Windows.Forms.Button btnWakeUpLocal;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.ColumnHeader colTimestamp;
        private System.Windows.Forms.ColumnHeader colEvent;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.CheckBox cbWakeUpLocalOnStartup;
        private System.Windows.Forms.CheckBox cbWakeUpByServerOnStartup;
        private System.Windows.Forms.CheckBox cbAutoCloseAfterWakeUp;
    }
}