using SeoulAir.Gateway.Domain.Options;
using System;

namespace SeoulAir.Gateway.Domain.Builders
{
    public interface IMicroserviceUriBuilder
    {
        IMicroserviceUriBuilder UseMicroserviceUrlOptions(MicroserviceUrlOptions microserviceOptions);
        IMicroserviceUriBuilder UseController(string controllerName);
        IMicroserviceUriBuilder SetEndpoint(string endpoint);
        IMicroserviceUriBuilder AddQueryPrameter<TParameter>(string parameterName, TParameter value);
        Uri Build();
    }
}
