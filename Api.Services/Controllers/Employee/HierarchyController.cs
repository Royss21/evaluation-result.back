namespace Api.Services.Controllers.Employee
{
    using SharedKernell.Wrappers;
    using Application.Dto.Employee.Hierarchy;
    using Application.Main.Services.Employee.Interfaces;

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
    }
}
