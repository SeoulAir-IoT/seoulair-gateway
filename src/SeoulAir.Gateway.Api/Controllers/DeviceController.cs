using Microsoft.AspNetCore.Mvc;
using SeoulAir.Gateway.Domain;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SeoulAir.Gateway.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }


        [HttpPut("AirQualitySensor/TurnOn")]
        public async Task<IActionResult> StartDeviceAsync()
        {
            HttpResponseMessage response = await _deviceService.StartDeviceAsync();

            string contentAsString = await response.Content.ReadAsStringAsync();
            ObjectResult result = new ObjectResult(JsonSerializer.Deserialize<object>(contentAsString));
            result.StatusCode = (int)response.StatusCode;
            return result;
        }

        [HttpPut("AirQualitySensor/TurnOff")]
        public async Task<IActionResult> StopDeviceAsync()
        {
            HttpResponseMessage response = await _deviceService.StopDeviceAsync();

            string contentAsString = await response.Content.ReadAsStringAsync();
            ObjectResult result = new ObjectResult(JsonSerializer.Deserialize<object>(contentAsString));
            result.StatusCode = (int)response.StatusCode;
            return result;
        }

        [HttpGet("AirQualitySensor/IsOn")]
        public async Task<IActionResult> IsDeviceOnAsync()
        {
            HttpResponseMessage response = await _deviceService.IsDeviceOnAsync();

            string contentAsString = await response.Content.ReadAsStringAsync();
            ObjectResult result = new ObjectResult(JsonSerializer.Deserialize<object>(contentAsString));
            result.StatusCode = (int)response.StatusCode;
            return result;
        }

        [HttpGet("AirQualitySensor/parameters")]
        public async Task<IActionResult> GetDeviceParametersAsync()
        {
            HttpResponseMessage response = await _deviceService.GetDeviceParametersAsync();

            string contentAsString = await response.Content.ReadAsStringAsync();
            ObjectResult result = new ObjectResult(JsonSerializer.Deserialize<object>(contentAsString));
            result.StatusCode = (int)response.StatusCode;
            return result;
        }

        [HttpPut("AirQualitySensor/parametars/name")]
        public async Task<IActionResult> UpdateDeviceNameAsync(string name)
        {
            HttpResponseMessage response = await _deviceService.UpdateDeviceNameAsync(name);

            string contentAsString = await response.Content.ReadAsStringAsync();
            ObjectResult result = new ObjectResult(JsonSerializer.Deserialize<object>(contentAsString));
            result.StatusCode = (int)response.StatusCode;
            return result;
        }

        [HttpPut("AirQualitySensor/parametars/sendingDelayMs")]
        public async Task<IActionResult> UpdateDeviceDelayAsync(string delay)
        {
            HttpResponseMessage response = await _deviceService.UpdateDeviceDelayAsync(delay);

            string contentAsString = await response.Content.ReadAsStringAsync();
            ObjectResult result = new ObjectResult(JsonSerializer.Deserialize<object>(contentAsString));
            result.StatusCode = (int)response.StatusCode;
            return result;
        }


        [HttpPut("SignalLight/TurnOn")]
        public async Task<IActionResult> StartStationAsync()
        {
            HttpResponseMessage response = await _deviceService.StartStationAsync();

            string contentAsString = await response.Content.ReadAsStringAsync();
            ObjectResult result = new ObjectResult(JsonSerializer.Deserialize<object>(contentAsString));
            result.StatusCode = (int)response.StatusCode;
            return result;
        }

        [HttpPut("SignalLight/TurnOff")]
        public async Task<IActionResult> StopStationAsync()
        {
            HttpResponseMessage response = await _deviceService.StopStationAsync();

            string contentAsString = await response.Content.ReadAsStringAsync();
            ObjectResult result = new ObjectResult(JsonSerializer.Deserialize<object>(contentAsString));
            result.StatusCode = (int)response.StatusCode;
            return result;
        }

        [HttpGet("SignalLight/IsOn")]
        public async Task<IActionResult> IsStationOnAsync(string stationCode)
        {
            HttpResponseMessage response = await _deviceService.IsStationOnAsync(stationCode);

            string contentAsString = await response.Content.ReadAsStringAsync();
            ObjectResult result = new ObjectResult(JsonSerializer.Deserialize<object>(contentAsString));
            result.StatusCode = (int)response.StatusCode;
            return result;
        }

        [HttpGet("SignalLight/parametars")]
        public async Task<IActionResult> GetSignalLightParametersAsync()
        {
            HttpResponseMessage response = await _deviceService.GetSignalLightParametersAsync();

            string contentAsString = await response.Content.ReadAsStringAsync();
            ObjectResult result = new ObjectResult(JsonSerializer.Deserialize<object>(contentAsString));
            result.StatusCode = (int)response.StatusCode;
            return result;
        }

        [HttpGet("SignalLight/ActiveColor")]
        public async Task<IActionResult> GetStationColorAsync(string stationCode)
        {
            HttpResponseMessage response = await _deviceService.GetStationColorAsync(stationCode);

            string contentAsString = await response.Content.ReadAsStringAsync();
            ObjectResult result = new ObjectResult(JsonSerializer.Deserialize<object>(contentAsString));
            result.StatusCode = (int)response.StatusCode;
            return result;
        }

        [HttpPut("SignalLight/ActiveColor")]
        public async Task<IActionResult> UpdateStationColorAsync(string stationCode, string color)
        {
            HttpResponseMessage response = await _deviceService.UpdateStationColorAsync(stationCode, color);

            string contentAsString = await response.Content.ReadAsStringAsync();
            ObjectResult result = new ObjectResult(JsonSerializer.Deserialize<object>(contentAsString));
            result.StatusCode = (int)response.StatusCode;
            return result;
        }

    }
}
