namespace Api.Services.Controllers.Config
{
    using SharedKernell.Wrappers;
    using Api.Services.Controllers;
    using Application.Dto.Pagination;
    using Application.Dto.Employee.Hierarchy;
    using Application.Main.Services.Config.Interfaces;
    using Application.Dto.Config.HierarchyComponent;

    [Route("api/hierarchy-component")]
    [ApiController]
    public class HierarchyComponentController : BaseController
    {
        private readonly IHierarchyComponentService _hierarchyComponentService;
        private readonly ILogger<HierarchyComponentController> _logger;

        public HierarchyComponentController(IHierarchyComponentService hierarchyComponentService, ILogger<HierarchyComponentController> logger)
        {
            _hierarchyComponentService = hierarchyComponentService;
            _logger = logger;
        }

        [HttpGet("paging")]
        [SwaggerOperation(
        Summary = "Lista Paginada Jerarquías de componentes",
        Description = "lista Paginada de Jerarquías de componentes",
        OperationId = "HierarchyComponentService.GetAllPaging",
        Tags = new[] { "HierarchyComponentService" })]
        [ProducesResponseType(typeof(JsonResult<PaginationResultDto<HierarchyComponentPagingDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPaging([FromQuery] PagingFilterDto filter)
        {
            var result = await _hierarchyComponentService.GetAllPagingAsync(filter);
            return new OkObjectResult(new JsonResult<PaginationResultDto<HierarchyComponentPagingDto>>(result));
        }

        [HttpPut]
        [SwaggerOperation(
        Summary = "Asignar pesos por jerarquía",
        Description = "Asignar pesos por jerarquía",
        OperationId = "HierarchyComponentService.Asign",
        Tags = new[] { "HierarchyComponentService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Asign(List<HierarchyComponentUpdateDto> request)
        {
            var result = await _hierarchyComponentService.UpdateBulkAsync(request);
            return new OkObjectResult(new JsonResult<bool>(result));
        }
    }
}
