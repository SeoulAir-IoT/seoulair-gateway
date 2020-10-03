using Microsoft.Extensions.Options;
using SeoulAir.Gateway.Domain.Options;

namespace SeoulAir.Gateway.Domain.Services.OptionsValidators
{
    public class SeoulAirAnalyticsValidator : MicroserviceUrlValidator, IValidateOptions<SeoulAirAnalyticsOptions>
    {
        public ValidateOptionsResult Validate(string name, SeoulAirAnalyticsOptions options)
        {
            return base.Validate(name, options);
        }
    }
}
