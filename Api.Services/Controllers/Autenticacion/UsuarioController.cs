namespace Api.Services.Controllers.Autenticacion
{
    using Api.Services.Controllers;
    using Application.Dto.Autenticacion.Usuario;
    using Application.Main.Servicios.Autenticacion.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioServicio _usuarioServicio;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(IUsuarioServicio usuarioServicio, ILogger<UsuarioController> logger)
        {
            _usuarioServicio = usuarioServicio;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Lista de Usuarios",
        Description = "Listado donde se listan las usuarios de la compa;ia",
        OperationId = "Usuario.Get",
        Tags = new[] { "UsuarioServicio" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<UsuarioDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodo()
        {
            var resultado = await _usuarioServicio.ObtenerTodoAsync();
            return new OkObjectResult(new JsonResult<List<UsuarioDto>>(resultado.ToList()));
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Crear Usuario",
        Description = "crear",
        OperationId = "Usuario.Post",
        Tags = new[] { "UsuarioServicio" })]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Crear(UsuarioCrearDto usuarioCrearDto)
        {
            var resultado = await _usuarioServicio.CrearAsync(usuarioCrearDto);
            return new OkObjectResult(new JsonResult<bool>(resultado));
        }

        [HttpPost("Compania")]
        [SwaggerOperation(
           Summary = "Crear Usuario con una compania",
           Description = "crear",
           OperationId = "UsuarioCompania.Post",
           Tags = new[] { "UsuarioServicio" })]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CrearConCompania(UsuarioCompaniaCrearDto usuarioCrearDto)
        {
            var resultado = await _usuarioServicio.CrearConCompaniaAsync(usuarioCrearDto);
            return new OkObjectResult(new JsonResult<bool>(resultado));
        }

    }
}
