
namespace Api.Services.Helpers
{
    using Application.Main.Exceptions;
    using Application.Main.Services.Security.Interfaces;
    using Application.Main.Servicios.Generico.Interfaces;
    using Domain.Main.Security;
    using SharedKernell.Helpers;
    using SharedKernell.Wrappers;
    using System.Net;
    using System.Text.Json;

    public class ExceptionHandlingMiddleware
    {
        private readonly ILogger<Controller> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<Controller> logger , IServiceProvider serviceProvider)
        {
            _next = next;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var statusCode = (int)HttpStatusCode.InternalServerError;
                var result = new JsonErrorResult(statusCode);
                var typeException = "";
                //var logService = _serviceProvider.GetService<ILogService>();
                var logService = context.RequestServices.GetRequiredService<ILogService>();

                switch (ex)
                {
                    case WarningException warningException:
                        result.StatusCode = (int)HttpStatusCode.InternalServerError;
                        result.Message = ex.Message;
                        typeException = typeof(WarningException).Name;
                        break;
                    case UnauthorizedException unauthorizedException:
                        result.StatusCode = (int)HttpStatusCode.Unauthorized;
                        result.Message = ex.Message;
                        typeException = typeof(UnauthorizedException).Name;
                        break;
                    case ForbiddenException forbiddenException:
                        result.StatusCode = (int)HttpStatusCode.Forbidden;
                        result.Message = ex.Message;
                        typeException = typeof(ForbiddenException).Name;
                        break;
                    case ValidatorException validatorException:
                        result.StatusCode = (int)HttpStatusCode.BadRequest;
                        result.Message = ex.Message;
                        typeException = typeof(ValidatorException).Name;
                        break;
                    case Exception exception:
                        result.StatusCode = (int)HttpStatusCode.InternalServerError;
                        result.Message = "Ha ocurrido un error en el servidor";
                        typeException = typeof(Exception).Name;
                        break;
                    default:
                        break;
                }

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = result.StatusCode;

                await logService.CreateAsync(new LogEntity
                {
                    TypeException = typeException,
                    Message = ex.Message,
                    InnerExceptionMessage = ex?.InnerException?.Message ?? string.Empty,
                    StackTrace = ex?.StackTrace ?? string.Empty,
                    FullNameService = ex?.TargetSite?.DeclaringType?.FullName ?? string.Empty,
                });

                await context.Response.WriteAsync(await JsonConverter.SerializeContent(result, options: new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                }).ReadAsStringAsync());
            } 
        }
    }
}
