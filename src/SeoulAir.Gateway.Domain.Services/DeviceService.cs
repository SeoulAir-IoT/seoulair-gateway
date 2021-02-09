using Microsoft.Extensions.Options;
using SeoulAir.Gateway.Domain.Builders;
using SeoulAir.Gateway.Domain.Enums;
using SeoulAir.Gateway.Domain.Options;
using SeoulAir.Gateway.Domain.Services.Extensions;
using System.Net.Http;
using System.Threading.Tasks;

namespace SeoulAir.Gateway.Domain.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IMicroserviceHttpRequestBuilder _requestBuilder;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IMicroserviceUriBuilder _uriBuilder;
        private readonly SeoulAirDeviceOptions _options;

        public DeviceService(IMicroserviceUriBuilder uriBuilder,
                             IMicroserviceHttpRequestBuilder requestBuilder,
                             IOptions<SeoulAirDeviceOptions> options,
                             IHttpClientFactory clientFactory)
        {
            _requestBuilder = requestBuilder;
            _clientFactory = clientFactory;
            _uriBuilder = uriBuilder;
            _options = options.Value;
        }

        public async Task<HttpResponseMessage> StartDeviceAsync()
        {
            HttpResponseMessage response;

            _uriBuilder.Restart()
                .UseMicroserviceUrlOptions(_options)
                .UseController(DeviceControllers.AirQualitySensor.GetDescription())
                .SetEndpoint("TurnOn");

            var request = _requestBuilder.Restart()
                .UseHttpMethod(HttpMethod.Put)
                .UseUri(_uriBuilder.Build())
                .Build();

            using(var client = _clientFactory.CreateClient())
            {
                response = await client.SendAsync(request);
            }

            return response;
        }

        public async Task<HttpResponseMessage> StopDeviceAsync()
        {
            HttpResponseMessage response;

            _uriBuilder.Restart()
                .UseMicroserviceUrlOptions(_options)
                .UseController(DeviceControllers.AirQualitySensor.GetDescription())
                .SetEndpoint("TurnOff");

            var request = _requestBuilder.Restart()
                .UseHttpMethod(HttpMethod.Put)
                .UseUri(_uriBuilder.Build())
                .Build();

            using (var client = _clientFactory.CreateClient())
            {
                response = await client.SendAsync(request);
            }

            return response;
        }

        public async Task<HttpResponseMessage> IsDeviceOnAsync()
        {
            HttpResponseMessage response;

            _uriBuilder.Restart()
                .UseMicroserviceUrlOptions(_options)
                .UseController(DeviceControllers.AirQualitySensor.GetDescription())
                .SetEndpoint("IsOn");
                

            var request = _requestBuilder.Restart()
                .UseHttpMethod(HttpMethod.Get)
                .UseUri(_uriBuilder.Build())
                .Build();

            using (var client = _clientFactory.CreateClient())
            {
                response = await client.SendAsync(request);
            }

            return response;
        }

        public async Task<HttpResponseMessage> GetDeviceParametersAsync()
        {
            HttpResponseMessage response;

            _uriBuilder.Restart()
                .UseMicroserviceUrlOptions(_options)
                .UseController(DeviceControllers.AirQualitySensor.GetDescription())
                .SetEndpoint("parameters");

            var request = _requestBuilder.Restart()
                .UseHttpMethod(HttpMethod.Get)
                .UseUri(_uriBuilder.Build())
                .Build();

            using (var client = _clientFactory.CreateClient())
            {
                response = await client.SendAsync(request);
            }

            return response;
        }

        public async Task<HttpResponseMessage> UpdateDeviceNameAsync(string name)
        {
            HttpResponseMessage response;

            _uriBuilder.Restart()
                .UseMicroserviceUrlOptions(_options)
                .UseController(DeviceControllers.AirQualitySensor.GetDescription())
                .SetEndpoint("parameters/name")
                .AddPathParameter(name);

            var request = _requestBuilder.Restart()
                .UseHttpMethod(HttpMethod.Put)
                .UseUri(_uriBuilder.Build())
                .Build();

            using (var client = _clientFactory.CreateClient())
            {
                response = await client.SendAsync(request);
            }

            return response;
        }
        
        public async Task<HttpResponseMessage> UpdateDeviceDelayAsync(string sendingDelayMs)
        {
            HttpResponseMessage response;

            _uriBuilder.Restart()
                .UseMicroserviceUrlOptions(_options)
                .UseController(DeviceControllers.AirQualitySensor.GetDescription())
                .SetEndpoint("parameters/sendingDelayMs")
                .AddPathParameter(sendingDelayMs);

            var request = _requestBuilder.Restart()
                .UseHttpMethod(HttpMethod.Put)
                .UseUri(_uriBuilder.Build())
                .Build();

            using (var client = _clientFactory.CreateClient())
            {
                response = await client.SendAsync(request);
            }

            return response;
        }


        public async Task<HttpResponseMessage> StartStationAsync(string stationCode)
        {
            HttpResponseMessage response;

            _uriBuilder.Restart()
                .UseMicroserviceUrlOptions(_options)
                .UseController(DeviceControllers.SignalLight.GetDescription())
                .SetEndpoint("TurnOn")
				.AddPathParameter(stationCode);

            var request = _requestBuilder.Restart()
                .UseHttpMethod(HttpMethod.Put)
                .UseUri(_uriBuilder.Build())
                .Build();

            using (var client = _clientFactory.CreateClient())
            {
                response = await client.SendAsync(request);
            }

            return response;
        }

        public async Task<HttpResponseMessage> StopStationAsync(string stationCode)
        {
            HttpResponseMessage response;

            _uriBuilder.Restart()
                .UseMicroserviceUrlOptions(_options)
                .UseController(DeviceControllers.SignalLight.GetDescription())
                .SetEndpoint("TurnOff")
				.AddPathParameter(stationCode);

            var request = _requestBuilder.Restart()
                .UseHttpMethod(HttpMethod.Put)
                .UseUri(_uriBuilder.Build())
                .Build();

            using (var client = _clientFactory.CreateClient())
            {
                response = await client.SendAsync(request);
            }

            return response;
        }

        public async Task<HttpResponseMessage> IsStationOnAsync(string stationCode)
        {
            HttpResponseMessage response;

            _uriBuilder.Restart()
                .UseMicroserviceUrlOptions(_options)
                .UseController(DeviceControllers.SignalLight.GetDescription())
                .SetEndpoint("IsOn")
                .AddPathParameter(stationCode);


            var request = _requestBuilder.Restart()
                .UseHttpMethod(HttpMethod.Get)
                .UseUri(_uriBuilder.Build())
                .Build();

            using (var client = _clientFactory.CreateClient())
            {
                response = await client.SendAsync(request);
            }

            return response;
        }

        public async Task<HttpResponseMessage> GetSignalLightParametersAsync()
        {
            HttpResponseMessage response;

            _uriBuilder.Restart()
                .UseMicroserviceUrlOptions(_options)
                .UseController(DeviceControllers.SignalLight.GetDescription())
                .SetEndpoint("parameters");


            var request = _requestBuilder.Restart()
                .UseHttpMethod(HttpMethod.Get)
                .UseUri(_uriBuilder.Build())
                .Build();

            using (var client = _clientFactory.CreateClient())
            {
                response = await client.SendAsync(request);
            }

            return response;
        }

        public async Task<HttpResponseMessage> GetStationColorAsync(string stationCode)
        {
            HttpResponseMessage response;

            _uriBuilder.Restart()
                .UseMicroserviceUrlOptions(_options)
                .UseController(DeviceControllers.SignalLight.GetDescription())
                .SetEndpoint("ActiveColor")
                .AddPathParameter(stationCode);


            var request = _requestBuilder.Restart()
                .UseHttpMethod(HttpMethod.Get)
                .UseUri(_uriBuilder.Build())
                .Build();

            using (var client = _clientFactory.CreateClient())
            {
                response = await client.SendAsync(request);
            }

            return response;
        }

        public async Task<HttpResponseMessage> UpdateStationColorAsync(string stationCode, string color)
        {
            HttpResponseMessage response;

            _uriBuilder.Restart()
                .UseMicroserviceUrlOptions(_options)
                .UseController(DeviceControllers.SignalLight.GetDescription())
                .SetEndpoint("ActiveColor")
                .AddPathParameter(stationCode)
                .AddPathParameter(color);

            var request = _requestBuilder.Restart()
                .UseHttpMethod(HttpMethod.Put)
                .UseUri(_uriBuilder.Build())
                .Build();

            using (var client = _clientFactory.CreateClient())
            {
                response = await client.SendAsync(request);
            }

            return response;
        }

    }
}
