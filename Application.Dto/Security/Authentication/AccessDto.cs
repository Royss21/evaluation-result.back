
namespace Application.Dto.Security.Authentication
{
    using Application.Dto.Security.Menu;
    public class AccessDto
    {
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public string ExpiredIn { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public List<MenuDto> Menus { get; set; }

    }
}
