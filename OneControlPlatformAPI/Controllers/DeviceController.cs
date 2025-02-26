using Microsoft.AspNetCore.Mvc;
using VirtualAVDeviceModule;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace OneControlPlatformAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly DeviceManager _deviceManager;
        private readonly ILogger<DeviceController> _logger;

        public DeviceController(ILogger<DeviceController> logger)
        {
            _deviceManager = new DeviceManager();
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _logger.LogInformation("Getting all devices.");
            return Ok(_deviceManager.GetDevices());
        }
        [HttpGet("{deviceId}/status")]
        public ActionResult<string> GetStatus(string deviceId)
        {
            _logger.LogInformation($"Getting status for device {deviceId}.");
            try
            {
                var device = _deviceManager.GetDevice(deviceId);
                return Ok(device.GetStatus());
            }
            catch (DeviceOperationException ex)
            {
                _logger.LogError(ex, $"Device operation failed for device: {deviceId}");
                return NotFound(ex.Message);
            }
            catch (InvalidInputException ex)
            {
                _logger.LogError(ex, $"Invalid input for device: {deviceId}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{deviceId}/power")]
        public ActionResult SwitchOnOff(string deviceId, bool state)
        {
            _logger.LogInformation($"Switching device {deviceId} to state {state}.");
            try
            {
                var device = _deviceManager.GetDevice(deviceId);
                if (state)
                {
                    device.PowerOn();
                    return Ok("Device powered on.");
                }
                else
                {
                    device.PowerOff();
                    return Ok("Device powered off.");
                }
            }
            catch (DeviceOperationException ex)
            {
                _logger.LogWarning($"Invalid power state requested: {state}");
                return NotFound(ex.Message);
            }
            catch (InvalidInputException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{deviceId}/volume")]
        public ActionResult SetVolume(string deviceId, int volume)
        {
            try
            {
                var device = _deviceManager.GetDevice(deviceId);
                device.SetVolume(volume);
                return Ok("Volume set to " + volume);
            }
            catch (DeviceOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidInputException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{deviceId}/brightness")]
        public ActionResult SetBrightness(string deviceId, int brightness)
        {
            try
            {
                var device = _deviceManager.GetDevice(deviceId);
                device.SetBrightness(brightness);
                return Ok("Brightness set to " + brightness);
            }
            catch (DeviceOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidInputException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{deviceId}/input")]
        public ActionResult SetInputSource(string deviceId, string inputSource)
        {
            try
            {
                var device = _deviceManager.GetDevice(deviceId);
                device.SetInputSource(inputSource);
                return Ok("Input source set to " + inputSource);
            }
            catch (DeviceOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidInputException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

