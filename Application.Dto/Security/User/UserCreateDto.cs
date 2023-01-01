namespace Application.Dto.Security.User
{
    public class UserCreateDto : BaseUser
    {
        public string Password { get; set; } = string.Empty;
        public List<int> RolesId { get; set; }
    }
}
