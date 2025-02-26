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
        public DeviceManager()
        {
            _devices = new Dictionary<string, VirtualAVDevice>();
        }

        public void AddDevice(string deviceId)
        {
            if (string.IsNullOrEmpty(deviceId))
            {
                throw new ArgumentException("Device ID cannot be null or empty.");
            }

            if (_devices.ContainsKey(deviceId))
            {
                throw new DeviceOperationException($"Device with ID {deviceId} already exists.");
            }
                _devices.Add(deviceId, new VirtualAVDevice());
        }

        public void RemoveDevice(string deviceId)
        {
            if (string.IsNullOrWhiteSpace(deviceId))
            {
                throw new InvalidInputException("Device ID cannot be null or empty.");
            }

            if (!_devices.ContainsKey(deviceId))
            {
                throw new DeviceOperationException($"Device with ID {deviceId} not found.");
            }

            _devices.Remove(deviceId);
        }
        

        public VirtualAVDevice GetDevice(string deviceId)
        {
            if (string.IsNullOrWhiteSpace(deviceId))
            {
                throw new InvalidInputException("Device ID cannot be null or empty.");
            }

            if (!_devices.ContainsKey(deviceId))
            {
                throw new DeviceOperationException($"Device with ID {deviceId} not found.");
            }

            return _devices[deviceId];
        }

        public IEnumerable<VirtualAVDevice> GetDevices()
        {
            return _devices.Values;
        }


    }
}
