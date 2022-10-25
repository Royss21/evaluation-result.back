namespace Domain.Main.Security
{
    public class UserToken : BaseModelActive<string>
    {
        public string UserId { get; set; }
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenExpirationDate { get; set; }
        public DateTime RefreshTokenExpirationDate { get; set; }

    }
}
