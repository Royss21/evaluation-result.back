namespace Application.Security.Entities
{
    public class UserClaim
    {
        public string Id { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string IdRole { get; set; } = string.Empty;
    }
}