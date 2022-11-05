namespace Api.Services.Controllers.EvaResult
{
    using Api.Services.Controllers;
    using Application.Dto.EvaResult.Evaluation;
    using Application.Dto.EvaResult.EvaluationLeader;
    using Application.Main.Exceptions;
    using Application.Main.Services.EvaResult.Interfaces;
    using ExcelDataReader;
    using SharedKernell.Wrappers;

    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationLeaderController : BaseController
    {
        private readonly IEvaluationLeaderService _evaluationLeaderService;
        private readonly ILogger<EvaluationController> _logger;

        public EvaluationLeaderController(IEvaluationLeaderService evaluationLeaderService, ILogger<EvaluationController> logger)
        {
            _evaluationLeaderService = evaluationLeaderService;
            _logger = logger;
        }

       
        [HttpPost]
        [SwaggerOperation(
        Summary = "Importar Masivo Evaluacion Lideres ",
        Description = "Importar EvaluationLeader",
        OperationId = "EvaluationLeader.ImportBulk",
        Tags = new[] { "EvaluationLeaderService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ImportBulk(EvaluationLeaderFileDto request)
        {           
            var result = await _evaluationLeaderService.ImportBulkAsync(request);
            return new OkObjectResult(new JsonResult<bool>(result));
        }
    }
}
