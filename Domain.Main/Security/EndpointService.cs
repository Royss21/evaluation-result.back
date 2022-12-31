namespace Domain.Main.Security
{
    public class EndpointService : BaseModel<Guid>
    {

        public EndpointService()
        {
            UserEndpointsLocked = new HashSet<UserEndpointLocked>();
        }

        public string Entity { get; set; } = string.Empty;
        public string Method { get; set; } = string.Empty;
        public string Controller { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string PathEndpoint { get; set; } = string.Empty;


        public virtual ICollection<UserEndpointLocked> UserEndpointsLocked { get; set; }
    }
}
