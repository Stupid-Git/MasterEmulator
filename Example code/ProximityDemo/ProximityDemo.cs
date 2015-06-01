/* Copyright (c) 2010 Nordic Semiconductor. All Rights Reserved.
 *
 * The information contained herein is property of Nordic Semiconductor ASA.
 * Terms and conditions of usage are described in detail in NORDIC
 * SEMICONDUCTOR STANDARD SOFTWARE LICENSE AGREEMENT.
 *
 * Licensees are granted free, non-transferable use of the information. NO
 * WARRANTY of ANY KIND is provided. This heading must NOT be removed from
 * the file.
 */

/* Project note:
 * 
 * The NetworkAvailabilityDemo project is a basic example implementation to demonstrate how 
 * the MasterEmulator api can be used.
 * 
 * The application implements a master running the proximity and battery services.
 * The "immediate alert level" and "link loss level" characteristics located on the peer 
 * server can be modified through the gui. 
 * Incoming notifications from the peer server for the "battery state" and "battery level"
 * characteristics are displayed in the gui when received.
 * 
 * Important: The slave side device is expected to run either
 * proximity_application_nrf8200 provided in the nRF8001 SDK or
 * ble_app_proximity provided in the nRF51822 SDK.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Nordicsemi;

namespace Proximity
{
    public partial class ProximityDemo : Form
    {
        enum AlertLevel : byte
        {
            Off = 0x00,
            Low = 0x01,
            High = 0x02,
        }

        class StringValue
        {
            public string Text { get; private set; }
            public object Data { get; private set; }

            public StringValue(string val)
            {
                Text = val;
            }

            public StringValue(string val, object data)
            {
                Text = val;
                Data = data;
            }
        }

        class AppText
        {
            public const string StartingUp = "Starting up";
            public const string Ready = "Ready";
            public const string WorkerCompleted = "WorkerCompleted";
            public const string Connect = "Connect";
            public const string Disconnect = "Disconnect";
            public const string NoDeviceSelected = "No device is selected";
            public const string Close = "Close";
            public const string Open = "Open";
            public const string OperationFailed = "Operation failed";
        }

        MasterEmulator masterEmulator;
        BackgroundWorker initMasterEmulatorWorker = new BackgroundWorker();
        BindingList<StringValue> log = new BindingList<StringValue>();
        BindingList<StringValue> discoveredDevices = new BindingList<StringValue>();

        bool pipeDiscoveryComplete = false;
        bool isOpen = false;
        bool isConnected = false;
        bool isRunning = false;

        int pipeNumberBatteryLevel;
        int pipeNumberBatteryLevelNotify;
        int pipeNumberImmediateAlertLevel;
        int pipeNumberAlertLevel;
        int pipeFindMe;

        public ProximityDemo()
        {
            InitializeComponent();
        }

        private void OnShown(object sender, EventArgs e)
        {
            appTableLayoutPanel.Enabled = false;
            btnOpenClose.Enabled = false;
            grpRight.Enabled = false;
            btnDeviceDiscovery.Enabled = false;
            btnConnectDisconnect.Enabled = false;
            lblConnectedSymbol.BackColor = Color.Pink;
            SetupLogGrid();
            SetupDeviceDiscoveryGrid();
            InitMasterEmulator();
        }

        private void SetupLogGrid()
        {
            dgvLog.DataSource = log;
            dgvLog.Columns["Data"].Visible = false;
            dgvLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLog.ColumnHeadersVisible = false;
            dgvLog.RowHeadersVisible = false;
            dgvLog.RowTemplate.Height = 18;
            dgvLog.AllowUserToResizeRows = false;
            dgvLog.ShowCellToolTips = false;
            dgvLog.ShowEditingIcon = false;
        }

        private void SetupDeviceDiscoveryGrid()
        {
            dgvDeviceDiscovery.DataSource = discoveredDevices;
            dgvDeviceDiscovery.Columns["Data"].Visible = false;
            dgvDeviceDiscovery.Columns[0].HeaderText = "Device name";
            dgvDeviceDiscovery.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDeviceDiscovery.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDeviceDiscovery.ColumnHeadersVisible = true;
            dgvDeviceDiscovery.RowHeadersVisible = false;
            dgvDeviceDiscovery.RowTemplate.Height = 18;
            dgvDeviceDiscovery.AllowUserToResizeRows = false;
            dgvDeviceDiscovery.ShowCellToolTips = false;
            dgvDeviceDiscovery.ShowEditingIcon = false;
        }

        private void OnConnectionUpdateRequest(object sender, ConnectionUpdateRequestEventArgs e)
        {
            masterEmulator.SendConnectionUpdateResponse(e.Identifier, ConnectionUpdateResponse.Accepted);
            BtConnectionParameters cxParam = new BtConnectionParameters();
            cxParam.ConnectionIntervalMs = e.ConnectionIntervalMinMs;
            cxParam.SupervisionTimeoutMs = e.ConnectionSupervisionTimeoutMs;
            masterEmulator.UpdateConnectionParameters(cxParam);
        }
        
        private void RegisterEventHandlers()
        {
            masterEmulator.LogMessage += OnLogMessage;
            masterEmulator.DataReceived += OnDataReceived;
            masterEmulator.Connected += OnConnected;
            masterEmulator.Disconnected += OnDisconnected;
            masterEmulator.ConnectionUpdateRequest += OnConnectionUpdateRequest;
        }

        private void InitMasterEmulator()
        {
            this.Cursor = Cursors.WaitCursor;
            initMasterEmulatorWorker.DoWork += OnInitMasterEmulatorWorkerDoWork;
            initMasterEmulatorWorker.RunWorkerCompleted += OnInitMasterEmulatorWorkerCompleted;
            initMasterEmulatorWorker.RunWorkerAsync();
        }

        void OnInitMasterEmulatorWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                log.Add(new StringValue(AppText.StartingUp));
            });

            masterEmulator = new MasterEmulator();
            RegisterEventHandlers();

            IEnumerable<string> usbDevices = masterEmulator.EnumerateUsb();

            this.BeginInvoke((MethodInvoker)delegate()
            {
                PopulateUsbDevComboBox(usbDevices);
            });

            initMasterEmulatorWorker.DoWork -= OnInitMasterEmulatorWorkerDoWork;
        }

        void OnInitMasterEmulatorWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
            this.BeginInvoke((MethodInvoker)delegate()
            {
                if (e.Error != null)
                {
                    DisplayErrorMessage(e.Error);
                }
                else
                {
                    log.Add(new StringValue(AppText.Ready));
                    btnOpenClose.Enabled = true;
                }
            });
            Debug.WriteLine(AppText.WorkerCompleted);
            initMasterEmulatorWorker.RunWorkerCompleted -= OnInitMasterEmulatorWorkerCompleted;
        }

        private void PerformPipeSetup()
        {
            const ushort batteryStatusServiceUuid = 0x180F;
            const ushort batteryLevelCharacteristicUuid = 0x2A19;
            const ushort immediateAlertServiceUuid = 0x1802;
            const ushort alertLevelCharacteristicUuid = 0x2A06;
            const ushort linkLossServiceUuid = 0x1803;

            /* Setup pipe Battery Level*/
            BtUuid serviceUuid1 = new BtUuid(batteryStatusServiceUuid);
            PipeStore pipeStore = PipeStore.Remote;
            masterEmulator.SetupAddService(serviceUuid1, pipeStore);

            BtUuid charDefUuid1 = new BtUuid(batteryLevelCharacteristicUuid);
            int maxDataLength = 1;
            byte[] data = new byte[] { };
            masterEmulator.SetupAddCharacteristicDefinition(charDefUuid1, maxDataLength, data);
            pipeNumberBatteryLevel = masterEmulator.SetupAssignPipe(PipeType.ReceiveRequest);
            pipeNumberBatteryLevelNotify = masterEmulator.SetupAssignPipe(PipeType.Receive);

            /* Setup pipe Immediate Alert Level */
            BtUuid serviceUuid3 = new BtUuid(immediateAlertServiceUuid);
            masterEmulator.SetupAddService(serviceUuid3, PipeStore.Remote);

            BtUuid charDefUuid3 = new BtUuid(alertLevelCharacteristicUuid);
            masterEmulator.SetupAddCharacteristicDefinition(charDefUuid3, maxDataLength, data);
            pipeNumberImmediateAlertLevel = masterEmulator.SetupAssignPipe(PipeType.Transmit);

            /* Setup pipe Alert Level */
            BtUuid serviceUuid4 = new BtUuid(linkLossServiceUuid);
            masterEmulator.SetupAddService(serviceUuid4, pipeStore);

            BtUuid charDefUuid4 = new BtUuid(alertLevelCharacteristicUuid);
            masterEmulator.SetupAddCharacteristicDefinition(charDefUuid4, maxDataLength, data);
            pipeNumberAlertLevel = masterEmulator.SetupAssignPipe(PipeType.TransmitWithAck);

            /* FindMe server */
            masterEmulator.SetupAddService(serviceUuid3, PipeStore.Local);

            masterEmulator.SetupAddCharacteristicDefinition(charDefUuid3, maxDataLength, data);
            pipeFindMe = masterEmulator.SetupAssignPipe(PipeType.Receive);
        }

        private void DisplayErrorMessage(Exception ex)
        {
            MessageBox.Show(String.Format("{0}: {1}", AppText.OperationFailed, ex.Message));
            Debug.WriteLine(ex.StackTrace);
        }

        private void OpenMasterEmulator(string usbSerial)
        {
            masterEmulator.Open(usbSerial);
            masterEmulator.Reset();
            isOpen = true;
            appTableLayoutPanel.Enabled = true;
        }

        private void CloseMasterEmulator()
        {
            masterEmulator.Close();
            isOpen = false;
            btnOpenClose.Text = AppText.Open;
            appTableLayoutPanel.Enabled = false;
        }

        private void Run()
        {
            try
            {
                masterEmulator.Run();
                btnDeviceDiscovery.Enabled = true;
                btnConnectDisconnect.Enabled = true;
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex);
                if (isOpen)
                {
                    CloseMasterEmulator();
                }
            }
        }

        private void DiscoverPipes()
        {
            try
            {
                masterEmulator.DiscoverPipes();
                masterEmulator.OpenAllRemotePipes();
                pipeDiscoveryComplete = true;
                if (isConnected)
                {
                    grpRight.Enabled = true;
                    pnlRight.BackColor = Color.LightGreen;
                }
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex);
            }
        }

        private void SetImmediateAlert(AlertLevel alert)
        {
            byte[] value = new byte[] { (byte)alert };
            int pipeNumber = pipeNumberImmediateAlertLevel;
            masterEmulator.SendData(pipeNumber, value);
        }

        private void SetLinkLossAlertLevel(AlertLevel level)
        {
            byte[] value = new byte[] { (byte)level };
            int pipeNumber = pipeNumberAlertLevel;
            masterEmulator.SendData(pipeNumber, value);
        }

        private void PopulateUsbDevComboBox(IEnumerable<string> devices)
        {
            List<string> devs = new List<string>(devices);
            cboUsbSerial.ComboBox.DataSource = devs;
        }

        #region Master Emulator event handlers

        void OnLogMessage(object sender, ValueEventArgs<string> e)
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                log.Add(new StringValue(e.Value));
                ScrollLogToBottom();
            });
        }

        void ScrollLogToBottom()
        {
            if (InvokeRequired)
            {
                this.Invoke((Action)delegate
                {
                    ScrollLogToBottom();
                });
                return;
            }
            dgvLog.FirstDisplayedScrollingRowIndex = log.Count - 1;
        }

        void OnDataReceived(object sender, PipeDataEventArgs e)
        {
            if (e.PipeNumber == pipeFindMe)
            {
                if (e.PipeData.Length == 1)
                {
                    Color color;
                    switch ((AlertLevel)e.PipeData[0])
                    {
                        case AlertLevel.High:
                            System.Media.SystemSounds.Exclamation.Play();
                            color = Color.Pink;
                            break;
                        case AlertLevel.Low:
                            System.Media.SystemSounds.Beep.Play();
                            color = Color.BurlyWood;
                            break;
                        case AlertLevel.Off:
                        default:
                            System.Media.SystemSounds.Asterisk.Play();
                            color = Color.LightGreen;
                            break;
                    }
                    this.Invoke((MethodInvoker)delegate()
                    {
                        pnlRight.BackColor = color;
                    });
                }
            }
            else if (e.PipeNumber == pipeNumberBatteryLevelNotify)
            {
                if (e.PipeData.Length == 1)
                {
                    this.BeginInvoke((MethodInvoker)delegate()
                    {
                        tbBatteryLevel.Text = e.PipeData[0].ToString();
                        string logMessage = 
                            string.Format("Received Battery Level update notification: {0}",
                            e.PipeData[0].ToString());
                        log.Add(new StringValue(logMessage));
                        ScrollLogToBottom();
                    });
                }
            }
        }

        void OnConnected(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                lblConnectedSymbol.BackColor = Color.LightGreen;
                btnConnectDisconnect.Text = AppText.Disconnect;
                if (pipeDiscoveryComplete)
                {
                    grpRight.Enabled = true;
                    pnlRight.BackColor = Color.LightGreen;
                }
                isConnected = true;
            });
        }

        void OnDisconnected(object sender, ValueEventArgs<DisconnectReason> e)
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                lblConnectedSymbol.BackColor = Color.Pink;
                btnConnectDisconnect.Text = AppText.Connect;
                grpRight.Enabled = false;
                tbBatteryLevel.Clear();
                pnlRight.BackColor = SystemColors.Control;
                isConnected = false;
            });
        }

        #endregion

        #region ui event handlers

        private void OnBtnOpenClose(object sender, EventArgs e)
        {
            int selectedItem = cboUsbSerial.SelectedIndex;
            string usbSerial;
            if (selectedItem >= 0)
            {
                usbSerial = (string)cboUsbSerial.Items[selectedItem];
            }
            else
            {
                MessageBox.Show(AppText.NoDeviceSelected);
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (!isOpen)
                {
                    OpenMasterEmulator(usbSerial);

                    if (!isRunning)
                    {
                        PerformPipeSetup();
                        Run();
                    }
                    btnOpenClose.Enabled = false;
                }
                else
                {
                    CloseMasterEmulator();
                }
            }
            catch (Exception ex)
            {
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    DisplayErrorMessage(ex);
                });
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void OnBtnDeviceDiscoveryClick(object sender, EventArgs e)
        {
            IEnumerable<BtDevice> devices;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                devices = masterEmulator.DiscoverDevices();
                discoveredDevices.Clear();
                foreach (BtDevice dev in devices)
                {
                    string deviceName = "";
                    IDictionary<DeviceInfoType, string> deviceInfo = dev.DeviceInfo;
                    if (deviceInfo.ContainsKey(DeviceInfoType.CompleteLocalName))
                    {
                        deviceName = deviceInfo[DeviceInfoType.CompleteLocalName];
                    }
                    else if (deviceInfo.ContainsKey(DeviceInfoType.ShortenedLocalName))
                    {
                        deviceName = deviceInfo[DeviceInfoType.ShortenedLocalName];
                    }
                    else
                    {
                        deviceName = dev.DeviceAddress.Value;
                    }

                    StringValue val = new StringValue(deviceName, dev.DeviceAddress);
                    discoveredDevices.Add(val);
                }
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void OnBtnConnectDisconnectClick(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                if (dgvDeviceDiscovery.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvDeviceDiscovery.SelectedRows[0];
                    BtDeviceAddress selectedDevice = (BtDeviceAddress)selectedRow.Cells["Data"].Value;
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        BtDeviceAddress address = new BtDeviceAddress(selectedDevice.Value);
                        bool connectSuccess = masterEmulator.Connect(address);
                        if (connectSuccess)
                        {
                            masterEmulator.Bond();
                            DiscoverPipes();
                        }
                    }
                    catch (Exception ex)
                    {
                        DisplayErrorMessage(ex);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            else
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    masterEmulator.Disconnect();
                    pipeDiscoveryComplete = false;
                }
                catch (Exception ex)
                {
                    DisplayErrorMessage(ex);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void OnBtnImmediateAlertSetClick(object sender, EventArgs e)
        {
            bool immediateAlertIsLow = rbtImmediateAlertLow.Checked;
            bool immediateAlertIsHigh = rbtImmediateAlertHigh.Checked;
            AlertLevel alert;

            if (immediateAlertIsLow)
            {
                alert = AlertLevel.Low;
            }
            else if (immediateAlertIsHigh)
            {
                alert = AlertLevel.High;
            }
            else
            {
                alert = AlertLevel.Off;
            }

            try
            {
                SetImmediateAlert(alert);
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex);
            }
        }

        private void OnBtnLinkLossSetClick(object sender, EventArgs e)
        {
            AlertLevel level;
            if (rbtLinkLossOff.Checked)
            {
                level = AlertLevel.Off;
            }
            else if (rbtLinkLossLow.Checked)
            {
                level = AlertLevel.Low;
            }
            else
            {
                level = AlertLevel.High;
            }

            try
            {
                SetLinkLossAlertLevel(level);
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex);
            }
        }

        private void OnBtnBatteryLevelReadClick(object sender, EventArgs e)
        {
            byte[] received = masterEmulator.RequestData(pipeNumberBatteryLevel);
            this.BeginInvoke((MethodInvoker)delegate()
                {
                    Int16 data = received[0];
                    tbBatteryLevel.Text = data.ToString();
                });
        }

        #endregion

    }
}