using System.Net.Http;
using System.Threading.Tasks;

namespace SeoulAir.Gateway.Domain
{
    public interface IDeviceService
    {
        HttpResponseMessage StartDevice();
        HttpResponseMessage StopDevice();
        Task<HttpResponseMessage> IsOn();
        Task<HttpResponseMessage> GetParameters();
        HttpResponseMessage UpdateParameters();
    }
}
