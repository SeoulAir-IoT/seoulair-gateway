using Microsoft.Extensions.Options;
using SeoulAir.Gateway.Domain.Options;

namespace SeoulAir.Gateway.Domain.Services.OptionsValidators
{
    public class SeoulAirDataValidator : MicroserviceUrlValidator, IValidateOptions<SeoulAirDataOptions>
    {
        public ValidateOptionsResult Validate(string name, SeoulAirDataOptions options)
        {
            return base.Validate(name, options);
        }
    }
}
