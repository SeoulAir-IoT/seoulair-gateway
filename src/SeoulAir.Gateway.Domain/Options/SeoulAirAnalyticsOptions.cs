namespace SeoulAir.Gateway.Domain.Options
{
    public class SeoulAirAnalyticsOptions : MicroserviceUrlOptions
    {
        public static string AppSettingsPath { get; protected set; } 
            = "MicroserviceUrlOptions:SeoulAir.Analytics";
    }
}
