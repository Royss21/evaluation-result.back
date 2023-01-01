namespace Application.Dto.Security.User
{
    public abstract class BaseUser
    {
        public string UserName { get; set; } = string.Empty;
        public string Names { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
