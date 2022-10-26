namespace Api.Services.Controllers.Config
{
    using Api.Services.Controllers;
    using Application.Dto.Employee.Area;
    using Application.Dto.Pagination;
    using Application.Main.Services.Config.Interfaces;
    using SharedKernell.Wrappers;

    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : BaseController
    {
        private readonly IAreaService _areaService;
        private readonly ILogger<AreaController> _logger;

        public AreaController(IAreaService areaService, ILogger<AreaController> logger)
        {
            _areaService = areaService;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Lista de Areas",
        Description = "Listado de areas",
        OperationId = "Area.GetAll",
        Tags = new[] { "AreaService" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<AreaDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _areaService.GetAllAsync();
            return new OkObjectResult(new JsonResult<List<AreaDto>>(result.ToList()));
        }

        [HttpGet("paging")]
        [SwaggerOperation(
        Summary = "Lista Paginada Areas",
        Description = "lista paginada de areas",
        OperationId = "Area.GetAllPaging",
        Tags = new[] { "AreaService" })]
        [ProducesResponseType(typeof(JsonResult<PaginationResultDto<AreaDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPaging([FromQuery] PrimeTable primeTable)
        {
            var result = await _areaService.GetAllPagingAsync(primeTable);
            return new OkObjectResult(new JsonResult<PaginationResultDto<AreaDto>>(result));
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Crear Area",
        Description = "crear area",
        OperationId = "Area.Create",
        Tags = new[] { "AreaService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(AreaCreateDto area)
        {
            var result = await _areaService.CreateAsync(area);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Eliminar Area",
        Description = "eliminar area",
        OperationId = "Area.Delete",
        Tags = new[] { "AreaService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _areaService.DeleteAsync(id);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

    }
}
