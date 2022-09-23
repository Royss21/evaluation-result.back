namespace Api.Services.Controllers.Entidades
{
    using Api.Services.Controllers;
    using Application.Dto.Entidades.Tamanio;
    using Application.Main.Servicios.Entidades.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class TamanioController : BaseController
    {
        private readonly ITamanioServicio _tamanioServicio;
        private readonly ILogger<TamanioController> _logger;

        public TamanioController(ITamanioServicio tamanioServicio, ILogger<TamanioController> logger)
        {
            _tamanioServicio = tamanioServicio;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Lista de Tamanios",
        Description = "Listado donde se listan las Tamanios de la compañia",
        OperationId = "Tamanio.Get",
        Tags = new[] { "TamanioServicio" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<TamanioDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodo()
        {
            var resultado = await _tamanioServicio.ObtenerTodoAsync();
            return new OkObjectResult(new JsonResult<List<TamanioDto>>(resultado.ToList()));
        }


        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Obtener  Tamanio",
        Description = "Listado donde se listan las Tamanios de la compañia",
        OperationId = "Tamanio.Get.obtenerPorId",
        Tags = new[] { "TamanioServicio" })]
        [ProducesResponseType(typeof(JsonResult<TamanioDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var resultado = await _tamanioServicio.ObtenerPorIdAsync(id);
            return new OkObjectResult(new JsonResult<TamanioDto>(resultado));
        }

        [HttpGet("paginado")]
        [SwaggerOperation(
        Summary = "Lista Paginada Tamanio",
        Description = "lista paginada de Tamanios",
        OperationId = "Tamanio.Get.paginado",
        Tags = new[] { "TamanioServicio" })]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodoPaginado([FromQuery] PrimeTable primeTable)
        {
            var resultado = await _tamanioServicio.ObtenerTodoPaginadoAsync(primeTable);
            return new OkObjectResult(new JsonResult<PaginacionResultadoDto<TamanioDto>>(resultado));
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Crear Tamanio",
        Description = "crear",
        OperationId = "Tamanio.Post",
        Tags = new[] { "TamanioServicio" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Crear(TamanioCrearDto TamanioCrearDto)
        {
            var resultado = await _tamanioServicio.CrearAsync(TamanioCrearDto);
            return new OkObjectResult(new JsonResult<bool>(resultado));
        }

        [HttpPut]
        [SwaggerOperation(
           Summary = "Actualizar Tamanio",
           Description = "crear",
           OperationId = "Tamanio.Put",
           Tags = new[] { "TamanioServicio" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Actualizar(TamanioActualizarDto TamanioActualizarDto)
        {
            var resultado = await _tamanioServicio.ActualizarAsync(TamanioActualizarDto);
            return new OkObjectResult(new JsonResult<bool>(resultado));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
           Summary = "Eliminar Tamanio",
           Description = "crear",
           OperationId = "Tamanio.Delete",
           Tags = new[] { "TamanioServicio" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Eliminar(int id)
        {
            var resultado = await _tamanioServicio.EliminarAsync(id);
            return new OkObjectResult(new JsonResult<bool>(resultado));
        }

    }
}
