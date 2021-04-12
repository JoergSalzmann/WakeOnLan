namespace WakeOnLanMonitor
{
    partial class MonitorView
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
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.cbStartDirect = new System.Windows.Forms.CheckBox();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.rbOwnPort = new System.Windows.Forms.RadioButton();
            this.rbDefaultPort = new System.Windows.Forms.RadioButton();
            this.lvLog = new System.Windows.Forms.ListView();
            this.colTimestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEvent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.btnClearLog);
            this.gbSettings.Controls.Add(this.btnStop);
            this.gbSettings.Controls.Add(this.btnStart);
            this.gbSettings.Controls.Add(this.cbStartDirect);
            this.gbSettings.Controls.Add(this.nudPort);
            this.gbSettings.Controls.Add(this.rbOwnPort);
            this.gbSettings.Controls.Add(this.rbDefaultPort);
            this.gbSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSettings.Location = new System.Drawing.Point(10, 10);
            this.gbSettings.Margin = new System.Windows.Forms.Padding(5);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Padding = new System.Windows.Forms.Padding(5);
            this.gbSettings.Size = new System.Drawing.Size(614, 148);
            this.gbSettings.TabIndex = 0;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Einstellungen";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(437, 100);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(149, 30);
            this.btnClearLog.TabIndex = 6;
            this.btnClearLog.Text = "Log löschen";
            this.btnClearLog.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(437, 61);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(149, 30);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Log stoppen";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(437, 27);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(149, 30);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Log starten";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // cbStartDirect
            // 
            this.cbStartDirect.AutoSize = true;
            this.cbStartDirect.Location = new System.Drawing.Point(8, 104);
            this.cbStartDirect.Name = "cbStartDirect";
            this.cbStartDirect.Size = new System.Drawing.Size(406, 24);
            this.cbStartDirect.TabIndex = 3;
            this.cbStartDirect.Text = "Bei Programmstart sofort Aufzeichnung starten";
            this.cbStartDirect.UseVisualStyleBackColor = true;
            // 
            // nudPort
            // 
            this.nudPort.Location = new System.Drawing.Point(251, 64);
            this.nudPort.Margin = new System.Windows.Forms.Padding(5);
            this.nudPort.Maximum = new decimal(new int[] {
            49151,
            0,
            0,
            0});
            this.nudPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(106, 26);
            this.nudPort.TabIndex = 2;
            this.nudPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudPort.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // rbOwnPort
            // 
            this.rbOwnPort.AutoSize = true;
            this.rbOwnPort.Location = new System.Drawing.Point(8, 64);
            this.rbOwnPort.Margin = new System.Windows.Forms.Padding(5);
            this.rbOwnPort.Name = "rbOwnPort";
            this.rbOwnPort.Size = new System.Drawing.Size(211, 24);
            this.rbOwnPort.TabIndex = 1;
            this.rbOwnPort.TabStop = true;
            this.rbOwnPort.Text = "Eigenen Port festlegen";
            this.rbOwnPort.UseVisualStyleBackColor = true;
            // 
            // rbDefaultPort
            // 
            this.rbDefaultPort.AutoSize = true;
            this.rbDefaultPort.Checked = true;
            this.rbDefaultPort.Location = new System.Drawing.Point(8, 30);
            this.rbDefaultPort.Margin = new System.Windows.Forms.Padding(5);
            this.rbDefaultPort.Name = "rbDefaultPort";
            this.rbDefaultPort.Size = new System.Drawing.Size(231, 24);
            this.rbDefaultPort.TabIndex = 0;
            this.rbDefaultPort.TabStop = true;
            this.rbDefaultPort.Text = "Standard-Port verwenden";
            this.rbDefaultPort.UseVisualStyleBackColor = true;
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
            this.lvLog.Location = new System.Drawing.Point(10, 158);
            this.lvLog.Name = "lvLog";
            this.lvLog.Size = new System.Drawing.Size(614, 193);
            this.lvLog.TabIndex = 1;
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
            this.colEvent.Width = 500;
            // 
            // MonitorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(634, 361);
            this.Controls.Add(this.lvLog);
            this.Controls.Add(this.gbSettings);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "MonitorView";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MonitorView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MonitorView_FormClosing);
            this.Load += new System.EventHandler(this.MonitorView_Load);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.RadioButton rbOwnPort;
        private System.Windows.Forms.RadioButton rbDefaultPort;
        private System.Windows.Forms.CheckBox cbStartDirect;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ColumnHeader colTimestamp;
        private System.Windows.Forms.ColumnHeader colEvent;
        private System.Windows.Forms.Button btnClearLog;
    }
}