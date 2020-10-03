using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SeoulAir.Gateway.Domain.Options;
using SeoulAir.Gateway.Domain.Services.OptionsValidators;

namespace SeoulAir.Gateway.Api.Configuration.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            return services;
        }


        public static IServiceCollection AddApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SeoulAirAnalyticsOptions>(
                configuration.GetSection(SeoulAirAnalyticsOptions.AppSettingsPath));
            services.AddSingleton<IValidateOptions<SeoulAirAnalyticsOptions>, SeoulAirAnalyticsValidator>();

            services.Configure<SeoulAirCommandOptions>(
                configuration.GetSection(SeoulAirCommandOptions.AppSettingsPath));
            services.AddSingleton<IValidateOptions<SeoulAirCommandOptions>, SeoulAirCommandValidator>();

            services.Configure<SeoulAirDataOptions>(
                configuration.GetSection(SeoulAirDataOptions.AppSettingsPath));
            services.AddSingleton<IValidateOptions<SeoulAirDataOptions>, SeoulAirDataValidator>();

            services.Configure<SeoulAirDeviceOptions>(
                configuration.GetSection(SeoulAirDeviceOptions.AppSettingsPath));
            services.AddSingleton<IValidateOptions<SeoulAirDeviceOptions>, SeoulAirDeviceValidator>();

            return services;
        }
    }
}
