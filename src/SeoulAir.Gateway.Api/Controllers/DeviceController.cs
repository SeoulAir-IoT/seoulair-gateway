using Microsoft.AspNetCore.Mvc;
using SeoulAir.Gateway.Domain;
using System;
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

        [HttpGet("parameters")]
        public async Task<IActionResult> GetParameters()
        {
            HttpResponseMessage response = await _deviceService.GetParameters();

            string contentAsString = await response.Content.ReadAsStringAsync();
            ObjectResult result = new ObjectResult(JsonSerializer.Deserialize<object>(contentAsString));
            result.StatusCode = (int)response.StatusCode;
            return result;
        }

        [HttpPut("parameters")]
        public Task<IActionResult> UpdateParametes()
        {
            throw new NotImplementedException();
        }

        [HttpGet("isOn")]
        public Task<IActionResult> IsOn()
        {
            throw new NotImplementedException();
        }

        [HttpPut("start")]
        public Task<IActionResult> Start()
        {
            throw new NotImplementedException();
        }

        [HttpPut("stop")]
        public Task<IActionResult> Stop()
        {
            throw new NotImplementedException();
        }

    }
}
