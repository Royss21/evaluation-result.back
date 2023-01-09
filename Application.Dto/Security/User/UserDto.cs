namespace Application.Dto.Security.User
{
    using Application.Dto.Security.Role;
    using System.Text.Json.Serialization;
    public class UserDto : BaseUserDto
    {
        public Guid Id { get; set; }
        public bool IsLocked { get; set; }
        public List<RoleDto> Roles { get; set; }
        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
