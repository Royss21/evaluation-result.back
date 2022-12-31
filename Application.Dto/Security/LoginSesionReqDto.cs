
namespace Application.Dto.Security
{
    public class LoginSesionReqDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Guid RoleId { get; set; }
    }
}
