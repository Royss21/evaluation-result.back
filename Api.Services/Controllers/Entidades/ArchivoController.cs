namespace Api.Services.Controllers.Entidades
{
    using Api.Services.Controllers;
    using Application.Dto.Entidades.Color;
    using Application.Main.Servicios.Entidades.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class ArchivoController : BaseController
    {
        private readonly IImagenServicio _imagenServicio;
        private readonly ILogger<ArchivoController> _logger;

        public ArchivoController(IImagenServicio imagenServicio, ILogger<ArchivoController> logger)
        {
            _imagenServicio = imagenServicio;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Lista de Archivos",
        Description = "Listado donde se listan las Archivos de la compañia",
        OperationId = "Archivo.Get",
        Tags = new[] { "ArchivoServicio" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<ImagenDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodo()
        {
            var resultado = await _imagenServicio.ObtenerTodoAsync();
            return new OkObjectResult(new JsonResult<List<ImagenDto>>(resultado.ToList()));
        }

        [HttpGet("paginado")]
        [SwaggerOperation(
        Summary = "Lista Paginada Archivo",
        Description = "lista paginada de Archivos",
        OperationId = "Archivo.Get.paginado",
        Tags = new[] { "ArchivoServicio" })]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodoPaginado([FromQuery] PrimeTable primeTable)
        {
            var resultado = await _imagenServicio.ObtenerTodoPaginadoAsync(primeTable);
            return new OkObjectResult(new JsonResult<PaginacionResultadoDto<ImagenDto>>(resultado));
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Crear Archivo",
        Description = "crear",
        OperationId = "Archivo.Post",
        Tags = new[] { "ArchivoServicio" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Crear([FromForm]ImagenCrearDto ArchivoCrearDto)
        {
            var resultado = await _imagenServicio.CrearAsync(ArchivoCrearDto);
            return new OkObjectResult(new JsonResult<int>(resultado));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
           Summary = "Eliminar Archivo",
           Description = "crear",
           OperationId = "Archivo.Delete",
           Tags = new[] { "ArchivoServicio" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Eliminar(int id)
        {
            var resultado = await _imagenServicio.EliminarAsync(id);
            return new OkObjectResult(new JsonResult<bool>(resultado));
        }

    }
}
