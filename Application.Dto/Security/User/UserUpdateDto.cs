namespace Application.Dto.Security.User
{
    public class UserUpdateDto : BaseUserDto
    {
        public Guid Id { get; set; }
        public string Password { get; set; } = string.Empty;
        public List<int> RolesId { get; set; }
    }
}
