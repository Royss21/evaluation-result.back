namespace Application.Dto.Security.Authentication
{
    public class LoginSesionReqDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RoleId { get; set; }
    }
}
