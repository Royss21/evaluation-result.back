namespace Api.Services.Controllers.Entidades
{
    using Api.Services.Controllers;
    using Application.Dto.Entidades.MarcaVehiculo;
    using Application.Main.Servicios.Entidades.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class MarcaVehiculoController : BaseController
    {
        private readonly IMarcaVehiculoServicio _marcaVehiculoServicio;
        private readonly ILogger<MarcaVehiculoController> _logger;

        public MarcaVehiculoController(IMarcaVehiculoServicio marcaVehiculoServicio, ILogger<MarcaVehiculoController> logger)
        {
            _marcaVehiculoServicio = marcaVehiculoServicio;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Lista de MarcaVehiculos",
        Description = "Listado donde se listan las MarcaVehiculos de la compañia",
        OperationId = "MarcaVehiculo.Get",
        Tags = new[] { "MarcaVehiculoServicio" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<MarcaVehiculoDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodo()
        {
            var resultado = await _marcaVehiculoServicio.ObtenerTodoAsync();
            return new OkObjectResult(new JsonResult<List<MarcaVehiculoDto>>(resultado.ToList()));
        }


        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Obtener  MarcaVehiculo",
        Description = "Listado donde se listan las MarcaVehiculos de la compañia",
        OperationId = "MarcaVehiculo.Get.obtenerPorId",
        Tags = new[] { "MarcaVehiculoServicio" })]
        [ProducesResponseType(typeof(JsonResult<MarcaVehiculoDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var resultado = await _marcaVehiculoServicio.ObtenerPorIdAsync(id);
            return new OkObjectResult(new JsonResult<MarcaVehiculoDto>(resultado));
        }

        [HttpGet("paginado")]
        [SwaggerOperation(
        Summary = "Lista Paginada MarcaVehiculo",
        Description = "lista paginada de MarcaVehiculos",
        OperationId = "MarcaVehiculo.Get.paginado",
        Tags = new[] { "MarcaVehiculoServicio" })]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodoPaginado([FromQuery] PrimeTable primeTable)
        {
            var resultado = await _marcaVehiculoServicio.ObtenerTodoPaginadoAsync(primeTable);
            return new OkObjectResult(new JsonResult<PaginacionResultadoDto<MarcaVehiculoDto>>(resultado));
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Crear MarcaVehiculo",
        Description = "crear",
        OperationId = "MarcaVehiculo.Post",
        Tags = new[] { "MarcaVehiculoServicio" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Crear(MarcaVehiculoCrearDto MarcaVehiculoCrearDto)
        {
            var resultado = await _marcaVehiculoServicio.CrearAsync(MarcaVehiculoCrearDto);
            return new OkObjectResult(new JsonResult<bool>(resultado));
        }

        [HttpPut]
        [SwaggerOperation(
           Summary = "Actualizar MarcaVehiculo",
           Description = "crear",
           OperationId = "MarcaVehiculo.Put",
           Tags = new[] { "MarcaVehiculoServicio" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Actualizar(MarcaVehiculoActualizarDto MarcaVehiculoActualizarDto)
        {
            var resultado = await _marcaVehiculoServicio.ActualizarAsync(MarcaVehiculoActualizarDto);
            return new OkObjectResult(new JsonResult<bool>(resultado));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
           Summary = "Eliminar MarcaVehiculo",
           Description = "crear",
           OperationId = "MarcaVehiculo.Delete",
           Tags = new[] { "MarcaVehiculoServicio" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Eliminar(int id)
        {
            var resultado = await _marcaVehiculoServicio.EliminarAsync(id);
            return new OkObjectResult(new JsonResult<bool>(resultado));
        }

    }
}
