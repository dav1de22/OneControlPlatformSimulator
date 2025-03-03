using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VirtualAVDeviceModule
{
    public class DeviceManager
    {
        private Dictionary<string, VirtualAVDevice> _devices;
        private ILogger<DeviceManager> _logger;
        public DeviceManager(ILogger<DeviceManager> logger)
        {
            _devices = new Dictionary<string, VirtualAVDevice>();
            _logger = logger;
        }

        public void AddDevice(string deviceId)
        {
            if (string.IsNullOrEmpty(deviceId))
            {
                _logger.LogError("Device ID cannot be null or empty.");
                throw new ArgumentException("Device ID cannot be null or empty.");
            }

            if (_devices.ContainsKey(deviceId))
            {
                _logger.LogError($"Device with ID {deviceId} already exists.");
                throw new DeviceOperationException($"Device with ID {deviceId} already exists.");
            }
            _logger.LogInformation($"Adding device with ID {deviceId}.");
            _devices.Add(deviceId, new VirtualAVDevice());
        }

        public void RemoveDevice(string deviceId)
        {
            if (string.IsNullOrWhiteSpace(deviceId))
            {
                _logger.LogError("Device ID cannot be null or empty.");
                throw new InvalidInputException("Device ID cannot be null or empty.");
            }

            if (!_devices.ContainsKey(deviceId))
            {
                _logger.LogError($"Device with ID {deviceId} not found.");
                throw new DeviceOperationException($"Device with ID {deviceId} not found.");
            }

            _logger.LogInformation($"Removing device with ID {deviceId}.");
            _devices.Remove(deviceId);
        }
        

        public VirtualAVDevice GetDevice(string deviceId)
        {
            if (string.IsNullOrWhiteSpace(deviceId))
            {
                _logger.LogError("Device ID cannot be null or empty.");
                throw new InvalidInputException("Device ID cannot be null or empty.");
            }

            if (!_devices.ContainsKey(deviceId))
            {
                _logger.LogError($"Device with ID {deviceId} not found.");
                throw new DeviceOperationException($"Device with ID {deviceId} not found.");
            }
            _logger.LogInformation($"Getting device with ID {deviceId}.");
            return _devices[deviceId];
        }

        public IEnumerable<VirtualAVDevice> GetDevices()
        {
            _logger.LogInformation("Getting all devices.");
            return _devices.Values;
        }


    }
}
