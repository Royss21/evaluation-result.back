
namespace Application.Security.JWT
{
    using SharedKernell.Helpers;
    using Microsoft.IdentityModel.Tokens;
    public class JwtOption
    {

        public string Issuer { get; set; }
        public string Subject { get; set; }
        public string Audience { get; set; }
        public int DaysTokenRefresh { get; set; }
        public DateTime Expiration => IssuedAt.Add(ValidFor);
        public DateTime NotBefore => DateTime.UtcNow.GetDatePeru();
        public DateTime IssuedAt => DateTime.UtcNow.GetDatePeru();
        public TimeSpan ValidFor { get; set; } = TimeSpan.FromHours(12);

        public string SecurityKey { get; set; }

        public SymmetricSecurityKey SymmetricSecurityKey =>
            new SymmetricSecurityKey(Convert.FromBase64String(SecurityKey));

        public SigningCredentials SigningCredentials =>
            new SigningCredentials(SymmetricSecurityKey, SecurityAlgorithms.HmacSha256);
    }
}