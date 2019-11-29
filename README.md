# AkaneCapture

Fast, Lightweight and Easy 2D bar-code reader for Windows.

## Why AkaneCapture

AkaneCapture has the following features:

- Free to use.
  - If you like this software, please send the movie tweet of the kawaii move to [@MikazukiFuyuno](https://twitter.com/MikazukiFuyuno).
- Reading results of 2D bar-codes are saved permanently.
- AkaneCapture can also recognize 2D bar-code displayed in the background.
  - The background is a state that is hidden from other applications.
- Support multiple displays.
  - AkaneCapture captures a single process, not monitors/displays.
- Support multiple bar-codes in the same frame.
- Send notification when AkaneCapture successfully reads 2D bar-codes.

It assumes 2D bar-code recognition in VR spaces/worlds like VRChat.

## Requirements

- .NET Core 3.x
- Windows 10 1903 or greater
  - \* AkaneCapture uses UWP Interop API that added in Windows 10 May 2019 Update.

## How to use

In this example, VRChat is configured for the target application.

### Process Detection

1. Launch AkaneCapture.
2. Launch VRChat.
3. Enjoy!

AkaneCapture can initiate capture in any order of startup as long as the process is running.

### Capture

1. Stare at the 2D bar-code that you want to capture for 5 seconds.
   1. You can change the gaze time from the settings.
2. AkaneCapture try to read 2D bar-code and store it.

## Test

This application has been tested in the following environments:

- VRChat (Steam) + Desktop PC (Desktop Mode)
- VRChat (Steam) + Oculus Rift S (SteamVR Mode)
- VRChat (Steam) + Valve Index (SteamVR Mode)
- VRChat (Oculus) + Desktop PC (Desktop Mode)
- VRChat (Oculus) + Oculus Rift S (VR Mode)
