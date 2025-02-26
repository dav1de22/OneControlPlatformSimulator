# **One Control Platform Simulator**

## **Overview**
The **One Control Platform Simulator** is a .NET-based project that simulates controlling virtual Audio-Visual (AV) devices. It includes:
- A **C# class library** (`VirtualAVDeviceModule`) for managing virtual AV devices.
- A **console application** (`VirtualAVDeviceConsole`) for testing the module.
- An **ASP.NET Core Web API** (`OneControlPlatformAPI`) for exposing device control functionality via RESTful endpoints.
- **Unit tests** (`VirtualAVDeviceTests`) to ensure the module works as expected.

This project demonstrates software development, API integration, error handling, and logging in a .NET environment.

---

## **Features**
- **Virtual AV Device Management:**
  - Power on/off devices.
  - Adjust volume, brightness, and input source.
  - Retrieve device status.
- **RESTful API:**
  - Exposes endpoints for controlling and querying devices.
  - Handles errors gracefully and logs all operations.
- **Logging:**
  - Logs information, warnings, and errors to the console.
  - Supports structured logging for better debugging.
- **Unit Testing:**
  - Comprehensive unit tests for the `VirtualAVDevice` module.

---

## **Technologies Used**
- **.NET 6.0** (or .NET 7.0)
- **ASP.NET Core** for the Web API.
- **xUnit** for unit testing.
- **Microsoft.Extensions.Logging** for logging.
- **Swagger** for API documentation.

---

## **Getting Started**

### **Prerequisites**
- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) (or later).
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/).
- (Optional) [Postman](https://www.postman.com/) for testing the API.

---

### **Setup**
1. **Clone the Repository:**
   ```bash
   git clone https://github.com/your-username/OneControlPlatformSimulator.git
   cd OneControlPlatformSimulator
   ```

2. **Open the Solution:**
   - Open the `OneControlPlatformSimulator.sln` file in Visual Studio or Visual Studio Code.

3. **Restore Dependencies:**
   - Run the following command to restore NuGet packages:
     ```bash
     dotnet restore
     ```

4. **Build the Solution:**
   - Run the following command to build the solution:
     ```bash
     dotnet build
     ```

---

### **Running the Project**

#### **1. Console Application**
- Navigate to the `VirtualAVDeviceConsole` project:
  ```bash
  cd VirtualAVDeviceConsole
  ```
- Run the application:
  ```bash
  dotnet run
  ```
- The console application will simulate controlling a virtual AV device.

#### **2. Web API**
- Navigate to the `OneControlPlatformAPI` project:
  ```bash
  cd OneControlPlatformAPI
  ```
- Run the API:
  ```bash
  dotnet run
  ```
- Open a browser and navigate to `https://localhost:5001/swagger` to access the Swagger UI.

#### **3. Unit Tests**
- Navigate to the `VirtualAVDeviceTests` project:
  ```bash
  cd VirtualAVDeviceTests
  ```
- Run the tests:
  ```bash
  dotnet test
  ```

---

## **API Documentation**

### **Endpoints**
- **GET `/api/devices`**
  - Returns a list of all device IDs.
- **GET `/api/devices/{deviceId}/status`**
  - Returns the status of the specified device.
- **POST `/api/devices/{deviceId}/power`**
  - Powers the device on or off. Use query parameter `state=on` or `state=off`.
- **POST `/api/devices/{deviceId}/volume`**
  - Sets the volume of the device. Use query parameter `volume={value}`.
- **POST `/api/devices/{deviceId}/brightness`**
  - Sets the brightness of the device. Use query parameter `brightness={value}`.
- **POST `/api/devices/{deviceId}/input`**
  - Sets the input source of the device. Use query parameter `inputSource={value}`.

### **Example Requests**
1. **Get Device Status:**
   ```bash
   GET https://localhost:5001/api/devices/Projector1/status
   ```

2. **Power On a Device:**
   ```bash
   POST https://localhost:5001/api/devices/Projector1/power?state=on
   ```

3. **Set Volume:**
   ```bash
   POST https://localhost:5001/api/devices/Projector1/volume?volume=75
   ```

4. **Set Brightness:**
   ```bash
   POST https://localhost:5001/api/devices/Projector1/brightness?brightness=80
   ```

5. **Set Input Source:**
   ```bash
   POST https://localhost:5001/api/devices/Projector1/input?inputSource=HDMI2
   ```

---

## **Logging**
Logs are written to the console by default. You can configure logging in the `appsettings.json` file:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```

---



---

## **License**
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

## **Acknowledgments**
- Thanks to the .NET team for providing a robust framework.
- Inspired by real-world AV control systems.

---

## **Contact**
For questions or feedback, please contact:
- **David Deidda**  
- **Email:** deiddadavideau@gmail.com
