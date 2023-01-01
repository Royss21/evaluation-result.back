namespace Application.Dto.Security.Authentication
{
    public class AccessDto
    {
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public string ExpiredIn { get; set; } = string.Empty;

    }
}
