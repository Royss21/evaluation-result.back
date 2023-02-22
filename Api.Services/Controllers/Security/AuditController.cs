namespace Api.Services.Controllers.Security
{
    using SharedKernell.Wrappers;
    using Api.Services.Controllers;
    using Application.Main.Services.Security.Interfaces;
    using Application.Dto.Security.Role;
    using Application.Dto.Pagination;
    using Domain.Main.Security;

    [Route("api/role")]
    [ApiController]
    public class AuditController : BaseController
    {
        private readonly IAuditService _auditService;
        private readonly ILogService _logService;
        private readonly ILogger<AuditController> _logger;
        public AuditController(IAuditService auditService, ILogService logService,  ILogger<AuditController> logger)
        {
            this._auditService = auditService;
            this._logService = logService;
            this._logger = logger;
        }

        [HttpGet("audit-paging")]
        [SwaggerOperation(
        Summary = "Lista Paginada de Auditoria",
        Description = "Lista Paginada de Auditoria",
        OperationId = "AuditService.GetAllAuditPaging",
        Tags = new[] { "AuditService" })]
        [ProducesResponseType(typeof(JsonResult<PaginationResultDto<AuditEntity>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAuditPaging([FromQuery] PagingFilterDto filter)
        {
            var result = await _auditService.GetAllPagingAsync(filter);
            return new OkObjectResult(new JsonResult<PaginationResultDto<AuditEntity>>(result));
        }


        [HttpGet("log-paging")]
        [SwaggerOperation(
        Summary = "Lista Paginada de Log",
        Description = "Lista Paginada de Log",
        OperationId = "AuditService.GetAllLogPaging",
        Tags = new[] { "AuditService" })]
        [ProducesResponseType(typeof(JsonResult<PaginationResultDto<LogEntity>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllLogPaging([FromQuery] PagingFilterDto filter)
        {
            var result = await _logService.GetAllPagingAsync(filter);
            return new OkObjectResult(new JsonResult<PaginationResultDto<LogEntity>>(result));
        }

    }
}
