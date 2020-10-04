using SeoulAir.Gateway.Domain.Builders;
using SeoulAir.Gateway.Domain.Options;
using SeoulAir.Gateway.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web;

namespace SeoulAir.Gateway.Domain.Services.Builders
{
    public class MicroserviceUriBuilder : IMicroserviceUriBuilder
    {
        private readonly Dictionary<string, string> _queryParameters;
        private string Endpoint;
        private string ControllerName;
        private MicroserviceUrlOptions MicroserviceUrlOptions;

        public MicroserviceUriBuilder()
        {
            _queryParameters = new Dictionary<string, string>();
        }

        public MicroserviceUriBuilder(MicroserviceUrlOptions options) : this()
        {
            MicroserviceUrlOptions = options;
        }

        public IMicroserviceUriBuilder AddQueryPrameter<TParameter>(string parameterName, TParameter value)
        {
            if (parameterName == default)
                throw new ArgumentNullException(nameof(parameterName));

            if (value.Equals(default(TParameter)))
                throw new ArgumentNullException(nameof(value));

            _queryParameters.Add(parameterName, value.ToString());
            return this;
        }

        public Uri Build()
        {
            ValidateProperties();

            UriBuilder builder = new UriBuilder();
            builder.Scheme = "http";
            builder.Host = MicroserviceUrlOptions.Address;
            builder.Port = MicroserviceUrlOptions.Port;
            builder.Path = BuildPath();
            builder.Query = BuildQuery();

            return builder.Uri;
        }

        public IMicroserviceUriBuilder SetEndpoint(string endpoint)
        {
            if (endpoint == default)
                throw new ArgumentNullException(nameof(endpoint));

            Endpoint = endpoint.ToLower().Trim();
            return this;
        }

        public IMicroserviceUriBuilder UseController(string controllerName)
        {
            if (controllerName == default)
                throw new ArgumentNullException(nameof(controllerName));

            ControllerName = controllerName.ToLower().Trim();
            return this;
        }

        public IMicroserviceUriBuilder UseMicroserviceUrlOptions(MicroserviceUrlOptions microserviceOptions)
        {
            if (microserviceOptions == default)
                throw new ArgumentNullException(nameof(microserviceOptions));

            if (microserviceOptions.Address == default || microserviceOptions.Port == default)
                throw new ArgumentException(string.Format(Strings.InvalidParameterValueMessage, nameof(microserviceOptions)));

            MicroserviceUrlOptions = microserviceOptions;
            return this;
        }

        private string BuildPath()
        {
            StringBuilder path = new StringBuilder("/");
            path.Append(ControllerName);
            path.Append("/");
            path.Append(Endpoint);
            return path.ToString();
        }

        private string BuildQuery()
        {
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

            foreach(var nameValue in _queryParameters)
                queryString.Add(nameValue.Key, nameValue.Value);

            return queryString.ToString();
        }

        private void ValidateProperties()
        {
            if (MicroserviceUrlOptions == default)
                throw new ArgumentNullException(nameof(MicroserviceUrlOptions));

            if (ControllerName == default)
                throw new ArgumentNullException(nameof(ControllerName));
        }
    }
}
