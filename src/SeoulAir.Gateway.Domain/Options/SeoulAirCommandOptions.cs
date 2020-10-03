namespace SeoulAir.Gateway.Domain.Options
{
    public class SeoulAirCommandOptions : MicroserviceUrlOptions
    {
        public static string AppSettingsPath { get; protected set; } 
            = "MicroserviceUrlOptions:SeoulAir.Command";
    }
}
