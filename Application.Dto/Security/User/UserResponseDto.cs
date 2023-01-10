namespace Application.Dto.Security.User
{
    public class UserResponseDto : BaseUserDto
    {
        public Guid Id { get; set; }
        public bool IsLocked { get; set; }
    }
}
