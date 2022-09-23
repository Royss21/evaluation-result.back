namespace Api.Services.Controllers.Entidades
{
    using Api.Services.Controllers;
    using Application.Dto.Entidades.TipoVehiculo;
    using Application.Main.Servicios.Entidades.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class TipoVehiculoController : BaseController
    {
        private readonly ITipoVehiculoServicio _tipoVehiculoServicio;
        private readonly ILogger<TipoVehiculoController> _logger;

        public TipoVehiculoController(ITipoVehiculoServicio tipoVehiculoServicio, ILogger<TipoVehiculoController> logger)
        {
            _tipoVehiculoServicio = tipoVehiculoServicio;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Lista de TipoVehiculos",
        Description = "Listado donde se listan las TipoVehiculos de la compañia",
        OperationId = "TipoVehiculo.Get",
        Tags = new[] { "TipoVehiculoServicio" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<TipoVehiculoDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodo()
        {
            var resultado = await _tipoVehiculoServicio.ObtenerTodoAsync();
            return new OkObjectResult(new JsonResult<List<TipoVehiculoDto>>(resultado.ToList()));
        }


        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Obtener  TipoVehiculo",
        Description = "Listado donde se listan las TipoVehiculos de la compañia",
        OperationId = "TipoVehiculo.Get.obtenerPorId",
        Tags = new[] { "TipoVehiculoServicio" })]
        [ProducesResponseType(typeof(JsonResult<TipoVehiculoDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var resultado = await _tipoVehiculoServicio.ObtenerPorIdAsync(id);
            return new OkObjectResult(new JsonResult<TipoVehiculoDto>(resultado));
        }

        [HttpGet("paginado")]
        [SwaggerOperation(
        Summary = "Lista Paginada TipoVehiculo",
        Description = "lista paginada de TipoVehiculos",
        OperationId = "TipoVehiculo.Get.paginado",
        Tags = new[] { "TipoVehiculoServicio" })]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodoPaginado([FromQuery] PrimeTable primeTable)
        {
            var resultado = await _tipoVehiculoServicio.ObtenerTodoPaginadoAsync(primeTable);
            return new OkObjectResult(new JsonResult<PaginacionResultadoDto<TipoVehiculoDto>>(resultado));
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Crear TipoVehiculo",
        Description = "crear",
        OperationId = "TipoVehiculo.Post",
        Tags = new[] { "TipoVehiculoServicio" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Crear(TipoVehiculoCrearDto TipoVehiculoCrearDto)
        {
            var resultado = await _tipoVehiculoServicio.CrearAsync(TipoVehiculoCrearDto);
            return new OkObjectResult(new JsonResult<bool>(resultado));
        }

        [HttpPut]
        [SwaggerOperation(
           Summary = "Actualizar TipoVehiculo",
           Description = "crear",
           OperationId = "TipoVehiculo.Put",
           Tags = new[] { "TipoVehiculoServicio" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Actualizar(TipoVehiculoActualizarDto TipoVehiculoActualizarDto)
        {
            var resultado = await _tipoVehiculoServicio.ActualizarAsync(TipoVehiculoActualizarDto);
            return new OkObjectResult(new JsonResult<bool>(resultado));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
           Summary = "Eliminar TipoVehiculo",
           Description = "crear",
           OperationId = "TipoVehiculo.Delete",
           Tags = new[] { "TipoVehiculoServicio" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Eliminar(int id)
        {
            var resultado = await _tipoVehiculoServicio.EliminarAsync(id);
            return new OkObjectResult(new JsonResult<bool>(resultado));
        }

    }
}
