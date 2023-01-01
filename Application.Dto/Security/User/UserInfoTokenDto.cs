namespace Application.Dto.Security.User
{
    public class UserInfoTokenDto
    {
        public Guid Id { get; set; }
        public string Password { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int HashType { get; set; } 

    }
}
