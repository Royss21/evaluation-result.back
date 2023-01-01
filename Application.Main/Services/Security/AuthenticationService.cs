
namespace Application.Main.Services.Security
{
    using Application.Dto.Security.Authentication;
    using Application.Dto.Security.Role;
    using Application.Dto.Security.User;
    using Application.Main.Exceptions;
    using Application.Main.Services.Security.Interfaces;
    using Application.Main.Servicios.Generico.Interfaces;
    using Application.Security.Entities;
    using Application.Security.Jwt;
    using Application.Security.Password;
    using Domain.Common.Constants;
    using Infrastructure.UnitOfWork.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;

    public class AuthenticationService : IAuthenticationService
    {
        private readonly IPasswordFactory _passwordFactory;
        private readonly IJwtFactory _jwtFactory;
        private readonly IMemoryCacheService _memoryCacheService;
        private readonly IUnitOfWorkApp _unitOfWorkApp;
        private readonly IMapper _mapper;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public AuthenticationService(
            IPasswordFactory passwordFactory,
            IJwtFactory jwtFactory,
            IUnitOfWorkApp unitOfWorkApp,
            IMapper mapper,
            IMemoryCacheService memoryCacheService,
            TokenValidationParameters tokenValidationParameters
        )
        {
            _passwordFactory = passwordFactory;
            _jwtFactory = jwtFactory;
            _unitOfWorkApp = unitOfWorkApp;
            _mapper = mapper;
            _tokenValidationParameters = tokenValidationParameters;
            _memoryCacheService = memoryCacheService;
        }

        public async Task<AccessDto> LoginSesionAsync(LoginSesionReqDto loginSesionReq, Controller controller)
        {
            var userInfoToken = await _unitOfWorkApp.Repository.UserRepository
                .Find(u => u.UserName.Trim().Equals(loginSesionReq.UserName.Trim()))
                .ProjectTo<UserInfoTokenDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (userInfoToken is null)
                throw new WarningException(string.Format(Messages.General.ResourceNotFound, "User Information Token"));

            if (!_passwordFactory.VerifyPassword(userInfoToken.Password,
                loginSesionReq.Password,
                userInfoToken.HashType)
             )
                throw new WarningException(Messages.Authentication.InvalidPassword);

            var usuarioTokenApp = _jwtFactory.GetJwt(new UserClaim
            {
                Id = userInfoToken.Id,
                UserName = userInfoToken.UserName,
                FullName = userInfoToken.FullName,
                RoleId = loginSesionReq.RoleId
            }, false);

            var endpointsBloqueados = await _unitOfWorkApp.Repository.UserEndpointLockedRepository
                .Find(uel => uel.UserId.Equals(userInfoToken.Id))
                .Select(c => c.EndpointService.PathEndpoint)
                .ToListAsync();

            if (endpointsBloqueados.Any())
                _memoryCacheService.SaveDataCache(endpointsBloqueados, $"{Messages.MemoryCache.UserEndpointLocked}{userInfoToken.Id}");
            else
                _memoryCacheService.RemoveDataCache($"{Messages.MemoryCache.UserEndpointLocked}{userInfoToken.Id}");

            //var email = new Email
            //{
            //    Asunto = "INICIO SESION",
            //    Correos = new List<string> { "martel.royss21@gmail.com" },
            //    CorreosCopiar = new List<string> { "martel.royss21@gmail.com" },
            //    Cuerpo = _correoServicio.CargarCuerpoCorreo<CorreoPruebaDto>(CorreoTemplateEnum.CorreoPrueba, controller, new CorreoPruebaDto { NombreCompletos = "royss", NombreUsuario = "rmartel", Endpoints = endpointsBloqueados })
            //};

            //BackgroundJob.Enqueue(() => _correoServicio.Enviar(email));
            //BackgroundJob.Enqueue(() => CrearActualizarToken(usuarioTokenApp, usuarioPersonaDto.Id));

            return _mapper.Map<AccessDto>(usuarioTokenApp);
        }
        public async Task<LoginSesionResDto> ValidateUserAsync(string userName)
        {
            var user = await _unitOfWorkApp.Repository.UserRepository
                .Find(u => u.UserName.Trim().Equals(userName.Trim()))
                .FirstOrDefaultAsync();

            if (user is null)
                throw new WarningException(string.Format(Messages.General.ResourceNotFound, "User"));

            var userRoles = await _unitOfWorkApp.Repository.UserRoleRepository
                .Find(ur => ur.UserId.Equals(user.Id))
                .ToListAsync();

            if (userRoles is null || !userRoles.Any())
                throw new WarningException(Messages.Authentication.RoleNotAssigned);

            var roles = await _unitOfWorkApp.Repository.RoleRepository
                .Find(r => userRoles.Select(eu => eu.RoleId).Contains(r.Id))
                .ProjectTo<RoleDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new LoginSesionResDto { Roles = roles };
        }
        public async Task<AccessDto> RefreshTokenAsync(TokenDto tokenReq)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var principal = jwtTokenHandler.ValidateToken(tokenReq.Token, _tokenValidationParameters, out var validarToken);

            if (validarToken is JwtSecurityToken jwtSecurityToken)
            {
                var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);

                if (!result)
                    throw new WarningException(Messages.Authentication.InvalidToken);
            }

            var dateExpiredUtc = long.Parse(principal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
            var dateExpired = CoreHelper.UnixTimeStampToDateTime(dateExpiredUtc);

            if (dateExpired > DateTime.UtcNow.GetDatePeru())
                throw new WarningException(Messages.Authentication.NotExpiredToken);

            var onlyToken = true;
            var userTokenExists = await _unitOfWorkApp.Repository.UserTokenRepository
                    .Find(ut => ut.RefreshToken.Equals(tokenReq.RefreshToken), @readonly: false)
                    .FirstOrDefaultAsync();

            if (userTokenExists is null)
                throw new WarningException(string.Format(Messages.General.ResourceNotFound, "User Token"));

            if (userTokenExists.IsActive)
            {
                if (DateTime.UtcNow.GetDatePeru() > userTokenExists.RefreshTokenExpirationDate)
                    onlyToken = false;

                var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenReq.Token);
                var userTokenApp = _jwtFactory.GetJwt(new UserClaim
                {
                    Id = new Guid(token.Claims.First(c => c.Type.Equals(Claims.Identificate)).Value.Decrypt()),
                    UserName = token.Claims.First(c => c.Type.Equals(Claims.UserName)).Value.Decrypt(),
                    FullName = token.Claims.First(c => c.Type.Equals(Claims.FullName)).Value.Decrypt(),
                    RoleId = Convert.ToInt32(token.Claims.First(c => c.Type.Equals(Claims.Role)).Value.Decrypt())
                }, onlyToken);

                userTokenExists.Token = userTokenApp.Token;
                userTokenExists.TokenExpirationDate = userTokenApp.ExpirationDate;

                if (!onlyToken)
                {
                    userTokenExists.RefreshToken = userTokenApp.RefreshToken;
                    userTokenExists.RefreshTokenExpirationDate = (DateTime)userTokenApp.RefreshTokenExpirationDate;
                }

                await _unitOfWorkApp.SaveChangesAsync();

                return _mapper.Map<AccessDto>(userTokenApp);
            }
            else
                throw new WarningException(Messages.Authentication.ReLogging);
        }



        //public async Task CrearActualizarToken(UsuarioTokenApp usuarioTokenApp, Guid usuarioId)
        //{
        //    var usuarioTokenExistente = await _unitOfWorkApp.Repository.UsuarioTokenRepository
        //        .Find(ut => ut.UsuarioId.Equals(usuarioId), @readonly: false)
        //        .FirstOrDefaultAsync();

        //    var fechaActual = DateTime.UtcNow.ObtenerFechaPeru();
        //    var tokenRefrescar = usuarioTokenApp.TokenRefrescar;
        //    var tokenRefrescarExpiracion = (DateTime)usuarioTokenApp.ExpiracionTokenRefrescar;

        //    if (usuarioTokenExistente is null)
        //    {
        //        await _unitOfWorkApp.Repository.UsuarioTokenRepository.AddAsync(new UsuarioToken
        //        {
        //            Token = usuarioTokenApp.Token,
        //            FechaExpiracionToken = usuarioTokenApp.Expiracion,
        //            RefrescarToken = tokenRefrescar,
        //            FechaExpiracionRefrescarToken = tokenRefrescarExpiracion
        //        });
        //    }
        //    else
        //    {
        //        usuarioTokenExistente.Token = usuarioTokenApp.Token;
        //        usuarioTokenExistente.FechaExpiracionToken = usuarioTokenApp.Expiracion;
        //        usuarioTokenExistente.RefrescarToken = tokenRefrescar;
        //        usuarioTokenExistente.FechaExpiracionRefrescarToken = tokenRefrescarExpiracion;
        //        usuarioTokenExistente.EsActivo = true;
        //    }

        //    await _unitOfWorkApp.SaveChangesAsync();
        //}
    }
}
