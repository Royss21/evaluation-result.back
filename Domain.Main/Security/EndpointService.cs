namespace Domain.Main.Security
{
    public class EndpointService : BaseModel<string>
    {
        public string Entity { get; set; } = string.Empty;
        public string Method { get; set; } = string.Empty;
        public string Controller { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string PathEndpoint { get; set; } = string.Empty;
    }
}
