using Microsoft.Extensions.Logging;

namespace VirtualAVDeviceModule
{
    public class VirtualAVDevice
    {
        public bool IsPowerOn { get; private set; }
        public int Volume { get; private set; }
        public int Brightness { get; private set; }
        public string InputSource { get; private set; }
        private ILogger<VirtualAVDevice> _logger;
        public VirtualAVDevice(ILogger<VirtualAVDevice> logger)
        {
            IsPowerOn = false;
            Volume = 10;
            Brightness = 50;
            InputSource = "HDMI1";
            _logger = logger;
        }
        public VirtualAVDevice()
        {
            IsPowerOn = false;
            Volume = 10;
            Brightness = 50;
            InputSource = "HDMI1";
            _logger = new LoggerFactory().CreateLogger<VirtualAVDevice>();
        }

        public void PowerOn()
        {
            if (IsPowerOn)
            {
                _logger.LogError("Device is already powered on.");
                throw new DeviceOperationException("Device is already powered on.");
            }

            IsPowerOn = true;
        }
        public void PowerOff()
        {
            if (!IsPowerOn)
            {
                _logger.LogError("Device is already powered off.");
                throw new DeviceOperationException("Device is already powered off.");
            }
            IsPowerOn = false;
        }

        public void SetVolume(int volume)
        {
            if (IsPowerOn)
            {
                if (volume < 0) volume = 0;
                if (volume > 100) volume = 100;


                Volume = volume;
            }
            else
            {
                _logger.LogError("Device is powered off. Cannot set volume.");
                throw new DeviceOperationException("Device is powered off. Cannot set volume.");
            }
        }

        public void SetBrightness(int brightness)
        {
            if (IsPowerOn)
            {
            if (brightness < 0) brightness = 0;
            if (brightness > 100) brightness = 100;
            Brightness = brightness;
                
            }
            else
            {

                throw new DeviceOperationException("Device is powered off. Cannot set brightness.");
            }
        }

        public void SetInputSource(string inputSource)
        {
            if (string.IsNullOrEmpty(inputSource))
            {
                throw new InvalidInputException("Input source cannot be empty.");
            }
            if (IsPowerOn)
            {
                InputSource = inputSource;
            }
            else
            {
                _logger.LogError("Device is powered off. Cannot set input source.");
                throw new DeviceOperationException("Device is powered off. Cannot set input source.");
            }

        }

        public string GetStatus()
        {
            if (IsPowerOn)
            {
                _logger.LogInformation("Getting device status.");
                return $"Powered: {(IsPowerOn ? "On" : "Off")}, Volume: {Volume}, Brightness: {Brightness}, Input: {InputSource}";
            }
            else
            {
                _logger.LogInformation("Getting device status.");
                return "Powered: Off";
            }
           

        }


    }

    // Custom exception for invalid device operations
    public class DeviceOperationException : Exception
    {
        public DeviceOperationException(string message) : base(message) { }
    }

    // Custom exception for invalid input values
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
    }
}
