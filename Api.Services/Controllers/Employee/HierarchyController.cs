namespace Api.Services.Controllers.Employee
{
    using SharedKernell.Wrappers;
    using Application.Dto.Employee.Hierarchy;
    using Application.Main.Services.Employee.Interfaces;
    using Application.Dto.Pagination;

    [Route("api/hierarchy")]
    [ApiController]
    public class HierarchyController : BaseController
    {
        private readonly IHierarchyService _hierarchyService;
        private readonly ILogger<HierarchyController> _logger;

        public HierarchyController(IHierarchyService hierarchyService, ILogger<HierarchyController> logger)
        {
            _hierarchyService = hierarchyService;
            _logger = logger;
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Crear Jerarquía",
        Description = "Crear Jerarquía",
        OperationId = "HierarchyService.Create",
        Tags = new[] { "HierarchyService" })]
        [ProducesResponseType(typeof(JsonResult<HierarchyDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(HierarchyCreateDto request)
        {
            var result = await _hierarchyService.CreateAsync(request);
            return new OkObjectResult(new JsonResult<HierarchyDto>(result));
        }

        [HttpPut]
        [SwaggerOperation(
        Summary = "Actualizar Jerarquía",
        Description = "Actualizar Jerarquía",
        OperationId = "HierarchyService.Update",
        Tags = new[] { "HierarchyService" })]
        [ProducesResponseType(typeof(JsonResult<HierarchyDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(HierarchyUpdateDto request)
        {
            var result = await _hierarchyService.UpdateAsync(request);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Lista de Jerarquías",
        Description = "Listado de Jerarquías",
        OperationId = "HierarchyService.GetAll",
        Tags = new[] { "HierarchyService" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<HierarchyDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _hierarchyService.GetAllAsync();
            return new OkObjectResult(new JsonResult<List<HierarchyDto>>(result.ToList()));
        }

        [HttpGet("paging")]
        [SwaggerOperation(
        Summary = "Lista Paginada de Jerarquías",
        Description = "Lista Paginada de Jerarquías",
        OperationId = "HierarchyService.GetAllPaging",
        Tags = new[] { "HierarchyService" })]
        [ProducesResponseType(typeof(JsonResult<PaginationResultDto<HierarchyDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPaging([FromQuery] PagingFilterDto filter)
        {
            var result = await _hierarchyService.GetAllPagingAsync(filter);
            return new OkObjectResult(new JsonResult<PaginationResultDto<HierarchyDto>>(result));
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Obtener Jerarquía",
        Description = "Obtener Jerarquía",
        OperationId = "HierarchyService.GetById",
        Tags = new[] { "HierarchyService" })]
        [ProducesResponseType(typeof(JsonResult<HierarchyDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _hierarchyService.GetByIdAsync(id);
            return new OkObjectResult(new JsonResult<HierarchyDto>(result));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Eliminar Jerarquía",
        Description = "Eliminar Jerarquía",
        OperationId = "HierarchyService.Delete",
        Tags = new[] { "HierarchyService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _hierarchyService.DeleteAsync(id);
            return new OkObjectResult(new JsonResult<bool>(result));
        }
    }
}
