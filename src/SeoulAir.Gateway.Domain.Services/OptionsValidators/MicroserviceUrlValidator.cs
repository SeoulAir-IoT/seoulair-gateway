﻿using Microsoft.Extensions.Options;
using SeoulAir.Gateway.Domain.Options;
using System.Collections.Generic;
using System.Linq;
using static SeoulAir.Gateway.Domain.Resources.Strings;

namespace SeoulAir.Gateway.Domain.Services.OptionsValidators
{
    public class MicroserviceUrlValidator : IValidateOptions<MicroserviceUrlOptions>
    {
        private const int PortMinNumber = 1024;
        private const int PortMaxNumber = 65535;

        public ValidateOptionsResult Validate(string name, MicroserviceUrlOptions options)
        {
            ICollection<string> failureMessages = new List<string>();

            if (string.IsNullOrEmpty(options.Address))
                failureMessages.Add(string.Format(
                    ParameterNullOrEmptyMessage,
                    nameof(options.Address)));

            if (options.Port < PortMinNumber || options.Port > PortMaxNumber)
                failureMessages.Add(string.Format(
                    ParameterBetweenMessage,
                    nameof(options.Port),
                    PortMinNumber,
                    PortMaxNumber));

            if (failureMessages.Any())
                return ValidateOptionsResult.Fail(failureMessages);

            return ValidateOptionsResult.Success;
        }
    }
}
