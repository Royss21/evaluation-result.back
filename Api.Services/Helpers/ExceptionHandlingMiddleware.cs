
namespace Api.Services.Helpers
{
    using Application.Main.Excepciones;
    using SharedKernell.Helpers;
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
                var estadoCode = (int)HttpStatusCode.InternalServerError;
                var resultado = new JsonErrorResult(estadoCode);

                switch (ex)
                {
                    case AdvertenciaExcepcion advertenciaExcepcion:
                        resultado.CodigoEstado = (int)HttpStatusCode.InternalServerError;
                        resultado.Mensaje = ex.Message;
                        break;
                    case NoAutorizadoExcepcion noAutorizadoExcepcion:
                        resultado.CodigoEstado = (int)HttpStatusCode.Unauthorized;
                        resultado.Mensaje = ex.Message;
                        break;
                    case ProhibidoExcepcion prohibidoExcepcion:
                        resultado.CodigoEstado = (int)HttpStatusCode.Forbidden;
                        resultado.Mensaje = ex.Message;
                        break;
                    case ValidadorExcepcion validadorExcepcion:
                        resultado.CodigoEstado = (int)HttpStatusCode.BadRequest;
                        resultado.Mensaje = ex.Message;
                        break;
                    case Exception exception:
                        resultado.CodigoEstado = (int)HttpStatusCode.InternalServerError;
                        resultado.Mensaje = "Ha ocurrido un error en el servidor";
                        break;
                    default:
                        break;
                }

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = resultado.CodigoEstado;

                await context.Response.WriteAsync(await JsonConverter.SerializeContent(resultado, options: new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                }).ReadAsStringAsync());
            } 
        }
    }
}
