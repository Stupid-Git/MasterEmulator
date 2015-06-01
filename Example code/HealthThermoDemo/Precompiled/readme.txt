Temperature demo user guide

Requirements:
*************

1. Before using the TemperatureDemo application, make sure the Master Control Panel
   is installed. The Master Control Panel is delivered with the nRF8001 SDK and 
   provides drivers for the master emulator (nRF2739).

2. At least one master emulator (nRF2739) must be plugged in before running the application.

3. Extract the files from TemperatureDemo.zip.
 
4. Keep the DLLs in the same folder. The application uses the .Net framework so make sure you have .Net installed on 
your computer.

Starting the application and connecting to the key fob:
*******************************************************

1. Run the TemperatureDemo.exe, wait until the log view displays "Ready".

2. Wait until the message "Ready" appears in the log view.

3. Turn on the temperature demo by a short press on the button. If it has not been previously bonded it will enter Bond mode indicated by LED0 blinking. 
Otherwise, turn it off by a long press (until LED is OFF) and then do a long press from OFF (the LED1 starts to blink and after about 4 seconds, LED0 flashes then blinks and LED1 turn off)
Once in Bond mode (LED0 blinking): 
        1. The temperature demo should automatically appear in the "Device name" list, select it.
        3. Click "Bond" and wait until the bonding procedure is complete. The background
           of the "Temperature" pane should turn green. Then a temperature value should be received with the pane flashing in brown. Then the temperature demo should disconnect and turn off.
        4. Do a short press, the LED1 should blink briefly and the application should automatically connect and receive a new temperature. The temperature demo should turn off again after 
           the new temperature value has been received.
  
