namespace SeoulAir.Gateway.Domain.Options
{
    public class SeoulAirDataOptions : MicroserviceUrlOptions
    {
        public static string AppSettingsPath { get; protected set; }
            = "MicroserviceUrlOptions:SeoulAir.Data";
    }
}
