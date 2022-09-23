
namespace Application.Security.JWT
{
    using Application.Security.Entidades;
    using Domain.Common.Constantes;
    using SharedKernell.Helpers;
    using Microsoft.Extensions.Options;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Security.Principal;
    public class JwtFabrica : IJwtFabrica
    {
        private readonly JwtEmisorOpciones _jwtEmisorOpciones;

        public JwtFabrica(IOptions<JwtEmisorOpciones> jwtOptions)
        {
            _jwtEmisorOpciones = jwtOptions.Value;
        }

        public UsuarioTokenApp ObtenerJwt(UsuarioClaim usuarioApp, bool soloToken = true)
        {
            var claimsIdentity = GenerarClaims(usuarioApp);
            return GenerarJwt(claimsIdentity, soloToken);
        }

        private ClaimsIdentity GenerarClaims(UsuarioClaim usuarioApp)
        {
            return new ClaimsIdentity(new GenericIdentity("tokenName", "Token"), new[]
            {
                new Claim(Claims.Identificador, usuarioApp.Id.ToString().Encriptar()),
                //new Claim(JwtRegisteredClaimNames.Sub, usuarioApp.Id.ToString().Encriptar()),
                new Claim(Claims.NombresCompletos, usuarioApp.NombreCompleto.Encriptar()),
                new Claim(Claims.NombreUsuario, usuarioApp.NombreUsuario.Encriptar()),
                new Claim(Claims.Rol, usuarioApp.RolId.ToString().Encriptar()),
                new Claim(Claims.Compania, usuarioApp.CompaniaId.ToString().Encriptar())
            });
        }

        private UsuarioTokenApp GenerarJwt(ClaimsIdentity identity, bool soloToken = true)
        {
            return new UsuarioTokenApp
            {
                Token = GenerarTokenCodificado(identity),
                TokenRefrescar = soloToken ? null : (RandomString(25) + Guid.NewGuid()).ToString(),
                Expiracion = _jwtEmisorOpciones.Expiration,
                ExpiraEn = _jwtEmisorOpciones.ValidFor.TotalMinutes,
                ExpiracionTokenRefrescar = soloToken ? null : _jwtEmisorOpciones.Expiration.AddDays(_jwtEmisorOpciones.DaysTokenRefresh)
            };
        }

        private string GenerarTokenCodificado(ClaimsIdentity claimsIdentity)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtEmisorOpciones.IssuedAt).ToString(),
                    ClaimValueTypes.Integer64)
            };
            
            foreach (var claim in claimsIdentity.Claims)
            {
                Array.Resize(ref claims, claims.Length + 1);
                claims[^1] = claim;
            }

            var jwt = new JwtSecurityToken(
                _jwtEmisorOpciones.Issuer,
                _jwtEmisorOpciones.Audience,
                claims,
                _jwtEmisorOpciones.NotBefore,
                _jwtEmisorOpciones.Expiration,
                _jwtEmisorOpciones.SigningCredentials);

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
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}