using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using VirtualAVDeviceModule;

namespace VirtualAVDeviceTests
{
    public class VirtualAVDeviceTests
    {
        private readonly Mock<ILogger<VirtualAVDevice>> _mockLogger;

        public VirtualAVDeviceTests()
        {
            _mockLogger = new Mock<ILogger<VirtualAVDevice>>();
        }

        [Fact]
        public void PowerOn_ShouldTurnDeviceOn_AndLogInformation()
        {
            // Arrange
            var device = new VirtualAVDevice(_mockLogger.Object);

            // Act
            device.PowerOn();

            // Assert
            Assert.True(device.IsPowerOn);
            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Device powered on.")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()
                ),
                Times.Once
            );
        }

        [Fact]
        public void PowerOff_ShouldTurnDeviceOff_AndLogInformation()
        {
            // Arrange
            var device = new VirtualAVDevice(_mockLogger.Object);
            device.PowerOn(); // Ensure the device is on initially

            // Act
            device.PowerOff();

            // Assert
            Assert.False(device.IsPowerOn);
            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Device powered off.")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()
                ),
                Times.Once
            );
        }

        [Fact]
        public void SetVolume_InvalidValue_ShouldThrowException_AndLogError()
        {
            // Arrange
            var device = new VirtualAVDevice(_mockLogger.Object);

            // Act & Assert
            var exception = Assert.Throws<InvalidInputException>(() => device.SetVolume(150));
            Assert.Equal("Volume must be between 0 and 100.", exception.Message);

            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Volume must be between 0 and 100.")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()
                ),
                Times.Once
            );
        }
    }
   
}