using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SeoulAir.Gateway.Domain;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SeoulAir.Gateway.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("SeoulAirPolicy")]
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
            return StatusCode((int)response.StatusCode);
        }

        [HttpPut("AirQualitySensor/TurnOff")]
        public async Task<IActionResult> StopDeviceAsync()
        {
            HttpResponseMessage response = await _deviceService.StopDeviceAsync();
            return StatusCode((int)response.StatusCode);
        }

        [HttpGet("AirQualitySensor/IsOn")]
        public async Task<IActionResult> IsDeviceOnAsync()
        {
            HttpResponseMessage response = await _deviceService.IsDeviceOnAsync();
            ObjectResult result = new ObjectResult(await response.Content.ReadAsStringAsync());
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

        [HttpPut("AirQualitySensor/parameters/name/{name}")]
        public async Task<IActionResult> UpdateDeviceNameAsync(string name)
        {
            HttpResponseMessage response = await _deviceService.UpdateDeviceNameAsync(name);
            return StatusCode((int)response.StatusCode);
        }

        [HttpPut("AirQualitySensor/parameters/sendingDelayMs/{sendingDelayMs}")]
        public async Task<IActionResult> UpdateDeviceDelayAsync(string sendingDelayMs)
        {
            HttpResponseMessage response = await _deviceService.UpdateDeviceDelayAsync(sendingDelayMs);
            return StatusCode((int)response.StatusCode);
        }


        [HttpPut("SignalLight/TurnOn/{stationCode}")]
        public async Task<IActionResult> StartStationAsync(string stationCode)
        {
            HttpResponseMessage response = await _deviceService.StartStationAsync(stationCode);
            return StatusCode((int)response.StatusCode);
        }

        [HttpPut("SignalLight/TurnOff/{stationCode}")]
        public async Task<IActionResult> StopStationAsync(string stationCode)
        {
            HttpResponseMessage response = await _deviceService.StopStationAsync(stationCode);
            return StatusCode((int)response.StatusCode);
        }

        [HttpGet("SignalLight/IsOn/{stationCode}")]
        public async Task<IActionResult> IsStationOnAsync(string stationCode)
        {
            HttpResponseMessage response = await _deviceService.IsStationOnAsync(stationCode);
            ObjectResult result = new ObjectResult(await response.Content.ReadAsStringAsync());
            result.StatusCode = (int)response.StatusCode;
            return result;
        }

        [HttpGet("SignalLight/parameters")]
        public async Task<IActionResult> GetSignalLightParametersAsync()
        {
            HttpResponseMessage response = await _deviceService.GetSignalLightParametersAsync();

            string contentAsString = await response.Content.ReadAsStringAsync();
            ObjectResult result = new ObjectResult(JsonSerializer.Deserialize<object>(contentAsString));
            result.StatusCode = (int)response.StatusCode;
            return result;
        }

        [HttpGet("SignalLight/ActiveColor/{stationCode}")]
        public async Task<IActionResult> GetStationColorAsync(string stationCode)
        {
            HttpResponseMessage response = await _deviceService.GetStationColorAsync(stationCode);
            ObjectResult result = new ObjectResult(await response.Content.ReadAsStringAsync());
            result.StatusCode = (int)response.StatusCode;
            return result;
        }

        [HttpPut("SignalLight/ActiveColor/{stationCode}/{color}")]
        public async Task<IActionResult> UpdateStationColorAsync(string stationCode, string color)
        {
            HttpResponseMessage response = await _deviceService.UpdateStationColorAsync(stationCode, color);
            return StatusCode((int)response.StatusCode);
        }

    }
}
