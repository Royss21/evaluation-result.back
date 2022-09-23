namespace Api.Services.Controllers.Entidades
{
    using Api.Services.Controllers;
    using Application.Dto.Entidades.Categoria;
    using Application.Main.Servicios.Entidades.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : BaseController
    {
        private readonly ICategoriaServicio _categoriaServicio;
        private readonly ILogger<CategoriaController> _logger;

        public CategoriaController(ICategoriaServicio categoriaServicio, ILogger<CategoriaController> logger)
        {
            _categoriaServicio = categoriaServicio;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Lista de Categorias",
        Description = "Listado donde se listan las categorias de la compañia",
        OperationId = "Categoria.Get",
        Tags = new[] { "CategoriaServicio" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<CategoriaDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodo()
        {
            var resultado = await _categoriaServicio.ObtenerTodoAsync();
            return new OkObjectResult(new JsonResult<List<CategoriaDto>>(resultado.ToList()));
        }


        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Obtener  Categoria",
        Description = "Listado donde se listan las categorias de la compañia",
        OperationId = "Categoria.Get.obtenerPorId",
        Tags = new[] { "CategoriaServicio" })]
        [ProducesResponseType(typeof(JsonResult<CategoriaDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var resultado = await _categoriaServicio.ObtenerPorIdAsync(id);
            return new OkObjectResult(new JsonResult<CategoriaDto>(resultado));
        }

        [HttpGet("paginado")]
        [SwaggerOperation(
        Summary = "Lista Paginada Categoria",
        Description = "lista paginada de categorias",
        OperationId = "Categoria.Get.paginado",
        Tags = new[] { "CategoriaServicio" })]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodoPaginado([FromQuery] PrimeTable primeTable)
        {
            var resultado = await _categoriaServicio.ObtenerTodoPaginadoAsync(primeTable);
            return new OkObjectResult(new JsonResult<PaginacionResultadoDto<CategoriaDto>>(resultado));
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Crear Categoria",
        Description = "crear",
        OperationId = "Categoria.Post",
        Tags = new[] { "CategoriaServicio" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Crear(CategoriaCrearDto categoriaCrearDto)
        {
            var resultado = await _categoriaServicio.CrearAsync(categoriaCrearDto);
            return new OkObjectResult(new JsonResult<bool>(resultado));
        }

        [HttpPut]
        [SwaggerOperation(
           Summary = "Actualizar Categoria",
           Description = "crear",
           OperationId = "Categoria.Put",
           Tags = new[] { "CategoriaServicio" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Actualizar(CategoriaActualizarDto categoriaActualizarDto)
        {
            var resultado = await _categoriaServicio.ActualizarAsync(categoriaActualizarDto);
            return new OkObjectResult(new JsonResult<bool>(resultado));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
           Summary = "Eliminar Categoria",
           Description = "crear",
           OperationId = "Categoria.Delete",
           Tags = new[] { "CategoriaServicio" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Eliminar(int id)
        {
            var resultado = await _categoriaServicio.EliminarAsync(id);
            return new OkObjectResult(new JsonResult<bool>(resultado));
        }

    }
}
