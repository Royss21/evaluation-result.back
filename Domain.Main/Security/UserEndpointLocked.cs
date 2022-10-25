namespace Domain.Main.Security
{
    public class UserEndpointLocked : BaseModel<int>
    {
        public string UserId { get; set; }
        public string EndpointServicetId { get; set; }

        public User? User { get; set; }
        public EndpointService? EndpointService { get; set; }
    }
}
