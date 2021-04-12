namespace WakeOnLanServer
{
    partial class ServerView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudServerPort = new System.Windows.Forms.NumericUpDown();
            this.rbOwnServerPort = new System.Windows.Forms.RadioButton();
            this.rbDefaultServerPort = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.cbLogDebugInfo = new System.Windows.Forms.CheckBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.cbAutoStart = new System.Windows.Forms.CheckBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lvLog = new System.Windows.Forms.ListView();
            this.colTimestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEvent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWakeUpPort)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudServerPort)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLocal
            // 
            this.gbLocal.Controls.Add(this.nudWakeUpPort);
            this.gbLocal.Controls.Add(this.rbOwnWakeUpPort);
            this.gbLocal.Controls.Add(this.rbDefaultWakeUpPort);
            this.gbLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbLocal.Location = new System.Drawing.Point(382, 0);
            this.gbLocal.Name = "gbLocal";
            this.gbLocal.Size = new System.Drawing.Size(382, 111);
            this.gbLocal.TabIndex = 1;
            this.gbLocal.TabStop = false;
            this.gbLocal.Text = "Port zum Aufwecken";
            // 
            // nudWakeUpPort
            // 
            this.nudWakeUpPort.Location = new System.Drawing.Point(251, 64);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.gbLocal);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(764, 200);
            this.panel1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudServerPort);
            this.groupBox2.Controls.Add(this.rbOwnServerPort);
            this.groupBox2.Controls.Add(this.rbDefaultServerPort);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(382, 111);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Port für Client";
            // 
            // nudServerPort
            // 
            this.nudServerPort.Location = new System.Drawing.Point(251, 64);
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
            this.nudServerPort.TabIndex = 6;
            this.nudServerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudServerPort.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // rbOwnServerPort
            // 
            this.rbOwnServerPort.AutoSize = true;
            this.rbOwnServerPort.Location = new System.Drawing.Point(8, 64);
            this.rbOwnServerPort.Margin = new System.Windows.Forms.Padding(5);
            this.rbOwnServerPort.Name = "rbOwnServerPort";
            this.rbOwnServerPort.Size = new System.Drawing.Size(211, 24);
            this.rbOwnServerPort.TabIndex = 5;
            this.rbOwnServerPort.Text = "Eigenen Port festlegen";
            this.rbOwnServerPort.UseVisualStyleBackColor = true;
            // 
            // rbDefaultServerPort
            // 
            this.rbDefaultServerPort.AutoSize = true;
            this.rbDefaultServerPort.Checked = true;
            this.rbDefaultServerPort.Location = new System.Drawing.Point(8, 30);
            this.rbDefaultServerPort.Margin = new System.Windows.Forms.Padding(5);
            this.rbDefaultServerPort.Name = "rbDefaultServerPort";
            this.rbDefaultServerPort.Size = new System.Drawing.Size(231, 24);
            this.rbDefaultServerPort.TabIndex = 4;
            this.rbDefaultServerPort.TabStop = true;
            this.rbDefaultServerPort.Text = "Standard-Port verwenden";
            this.rbDefaultServerPort.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClearLog);
            this.groupBox1.Controls.Add(this.cbLogDebugInfo);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.cbAutoStart);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(764, 89);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(659, 20);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(80, 64);
            this.btnClearLog.TabIndex = 9;
            this.btnClearLog.Text = "Log löschen";
            this.btnClearLog.UseVisualStyleBackColor = true;
            // 
            // cbLogDebugInfo
            // 
            this.cbLogDebugInfo.AutoSize = true;
            this.cbLogDebugInfo.Location = new System.Drawing.Point(8, 58);
            this.cbLogDebugInfo.Name = "cbLogDebugInfo";
            this.cbLogDebugInfo.Size = new System.Drawing.Size(302, 24);
            this.cbLogDebugInfo.TabIndex = 1;
            this.cbLogDebugInfo.Text = "Debug-Informationen aufzeichnen";
            this.cbLogDebugInfo.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(535, 20);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 64);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "Server stoppen";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // cbAutoStart
            // 
            this.cbAutoStart.AutoSize = true;
            this.cbAutoStart.Location = new System.Drawing.Point(8, 24);
            this.cbAutoStart.Name = "cbAutoStart";
            this.cbAutoStart.Size = new System.Drawing.Size(348, 24);
            this.cbAutoStart.TabIndex = 0;
            this.cbAutoStart.Text = "Bei Programmstart sofort Server starten";
            this.cbAutoStart.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(429, 20);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 64);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Server starten";
            this.btnStart.UseVisualStyleBackColor = true;
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
            this.lvLog.Location = new System.Drawing.Point(10, 210);
            this.lvLog.Name = "lvLog";
            this.lvLog.Size = new System.Drawing.Size(764, 241);
            this.lvLog.TabIndex = 5;
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
            // ServerView
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
            this.Name = "ServerView";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ServerView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerView_FormClosing);
            this.Load += new System.EventHandler(this.ServerView_Load);
            this.gbLocal.ResumeLayout(false);
            this.gbLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWakeUpPort)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudServerPort)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLocal;
        private System.Windows.Forms.NumericUpDown nudWakeUpPort;
        private System.Windows.Forms.RadioButton rbOwnWakeUpPort;
        private System.Windows.Forms.RadioButton rbDefaultWakeUpPort;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudServerPort;
        private System.Windows.Forms.RadioButton rbOwnServerPort;
        private System.Windows.Forms.RadioButton rbDefaultServerPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbLogDebugInfo;
        private System.Windows.Forms.CheckBox cbAutoStart;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.ColumnHeader colTimestamp;
        private System.Windows.Forms.ColumnHeader colEvent;
    }
}