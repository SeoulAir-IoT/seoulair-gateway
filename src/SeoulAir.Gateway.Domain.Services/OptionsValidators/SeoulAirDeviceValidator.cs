using Microsoft.Extensions.Options;
using SeoulAir.Gateway.Domain.Options;

namespace SeoulAir.Gateway.Domain.Services.OptionsValidators
{
    public class SeoulAirDeviceValidator : MicroserviceUrlValidator, IValidateOptions<SeoulAirDeviceOptions>
    {
        public ValidateOptionsResult Validate(string name, SeoulAirDeviceOptions options)
        {
            return base.Validate(name, options);
        }
    }
}
