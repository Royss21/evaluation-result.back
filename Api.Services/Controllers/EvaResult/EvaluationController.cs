namespace Api.Services.Controllers.EvaResult
{
    using Api.Services.Controllers;
    using Application.Dto.EvaResult.Evaluation;
    using Application.Main.Services.EvaResult.Interfaces;
    using SharedKernell.Wrappers;

    [Route("api/evaluation")]
    [ApiController]
    public class EvaluationController : BaseController
    {
        private readonly IEvaluationService _evaluationService;
        private readonly ILogger<EvaluationController> _logger;

        public EvaluationController(IEvaluationService evaluationService, ILogger<EvaluationController> logger)
        {
            _evaluationService = evaluationService;
            _logger = logger;
        }

        //[HttpGet]
        //[SwaggerOperation(
        //Summary = "Lista de Evaluaciones",
        //Description = "Listado de Evaluationos",
        //OperationId = "Evaluation.GetAll",
        //Tags = new[] { "EvaluationService" })]
        //[ProducesResponseType(typeof(JsonResult<IEnumerable<EvaluationDto>>), StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetAll()
        //{
        //    var result = await _evaluationService.GetAllAsync();
        //    return new OkObjectResult(new JsonResult<IEnumerable<EvaluationDto>>(result));
        //}

        //[HttpGet("paging")]
        //[SwaggerOperation(
        //Summary = "Lista Paginada Evaluaciones",
        //Description = "lista paginada de Evaluationso",
        //OperationId = "Evaluation.GetAllPaging",
        //Tags = new[] { "EvaluationService" })]
        //[ProducesResponseType(typeof(JsonResult<PaginationResultDto<EvaluationDto>>), StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetAllPaging([FromQuery] PrimeTable primeTable)
        //{
        //    var result = await _evaluationService.GetAllPagingAsync(primeTable);
        //    return new OkObjectResult(new JsonResult<PaginationResultDto<EvaluationDto>>(result));
        //}

        [HttpPost]
        [SwaggerOperation(
        Summary = "Crear Evaluacion",
        Description = "crear Evaluation",
        OperationId = "Evaluation.Create",
        Tags = new[] { "EvaluationService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(EvaluationCreateDto Evaluation)
        {
            var result = await _evaluationService.CreateAsync(Evaluation);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

       

        [HttpGet("{id}/detail")]
        [SwaggerOperation(
        Summary = "Obtener Evaluacion",
        Description = "evaluacion",
        OperationId = "Evaluation.GetEvaluationDetail",
        Tags = new[] { "EvaluationService" })]
        [ProducesResponseType(typeof(JsonResult<EvaluationDetailDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEvaluationDetail(Guid id)
        {
            var result = await _evaluationService.GetEvaluationDetailAsync(id);
            return new OkObjectResult(new JsonResult<EvaluationDetailDto>(result));
        }

        [HttpGet("{id}/enabled-components")]
        [SwaggerOperation(
        Summary = "Obtener Evaluacion",
        Description = "evaluacion",
        OperationId = "Evaluation.GetEnabledComponents",
        Tags = new[] { "EvaluationService" })]
        [ProducesResponseType(typeof(JsonResult<EvaluationDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEnabledComponents(Guid id)
        {
            var result = await _evaluationService.GetEnabledComponentsAsync(id);
            return new OkObjectResult(new JsonResult<EvaluationDto>(result));
        }

        [HttpGet("all-detail")]
        [SwaggerOperation(
        Summary = "Obtener Listado de Evaluaciones",
        Description = "Obtener Listado de Evaluaciones",
        OperationId = "Evaluation.GetAllEvaluationDetail",
        Tags = new[] { "EvaluationService" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<EvaluationDetailDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllEvaluationDetail()
        {
            var result = await _evaluationService.GetAllEvaluationDetailAsync();
            return new OkObjectResult(new JsonResult<IEnumerable<EvaluationDetailDto>>(result));
        }

        //[HttpDelete("{id}")]
        //[SwaggerOperation(
        //Summary = "Eliminar Evaluationo",
        //Description = "eliminar Evaluationo",
        //OperationId = "Evaluation.Delete",
        //Tags = new[] { "EvaluationService" })]
        //[ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await _evaluationService.DeleteAsync(id);
        //    return new OkObjectResult(new JsonResult<bool>(result));
        //}

    }
}
