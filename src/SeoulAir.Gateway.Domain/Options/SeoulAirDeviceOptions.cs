namespace SeoulAir.Gateway.Domain.Options
{
    public class SeoulAirDeviceOptions : MicroserviceUrlOptions
    {
        public static string AppSettingsPath { get; protected set; } 
            = "MicroserviceUrlOptions:SeoulAir.Device";
    }
}
