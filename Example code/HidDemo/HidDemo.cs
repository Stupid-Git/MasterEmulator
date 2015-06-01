/* Copyright (c) 2012 Nordic Semiconductor. All Rights Reserved.
 *
 * The information contained herein is property of Nordic Semiconductor ASA.
 * Terms and conditions of usage are described in detail in NORDIC
 * SEMICONDUCTOR STANDARD SOFTWARE LICENSE AGREEMENT. 
 *
 * Licensees are granted free, non-transferable use of the information. NO
 * WARRANTY of ANY KIND is provided. This heading must NOT be removed from
 * the file.
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using Nordicsemi;

namespace HidDemo
{
    public partial class HidDemo : Form
    {
        /* Class variables */
        MasterEmulator masterEmulator;
        PipeSetup pipeSetup;
        BtDeviceAddress connectedAddress;
        PipeSetup.SetupMode setupMode;
        bool connectionInProgress = false;
        AutoResetEvent connectionResetEvent = new AutoResetEvent(true);

        /* GUI component(s) */
        TextBox textBox;

        public HidDemo()
        {
            InitializeComponent();
            Shown += OnShown;
        }

        /// <summary>
        /// When the Shown event has been called it's safe to call SetupGui for operations
        /// on the gui components.
        /// </summary>
        void OnShown(object sender, EventArgs e)
        {
            SetupGui();
            StartMasterEmulator();
        }

        /// <summary>
        /// Prompt user to select which SetupMode to proceed with: keyboard or mouse.
        /// </summary>
        void SelectHidMode()
        {
            AddToLog("Select setup:");
            AddToLog("1) Keyboard");
            AddToLog("2) Mouse");

            /* Loop until a valid keypress has been registered */
            while (true)
            {
                char key = GetUserKeypress();

                if (key == '1')
                {
                    setupMode = PipeSetup.SetupMode.HidKeyboard;
                    AddToLog("Keyboard setup selected");
                    break;
                }
                else if (key == '2')
                {
                    setupMode = PipeSetup.SetupMode.HidMouse;
                    AddToLog("Mouse setup selected");
                    break;
                }
                else
                {
                    /* Illegal keystroke registered, keep looping */
                    AddToLog("Illegal keystroke, press 1 or 2");
                }
            }
        }

        /// <summary>
        /// Wire up a handler for textbox keypress event and catch the user key selection.
        /// Note, the textbox must have focus for this to work.
        /// </summary>
        /// <returns>Returns the keyboard character pressed.</returns>
        char GetUserKeypress()
        {
            char key = '0';
            AutoResetEvent resetEvent = new AutoResetEvent(false);

            KeyPressEventHandler handler = (sender, args) =>
            {
                key = args.KeyChar;
                args.Handled = true;
                resetEvent.Set();
            };
            textBox.KeyPress += handler;

            /* Wait indefinitely for keypress */
            resetEvent.WaitOne();

            textBox.KeyPress -= handler;
            return key;
        }

        /// <summary>
        /// Initialize and configure the gui components of the application.
        /// </summary>
        void SetupGui()
        {
            this.Text = "HID Demo";
            textBox = new TextBox();
            textBox.Multiline = true;
            textBox.Dock = DockStyle.Fill;
            textBox.ScrollBars = ScrollBars.Vertical;
            this.Controls.Add(textBox);
        }

        /// <summary>
        ///  Method for adding text to the textbox and logfile.
        ///  When called on the main thread, invoke is not required.
        ///  For other threads, the invoke is required.
        /// </summary>
        /// <param name="message">The message string to add to the log.</param>
        void AddToLog(string message)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke((Action)delegate()
                {
                    AddToLog(message);
                });
                return;
            }

            textBox.AppendText(message + Environment.NewLine);

            /* Writing to trace also, which causes the message to be put in the log file. */
            Trace.WriteLine(message);
        }

        /// <summary>
        /// Convenience method for logging exception messages.
        /// </summary>
        void LogErrorMessage(string errorMessage, string stackTrace)
        {
            AddToLog(errorMessage);
            Trace.WriteLine(stackTrace);
        }

        /// <summary>
        /// Collection of method calls to start and setup MasterEmulator.
        /// The calls are placed in a background task for not blocking the gui thread.
        /// </summary>
        void StartMasterEmulator()
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    InitializeMasterEmulator();
                    SelectHidMode();
                    RegisterEventHandlers();
                    string device = FindUsbDevice();
                    OpenMasterEmulatorDevice(device);
                    pipeSetup = new PipeSetup(masterEmulator);
                    pipeSetup.PerformPipeSetup(setupMode);
                    Run();
                    StartDeviceDiscovery();
                    /* Next step is to wait for discovered devices, 
                     * see OnDeviceDiscovered event handler.*/
                }
                catch (Exception ex)
                {
                    LogErrorMessage(string.Format("Exception in StartMasterEmulator", ex.Message),
                    ex.StackTrace);
                }
            });
        }

        void InitializeMasterEmulator()
        {
            AddToLog("Loading");
            masterEmulator = new MasterEmulator();
        }

        void RegisterEventHandlers()
        {
            AddToLog("Registering event handlers");
            masterEmulator.Connected += OnConnected;
            masterEmulator.ConnectionUpdateRequest += OnConnectionUpdateRequest;
            masterEmulator.DataReceived += OnDataReceived;
            masterEmulator.DeviceDiscovered += OnDeviceDiscovered;
            masterEmulator.Disconnected += OnDisconnected;
            masterEmulator.DisplayPasskey += OnDisplayPasskey;
            masterEmulator.LogMessage += OnLogMessage;
        }

        /// <summary>
        /// Searching for master emulator devices attached to the pc. 
        /// If more than one is connected it will simply return the first in the list.
        /// </summary>
        /// <returns>Returns the first master emulator device found.</returns>
        string FindUsbDevice()
        {
            /* The UsbDeviceType argument is used for filtering master emulator device types,
             * more specifically between pca10000/pca10001 (Segger JLink) and nRF2739. */
            IEnumerable<string> devices =
                masterEmulator.EnumerateUsb(UsbDeviceType.AnyMasterEmulator);

            List<string> devicesList = devices.ToList<string>();
            if (devicesList.Count > 0)
            {
                AddToLog(string.Format("Found master emulator device: {0}", devicesList[0]));
                return devicesList[0];
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Tell the api to use the given master emulator device.
        /// </summary>
        /// <param name="device"></param>
        void OpenMasterEmulatorDevice(string device)
        {
            if (masterEmulator.IsOpen)
            {
                return;
            }

            masterEmulator.Open(device);
        }

        /// <summary>
        /// By calling Run, the pipesetup is processed and the stack engine is started.
        /// </summary>
        void Run()
        {
            if (masterEmulator.IsRunning)
            {
                return;
            }

            masterEmulator.Run();
        }

        /// <summary>
        /// Device discovery is started with the given scan parameters.
        /// By stating active scan, we will be receiving data from both advertising
        /// and scan repsonse packets.
        /// </summary>
        /// <returns></returns>
        bool StartDeviceDiscovery()
        {
            BtScanParameters scanParameters = new BtScanParameters();
            scanParameters.ScanIntervalMs = 250;
            scanParameters.ScanWindowMs = 200;
            scanParameters.ScanType = BtScanType.ActiveScanning;
            bool startSuccess = masterEmulator.StartDeviceDiscovery(scanParameters);
            return startSuccess;
        }

        /// <summary>
        /// Connecting to the given device, and with the given connection parameters.
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        bool Connect(BtDevice device)
        {
            if (masterEmulator.IsDeviceDiscoveryOngoing)
            {
                masterEmulator.StopDeviceDiscovery();
            }

            string deviceName = GetDeviceName(device.DeviceInfo);
            AddToLog(string.Format("Connecting to {0} {1}",
                device.DeviceAddress.ToString(), deviceName));

            BtConnectionParameters connectionParams = new BtConnectionParameters();
            connectionParams.ConnectionIntervalMs = 7.5;
            bool connectSuccess = masterEmulator.Connect(device.DeviceAddress, connectionParams);
            return connectSuccess;
        }

        /// <summary>
        /// Initiating bond procedure. Note: one must be connected before calling the Bond 
        /// command.
        /// </summary>
        void Bond()
        {
            SecurityParameters securityParams = new SecurityParameters();
            securityParams.IoCapabilities = IoCapabilitiesEnum.KeyboardDisplay;
            securityParams.OobAvailability = OobAvailibilityEnum.OobNotAvailable;
            bool bondSuccess = masterEmulator.Bond(securityParams);
            if (!bondSuccess)
            {
                throw new Exception("Bonding failed.");
            }
        }

        /// <summary>
        /// By discovering pipes, the pipe setup we have specified will be matched up
        /// to the remote device's ATT table by ATT service discovery. The command 
        /// will return false if problems were found during the discovery.
        /// </summary>
        void DiscoverPipes()
        {
            bool success = masterEmulator.DiscoverPipes();

            if (!success)
            {
                AddToLog("PipeSetup did not match ATT table of connected device. "
                    + "Was the correct mode (keyboard/mouse) selected?");
            }
        }

        /// <summary>
        /// Pipes of type _Receive_ must be opened before they will start receiving notifications.
        /// This maps to ATT Client Configuration Descriptors.
        /// </summary>
        void OpenRemotePipes()
        {
            var openedPipesEnumeration = masterEmulator.OpenAllRemotePipes();
            List<int> openedPipes = new List<int>(openedPipesEnumeration);
        }

        /// <summary>
        /// Event handler for DeviceDiscovered. This handler will be called when devices
        /// are discovered during asynchronous device discovery (see StartDeviceDiscovery).
        /// </summary>
        void OnDeviceDiscovered(object sender, ValueEventArgs<BtDevice> arguments)
        {
            /* Avoid call after a connect procedure is being started,
             * and the discovery procedure hasn't yet been stopped. */
            if (connectionInProgress)
            {
                return;
            }

            BtDevice device = arguments.Value;

            if (!IsEligibleForConnection(device))
            {
                return;
            }

            /* Store the address in case of reconnection with same device */
            connectedAddress = device.DeviceAddress;

            connectionInProgress = true;

            /* Start the connection procedure in a background task to avoid 
             * blocking the event. */
            Task.Factory.StartNew(() =>
            {
                try
                {
                    Connect(device);
                }
                catch (Exception ex)
                {
                    LogErrorMessage(string.Format("Exception in OnDeviceDiscovered: {0}",
                        ex.Message), ex.StackTrace);
                }
            });
        }

        /// <summary>
        /// Check if a device has the advertising data we're looking for.
        /// </summary>
        bool IsEligibleForConnection(BtDevice device)
        {
            bool isAddressKnown = (device.DeviceAddress == connectedAddress);
            if (isAddressKnown)
            {
                return true;
            }

            IDictionary<DeviceInfoType, string> deviceInfo = device.DeviceInfo;

            string deviceName = GetDeviceName(deviceInfo);

            string message = string.Format(
                "[DEVICE_DISCOVERED] Device {0} does not appear to support HID " +
                "(UUID 0x1812).",
                deviceName);

            bool hasServicesMoreAvailAdField = 
                deviceInfo.ContainsKey(DeviceInfoType.ServicesMoreAvailableUuid16);

            bool hasServicesCompleteAdField = 
                deviceInfo.ContainsKey(DeviceInfoType.ServicesCompleteListUuid16);

            if (!hasServicesMoreAvailAdField && !hasServicesCompleteAdField)
            {
                AddToLog(message);
                return false;
            }

            bool hasHidServiceUuid = false;
            if (hasServicesMoreAvailAdField)
            {
                hasHidServiceUuid = 
                    deviceInfo[DeviceInfoType.ServicesMoreAvailableUuid16].Contains("0x1812");
            }
            else
            {
                hasHidServiceUuid = 
                    deviceInfo[DeviceInfoType.ServicesCompleteListUuid16].Contains("0x1812");
            }

            if (!hasHidServiceUuid)
            {
                AddToLog(message);
                return false;
            }

            /* If we have reached here it means all the criterias have passed. */
            return true;
        }

        /// <summary>
        /// Extract the device name from the advertising data.
        /// </summary>
        string GetDeviceName(IDictionary<DeviceInfoType, string> deviceInfo)
        {
            string deviceName = string.Empty;
            bool hasNameField = deviceInfo.ContainsKey(DeviceInfoType.CompleteLocalName);
            if (hasNameField)
            {
                deviceName = deviceInfo[DeviceInfoType.CompleteLocalName];
            }
            return deviceName;
        }

        /// <summary>
        /// This event handler is called when data has been received on any of our pipes.
        /// </summary>
        void OnDataReceived(object sender, PipeDataEventArgs arguments)
        {
            AddToLog(string.Format("Notification received on pipe {0}: {1}", 
                arguments.PipeNumber, BitConverter.ToString(arguments.PipeData)));
        }

        /// <summary>
        /// This event handler is called when a connection has been successfully established.
        /// </summary>
        void OnConnected(object sender, EventArgs arguments)
        {
            AddToLog("[CONNECTED]");

            /* The connection is up, proceed with Bond and pipe discovery. 
             * Using a background task in order not to block the event caller. */
            Task.Factory.StartNew(() =>
            {
                try
                {
                    connectionResetEvent.Reset();
                    Bond();
                    DiscoverPipes();
                    OpenRemotePipes();
                    ReadBatteryLevel();
                    WriteHidProtocolMode();
                    AddToLog("Ready");
                }
                catch (Exception ex)
                {
                    LogErrorMessage(string.Format("Exception in OnConnected: {0}", ex.Message),
                        ex.StackTrace);
                }
                finally
                {
                    connectionResetEvent.Set();
                }
            });
        }

        /// <summary>
        /// Example of read operation. Reading battery level attribute by calling 
        /// RequestData on the BatteryLevelPipe that was defined in pipesetup. 
        /// </summary>
        void ReadBatteryLevel()
        {
            byte[] batteryLevelData = masterEmulator.RequestData(pipeSetup.BatteryLevelPipe);
            byte batteryLevel = batteryLevelData[0];
            AddToLog(string.Format("Battery level was successfully read: {0}", batteryLevel));
        }

        /// <summary>
        /// Example of write operation. Writing data to HID Protocol Mode by calling SendData
        /// on the HidProtocolMode that was defined in pipesetup.
        /// </summary>
        void WriteHidProtocolMode()
        {
            byte[] protocolModeData = new byte[] { 0x01 };
            bool success = 
                masterEmulator.SendData(pipeSetup.HidProtocolModePipe, protocolModeData);
            if (success)
            {
                AddToLog(string.Format("HID Protocol Mode was successfully written: {0}", 
                    protocolModeData[0]));
            }
        }

        /// <summary>
        /// This event handler is called when a connection update request has been received.
        /// A connection update must be responded to in two steps: sending a connection update
        /// response, and performing the actual update.
        /// </summary>
        void OnConnectionUpdateRequest(object sender, ConnectionUpdateRequestEventArgs arguments)
        {
            Task.Factory.StartNew(() =>
            {
                masterEmulator.SendConnectionUpdateResponse(arguments.Identifier,
                    ConnectionUpdateResponse.Accepted);
                BtConnectionParameters updateParams = new BtConnectionParameters();
                updateParams.ConnectionIntervalMs = arguments.ConnectionIntervalMaxMs;
                updateParams.SupervisionTimeoutMs = arguments.ConnectionSupervisionTimeoutMs;
                updateParams.SlaveLatency = arguments.SlaveLatency;
                masterEmulator.UpdateConnectionParameters(updateParams);
            });
        }

        /// <summary>
        /// This event handler is called when a connection has been terminated.
        /// </summary>
        void OnDisconnected(object sender, ValueEventArgs<DisconnectReason> arguments)
        {
            connectionInProgress = false;
            AddToLog(string.Format("[DISCONNECTED] Reason: {0}", arguments.Value.ToString()));

            /* Starting a new device discovery, and if a device is found and is eligible,
             * then a new connection will be established (in the OnDeviceDiscovered handler). 
             * Running in a background task in order not to block the event */
            Task.Factory.StartNew(() =>
            {
                try
                {
                    connectionInProgress = false;
                    WaitForConnectionResetEvent();
                    StartDeviceDiscovery();
                }
                catch (Exception ex)
                {
                    LogErrorMessage(string.Format("Exception in OnDisconnected", ex.Message),
                        ex.StackTrace);
                }
            });
        }

        void WaitForConnectionResetEvent()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int totalTimeout = 60000;
            int waitTimeoutMs = 5000;
            bool waitSuccess = connectionResetEvent.WaitOne(waitTimeoutMs);
            while (!waitSuccess)
            {
                AddToLog(
                    string.Format("Waiting to restart device discovery, {0:D} seconds elapsed",
                    stopWatch.ElapsedMilliseconds / 1000));

                if (stopWatch.ElapsedMilliseconds > totalTimeout)
                {
                    throw new InvalidOperationException(
                        "Did not receive signal on connectionResetEvent within timeout.");
                }
                waitSuccess = connectionResetEvent.WaitOne(waitTimeoutMs);
            }
        }

        /// <summary>
        /// Relay received log message events to the log method.
        /// </summary>
        void OnLogMessage(object sender, ValueEventArgs<string> arguments)
        {
            AddToLog(string.Format("[LOG_MESSAGE]: {0}", arguments.Value));
        }

        /// <summary>
        /// This event is called when a passkey has been received with the DisplayPasskey event.
        /// </summary>
        void OnDisplayPasskey(object sender, ValueEventArgs<int> arguments)
        {
            AddToLog(string.Format("[DISPLAY_PASSKEY] Passkey: {0:D6}", arguments.Value));
        }
    }
}
