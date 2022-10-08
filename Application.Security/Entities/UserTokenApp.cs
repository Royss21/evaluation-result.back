
namespace Application.Security.Entities
{
    using System;
    public class UserTokenApp
    {
        public string Token { get; set; } = string.Empty;
        public string? RefreshToken { get; set; } = string.Empty;
        public double ExpiredIn { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime? RefreshTokenExpirationDate { get; set; }
    }
}