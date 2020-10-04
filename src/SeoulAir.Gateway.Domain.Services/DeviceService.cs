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

        public async Task<HttpResponseMessage> GetParameters()
        {
            HttpResponseMessage response;

            _uriBuilder.Restart()
                .UseMicroserviceUrlOptions(_options)
                .UseController(DeviceControllers.Parameter.GetDescription());

            var request = _requestBuilder.Restart()
                .UseHttpMethod(HttpMethod.Get)
                .UseUri(_uriBuilder.Build())
                .Build();

            using(var client = _clientFactory.CreateClient())
            {
                response = await client.SendAsync(request);
            }

            return response;
        }

        public async Task<HttpResponseMessage> IsOn()
        {
            HttpResponseMessage response;

            _uriBuilder.Restart()
                .UseMicroserviceUrlOptions(_options)
                .UseController(DeviceControllers.Device.GetDescription());

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

        public HttpResponseMessage StartDevice()
        {
            throw new System.NotImplementedException();
        }

        public HttpResponseMessage StopDevice()
        {
            throw new System.NotImplementedException();
        }

        public HttpResponseMessage UpdateParameters()
        {
            throw new System.NotImplementedException();
        }
    }
}
