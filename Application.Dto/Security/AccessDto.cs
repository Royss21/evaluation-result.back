namespace Application.Dto.Security
{
    public class AccessDto
    {
        public string Token { get; set; } = string.Empty;
        public string TokenRefresh { get; set; } = string.Empty;
        public string ExpiredIn { get; set; } = string.Empty;

    }
}
