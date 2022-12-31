
namespace Application.Dto.Security
{
    using Application.Dto.Security.Role;
    public class LoginSesionResDto
    {
        public IEnumerable<RoleDto> Roles { get; set; }
    }
}
