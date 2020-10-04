using Microsoft.Extensions.DependencyInjection;
using SeoulAir.Gateway.Domain.Builders;
using SeoulAir.Gateway.Domain.Services.Builders;

namespace SeoulAir.Gateway.Domain.Services.Extensions
{
    public static class DependencyExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IMicroserviceHttpRequestBuilder, MicroserviceHttpRequestBuilder>();
            services.AddScoped<IMicroserviceUriBuilder, MicroserviceUriBuilder>();
            services.AddScoped<IDeviceService, DeviceService>();

            return services;
        }
    }
}
