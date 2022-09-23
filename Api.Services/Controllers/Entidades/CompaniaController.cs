namespace Api.Services.Controllers.Entidades
{
    using Api.Services.Controllers;
    using Application.Dto.Entidades.Compania;
    using Application.Main.Servicios.Entidades.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class CompaniaController : BaseController
    {
        private readonly ICompaniaServicio _companiaServicio;
        private readonly ILogger<CompaniaController> _logger;

        public CompaniaController(ICompaniaServicio companiaServicio, ILogger<CompaniaController> logger)
        {
            _companiaServicio = companiaServicio;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Lista de Companias",
        Description = "Listado donde se listan las Companias de la compañia",
        OperationId = "Compania.Get",
        Tags = new[] { "CompaniaServicio" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<CompaniaDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodo()
        {
            var resultado = await _companiaServicio.ObtenerTodoAsync();
            return new OkObjectResult(new JsonResult<List<CompaniaDto>>(resultado.ToList()));
        }


        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Obtener  Compania",
        Description = "Listado donde se listan las Companias de la compañia",
        OperationId = "Compania.Get.obtenerPorId",
        Tags = new[] { "CompaniaServicio" })]
        [ProducesResponseType(typeof(JsonResult<CompaniaDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerPorId(Guid id)
        {
            var resultado = await _companiaServicio.ObtenerPorIdAsync(id);
            return new OkObjectResult(new JsonResult<CompaniaDto>(resultado));
        }

        [HttpGet("paginado")]
        [SwaggerOperation(
        Summary = "Lista Paginada Compania",
        Description = "lista paginada de Companias",
        OperationId = "Compania.Get.paginado",
        Tags = new[] { "CompaniaServicio" })]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodoPaginado([FromQuery] PrimeTable primeTable)
        {
            var resultado = await _companiaServicio.ObtenerTodoPaginadoAsync(primeTable);
            return new OkObjectResult(new JsonResult<PaginacionResultadoDto<CompaniaDto>>(resultado));
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Crear Compania",
        Description = "crear",
        OperationId = "Compania.Post",
        Tags = new[] { "CompaniaServicio" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Crear(CompaniaCrearDto CompaniaCrearDto)
        {
            var resultado = await _companiaServicio.CrearAsync(CompaniaCrearDto);
            return new OkObjectResult(new JsonResult<bool>(resultado));
        }

        [HttpPut]
        [SwaggerOperation(
           Summary = "Actualizar Compania",
           Description = "crear",
           OperationId = "Compania.Put",
           Tags = new[] { "CompaniaServicio" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Actualizar(CompaniaActualizarDto CompaniaActualizarDto)
        {
            var resultado = await _companiaServicio.ActualizarAsync(CompaniaActualizarDto);
            return new OkObjectResult(new JsonResult<bool>(resultado));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
           Summary = "Eliminar Compania",
           Description = "crear",
           OperationId = "Compania.Delete",
           Tags = new[] { "CompaniaServicio" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var resultado = await _companiaServicio.EliminarAsync(id);
            return new OkObjectResult(new JsonResult<bool>(resultado));
        }

    }
}
