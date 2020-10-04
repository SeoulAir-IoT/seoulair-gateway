using System.ComponentModel;

namespace SeoulAir.Gateway.Domain.Enums
{
    public enum DeviceControllers : byte
    {
        [Description("api/Device")]
        Device,
        [Description("api/Parameters")]
        Parameter,
    }
}
