namespace Api.Services.Controllers.Security
{
    using Api.Services.Controllers;
    using Application.Dto.Config.Subcomponent;
    using Application.Dto.Pagination;
    using Application.Dto.Report;
    using Application.Main.Services.Report.Interfaces;
    using Domain.Main.EvaResult;
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

        [HttpGet("paging-final-result")]
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
        OperationId = "Report.GetAllByFinalResult",
        Tags = new[] { "ReportService" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<EvaluationCollaboratorFinalResultDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllByFinalResult(string? globalFilter, Guid? evaluationId)
        {
            var result = await _reportService.GetAllByFinalResultAsync(evaluationId, globalFilter);
            return new OkObjectResult(new JsonResult<IEnumerable<EvaluationCollaboratorFinalResultDto>>(result));
        }


        [HttpGet("paging-follow-evaluation")]
        [SwaggerOperation(
        Summary = "Lista paginada seguimento evaluacion",
        Description = "lista paginada seguimento evaluacion",
        OperationId = "Report.GetAllPagingFollowResult",
        Tags = new[] { "ReportService" })]
        [ProducesResponseType(typeof(JsonResult<PaginationResultDto<EvaluationCollaboratorarFollowResultDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPagingFollowResult([FromQuery] EvaluationCollaboratorarFollowResultFilterDto filter)
        {
            var result = await _reportService.GetAllPagingFollowResultAsync(filter);
            return new OkObjectResult(new JsonResult<PaginationResultDto<EvaluationCollaboratorarFollowResultDto>>(result));
        }


        [HttpGet("get-all-follow-evaluation")]
        [SwaggerOperation(
        Summary = "Lista seguimento evaluacion",
        Description = "lista  seguimento evaluacion",
        OperationId = "Report.GetAllFollowResult",
        Tags = new[] { "ReportService" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<EvaluationCollaboratorarFollowResultDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllFollowResult(string? globalFilter, Guid? evaluationId)
        {
            var result = await _reportService.GetAllFollowResultAsync(evaluationId, globalFilter);
            return new OkObjectResult(new JsonResult<IEnumerable<EvaluationCollaboratorarFollowResultDto>>(result));
        }
    }
}
