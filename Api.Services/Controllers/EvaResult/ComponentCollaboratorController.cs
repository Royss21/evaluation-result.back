namespace Api.Services.Controllers.EvaResult
{
    using Api.Services.Controllers;
    using Application.Dto.EvaResult.ComponentCollaborator;
    using Application.Dto.Pagination;
    using Application.Main.Services.EvaResult.Interfaces;
    using SharedKernell.Wrappers;

    [Route("api/component-collaborator")]
    [ApiController]
    public class ComponentCollaboratorController : BaseController
    {
        private readonly IComponentCollaboratorService _componentCollaboratorService;
        private readonly ILogger<ComponentCollaboratorController> _logger;

        public ComponentCollaboratorController(IComponentCollaboratorService componentCollaboratorService, ILogger<ComponentCollaboratorController> logger)
        {
            _componentCollaboratorService = componentCollaboratorService;
            _logger = logger;
        }

        [HttpGet("{id}/evaluation-data")]
        [SwaggerOperation(
        Summary = "Obtener datos de la evaluacion del componente",
        Description = "Obtener datos de la evaluacion del componente",
        OperationId = "ComponentCollaborator.GetEvaluationDataById",
        Tags = new[] { "ComponentCollaboratorService" })]
        [ProducesResponseType(typeof(JsonResult<ComponentCollaboratorDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEvaluationDataById(Guid id)
        {
            var result = await _componentCollaboratorService.GetEvaluationDataByIdAsync(id);
            return new OkObjectResult(new JsonResult<ComponentCollaboratorDto>(result));
        }

        [HttpPost("evaluate")]
        [SwaggerOperation(
        Summary = "Evaluar a colaborador",
        Description = "Evaluar a colaborador",
        OperationId = "ComponentCollaborator.Evaluate",
        Tags = new[] { "ComponentCollaboratorService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Evaluate(ComponentCollaboratorEvaluateDto request)
        {
            var result = await _componentCollaboratorService.EvaluateAsync(request);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

        [HttpGet("paging")]
        [SwaggerOperation(
        Summary = "Lista Paginada colaboradores de la evaluacion",
        Description = "lista paginada colaboradores de la evaluacion",
        OperationId = "ComponentCollaborator.GetPagingByComponent",
        Tags = new[] { "ComponentCollaboratorService" })]
        [ProducesResponseType(typeof(JsonResult<PaginationResultDto<ComponentCollaboratorPagingDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPaging([FromQuery] ComponentCollaboratorFilterDto filter)
        {
            var result = await _componentCollaboratorService.GetPagingAsync(filter);
            return new OkObjectResult(new JsonResult<PaginationResultDto<ComponentCollaboratorPagingDto>>(result));
        }
    }
}
