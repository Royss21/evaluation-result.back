namespace Application.Security.Entities
{
    public class UserClaim
    {
        public Guid Id { get; set; } 
        public string FullName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public int RoleId { get; set; } 
    }
}