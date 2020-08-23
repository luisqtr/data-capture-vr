# PortalSense dev-kit

## Initial Setup

*Tested in Unity 2019.4 LTS.*

- Requires the installation of **XR Package Management** with *Oculus* plugin provider.

## LSL-communication

The *.so* libraries in the path **LSL/Plugins/Android/libs/arm-v8a/\*.so** were compiled in Android Studio specifically for ARMv64 architecture *(minSDK=24)*

- In **Player Settings > Other Settings**: Compile the application with IL2CPP backend and enable only targt architecture ARM64.

