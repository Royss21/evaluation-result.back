
namespace Api.Services.Helpers
{
    using Application.Main.Exceptions;
    using SharedKernell.Helpers;
    using SharedKernell.Wrappers;
    using System.Net;
    using System.Text.Json;

    public class ExceptionHandlingMiddleware
    {
        private readonly ILogger<Controller> _logger;
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<Controller> logger)
        {
            _next = next;
            _logger = logger;
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

                switch (ex)
                {
                    case WarningException warningException:
                        result.StatusCode = (int)HttpStatusCode.InternalServerError;
                        result.Message = ex.Message;
                        break;
                    case UnauthorizedException unauthorizedException:
                        result.StatusCode = (int)HttpStatusCode.Unauthorized;
                        result.Message = ex.Message;
                        break;
                    case ForbiddenException forbiddenException:
                        result.StatusCode = (int)HttpStatusCode.Forbidden;
                        result.Message = ex.Message;
                        break;
                    case ValidatorException validatorException:
                        result.StatusCode = (int)HttpStatusCode.BadRequest;
                        result.Message = ex.Message;
                        break;
                    case Exception exception:
                        result.StatusCode = (int)HttpStatusCode.InternalServerError;
                        result.Message = "Ha ocurrido un error en el servidor";
                        break;
                    default:
                        break;
                }

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = result.StatusCode;

                await context.Response.WriteAsync(await JsonConverter.SerializeContent(result, options: new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                }).ReadAsStringAsync());
            } 
        }
    }
}
