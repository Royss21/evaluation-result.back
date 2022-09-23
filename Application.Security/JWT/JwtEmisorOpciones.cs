
namespace Application.Security.JWT
{
    using SharedKernell.Helpers;
    using Microsoft.IdentityModel.Tokens;
    public class JwtEmisorOpciones
    {

        public string Issuer { get; set; }
        public string Subject { get; set; }
        public string Audience { get; set; }
        public int DaysTokenRefresh { get; set; }
        public DateTime Expiration => IssuedAt.Add(ValidFor);
        public DateTime NotBefore => DateTime.UtcNow.ObtenerFechaPeru();
        public DateTime IssuedAt => DateTime.UtcNow.ObtenerFechaPeru();
        public TimeSpan ValidFor { get; set; } = TimeSpan.FromHours(12);
        public Func<Task<string>> JtiGenerator =>
            () => Task.FromResult(Guid.NewGuid().ToString());

        public string SecurityKey { get; set; }

        public SymmetricSecurityKey SymmetricSecurityKey =>
            new SymmetricSecurityKey(Convert.FromBase64String(SecurityKey));

        public SigningCredentials SigningCredentials =>
            new SigningCredentials(SymmetricSecurityKey, SecurityAlgorithms.HmacSha256);
    }
}