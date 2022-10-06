namespace Domain.Main.Security
{
    
    using Domain.Main.Authentication;
    public class UserEndpointLocked : BaseModel<int>
    {
        public Guid UserId { get; set; }
        public Guid EndpointId { get; set; }

        public User User { get; set; }
        public Endpoint Endpoint { get; set; }
    }
}
