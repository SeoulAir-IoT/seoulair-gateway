using System.ComponentModel;

namespace SeoulAir.Gateway.Domain.Enums
{
    public enum DeviceControllers : byte
    {
        [Description("api/AirQualitySensor")]
        AirQualitySensor,
        [Description("api/SignalLight")]
        SignalLight,
    }
}
