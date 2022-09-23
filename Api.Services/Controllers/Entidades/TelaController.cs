namespace Api.Services.Controllers.Entidades
{
    using Api.Services.Controllers;
    using Application.Dto.Entidades.Tela;
    using Application.Main.Servicios.Entidades.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class TelaController : BaseController
    {
        private readonly ITelaServicio _TelaServicio;
        private readonly ILogger<TelaController> _logger;

        public TelaController(ITelaServicio TelaServicio, ILogger<TelaController> logger)
        {
            _TelaServicio = TelaServicio;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Lista de Telas",
        Description = "Listado donde se listan las Telas de la compañia",
        OperationId = "Tela.Get",
        Tags = new[] { "TelaServicio" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<TelaDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodo()
        {
            var resultado = await _TelaServicio.ObtenerTodoAsync();
            return new OkObjectResult(new JsonResult<List<TelaDto>>(resultado.ToList()));
        }


        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Obtener  Tela",
        Description = "Listado donde se listan las Telas de la compañia",
        OperationId = "Tela.Get.obtenerPorId",
        Tags = new[] { "TelaServicio" })]
        [ProducesResponseType(typeof(JsonResult<TelaDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var resultado = await _TelaServicio.ObtenerPorIdAsync(id);
            return new OkObjectResult(new JsonResult<TelaDto>(resultado));
        }

        [HttpGet("paginado")]
        [SwaggerOperation(
        Summary = "Lista Paginada Tela",
        Description = "lista paginada de Telas",
        OperationId = "Tela.Get.paginado",
        Tags = new[] { "TelaServicio" })]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodoPaginado([FromQuery] PrimeTable primeTable)
        {
            var resultado = await _TelaServicio.ObtenerTodoPaginadoAsync(primeTable);
            return new OkObjectResult(new JsonResult<PaginacionResultadoDto<TelaPaginadoDto>>(resultado));
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Crear Tela",
        Description = "crear",
        OperationId = "Tela.Post",
        Tags = new[] { "TelaServicio" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Crear(TelaCrearDto TelaCrearDto)
        {
            var resultado = await _TelaServicio.CrearAsync(TelaCrearDto);
            return new OkObjectResult(new JsonResult<bool>(resultado));
        }

        [HttpPut]
        [SwaggerOperation(
           Summary = "Actualizar Tela",
           Description = "crear",
           OperationId = "Tela.Put",
           Tags = new[] { "TelaServicio" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Actualizar(TelaActualizarDto TelaActualizarDto)
        {
            var resultado = await _TelaServicio.ActualizarAsync(TelaActualizarDto);
            return new OkObjectResult(new JsonResult<bool>(resultado));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
           Summary = "Eliminar Tela",
           Description = "crear",
           OperationId = "Tela.Delete",
           Tags = new[] { "TelaServicio" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Eliminar(int id)
        {
            var resultado = await _TelaServicio.EliminarAsync(id);
            return new OkObjectResult(new JsonResult<bool>(resultado));
        }

    }
}
