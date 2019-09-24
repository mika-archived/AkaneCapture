# QuickCapture

Fast, Lightweight and Easy QR-Code reader for Windows.


## Why QuickCapture

QuickCapture has the following features:

* Free to use.
  * If you like this software, please send the movie tweet of kawaii move to [@MikazukiFuyuno](https://twiter.com/MikazukiFuyuno).
* Reading results of QR codes are saved permanently.
* QuickCapture can also recognize QR code displayed in the background.
  * Background is a state that is hidden from other applications. 
* Support multiple displays.
  * QuickCapture captures single process, not monitors/displays.

Basically, it assumes QR code recognition in VR spaces/worlds like VRChat.


## Requirements

* .NET Framework 4.7
* Windows 10 1903 or greater
	* QuickCapture uses UWP Interop API


## How to use

In this example, VRChat is configured for the target application.


### Process Detection

1. Launch QuickCapture.
2. Launch VRChat.
3. Enjoy!


### Capture

1. Stare at the QR code that you want to capture for 3 seconds.
   1. You can change the gaze time from the settings. 
2. QuickCapture try to read QR code and store it.