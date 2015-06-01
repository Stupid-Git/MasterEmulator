namespace Proximity
{
    partial class ProximityDemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProximityDemo));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.cboUsbSerial = new System.Windows.Forms.ToolStripComboBox();
            this.btnOpenClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblConnected = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblConnectedSymbol = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnConnectDisconnect = new System.Windows.Forms.Button();
            this.btnDeviceDiscovery = new System.Windows.Forms.Button();
            this.grpRight = new System.Windows.Forms.GroupBox();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.grpBatteryLevel = new System.Windows.Forms.GroupBox();
            this.btnBatteryLevelRead = new System.Windows.Forms.Button();
            this.tbBatteryLevel = new System.Windows.Forms.TextBox();
            this.lblBatteryLevel = new System.Windows.Forms.Label();
            this.grpLinkLoss = new System.Windows.Forms.GroupBox();
            this.btnLinkLossSet = new System.Windows.Forms.Button();
            this.rbtLinkLossHigh = new System.Windows.Forms.RadioButton();
            this.rbtLinkLossLow = new System.Windows.Forms.RadioButton();
            this.rbtLinkLossOff = new System.Windows.Forms.RadioButton();
            this.lblLinkLoss = new System.Windows.Forms.Label();
            this.grpImmediateAlert = new System.Windows.Forms.GroupBox();
            this.rbtImmediateAlertHigh = new System.Windows.Forms.RadioButton();
            this.btnImmediateAlertSet = new System.Windows.Forms.Button();
            this.rbtImmediateAlertLow = new System.Windows.Forms.RadioButton();
            this.rbtImmediateAlertOff = new System.Windows.Forms.RadioButton();
            this.lblImmediateAlert = new System.Windows.Forms.Label();
            this.grpLog = new System.Windows.Forms.GroupBox();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.appTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.connectTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.dgvDeviceDiscovery = new System.Windows.Forms.DataGridView();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.grpRight.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.grpBatteryLevel.SuspendLayout();
            this.grpLinkLoss.SuspendLayout();
            this.grpImmediateAlert.SuspendLayout();
            this.grpLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.appTableLayoutPanel.SuspendLayout();
            this.connectTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceDiscovery)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cboUsbSerial,
            this.btnOpenClose,
            this.toolStripSeparator1});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(654, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // cboUsbSerial
            // 
            this.cboUsbSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsbSerial.Name = "cboUsbSerial";
            this.cboUsbSerial.Size = new System.Drawing.Size(92, 25);
            // 
            // btnOpenClose
            // 
            this.btnOpenClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOpenClose.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenClose.Image")));
            this.btnOpenClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenClose.Name = "btnOpenClose";
            this.btnOpenClose.Size = new System.Drawing.Size(40, 22);
            this.btnOpenClose.Text = "Open";
            this.btnOpenClose.Click += new System.EventHandler(this.OnBtnOpenClose);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblConnected,
            this.lblConnectedSymbol});
            this.statusStrip.Location = new System.Drawing.Point(0, 497);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(654, 24);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblConnected
            // 
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(68, 19);
            this.lblConnected.Text = "Connected:";
            // 
            // lblConnectedSymbol
            // 
            this.lblConnectedSymbol.BackColor = System.Drawing.Color.Transparent;
            this.lblConnectedSymbol.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblConnectedSymbol.Name = "lblConnectedSymbol";
            this.lblConnectedSymbol.Size = new System.Drawing.Size(17, 19);
            this.lblConnectedSymbol.Text = "  ";
            // 
            // btnConnectDisconnect
            // 
            this.btnConnectDisconnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConnectDisconnect.Location = new System.Drawing.Point(0, 272);
            this.btnConnectDisconnect.Name = "btnConnectDisconnect";
            this.btnConnectDisconnect.Size = new System.Drawing.Size(144, 24);
            this.btnConnectDisconnect.TabIndex = 2;
            this.btnConnectDisconnect.Text = "Connect";
            this.btnConnectDisconnect.UseVisualStyleBackColor = true;
            this.btnConnectDisconnect.Click += new System.EventHandler(this.OnBtnConnectDisconnectClick);
            // 
            // btnDeviceDiscovery
            // 
            this.btnDeviceDiscovery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeviceDiscovery.Location = new System.Drawing.Point(0, 242);
            this.btnDeviceDiscovery.Name = "btnDeviceDiscovery";
            this.btnDeviceDiscovery.Size = new System.Drawing.Size(144, 24);
            this.btnDeviceDiscovery.TabIndex = 0;
            this.btnDeviceDiscovery.Text = "Perfom device discovery";
            this.btnDeviceDiscovery.UseVisualStyleBackColor = true;
            this.btnDeviceDiscovery.Click += new System.EventHandler(this.OnBtnDeviceDiscoveryClick);
            // 
            // grpRight
            // 
            this.grpRight.BackColor = System.Drawing.SystemColors.Control;
            this.grpRight.Controls.Add(this.pnlRight);
            this.grpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRight.Location = new System.Drawing.Point(152, 3);
            this.grpRight.Name = "grpRight";
            this.grpRight.Padding = new System.Windows.Forms.Padding(10);
            this.grpRight.Size = new System.Drawing.Size(499, 299);
            this.grpRight.TabIndex = 4;
            this.grpRight.TabStop = false;
            this.grpRight.Text = "Proximity App";
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.grpBatteryLevel);
            this.pnlRight.Controls.Add(this.grpLinkLoss);
            this.pnlRight.Controls.Add(this.grpImmediateAlert);
            this.pnlRight.Location = new System.Drawing.Point(10, 29);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(480, 265);
            this.pnlRight.TabIndex = 5;
            // 
            // grpBatteryLevel
            // 
            this.grpBatteryLevel.BackColor = System.Drawing.Color.Transparent;
            this.grpBatteryLevel.Controls.Add(this.btnBatteryLevelRead);
            this.grpBatteryLevel.Controls.Add(this.tbBatteryLevel);
            this.grpBatteryLevel.Controls.Add(this.lblBatteryLevel);
            this.grpBatteryLevel.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBatteryLevel.Location = new System.Drawing.Point(0, 182);
            this.grpBatteryLevel.Name = "grpBatteryLevel";
            this.grpBatteryLevel.Size = new System.Drawing.Size(480, 70);
            this.grpBatteryLevel.TabIndex = 5;
            this.grpBatteryLevel.TabStop = false;
            // 
            // btnBatteryLevelRead
            // 
            this.btnBatteryLevelRead.Location = new System.Drawing.Point(397, 34);
            this.btnBatteryLevelRead.Name = "btnBatteryLevelRead";
            this.btnBatteryLevelRead.Size = new System.Drawing.Size(75, 26);
            this.btnBatteryLevelRead.TabIndex = 4;
            this.btnBatteryLevelRead.Text = "Read";
            this.btnBatteryLevelRead.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBatteryLevelRead.UseVisualStyleBackColor = true;
            this.btnBatteryLevelRead.Click += new System.EventHandler(this.OnBtnBatteryLevelReadClick);
            // 
            // tbBatteryLevel
            // 
            this.tbBatteryLevel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tbBatteryLevel.Location = new System.Drawing.Point(297, 28);
            this.tbBatteryLevel.Name = "tbBatteryLevel";
            this.tbBatteryLevel.ReadOnly = true;
            this.tbBatteryLevel.Size = new System.Drawing.Size(75, 26);
            this.tbBatteryLevel.TabIndex = 3;
            this.tbBatteryLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBatteryLevel
            // 
            this.lblBatteryLevel.AutoSize = true;
            this.lblBatteryLevel.Location = new System.Drawing.Point(6, 40);
            this.lblBatteryLevel.Name = "lblBatteryLevel";
            this.lblBatteryLevel.Size = new System.Drawing.Size(108, 20);
            this.lblBatteryLevel.TabIndex = 2;
            this.lblBatteryLevel.Text = "Battery level";
            // 
            // grpLinkLoss
            // 
            this.grpLinkLoss.BackColor = System.Drawing.Color.Transparent;
            this.grpLinkLoss.Controls.Add(this.btnLinkLossSet);
            this.grpLinkLoss.Controls.Add(this.rbtLinkLossHigh);
            this.grpLinkLoss.Controls.Add(this.rbtLinkLossLow);
            this.grpLinkLoss.Controls.Add(this.rbtLinkLossOff);
            this.grpLinkLoss.Controls.Add(this.lblLinkLoss);
            this.grpLinkLoss.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLinkLoss.Location = new System.Drawing.Point(0, 91);
            this.grpLinkLoss.Name = "grpLinkLoss";
            this.grpLinkLoss.Size = new System.Drawing.Size(480, 91);
            this.grpLinkLoss.TabIndex = 3;
            this.grpLinkLoss.TabStop = false;
            // 
            // btnLinkLossSet
            // 
            this.btnLinkLossSet.AutoSize = true;
            this.btnLinkLossSet.Location = new System.Drawing.Point(397, 33);
            this.btnLinkLossSet.Name = "btnLinkLossSet";
            this.btnLinkLossSet.Size = new System.Drawing.Size(75, 30);
            this.btnLinkLossSet.TabIndex = 5;
            this.btnLinkLossSet.Text = "Set";
            this.btnLinkLossSet.UseVisualStyleBackColor = true;
            this.btnLinkLossSet.Click += new System.EventHandler(this.OnBtnLinkLossSetClick);
            // 
            // rbtLinkLossHigh
            // 
            this.rbtLinkLossHigh.AutoSize = true;
            this.rbtLinkLossHigh.Location = new System.Drawing.Point(323, 36);
            this.rbtLinkLossHigh.Name = "rbtLinkLossHigh";
            this.rbtLinkLossHigh.Size = new System.Drawing.Size(64, 24);
            this.rbtLinkLossHigh.TabIndex = 4;
            this.rbtLinkLossHigh.TabStop = true;
            this.rbtLinkLossHigh.Text = "High";
            this.rbtLinkLossHigh.UseVisualStyleBackColor = true;
            // 
            // rbtLinkLossLow
            // 
            this.rbtLinkLossLow.AutoSize = true;
            this.rbtLinkLossLow.Location = new System.Drawing.Point(258, 36);
            this.rbtLinkLossLow.Name = "rbtLinkLossLow";
            this.rbtLinkLossLow.Size = new System.Drawing.Size(59, 24);
            this.rbtLinkLossLow.TabIndex = 3;
            this.rbtLinkLossLow.TabStop = true;
            this.rbtLinkLossLow.Text = "Low";
            this.rbtLinkLossLow.UseVisualStyleBackColor = true;
            // 
            // rbtLinkLossOff
            // 
            this.rbtLinkLossOff.AutoSize = true;
            this.rbtLinkLossOff.Checked = true;
            this.rbtLinkLossOff.Location = new System.Drawing.Point(200, 36);
            this.rbtLinkLossOff.Name = "rbtLinkLossOff";
            this.rbtLinkLossOff.Size = new System.Drawing.Size(52, 24);
            this.rbtLinkLossOff.TabIndex = 2;
            this.rbtLinkLossOff.TabStop = true;
            this.rbtLinkLossOff.Text = "Off";
            this.rbtLinkLossOff.UseVisualStyleBackColor = true;
            // 
            // lblLinkLoss
            // 
            this.lblLinkLoss.AutoSize = true;
            this.lblLinkLoss.Location = new System.Drawing.Point(6, 40);
            this.lblLinkLoss.Name = "lblLinkLoss";
            this.lblLinkLoss.Size = new System.Drawing.Size(120, 20);
            this.lblLinkLoss.TabIndex = 1;
            this.lblLinkLoss.Text = "Link loss level";
            // 
            // grpImmediateAlert
            // 
            this.grpImmediateAlert.BackColor = System.Drawing.Color.Transparent;
            this.grpImmediateAlert.Controls.Add(this.rbtImmediateAlertHigh);
            this.grpImmediateAlert.Controls.Add(this.btnImmediateAlertSet);
            this.grpImmediateAlert.Controls.Add(this.rbtImmediateAlertLow);
            this.grpImmediateAlert.Controls.Add(this.rbtImmediateAlertOff);
            this.grpImmediateAlert.Controls.Add(this.lblImmediateAlert);
            this.grpImmediateAlert.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpImmediateAlert.Location = new System.Drawing.Point(0, 0);
            this.grpImmediateAlert.Name = "grpImmediateAlert";
            this.grpImmediateAlert.Size = new System.Drawing.Size(480, 91);
            this.grpImmediateAlert.TabIndex = 2;
            this.grpImmediateAlert.TabStop = false;
            // 
            // rbtImmediateAlertHigh
            // 
            this.rbtImmediateAlertHigh.AutoSize = true;
            this.rbtImmediateAlertHigh.Location = new System.Drawing.Point(323, 33);
            this.rbtImmediateAlertHigh.Name = "rbtImmediateAlertHigh";
            this.rbtImmediateAlertHigh.Size = new System.Drawing.Size(64, 24);
            this.rbtImmediateAlertHigh.TabIndex = 5;
            this.rbtImmediateAlertHigh.TabStop = true;
            this.rbtImmediateAlertHigh.Text = "High";
            this.rbtImmediateAlertHigh.UseVisualStyleBackColor = true;
            // 
            // btnImmediateAlertSet
            // 
            this.btnImmediateAlertSet.AutoSize = true;
            this.btnImmediateAlertSet.Location = new System.Drawing.Point(397, 30);
            this.btnImmediateAlertSet.Name = "btnImmediateAlertSet";
            this.btnImmediateAlertSet.Size = new System.Drawing.Size(75, 30);
            this.btnImmediateAlertSet.TabIndex = 3;
            this.btnImmediateAlertSet.Text = "Set";
            this.btnImmediateAlertSet.UseVisualStyleBackColor = true;
            this.btnImmediateAlertSet.Click += new System.EventHandler(this.OnBtnImmediateAlertSetClick);
            // 
            // rbtImmediateAlertLow
            // 
            this.rbtImmediateAlertLow.AutoSize = true;
            this.rbtImmediateAlertLow.Location = new System.Drawing.Point(258, 33);
            this.rbtImmediateAlertLow.Name = "rbtImmediateAlertLow";
            this.rbtImmediateAlertLow.Size = new System.Drawing.Size(59, 24);
            this.rbtImmediateAlertLow.TabIndex = 2;
            this.rbtImmediateAlertLow.Text = "Low";
            this.rbtImmediateAlertLow.UseVisualStyleBackColor = true;
            // 
            // rbtImmediateAlertOff
            // 
            this.rbtImmediateAlertOff.AutoSize = true;
            this.rbtImmediateAlertOff.Checked = true;
            this.rbtImmediateAlertOff.Location = new System.Drawing.Point(200, 33);
            this.rbtImmediateAlertOff.Name = "rbtImmediateAlertOff";
            this.rbtImmediateAlertOff.Size = new System.Drawing.Size(52, 24);
            this.rbtImmediateAlertOff.TabIndex = 1;
            this.rbtImmediateAlertOff.TabStop = true;
            this.rbtImmediateAlertOff.Text = "Off";
            this.rbtImmediateAlertOff.UseVisualStyleBackColor = true;
            // 
            // lblImmediateAlert
            // 
            this.lblImmediateAlert.AutoSize = true;
            this.lblImmediateAlert.Location = new System.Drawing.Point(6, 33);
            this.lblImmediateAlert.Name = "lblImmediateAlert";
            this.lblImmediateAlert.Size = new System.Drawing.Size(175, 20);
            this.lblImmediateAlert.TabIndex = 0;
            this.lblImmediateAlert.Text = "Immediate alert level";
            // 
            // grpLog
            // 
            this.appTableLayoutPanel.SetColumnSpan(this.grpLog, 2);
            this.grpLog.Controls.Add(this.dgvLog);
            this.grpLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLog.Location = new System.Drawing.Point(3, 308);
            this.grpLog.Name = "grpLog";
            this.grpLog.Size = new System.Drawing.Size(648, 161);
            this.grpLog.TabIndex = 5;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "Log";
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToDeleteRows = false;
            this.dgvLog.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLog.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvLog.Location = new System.Drawing.Point(3, 16);
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.ReadOnly = true;
            this.dgvLog.Size = new System.Drawing.Size(642, 142);
            this.dgvLog.TabIndex = 0;
            // 
            // appTableLayoutPanel
            // 
            this.appTableLayoutPanel.ColumnCount = 2;
            this.appTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.appTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 505F));
            this.appTableLayoutPanel.Controls.Add(this.grpLog, 0, 1);
            this.appTableLayoutPanel.Controls.Add(this.grpRight, 1, 0);
            this.appTableLayoutPanel.Controls.Add(this.connectTableLayoutPanel, 0, 0);
            this.appTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appTableLayoutPanel.Location = new System.Drawing.Point(0, 25);
            this.appTableLayoutPanel.Name = "appTableLayoutPanel";
            this.appTableLayoutPanel.RowCount = 2;
            this.appTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 305F));
            this.appTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.appTableLayoutPanel.Size = new System.Drawing.Size(654, 472);
            this.appTableLayoutPanel.TabIndex = 7;
            // 
            // connectTableLayoutPanel
            // 
            this.connectTableLayoutPanel.ColumnCount = 3;
            this.connectTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.connectTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.connectTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.connectTableLayoutPanel.Controls.Add(this.dgvDeviceDiscovery, 0, 0);
            this.connectTableLayoutPanel.Controls.Add(this.btnDeviceDiscovery, 1, 1);
            this.connectTableLayoutPanel.Controls.Add(this.btnConnectDisconnect, 1, 2);
            this.connectTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.connectTableLayoutPanel.Name = "connectTableLayoutPanel";
            this.connectTableLayoutPanel.RowCount = 3;
            this.connectTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.connectTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.connectTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.connectTableLayoutPanel.Size = new System.Drawing.Size(143, 299);
            this.connectTableLayoutPanel.TabIndex = 6;
            // 
            // dgvDeviceDiscovery
            // 
            this.dgvDeviceDiscovery.AllowUserToAddRows = false;
            this.dgvDeviceDiscovery.AllowUserToDeleteRows = false;
            this.dgvDeviceDiscovery.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvDeviceDiscovery.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDeviceDiscovery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.connectTableLayoutPanel.SetColumnSpan(this.dgvDeviceDiscovery, 3);
            this.dgvDeviceDiscovery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeviceDiscovery.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvDeviceDiscovery.Location = new System.Drawing.Point(3, 3);
            this.dgvDeviceDiscovery.Name = "dgvDeviceDiscovery";
            this.dgvDeviceDiscovery.ReadOnly = true;
            this.dgvDeviceDiscovery.Size = new System.Drawing.Size(138, 233);
            this.dgvDeviceDiscovery.TabIndex = 1;
            // 
            // ProximityDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 521);
            this.Controls.Add(this.appTableLayoutPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(670, 500);
            this.Name = "ProximityDemo";
            this.Text = "Proximity Demo";
            this.Shown += new System.EventHandler(this.OnShown);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.grpRight.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.grpBatteryLevel.ResumeLayout(false);
            this.grpBatteryLevel.PerformLayout();
            this.grpLinkLoss.ResumeLayout(false);
            this.grpLinkLoss.PerformLayout();
            this.grpImmediateAlert.ResumeLayout(false);
            this.grpImmediateAlert.PerformLayout();
            this.grpLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.appTableLayoutPanel.ResumeLayout(false);
            this.connectTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceDiscovery)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripComboBox cboUsbSerial;
        private System.Windows.Forms.ToolStripButton btnOpenClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel lblConnectedSymbol;
        private System.Windows.Forms.ToolStripStatusLabel lblConnected;
        private System.Windows.Forms.Button btnConnectDisconnect;
        private System.Windows.Forms.Button btnDeviceDiscovery;
        private System.Windows.Forms.GroupBox grpRight;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.GroupBox grpBatteryLevel;
        private System.Windows.Forms.Button btnBatteryLevelRead;
        private System.Windows.Forms.TextBox tbBatteryLevel;
        private System.Windows.Forms.Label lblBatteryLevel;
        private System.Windows.Forms.GroupBox grpLinkLoss;
        private System.Windows.Forms.Button btnLinkLossSet;
        private System.Windows.Forms.RadioButton rbtLinkLossHigh;
        private System.Windows.Forms.RadioButton rbtLinkLossLow;
        private System.Windows.Forms.RadioButton rbtLinkLossOff;
        private System.Windows.Forms.Label lblLinkLoss;
        private System.Windows.Forms.GroupBox grpImmediateAlert;
        private System.Windows.Forms.RadioButton rbtImmediateAlertHigh;
        private System.Windows.Forms.Button btnImmediateAlertSet;
        private System.Windows.Forms.RadioButton rbtImmediateAlertLow;
        private System.Windows.Forms.RadioButton rbtImmediateAlertOff;
        private System.Windows.Forms.Label lblImmediateAlert;
        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.TableLayoutPanel appTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel connectTableLayoutPanel;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.DataGridView dgvDeviceDiscovery;

    }
}

