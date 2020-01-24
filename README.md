# Data Collection in VR Systems

> **Project under development! Not functional yet!**

This project intends to create a Unity module that gathers signals from the Oculus Quest in real-time.

## Data Capture in Unity

Among the intended signals to collect:
- HMD position (*x, y, z*)
- HMD rotation (*roll, pitch, yaw*)
- Controllers position (*x, y, z*)
- Controllers rotation (*roll, pitch, yaw*)
- Audio from Microphone 
- Hands interactions (when active instead of controllers)

### Usage

1. Clone the repository and open the project in Unity.
	- Tested on Unity 2019.2.12f1
	
2. Install the [Oculus Integration](https://assetstore.unity.com/packages/tools/integration/oculus-integration-82022) package from the Unity Asset Store.
	- Tested with the version 12.0, which includes Utilities for Unity 1.44, Platform SDK 12.0, Avatar SDK 1.42, Spatializer 1.43, VoiceMod 1.0, and LipSync 1.43
### Acknowledgements
- [LSL4Unity](https://github.com/labstreaminglayer/LSL4Unity)