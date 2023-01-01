
namespace Application.Security.JWT
{
    using Application.Security.Entities;
    using SharedKernell.Helpers;
    using Microsoft.Extensions.Options;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Security.Principal;
    using Application.Security.Jwt;
    using Domain.Common.Constants;

    public class JwtFactory : IJwtFactory
    {
        private readonly JwtOption _options;

        public JwtFactory(IOptions<JwtOption> options)
        {
            _options = options.Value;
        }

        public UserTokenApp GetJwt(UserClaim userApp, bool onlyToken = true)
        {
            var claimsIdentity = GenerateClaims(userApp);
            return GenerateJwt(claimsIdentity, onlyToken);
        }

        private ClaimsIdentity GenerateClaims(UserClaim usuarioApp)
        {
            return new ClaimsIdentity(new GenericIdentity("tokenName", "Token"), new[]
            {
                new Claim(Claims.Identificate, usuarioApp.Id.ToString().Encrypt()),
                new Claim(Claims.FullName, usuarioApp.FullName.Encrypt()),
                new Claim(Claims.UserName, usuarioApp.UserName.Encrypt()),
                new Claim(Claims.Role, usuarioApp.RoleId.ToString().Encrypt()),
            });
        }

        private UserTokenApp GenerateJwt(ClaimsIdentity claimsIdentity, bool soloToken = true)
        {
            return new UserTokenApp
            {
                Token = GenerateEncryptedToken(claimsIdentity),
                RefreshToken = soloToken ? null : (RandomString(25) + Guid.NewGuid()).ToString(),
                ExpirationDate = _options.Expiration,
                ExpiredIn = _options.ValidFor.TotalMinutes,
                RefreshTokenExpirationDate = soloToken ? null : _options.Expiration.AddDays(_options.DaysTokenRefresh)
            };
        }

        private string GenerateEncryptedToken(ClaimsIdentity claimsIdentity)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_options.IssuedAt).ToString(),
                    ClaimValueTypes.Integer64)
            };
            
            foreach (var claim in claimsIdentity.Claims)
            {
                Array.Resize(ref claims, claims.Length + 1);
                claims[^1] = claim;
            }

            var jwt = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                claims,
                _options.NotBefore,
                _options.Expiration,
                _options.SigningCredentials);

            var jwtCodificado = new JwtSecurityTokenHandler().WriteToken(jwt);

            return jwtCodificado;
        }

        private static long ToUnixEpochDate(DateTime date)
        {
            return (long) Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
                .TotalSeconds);
        }

        private string RandomString(int length)
        {
            var random = new Random();
            var chars = "abcdefghijqlmnopqrstuvwxyABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}