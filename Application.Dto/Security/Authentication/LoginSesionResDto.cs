namespace Application.Dto.Security.Authentication
{
    using Application.Dto.Security.Role;
    public class LoginSesionResDto
    {
        public IEnumerable<RoleDto> Roles { get; set; }
    }
}
