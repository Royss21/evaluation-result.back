namespace Api.Services.Controllers.Autenticacion
{
    using Application.Dto.Autenticacion.InicioSesion;
    using Application.Main.Servicios.Autenticacion.Interfaces;
    using Microsoft.AspNetCore.Authorization;

    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AutenticacionController : Controller
    {

        private readonly ILogger<AutenticacionController> _logger;
        private readonly IAutenticacionServicio _seguridadServicio;

        public AutenticacionController(IAutenticacionServicio seguridadServicio, ILogger<AutenticacionController> logger)
        {

            _logger = logger;
            _seguridadServicio = seguridadServicio;
        }

        [HttpGet("ValidarUsuario/{nombreUsuario}")]
        [SwaggerOperation(
        Summary = "Validar nombbre de usuario",
        Description = "Servicio donde se valida el nombre del usuario si existe o no",
        OperationId = "Autenticacion.Get.ValidarUsuario",
        Tags = new[] { "AutenticacionEndpoint" })]
        [ProducesResponseType(typeof(JsonResult<IniciarSesionResDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ValidarUsuario(string nombreUsuario)
        {
            var resultado = await _seguridadServicio.ValidarUsuario(nombreUsuario);
            return new OkObjectResult(new JsonResult<IniciarSesionResDto>(resultado));
        }

        [HttpPost("IniciarSesion")]
        [SwaggerOperation(
        Summary = "Validar nombbre de usuario",
        Description = "Servicio donde se valida el nombre del usuario si existe o no",
        OperationId = "Autenticacion.Post.IniciarSesion",
        Tags = new[] { "AutenticacionEndpoint" })]
        [ProducesResponseType(typeof(JsonResult<AccesoDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> IniciarSesion(IniciarSesionReqDto iniciarSesionReqDto)
        {
            var resultado = await _seguridadServicio.IniciarSesion(iniciarSesionReqDto, this);
            return new OkObjectResult(new JsonResult<AccesoDto>(resultado));
        }

        [HttpPost("RefrescarToken")]
        [SwaggerOperation(
        Summary = "Validar nombbre de usuario",
        Description = "Servicio donde se valida el nombre del usuario si existe o no",
        OperationId = "Autenticacion.Get.RefrescarToken",
        Tags = new[] { "AutenticacionEndpoint" })]
        [ProducesResponseType(typeof(JsonResult<AccesoDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> RefrescarToken(TokenReqDto tokenReqDto)
        {
            var resultado = await _seguridadServicio.RefrescarToken(tokenReqDto);
            return new OkObjectResult(new JsonResult<AccesoDto>(resultado));
        }

    }
}
