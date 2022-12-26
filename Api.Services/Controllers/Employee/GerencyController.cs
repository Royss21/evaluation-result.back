namespace Api.Services.Controllers.Employee
{
    using Api.Services.Controllers;
    using Application.Dto.Employee.Gerency;
    using Application.Dto.Pagination;
    using Application.Main.Services.Employee.Interfaces;
    using SharedKernell.Wrappers;

    [Route("api/gerency")]
    [ApiController]
    public class GerencyController : BaseController
    {
        private readonly IGerencyService _gerencyService;
        private readonly ILogger<GerencyController> _logger;
        public GerencyController(IGerencyService gerencyService, ILogger<GerencyController> logger)
        {
            this._gerencyService = gerencyService;
            this._logger = logger;
        }

        [HttpGet("paging")]
        [SwaggerOperation(
        Summary = "Lista Paginada de Gerencias",
        Description = "Lista Paginada de Gerencias",
        OperationId = "GerencyService.GetAllPaging",
        Tags = new[] { "GerencyService" })]
        [ProducesResponseType(typeof(JsonResult<PaginationResultDto<GerencyDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPaging([FromQuery] PagingFilterDto filter)
        {
            var result = await _gerencyService.GetAllPagingAsync(filter);
            return new OkObjectResult(new JsonResult<PaginationResultDto<GerencyDto>>(result));
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Obtener Lista de Gerencias",
        Description = "Obtener Lista de Gerencias",
        OperationId = "GerencyService.GetAll",
        Tags = new[] { "GerencyService" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<GerencyDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _gerencyService.GetAllAsync();
            return new OkObjectResult(new JsonResult<IEnumerable<GerencyDto>>(result));
        }
    }
}
