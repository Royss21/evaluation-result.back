namespace Application.Main.Servicios.Autenticacion
{
    using Application.Dto.Autenticacion.InicioSesion;
    using Application.Dto.Autenticacion.Rol;
    using Application.Dto.Autenticacion.Usuario;
    using Application.Main.Servicios.Autenticacion.Interfaces;
    using Application.Main.Servicios.Generico.Interfaces;
    using Application.Security.Contrasenia;
    using Application.Security.Entidades;
    using Application.Security.JWT;
    using Domain.Common.Constantes;
    using Domain.Main.Autenticacion;
    using Hangfire;
    using Infrastructure.UnitOfWork.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Threading.Tasks;

    public class AutenticacionServicio : IAutenticacionServicio
    {
        private readonly IContraseniaFabrica _contraseniaFabrica;
        private readonly IUnitOfWorkApp _unitOfWorkApp;
        private readonly IMapper _mapper;
        private readonly IJwtFabrica _jwtFabrica;
        private readonly IMemoriaCacheServicio _memoriaCacheServicio;
        private readonly ICorreoServicio _correoServicio;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public AutenticacionServicio(
            IContraseniaFabrica contraseniaFabrica,
            IJwtFabrica jwtFabrica,
            IUnitOfWorkApp unitOfWorkApp,
            IMapper mapper,
            IMemoriaCacheServicio memoriaCacheServicio,
            ICorreoServicio correoServicio,
            TokenValidationParameters tokenValidationParameters
        )
        {
            _contraseniaFabrica = contraseniaFabrica;
            _jwtFabrica = jwtFabrica;
            _unitOfWorkApp = unitOfWorkApp;
            _mapper = mapper;
            _tokenValidationParameters = tokenValidationParameters;
            _correoServicio = correoServicio;
            _memoriaCacheServicio = memoriaCacheServicio;
        }

        public async Task<AccesoDto> IniciarSesion(IniciarSesionReqDto iniciarSesionDto, Controller controller)
        {
            var usuarioPersonaDto = await _unitOfWorkApp.Repositorio.UsuarioRepositorio
                .Find(u => u.NombreUsuario.Trim().Equals(iniciarSesionDto.NombreUsuario.Trim()))
                .ProjectTo<UsuarioPersonaTokenDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (usuarioPersonaDto is null)
                throw new AdvertenciaExcepcion(string.Format(Mensajes.General.RecursoNoEncontrado, typeof(UsuarioPersonaTokenDto).Name));

            if (!_contraseniaFabrica.Verificar(usuarioPersonaDto.Contrasenia,
                iniciarSesionDto.Contrasenia,
                usuarioPersonaDto.TipoHash)
             )
                throw new AdvertenciaExcepcion(Mensajes.Autenticacion.ContraseniaIncorrecta);

            var usuarioTokenApp = _jwtFabrica.ObtenerJwt(new UsuarioClaim
            {
                CompaniaId = usuarioPersonaDto.CompaniaId,
                Id = usuarioPersonaDto.Id,
                NombreUsuario = usuarioPersonaDto.NombreUsuario,
                NombreCompleto = $"{usuarioPersonaDto.Nombres} {usuarioPersonaDto.Apellidos}",
                RolId = new Guid(iniciarSesionDto.RolId)
            }, false);

            var endpointsBloqueados = await _unitOfWorkApp.Repositorio.UsuarioEndpointBloqueadoRepositorio
                .Find(ueb => ueb.UsuarioId.Equals(usuarioPersonaDto.Id))
                .Select(c => c.Endpoint.RutaEndpoint)
                .ToListAsync();

            if (endpointsBloqueados.Any())
                _memoriaCacheServicio.GuardarDatoCache(endpointsBloqueados, $"{Mensajes.MemoriaCache.UsuarioEndpointsBloqueados}{usuarioPersonaDto.Id}");
            else
                _memoriaCacheServicio.RemoverDatoCache($"{Mensajes.MemoriaCache.UsuarioEndpointsBloqueados}{usuarioPersonaDto.Id}");

            //var email = new Email
            //{
            //    Asunto = "INICIO SESION",
            //    Correos = new List<string> { "martel.royss21@gmail.com" },
            //    CorreosCopiar = new List<string> { "martel.royss21@gmail.com" },
            //    Cuerpo = _correoServicio.CargarCuerpoCorreo<CorreoPruebaDto>(CorreoTemplateEnum.CorreoPrueba, controller, new CorreoPruebaDto { NombreCompletos = "royss", NombreUsuario = "rmartel", Endpoints = endpointsBloqueados })
            //};

                //BackgroundJob.Enqueue(() => _correoServicio.Enviar(email));
            BackgroundJob.Enqueue(() => CrearActualizarToken(usuarioTokenApp, usuarioPersonaDto.Id));

            return _mapper.Map<AccesoDto>(usuarioTokenApp);
        }
        public async Task<IniciarSesionResDto> ValidarUsuario(string nombreUsuario)
        {
            var usuario = await _unitOfWorkApp.Repositorio.UsuarioRepositorio
                .Find(u => u.NombreUsuario.Trim().Equals(nombreUsuario.Trim()))
                .FirstOrDefaultAsync();

            if (usuario is null)
                throw new AdvertenciaExcepcion(string.Format(Mensajes.General.RecursoNoEncontrado, typeof(Usuario).Name));

            var rolesUsuario = await _unitOfWorkApp.Repositorio.UsuarioRolRepositorio
                .Find(ur => ur.UsuarioId.Equals(usuario.Id))
                .ToListAsync();

            if (rolesUsuario is null || !rolesUsuario.Any())
                throw new AdvertenciaExcepcion(Mensajes.Autenticacion.RolNoAsignado);

            var roles = await _unitOfWorkApp.Repositorio.RolRepositorio
                .Find(r => rolesUsuario.Select(eu => eu.RolId).Contains(r.Id))
                .ProjectTo<RolDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new IniciarSesionResDto { Roles = roles };
        }
        public async Task<AccesoDto> RefrescarToken(TokenReqDto tokenReq)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var principal = jwtTokenHandler.ValidateToken(tokenReq.Token, _tokenValidationParameters, out var validarToken);

            if (validarToken is JwtSecurityToken jwtSecurityToken)
            {
                var resultado = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);

                if (!resultado)
                    throw new AdvertenciaExcepcion(Mensajes.Autenticacion.TokenInvalido);
            }

            var fechaExpiracionUtc = long.Parse(principal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
            var fechaExp = CoreHelper.UnixTimeStampToDateTime(fechaExpiracionUtc);

            if (fechaExp > DateTime.UtcNow.ObtenerFechaPeru())
                throw new AdvertenciaExcepcion(Mensajes.Autenticacion.TokenNoCaducado);

            var soloToken = true;
            var usuarioTokenExistente = await _unitOfWorkApp.Repositorio.UsuarioTokenRepositorio
                    .Find(ut => ut.RefrescarToken.Equals(tokenReq.TokenRefrescar), @readonly: false)
                    .FirstOrDefaultAsync();

            if (usuarioTokenExistente is null)
                throw new AdvertenciaExcepcion(string.Format(Mensajes.General.RecursoNoEncontrado, typeof(UsuarioToken).Name));

            if (usuarioTokenExistente.EsActivo)
            {
                if (DateTime.UtcNow.ObtenerFechaPeru() > usuarioTokenExistente.FechaExpiracionRefrescarToken)
                    soloToken = false;

                var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenReq.Token);
                var usuarioTokenApp = _jwtFabrica.ObtenerJwt(new UsuarioClaim
                {
                    CompaniaId = new Guid(token.Claims.First(c => c.Type.Equals(Claims.Compania)).Value.Desencriptar()),
                    Id = new Guid(token.Claims.First(c => c.Type.Equals(Claims.Identificador)).Value.Desencriptar()),
                    NombreUsuario = token.Claims.First(c => c.Type.Equals(Claims.NombreUsuario)).Value.Desencriptar(),
                    NombreCompleto = token.Claims.First(c => c.Type.Equals(Claims.NombresCompletos)).Value.Desencriptar(),
                    RolId = new Guid(token.Claims.First(c => c.Type.Equals(Claims.Rol)).Value.Desencriptar())
                }, soloToken);

                usuarioTokenExistente.Token = usuarioTokenApp.Token;
                usuarioTokenExistente.FechaExpiracionToken = usuarioTokenApp.Expiracion;

                if (!soloToken)
                {
                    usuarioTokenExistente.RefrescarToken = usuarioTokenApp.TokenRefrescar;
                    usuarioTokenExistente.FechaExpiracionRefrescarToken = (DateTime)usuarioTokenApp.ExpiracionTokenRefrescar;
                }

                await _unitOfWorkApp.SaveChangesAsync();

                return _mapper.Map<AccesoDto>(usuarioTokenApp);
            }
            else
                throw new AdvertenciaExcepcion(Mensajes.Autenticacion.IniciarSesion);
        }



        public async Task CrearActualizarToken(UsuarioTokenApp usuarioTokenApp, Guid usuarioId)
        {
            var usuarioTokenExistente = await _unitOfWorkApp.Repositorio.UsuarioTokenRepositorio
                .Find(ut => ut.UsuarioId.Equals(usuarioId), @readonly: false)
                .FirstOrDefaultAsync();

            var fechaActual = DateTime.UtcNow.ObtenerFechaPeru();
            var tokenRefrescar = usuarioTokenApp.TokenRefrescar;
            var tokenRefrescarExpiracion = (DateTime)usuarioTokenApp.ExpiracionTokenRefrescar;

            if (usuarioTokenExistente is null)
            {
                await _unitOfWorkApp.Repositorio.UsuarioTokenRepositorio.AddAsync(new UsuarioToken
                {
                    Token = usuarioTokenApp.Token,
                    FechaExpiracionToken = usuarioTokenApp.Expiracion,
                    RefrescarToken = tokenRefrescar,
                    FechaExpiracionRefrescarToken = tokenRefrescarExpiracion
                });
            }
            else
            {
                usuarioTokenExistente.Token = usuarioTokenApp.Token;
                usuarioTokenExistente.FechaExpiracionToken = usuarioTokenApp.Expiracion;
                usuarioTokenExistente.RefrescarToken = tokenRefrescar;
                usuarioTokenExistente.FechaExpiracionRefrescarToken = tokenRefrescarExpiracion;
                usuarioTokenExistente.EsActivo = true;
            }

            await _unitOfWorkApp.SaveChangesAsync();
        }
    }
}
