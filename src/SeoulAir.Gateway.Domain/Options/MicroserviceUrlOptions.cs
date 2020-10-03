namespace SeoulAir.Gateway.Domain.Options
{
    public abstract class MicroserviceUrlOptions : IMicroserviceUrlOptions
    {
        public string Address { get; set; }
        public int Port { get; set; }
    }
}
