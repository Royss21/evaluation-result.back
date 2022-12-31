namespace Domain.Main.Security
{
    public class UserEndpointLocked : BaseModel<int>
    {
        public Guid UserId { get; set; }
        public Guid EndpointServiceId { get; set; }

        public virtual User User { get; set; }
        public virtual EndpointService EndpointService { get; set; }
    }
}
