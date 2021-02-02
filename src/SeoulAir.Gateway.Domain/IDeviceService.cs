using System.Net.Http;
using System.Threading.Tasks;

namespace SeoulAir.Gateway.Domain
{
    public interface IDeviceService
    {
        Task<HttpResponseMessage> StartDeviceAsync();
        Task<HttpResponseMessage> StopDeviceAsync();
        Task<HttpResponseMessage> IsDeviceOnAsync();
        Task<HttpResponseMessage> GetDeviceParametersAsync();
        Task<HttpResponseMessage> UpdateDeviceNameAsync(string name);
        Task<HttpResponseMessage> UpdateDeviceDelayAsync(string sendingDelayMs);

        Task<HttpResponseMessage> StartStationAsync(string stationCode);
        Task<HttpResponseMessage> StopStationAsync(string stationCode);
        Task<HttpResponseMessage> IsStationOnAsync(string stationCode);
        Task<HttpResponseMessage> GetSignalLightParametersAsync();
        Task<HttpResponseMessage> GetStationColorAsync(string stationCode);
        Task<HttpResponseMessage> UpdateStationColorAsync(string stationCode, string color);

    }
}
