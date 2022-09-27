
namespace Api.Services.Helpers
{
    using Application.Main.Excepciones;
    using Application.Main.Servicios.Generico.Interfaces;
    using Domain.Common.Constantes;
    using Microsoft.AspNetCore.Mvc.Filters;
    using SharedKernell.Helpers;

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
            var actionDescription = context.ActionDescriptor;
            var actionName = actionDescription?.RouteValues["action"]?.ToString() ?? "";
            var controllerName = actionDescription?.RouteValues["controller"]?.ToString() ?? "";
            var method = _httpContextAccessor?.HttpContext?.Request.Method ?? "";
            var endpoint = $"{method}.{controllerName}.{actionName}";

            if (!string.IsNullOrWhiteSpace(endpoint) && 
                !endpoint.Contains("Authentication") &&
                _httpContextAccessor?.HttpContext?.User is not null)
            {
                var claims = _httpContextAccessor.HttpContext.User;
                var userId = claims.FindFirst(Claims.Identificador)?.Value?.Decrypt();

                if (!string.IsNullOrWhiteSpace(userId))
                {
                    var memoryCacheService = _serviceProvider.GetService<IMemoriaCacheServicio>();
                    var endpointLocked = memoryCacheService.ObtenerDatoCache($"{Messages.MemoriaCache.UsuarioEndpointsBloqueados}{userId}") as List<string>;

                    if (endpointLocked is null)
                        await next();
                    else
                    {
                        if (!endpointLocked.Contains(endpoint))
                            await next();
                        else
                            throw new ProhibidoExcepcion(Messages.Autenticacion.EndpointProhibido);
                    }
                }
                else
                    throw new NoAutorizadoExcepcion(Messages.Autenticacion.NoAutorizado);
            }
            else
                await next();
        }
    }
}
