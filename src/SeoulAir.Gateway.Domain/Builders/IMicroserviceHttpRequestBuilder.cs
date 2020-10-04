using System;
using System.Net.Http;

namespace SeoulAir.Gateway.Domain.Builders
{
    public interface IMicroserviceHttpRequestBuilder
    {
        IMicroserviceHttpRequestBuilder UseUri(Uri uri);
        IMicroserviceHttpRequestBuilder UseHttpMethod(HttpMethod method);
        IMicroserviceHttpRequestBuilder UseRequestBody<TParameter>(TParameter parameter);
        HttpRequestMessage Build();
    }
}
