namespace VirtualAVDeviceModule
{
    public class VirtualAVDevice
    {
        public bool IsPowerOn { get; private set; }
        public int Volume { get; private set; }
        public int Brightness { get; private set; }
        public string InputSource { get; private set; }

        public VirtualAVDevice()
        {
            IsPowerOn = false;
            Volume = 10;
            Brightness = 50;
            InputSource = "HDMI1";
        }

        public void PowerOn()
        {
            if (IsPowerOn)
            {
                throw new DeviceOperationException("Device is already powered on.");
            }

            IsPowerOn = true;
        }
        public void PowerOff()
        {
            if (!IsPowerOn)
            {
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
                throw new DeviceOperationException("Device is powered off. Cannot set input source.");
            }

        }

        public string GetStatus()
        {
            if (IsPowerOn)
            {
                return $"Powered: {(IsPowerOn ? "On" : "Off")}, Volume: {Volume}, Brightness: {Brightness}, Input: {InputSource}";
            }
            else
            {
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
