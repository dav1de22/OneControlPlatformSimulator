using System;
using VirtualAVDeviceModule;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;


class Program
{
    static void Main(string[] args)
    {
        // Setup service collection
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        // Build service provider
        var serviceProvider = serviceCollection.BuildServiceProvider();

        // Get the DeviceManager from the service provider
        var deviceManager = serviceProvider.GetRequiredService<DeviceManager>();

        // Add a device
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

    private static void ConfigureServices(IServiceCollection services)
    {
        // Register DeviceManager as a singleton
        services.AddSingleton<DeviceManager>();
        // Add other necessary services here
    }
}
