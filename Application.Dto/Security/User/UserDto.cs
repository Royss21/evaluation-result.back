namespace Application.Dto.Security.User
{
    public class UserDto : BaseUserDto
    {
        public bool IsLocked { get; set; }
    }
}
