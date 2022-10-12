
namespace Api.Services.Helpers
{
    using Application.Main.Exceptions;
    using Application.Main.Servicios.Generico.Interfaces;
    using Domain.Common.Constants;
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
                var userId = claims.FindFirst(Claims.Identificate)?.Value?.Decrypt();

                if (!string.IsNullOrWhiteSpace(userId))
                {
                    var memoryCacheService = _serviceProvider.GetService<IMemoryCacheService>();
                    var endpointLocked = memoryCacheService.GetDataCache($"{Messages.MemoryCache.UserEndpointLocked}{userId}") as List<string>;

                    if (endpointLocked is null)
                        await next();
                    else
                    {
                        if (endpointLocked.Contains(endpoint))
                            throw new ForbiddenException(Messages.Authentication.EndpointForbidden);
                        else
                            await next();
                    }
                }
                else
                    throw new UnauthorizedException(Messages.Authentication.NoAuthorize);
            }
            else
                await next();
        }
    }
}
