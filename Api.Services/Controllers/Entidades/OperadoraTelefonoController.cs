namespace Api.Services.Controllers.Entidades
{
    using Api.Services.Controllers;
    using Application.Dto.Entidades.OperadoraTelefono;
    using Application.Main.Servicios.Entidades.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class OperadoraTelefonoController : BaseController
    {
        private readonly IOperadoraTelefonoServicio _operadoraTelefonoServicio;
        private readonly ILogger<OperadoraTelefonoController> _logger;

        public OperadoraTelefonoController(IOperadoraTelefonoServicio operadoraTelefonoServicio, ILogger<OperadoraTelefonoController> logger)
        {
            _operadoraTelefonoServicio = operadoraTelefonoServicio;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Lista de OperadoraTelefonos",
        Description = "Listado donde se listan las OperadoraTelefonos de la compañia",
        OperationId = "OperadoraTelefono.Get",
        Tags = new[] { "OperadoraTelefonoServicio" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<OperadoraTelefonoDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodo()
        {
            var resultado = await _operadoraTelefonoServicio.ObtenerTodoAsync();
            return new OkObjectResult(new JsonResult<List<OperadoraTelefonoDto>>(resultado.ToList()));
        }


        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Obtener  OperadoraTelefono",
        Description = "Listado donde se listan las OperadoraTelefonos de la compañia",
        OperationId = "OperadoraTelefono.Get.obtenerPorId",
        Tags = new[] { "OperadoraTelefonoServicio" })]
        [ProducesResponseType(typeof(JsonResult<OperadoraTelefonoDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var resultado = await _operadoraTelefonoServicio.ObtenerPorIdAsync(id);
            return new OkObjectResult(new JsonResult<OperadoraTelefonoDto>(resultado));
        }

        [HttpGet("paginado")]
        [SwaggerOperation(
        Summary = "Lista Paginada OperadoraTelefono",
        Description = "lista paginada de OperadoraTelefonos",
        OperationId = "OperadoraTelefono.Get.paginado",
        Tags = new[] { "OperadoraTelefonoServicio" })]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodoPaginado([FromQuery] PrimeTable primeTable)
        {
            var resultado = await _operadoraTelefonoServicio.ObtenerTodoPaginadoAsync(primeTable);
            return new OkObjectResult(new JsonResult<PaginacionResultadoDto<OperadoraTelefonoDto>>(resultado));
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Crear OperadoraTelefono",
        Description = "crear",
        OperationId = "OperadoraTelefono.Post",
        Tags = new[] { "OperadoraTelefonoServicio" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Crear(OperadoraTelefonoCrearDto OperadoraTelefonoCrearDto)
        {
            var resultado = await _operadoraTelefonoServicio.CrearAsync(OperadoraTelefonoCrearDto);
            return new OkObjectResult(new JsonResult<bool>(resultado));
        }

        [HttpPut]
        [SwaggerOperation(
           Summary = "Actualizar OperadoraTelefono",
           Description = "crear",
           OperationId = "OperadoraTelefono.Put",
           Tags = new[] { "OperadoraTelefonoServicio" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Actualizar(OperadoraTelefonoActualizarDto OperadoraTelefonoActualizarDto)
        {
            var resultado = await _operadoraTelefonoServicio.ActualizarAsync(OperadoraTelefonoActualizarDto);
            return new OkObjectResult(new JsonResult<bool>(resultado));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
           Summary = "Eliminar OperadoraTelefono",
           Description = "crear",
           OperationId = "OperadoraTelefono.Delete",
           Tags = new[] { "OperadoraTelefonoServicio" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Eliminar(int id)
        {
            var resultado = await _operadoraTelefonoServicio.EliminarAsync(id);
            return new OkObjectResult(new JsonResult<bool>(resultado));
        }

    }
}
