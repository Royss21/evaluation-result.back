namespace Api.Services.Controllers.EvaResult
{
    using Api.Services.Controllers;
    using Application.Dto.EvaResult.Evaluation;
    using Application.Dto.EvaResult.EvaluationCollaborator;
    using Application.Dto.Pagination;
    using Application.Main.Services.EvaResult.Interfaces;
    using SharedKernell.Wrappers;

    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationCollaboratorController : BaseController
    {
        private readonly IEvaluationCollaboratorService _evaluationCollaboratorService;
        private readonly ILogger<EvaluationCollaboratorController> _logger;

        public EvaluationCollaboratorController(IEvaluationCollaboratorService evaluationCollaboratorService, ILogger<EvaluationCollaboratorController> logger)
        {
            _evaluationCollaboratorService = evaluationCollaboratorService;
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
        //    return new OkObjectResult(new JsonResult<List<EvaluationDto>>(result.ToList()));
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
        Summary = "Agregar Colaborador a Evaluacion",
        Description = "Agregar Colaborador a Evaluacion",
        OperationId = "EvaluationCollaborator.Create",
        Tags = new[] { "EvaluationCollaboratorService" })]
        [ProducesResponseType(typeof(JsonResult<EvaluationCollaboratorDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(EvaluationCollaboratorCreateDto request)
        {
            var result = await _evaluationCollaboratorService.CreateAsync(request);
            return new OkObjectResult(new JsonResult<EvaluationCollaboratorDto>(result));
        }

        //[HttpPut]
        //[SwaggerOperation(
        //Summary = "Actualizar Evaluationo",
        //Description = "actualizar Evaluationo",
        //OperationId = "Evaluation.Create",
        //Tags = new[] { "EvaluationService" })]
        //[ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        //public async Task<IActionResult> Udpate(EvaluationUpdateDto request)
        //{
        //    var result = await _evaluationService.UpdateAsync(request);
        //    return new OkObjectResult(new JsonResult<bool>(result));
        //}

        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Eliminar Colaborador de la Evaluacion",
        Description = "Eliminar Colaborador de la Evaluacion",
        OperationId = "EvaluationCollaborator.Delete",
        Tags = new[] { "EvaluationCollaboratorService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _evaluationCollaboratorService.DeleteAsync(id);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

    }
}
