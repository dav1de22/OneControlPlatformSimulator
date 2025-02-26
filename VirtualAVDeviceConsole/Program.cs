using System;
using VirtualAVDeviceModule;

class Program
{
    static void Main(string[] args)
    {
        // Create a device manager and add a device
        var deviceManager = new DeviceManager();
        deviceManager.AddDevice("Projector1");

        // Get the device
        var device = deviceManager.GetDevice("Projector1");

        // Interact with the device
        device.PowerOn();
        device.SetVolume(75);
        device.SetBrightness(80);
        device.SetInputSource("HDMI2");

        // Print device status
        Console.WriteLine(device.GetStatus());

        // Turn off the device
        device.PowerOff();
        Console.WriteLine(device.GetStatus());
    }
}