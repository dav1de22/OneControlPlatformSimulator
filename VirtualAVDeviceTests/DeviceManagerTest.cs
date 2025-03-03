using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using VirtualAVDeviceModule;

namespace VirtualAVDeviceTests
{
    public class DeviceManagerTests
    {
        private readonly Mock<ILogger<DeviceManager>> _mockLogger;

        public DeviceManagerTests()
        {
            _mockLogger = new Mock<ILogger<DeviceManager>>();
        }

        [Fact]
        public void AddDevice_ShouldAddDevice_AndLogInformation()
        {
            // Arrange
            var deviceManager = new DeviceManager(_mockLogger.Object);

            // Act
            deviceManager.AddDevice("Projector1");

            // Assert
            var device = deviceManager.GetDevice("Projector1");
            Assert.NotNull(device);

            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Added device with ID: Projector1")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()
                ),
                Times.Once
            );
        }

        [Fact]
        public void GetDevice_WhenDeviceDoesNotExist_ShouldThrowException_AndLogError()
        {
            // Arrange
            var deviceManager = new DeviceManager(_mockLogger.Object);

            // Act & Assert
            var exception = Assert.Throws<DeviceOperationException>(() => deviceManager.GetDevice("NonExistentDevice"));
            Assert.Equal("Device with ID NonExistentDevice not found.", exception.Message);

            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Device with ID NonExistentDevice not found.")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()
                ),
                Times.Once
            );
        }

        [Fact]
        public void RemoveDevice_ShouldRemoveDevice_AndLogInformation()
        {
            // Arrange
            var deviceManager = new DeviceManager(_mockLogger.Object);
            deviceManager.AddDevice("Projector1");

            // Act
            deviceManager.RemoveDevice("Projector1");

            // Assert
            Assert.Throws<DeviceOperationException>(() => deviceManager.GetDevice("Projector1"));

            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Removed device with ID: Projector1")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()
                ),
                Times.Once
            );
        }
    }
}