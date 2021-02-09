namespace SeoulAir.Gateway.Domain.Options
{
    public abstract class MicroserviceUrlOptions
    {
        public string Address { get; set; }
        public int Port { get; set; }
    }
}
