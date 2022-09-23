
namespace Api.Services.Ayudantes
{
    using Application.Main.Excepciones;
    using Application.Main.Servicios.Generico.Interfaces;
    using Domain.Common.Constantes;
    using SharedKernell.Helpers;
    using Microsoft.AspNetCore.Mvc.Filters;
    public class AsyncActionFilter : IAsyncActionFilter
    {
        private readonly ILogger<Controller> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AsyncActionFilter(
            ILogger<Controller> logger,
            IServiceProvider  serviceProvider,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var accionDescripcion = context.ActionDescriptor;
            var nombreAccion = accionDescripcion?.RouteValues["action"]?.ToString() ?? "";
            var nombreControlador = accionDescripcion?.RouteValues["controller"]?.ToString() ?? "";
            var metodo = _httpContextAccessor?.HttpContext?.Request.Method ?? "";
            var rutaEndpoint = $"{metodo}.{nombreControlador}.{nombreAccion}";

            if (!string.IsNullOrWhiteSpace(rutaEndpoint) && 
                !rutaEndpoint.Contains("Autenticacion") &&
                _httpContextAccessor?.HttpContext?.User is not null)
            {
                var claimsPrincipal = _httpContextAccessor.HttpContext.User;
                var usuarioId = claimsPrincipal.FindFirst(Claims.Identificador)?.Value?.Desencriptar();

                if (!string.IsNullOrWhiteSpace(usuarioId))
                {
                    var memoriaCacheServicio = _serviceProvider.GetService<IMemoriaCacheServicio>();
                    var endpointBloqueados = memoriaCacheServicio.ObtenerDatoCache($"{Mensajes.MemoriaCache.UsuarioEndpointsBloqueados}{usuarioId}") as List<string>;

                    if (endpointBloqueados is null)
                        await next();
                    else
                    {
                        if (!endpointBloqueados.Contains(rutaEndpoint))
                            await next();
                        else
                            throw new ProhibidoExcepcion(Mensajes.Autenticacion.EndpointProhibido);
                    }
                }
                else
                    throw new NoAutorizadoExcepcion(Mensajes.Autenticacion.NoAutorizado);
            }
            else
                await next();
        }
    }
}
