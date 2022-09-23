namespace Api.Services.Controllers.Entidades
{
    using Api.Services.Controllers;
    using Application.Dto.Entidades.Color;
    using Application.Main.Servicios.Entidades.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : BaseController
    {
        private readonly IColorServicio _ColorServicio;
        private readonly ILogger<ColorController> _logger;

        public ColorController(IColorServicio ColorServicio, ILogger<ColorController> logger)
        {
            _ColorServicio = ColorServicio;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Lista de Colors",
        Description = "Listado donde se listan las Colors de la compañia",
        OperationId = "Color.get",
        Tags = new[] { "ColorServicio" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<ColorDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodo()
        {
            var resultado = await _ColorServicio.ObtenerTodoAsync();
            return new OkObjectResult(new JsonResult<List<ColorDto>>(resultado.ToList()));
        }


        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Obtener  Color",
        Description = "Listado donde se listan las Colors de la compañia",
        OperationId = "Color.Get.obtenerPorId",
        Tags = new[] { "ColorServicio" })]
        [ProducesResponseType(typeof(JsonResult<ColorDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var resultado = await _ColorServicio.ObtenerPorIdAsync(id);
            return new OkObjectResult(new JsonResult<ColorDto>(resultado));
        }

        [HttpGet("paginado")]
        [SwaggerOperation(
        Summary = "Lista Paginada Color",
        Description = "lista paginada de Colors",
        OperationId = "Color.Get.paginado",
        Tags = new[] { "ColorServicio" })]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodoPaginado([FromQuery] PrimeTable primeTable)
        {
            var resultado = await _ColorServicio.ObtenerTodoPaginadoAsync(primeTable);
            return new OkObjectResult(new JsonResult<PaginacionResultadoDto<ColorDto>>(resultado));
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Crear Color",
        Description = "crear",
        OperationId = "Color.post",
        Tags = new[] { "ColorServicio" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Crear(ColorCrearDto ColorCrearDto)
        {
            var resultado = await _ColorServicio.CrearAsync(ColorCrearDto);
            return new OkObjectResult(new JsonResult<bool>(resultado));
        }

        [HttpPut]
        [SwaggerOperation(
           Summary = "Actualizar Color",
           Description = "crear",
           OperationId = "Color.put",
           Tags = new[] { "ColorServicio" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Actualizar(ColorActualizarDto ColorActualizarDto)
        {
            var resultado = await _ColorServicio.ActualizarAsync(ColorActualizarDto);
            return new OkObjectResult(new JsonResult<bool>(resultado));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
           Summary = "Eliminar Color",
           Description = "crear",
           OperationId = "Color.delete",
           Tags = new[] { "ColorServicio" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Eliminar(int id)
        {
            var resultado = await _ColorServicio.EliminarAsync(id);
            return new OkObjectResult(new JsonResult<bool>(resultado));
        }

    }
}
