using Microsoft.Extensions.Options;
using SeoulAir.Gateway.Domain.Options;

namespace SeoulAir.Gateway.Domain.Services.OptionsValidators
{
    public class SeoulAirCommandValidator : MicroserviceUrlValidator, IValidateOptions<SeoulAirCommandOptions>
    {
        public ValidateOptionsResult Validate(string name, SeoulAirCommandOptions options)
        {
            return base.Validate(name, options);
        }
    }
}
