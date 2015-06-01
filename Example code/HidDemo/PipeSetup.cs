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
using Nordicsemi;

namespace HidDemo
{
    internal class PipeSetup
    {
        /* Public properties for accessing discovered pipe IDs */
        public int DeviceNamePipe { get; private set; }
        public int BatteryLevelPipe { get; private set; }
        public int HidProtocolModePipe { get; private set; }
        public int HidReportPipe1 { get; private set; }
        public int HidReportPipe2 { get; private set; }
        public int HidReportPipe3 { get; private set; }

        public enum SetupMode
        {
            HidMouse,
            HidKeyboard
        }

        MasterEmulator masterEmulator;

        public PipeSetup(MasterEmulator master)
        {
            masterEmulator = master;
        }

        /// <summary>
        /// Pipe setup is performed by sequentially adding services, characteristics and
        /// descriptors. Pipes can be added to the characteristics and descriptors one wants
        /// to have access to from the application during runtime. A pipe assignment must
        /// be stated directly after the characteristic or descriptor it shall apply for.
        /// The pipe type chosen will affect what operations can be performed on the pipe
        /// at runtime. <see cref="Nordicsemi.PipeType"/>.
        /// </summary>
        /// 
        public void PerformPipeSetup(SetupMode mode)
        {
            switch (mode)
            {
                case SetupMode.HidKeyboard:
                    PerformHidKeyboardPipeSetup();
                    break;
                case SetupMode.HidMouse:
                    PerformHidMousePipeSetup();
                    break;
                default:
                    throw new ArgumentException("Invalid setup mode");
            }
        }

        void PerformSharedPipeSetup()
        {
            /* GAP service */
            BtUuid gapServiceUuid = new BtUuid(0x1800);
            masterEmulator.SetupAddService(gapServiceUuid, PipeStore.Remote);

            /* Device Name characteristic */
            BtUuid deviceNameUuid = new BtUuid(0x2A00);
            int deviceNameMaxLength = 0;
            byte[] deviceNameData = null;
            masterEmulator.SetupAddCharacteristicDefinition(deviceNameUuid, deviceNameMaxLength,
                deviceNameData);
            /* Using pipe type ReceiveRequest to enable read operations */
            DeviceNamePipe = masterEmulator.SetupAssignPipe(PipeType.ReceiveRequest);

            /* Battery service */
            BtUuid batteryServiceUuid = new BtUuid(0x180F);
            masterEmulator.SetupAddService(batteryServiceUuid, PipeStore.Remote);

            /* Battery level characteristic */
            BtUuid batteryLevelUuid = new BtUuid(0x2A19);
            int batterlLevelMaxLength = 0;
            byte[] batteryLevelData = null;
            masterEmulator.SetupAddCharacteristicDefinition(batteryLevelUuid, 
                batterlLevelMaxLength, batteryLevelData);
            BatteryLevelPipe = masterEmulator.SetupAssignPipe(PipeType.ReceiveRequest);
            
            /* HID service */
            BtUuid hidServiceUuid = new BtUuid(0x1812);
            masterEmulator.SetupAddService(hidServiceUuid, PipeStore.Remote);

            /* HID protocol mode characteristic */
            BtUuid hidProtocolModeUuid = new BtUuid(0x2A4E);
            int hidProtocolMaxLength = 1;
            byte[] hidProtocolData = null;
            masterEmulator.SetupAddCharacteristicDefinition(hidProtocolModeUuid,
                hidProtocolMaxLength, hidProtocolData);
            /* Using pipe type Transmit to enable write commands */
            HidProtocolModePipe = masterEmulator.SetupAssignPipe(PipeType.Transmit);
        }

        void PerformHidMousePipeSetup()
        {
            PerformSharedPipeSetup();

            /* HID Resport characteristic #1 */
            BtUuid hidReportUuid = new BtUuid(0x2A4D);
            int hidReportMaxLength = 0; /* Length is not applicable since pipe is not written to */
            byte[] hidReportData = null; /* Initial data not applicable since pipe is remote */
            masterEmulator.SetupAddCharacteristicDefinition(hidReportUuid,
                hidReportMaxLength, hidReportData);
            /* Using pipe type Receive to enable receiving notifications. */
            HidReportPipe1 = masterEmulator.SetupAssignPipe(PipeType.Receive);

            /* HID Report Reference descriptor #1*/
            BtUuid hidReportReferenceUuid = new BtUuid(0x2908);
            int hidReportReferenceMaxDataLength = 2;
            /* Specifying descriptor data in order to match specific instance */
            byte[] hidReportReference1Data = new byte[] { 0x01, 0x01 };
            masterEmulator.SetupAddCharacteristicDescriptor(hidReportReferenceUuid,
                hidReportReferenceMaxDataLength, hidReportReference1Data);

            /* HID Report characteristic #2 */
            masterEmulator.SetupAddCharacteristicDefinition(hidReportUuid,
                hidReportMaxLength, hidReportData);
            HidReportPipe2 = masterEmulator.SetupAssignPipe(PipeType.Receive);

            /* HID Report Reference descriptor #2 */
            byte[] hidReportReference2Data = new byte[] { 0x02, 0x01 };
            masterEmulator.SetupAddCharacteristicDescriptor(hidReportReferenceUuid,
                hidReportReferenceMaxDataLength, hidReportReference2Data);

            /* HID Report characteristic #3 */
            masterEmulator.SetupAddCharacteristicDefinition(hidReportUuid,
                hidReportMaxLength, hidReportData);
            HidReportPipe3 = masterEmulator.SetupAssignPipe(PipeType.Receive);

            /* HID Report Reference descriptor #3 */
            byte[] hidReportReference3Data = new byte[] { 0x03, 0x01 };
            masterEmulator.SetupAddCharacteristicDescriptor(hidReportReferenceUuid,
                hidReportReferenceMaxDataLength, hidReportReference3Data);
        }

        void PerformHidKeyboardPipeSetup()
        {
            PerformSharedPipeSetup();

            /* HID Resport characteristic #1 */
            BtUuid hidReportUuid = new BtUuid(0x2A4D);
            int hidReportMaxLength = 0;
            byte[] hidReportData = null;
            masterEmulator.SetupAddCharacteristicDefinition(hidReportUuid,
                hidReportMaxLength, hidReportData);
            HidReportPipe1 = masterEmulator.SetupAssignPipe(PipeType.Receive);

            /* HID Report Reference descriptor #1*/
            BtUuid hidReportReferenceUuid = new BtUuid(0x2908);
            int hidReportReferenceMaxDataLength = 2;
            byte[] hidReportReference1Data = new byte[] { 0x00, 0x01 };
            masterEmulator.SetupAddCharacteristicDescriptor(hidReportReferenceUuid,
                hidReportReferenceMaxDataLength, hidReportReference1Data);

            /* HID Report characteristic #2 */
            masterEmulator.SetupAddCharacteristicDefinition(hidReportUuid,
                hidReportMaxLength, hidReportData);
            HidReportPipe2 = masterEmulator.SetupAssignPipe(PipeType.Transmit);

            /* HID Report Reference descriptor #2 */
            byte[] hidReportReference2Data = new byte[] { 0x00, 0x02 };
            masterEmulator.SetupAddCharacteristicDescriptor(hidReportReferenceUuid,
                hidReportReferenceMaxDataLength, hidReportReference2Data);
        }

    }
}
