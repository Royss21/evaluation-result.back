namespace Api.Services.Controllers.Security
{
    using Api.Services.Controllers;
    using Application.Dto.Config.Subcomponent;
    using Application.Dto.Pagination;
    using Application.Dto.Report;
    using Application.Main.Services.Report.Interfaces;
    using SharedKernell.Wrappers;

    [Route("api/report")]
    [ApiController]
    public class ReportController : BaseController
    {
        private readonly IReportService _reportService;
        private readonly ILogger<ReportController> _logger;
        public ReportController( ILogger<ReportController> logger, IReportService reportService)
        {
            this._logger = logger;
            _reportService = reportService;
        }

        [HttpGet("paging")]
        [SwaggerOperation(
        Summary = "Lista paginada resultado evaluacion final",
        Description = "lista paginada resultado evaluacion final",
        OperationId = "Report.GetAllPagingByFinalResult",
        Tags = new[] { "ReportService" })]
        [ProducesResponseType(typeof(JsonResult<PaginationResultDto<EvaluationCollaboratorFinalResultDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPagingByFinalResult([FromQuery] EvaluationCollaboratorFinalResultFilterDto filter)
        {
            var result = await _reportService.GetAllPagingByFinalResultAsync(filter);
            return new OkObjectResult(new JsonResult<PaginationResultDto<EvaluationCollaboratorFinalResultDto>>(result));
        }

        [HttpGet("get-all-final-result")]
        [SwaggerOperation(
        Summary = "Lista resultado evaluacion final",
        Description = "lista  resultado evaluacion final",
        OperationId = "Report.GetAllPagingByFinalResult",
        Tags = new[] { "ReportService" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<EvaluationCollaboratorFinalResultDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllByFinalResult(string globalFilter, Guid? evluationId)
        {
            var result = await _reportService.GetAllByFinalResultAsync(globalFilter, evluationId);
            return new OkObjectResult(new JsonResult<IEnumerable<EvaluationCollaboratorFinalResultDto>>(result));
        }
    }
}
