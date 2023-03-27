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

        [HttpPost]
        [SwaggerOperation(
        Summary = "Crear Evaluacion",
        Description = "crear Evaluation",
        OperationId = "Evaluation.Create",
        Tags = new[] { "EvaluationService" })]
        [ProducesResponseType(typeof(JsonResult<EvaluationResDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(EvaluationCreateDto Evaluation)
        {
            var result = await _evaluationService.CreateAsync(Evaluation);
            return new OkObjectResult(new JsonResult<EvaluationResDto>(result));
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

        [HttpGet("finished")]
        [SwaggerOperation(
        Summary = "Lista de evaluaciones finalizadas",
        Description = "Listado de evaluaciones finalizadas",
        OperationId = "Evaluation.GetAllEvaluationFinished",
        Tags = new[] { "EvaluationService" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<EvaluationListDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllEvaluationFinished()
        {
            var result = await _evaluationService.GetAllEvaluationFinishedAsync();
            return new OkObjectResult(new JsonResult<List<EvaluationListDto>>(result.ToList()));
        }

        [HttpGet("edit/{evaluationId}")]
        [SwaggerOperation(
        Summary = "Obtener fechas de evaluation y componentes",
        Description = "Obtener fechas de evaluation y componentes",
        OperationId = "Evaluation.GetDatesComponents",
        Tags = new[] { "EvaluationService" })]
        [ProducesResponseType(typeof(JsonResult<EvaluationComponentsDatesDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDatesComponents(Guid evaluationId)
        {
            var result = await _evaluationService.GetDatesComponents(evaluationId);
            return new OkObjectResult(new JsonResult<EvaluationComponentsDatesDto>(result));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Eliminar evaluación",
        Description = "Eliminar evaluación",
        OperationId = "Evaluation.Delete",
        Tags = new[] { "EvaluationService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _evaluationService.DeleteAsync(id);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
        Summary = "Actualizar fechas evaluación",
        Description = "Actualizar fechas evaluación",
        OperationId = "Evaluation.Update",
        Tags = new[] { "EvaluationService" })]
        [ProducesResponseType(typeof(JsonResult<EvaluationResDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(EvaluationCreateDto evaluation, Guid id)
        {
            var result = await _evaluationService.UpdateAsync(evaluation, id);
            return new OkObjectResult(new JsonResult<EvaluationResDto>(result));
        }
    }
}
