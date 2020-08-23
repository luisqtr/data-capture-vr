# Data Collection in VR Systems

> **Project under development! Not functional yet!**

This project intends to create a Unity module that gathers signals from the Oculus Quest in real-time.

[LabStreamingLayer](https://github.com/sccn/labstreaminglayer) is used to send real-time data from the application running in Oculus Quest.

The project is comprised by two modules:
1. DataReceiver: 
1. DataStreaming: 

## Dev

Tested on Unity 2019.4.1f1. To use in your project is it necessary to install manually the following packages:
- XR Interaction Toolkit 0.9.4 (*preview*)

The project **DataStreaming** needs to be configured in such a way that makes it compatible with the library LSL. The main manual configurations are:
- Change Platform to Android.
- Install XR Plugin Management (with Oculus-Plugin provider)

All other settings are likely to be configure by default from the project settings. However, in case of problems in compilation or package communication, check the following settings compiling appear:

**Project Settings > Player > Other Settings**
- Color Space **Linear**
- Multithreaded Rendering **Checked**
- Low Overhead Mode **Checked** (Used to skip error checking in release, might not be available in some versions of Unity)
- Minimum API **23** (minimum version compatible with Oculus Quest)
- Target API **Automatic**
- Scripting Backend **IL2CPP** (Necessary to compile native library LSL)
- Install location **Automatic**
- Internet Access **Require** (Necessary for network communication)
- Target Architectures (ARMv7 **Unchecked**, ARM64 **Checked**). *The microprocessor of the Oculus Quest is architecture arm-v8a*

According to Oculus dev, the recommended rendering settings for Oculus Quest are *(updated 2020-08-15)*:
**Project Settings > Quality > Other Settings**
- Pixel Light Count set to **1**
- Texture Quality **Full Res**
- Anisotropic Textures **Per Texture**
- Anti Aliasing **4x**
- Soft Particles **Unchecked**
- Realtime Reflection Probes **Checked**
- Billboards Face Camera **Checked**

## Data Receiver

This module contains the interface that receives all the data sent from the Oculus Quest. Keep in mind that the computer running the receiver app and the Oculus Quest should be in the same local network.

## Data Streaming for Oculus Quest

**CURRENTLY**
Among the intended signals to collect:
- HMD position (*x, y, z*)
- HMD rotation (*roll, pitch, yaw*)
- Controllers position (*x, y, z*)
- Controllers rotation (*roll, pitch, yaw*)

**FUTURE**
- Hands interactions (when active instead of controllers)
- Audio from Microphone 

### Acknowledgements
- [LabStreamingLayer](https://github.com/sccn/labstreaminglayer)