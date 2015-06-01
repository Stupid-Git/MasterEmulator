namespace HealthThermo
{
    partial class HealthThermoDemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HealthThermoDemo));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cboUsbSerial = new System.Windows.Forms.ToolStripComboBox();
            this.btnOpenClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblConnected = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblConnectedSymbol = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpLeft = new System.Windows.Forms.GroupBox();
            this.pnlLeftBottom = new System.Windows.Forms.Panel();
            this.btnBond = new System.Windows.Forms.Button();
            this.pnlLeftMiddle = new System.Windows.Forms.Panel();
            this.dgvDeviceDiscovery = new System.Windows.Forms.DataGridView();
            this.grpRight = new System.Windows.Forms.GroupBox();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.grpBatteryState = new System.Windows.Forms.GroupBox();
            this.tbTemperature = new System.Windows.Forms.TextBox();
            this.lblBatteryState = new System.Windows.Forms.Label();
            this.grpLog = new System.Windows.Forms.GroupBox();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.grpLeft.SuspendLayout();
            this.pnlLeftBottom.SuspendLayout();
            this.pnlLeftMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceDiscovery)).BeginInit();
            this.grpRight.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.grpBatteryState.SuspendLayout();
            this.grpLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cboUsbSerial,
            this.btnOpenClose,
            this.toolStripSeparator1});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(435, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(97, 22);
            this.toolStripLabel1.Text = "Master emulator:";
            // 
            // cboUsbSerial
            // 
            this.cboUsbSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsbSerial.Name = "cboUsbSerial";
            this.cboUsbSerial.Size = new System.Drawing.Size(120, 25);
            // 
            // btnOpenClose
            // 
            this.btnOpenClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOpenClose.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenClose.Image")));
            this.btnOpenClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenClose.Name = "btnOpenClose";
            this.btnOpenClose.Size = new System.Drawing.Size(40, 22);
            this.btnOpenClose.Text = "Open";
            this.btnOpenClose.Click += new System.EventHandler(this.OnBtnOpenCloseClick);
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
            this.statusStrip.Location = new System.Drawing.Point(0, 326);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(435, 24);
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
            // grpLeft
            // 
            this.grpLeft.Controls.Add(this.pnlLeftBottom);
            this.grpLeft.Controls.Add(this.pnlLeftMiddle);
            this.grpLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpLeft.Location = new System.Drawing.Point(0, 0);
            this.grpLeft.Name = "grpLeft";
            this.grpLeft.Padding = new System.Windows.Forms.Padding(8);
            this.grpLeft.Size = new System.Drawing.Size(179, 214);
            this.grpLeft.TabIndex = 3;
            this.grpLeft.TabStop = false;
            // 
            // pnlLeftBottom
            // 
            this.pnlLeftBottom.Controls.Add(this.btnBond);
            this.pnlLeftBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLeftBottom.Location = new System.Drawing.Point(8, 131);
            this.pnlLeftBottom.Name = "pnlLeftBottom";
            this.pnlLeftBottom.Size = new System.Drawing.Size(163, 80);
            this.pnlLeftBottom.TabIndex = 4;
            // 
            // btnBond
            // 
            this.btnBond.Location = new System.Drawing.Point(5, 42);
            this.btnBond.Name = "btnBond";
            this.btnBond.Size = new System.Drawing.Size(150, 23);
            this.btnBond.TabIndex = 2;
            this.btnBond.Text = "Bond";
            this.btnBond.UseVisualStyleBackColor = true;
            this.btnBond.Click += new System.EventHandler(this.OnBtnBondClick);
            // 
            // pnlLeftMiddle
            // 
            this.pnlLeftMiddle.Controls.Add(this.dgvDeviceDiscovery);
            this.pnlLeftMiddle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLeftMiddle.Location = new System.Drawing.Point(8, 21);
            this.pnlLeftMiddle.Name = "pnlLeftMiddle";
            this.pnlLeftMiddle.Size = new System.Drawing.Size(163, 110);
            this.pnlLeftMiddle.TabIndex = 4;
            // 
            // dgvDeviceDiscovery
            // 
            this.dgvDeviceDiscovery.AllowUserToAddRows = false;
            this.dgvDeviceDiscovery.AllowUserToDeleteRows = false;
            this.dgvDeviceDiscovery.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvDeviceDiscovery.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDeviceDiscovery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeviceDiscovery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeviceDiscovery.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvDeviceDiscovery.Location = new System.Drawing.Point(0, 0);
            this.dgvDeviceDiscovery.MultiSelect = false;
            this.dgvDeviceDiscovery.Name = "dgvDeviceDiscovery";
            this.dgvDeviceDiscovery.ReadOnly = true;
            this.dgvDeviceDiscovery.Size = new System.Drawing.Size(163, 110);
            this.dgvDeviceDiscovery.TabIndex = 1;
            // 
            // grpRight
            // 
            this.grpRight.BackColor = System.Drawing.SystemColors.Control;
            this.grpRight.Controls.Add(this.pnlRight);
            this.grpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRight.Location = new System.Drawing.Point(179, 0);
            this.grpRight.Name = "grpRight";
            this.grpRight.Padding = new System.Windows.Forms.Padding(10);
            this.grpRight.Size = new System.Drawing.Size(256, 214);
            this.grpRight.TabIndex = 4;
            this.grpRight.TabStop = false;
            this.grpRight.Text = "Health Thermometer";
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.grpBatteryState);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRight.Location = new System.Drawing.Point(10, 29);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(236, 182);
            this.pnlRight.TabIndex = 5;
            // 
            // grpBatteryState
            // 
            this.grpBatteryState.BackColor = System.Drawing.Color.Transparent;
            this.grpBatteryState.Controls.Add(this.tbTemperature);
            this.grpBatteryState.Controls.Add(this.lblBatteryState);
            this.grpBatteryState.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBatteryState.Location = new System.Drawing.Point(0, 0);
            this.grpBatteryState.Name = "grpBatteryState";
            this.grpBatteryState.Size = new System.Drawing.Size(236, 182);
            this.grpBatteryState.TabIndex = 4;
            this.grpBatteryState.TabStop = false;
            // 
            // tbTemperature
            // 
            this.tbTemperature.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tbTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.tbTemperature.Location = new System.Drawing.Point(123, 64);
            this.tbTemperature.Multiline = true;
            this.tbTemperature.Name = "tbTemperature";
            this.tbTemperature.ReadOnly = true;
            this.tbTemperature.Size = new System.Drawing.Size(101, 38);
            this.tbTemperature.TabIndex = 3;
            this.tbTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBatteryState
            // 
            this.lblBatteryState.AutoSize = true;
            this.lblBatteryState.Location = new System.Drawing.Point(6, 73);
            this.lblBatteryState.Name = "lblBatteryState";
            this.lblBatteryState.Size = new System.Drawing.Size(111, 20);
            this.lblBatteryState.TabIndex = 2;
            this.lblBatteryState.Text = "Temperature";
            // 
            // grpLog
            // 
            this.grpLog.Controls.Add(this.dgvLog);
            this.grpLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLog.Location = new System.Drawing.Point(0, 0);
            this.grpLog.Name = "grpLog";
            this.grpLog.Size = new System.Drawing.Size(435, 83);
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
            this.dgvLog.Size = new System.Drawing.Size(429, 64);
            this.dgvLog.TabIndex = 0;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 25);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.grpRight);
            this.splitContainer.Panel1.Controls.Add(this.grpLeft);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.grpLog);
            this.splitContainer.Size = new System.Drawing.Size(435, 301);
            this.splitContainer.SplitterDistance = 214;
            this.splitContainer.TabIndex = 6;
            // 
            // HealthThermoDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 350);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HealthThermoDemo";
            this.Text = "HealthThermo Demo";
            this.Shown += new System.EventHandler(this.OnShown);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.grpLeft.ResumeLayout(false);
            this.pnlLeftBottom.ResumeLayout(false);
            this.pnlLeftMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceDiscovery)).EndInit();
            this.grpRight.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.grpBatteryState.ResumeLayout(false);
            this.grpBatteryState.PerformLayout();
            this.grpLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripComboBox cboUsbSerial;
        private System.Windows.Forms.ToolStripButton btnOpenClose;
        private System.Windows.Forms.GroupBox grpLeft;
        private System.Windows.Forms.GroupBox grpRight;
        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.DataGridView dgvDeviceDiscovery;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.Button btnBond;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel lblConnectedSymbol;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolStripStatusLabel lblConnected;
        private System.Windows.Forms.Panel pnlLeftBottom;
        private System.Windows.Forms.Panel pnlLeftMiddle;
        private System.Windows.Forms.GroupBox grpBatteryState;
        private System.Windows.Forms.TextBox tbTemperature;
        private System.Windows.Forms.Label lblBatteryState;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;

    }
}

