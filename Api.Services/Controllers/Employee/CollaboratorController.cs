namespace Api.Services.Controllers.Employee
{
    using Api.Services.Controllers;
    using Application.Dto.Employee.Collaborator;
    using Application.Dto.Pagination;
    using Application.Main.Services.Employee.Interfaces;
    using SharedKernell.Wrappers;

    [Route("api/collaborator")]
    [ApiController]
    public class CollaboratorController : BaseController
    {
        private readonly ICollaboratorService _collaboratorService;
        private readonly ILogger<CollaboratorController> _logger;

        public CollaboratorController(ICollaboratorService collaboratorService, ILogger<CollaboratorController> logger)
        {
            _collaboratorService = collaboratorService;
            _logger = logger;
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Crear colaborador",
        Description = "crear colaborador",
        OperationId = "CollaboratorService.Create",
        Tags = new[] { "CollaboratorService" })]
        [ProducesResponseType(typeof(JsonResult<CollaboratorNotInEvaluationDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(CollaboratorNotInEvaluationCreateDto request)
        {
            var result = await _collaboratorService.CreateAsync(request);
            return new OkObjectResult(new JsonResult<CollaboratorNotInEvaluationDto>(result));
        }

        [HttpPut]
        [SwaggerOperation(
        Summary = "Actualiza colaborador",
        Description = "Actualizar colaborador",
        OperationId = "CollaboratorService.Update",
        Tags = new[] { "CollaboratorService" })]
        [ProducesResponseType(typeof(JsonResult<CollaboratorNotInEvaluationDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(CollaboratorUpdateDto request)
        {
            var result = await _collaboratorService.UpdateAsync(request);
            return new OkObjectResult(new JsonResult<bool>(result));
        }


        [HttpGet("not-in-evaluation/paging")]
        [SwaggerOperation(
        Summary = "Lista Paginada de Collaborators que no estan en la evaluacion",
        Description = "Listado paginado de collaborators que no estan en la evaluacion",
        OperationId = "Collaborator.GetAllPagingCollaboratorNotInEvaluation",
        Tags = new[] { "CollaboratorService" })]
        [ProducesResponseType(typeof(JsonResult<PaginationResultDto<CollaboratorNotInEvaluationDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPagingCollaboratorNotInEvaluation([FromQuery] PagingFilterDto filter)
        {
            var result = await _collaboratorService.GetAllPagingCollaboratorNotInEvaluationAsync(filter);
            return new OkObjectResult(new JsonResult<PaginationResultDto<CollaboratorNotInEvaluationDto>>(result));
        }

        [HttpGet("not-in-evaluation/{evaluationId}")]
        [SwaggerOperation(
        Summary = "Lista de Collaborators que no estan en la evaluacion",
        Description = "Listado de collaborators que no estan en la evaluacion",
        OperationId = "Collaborator.GetAllCollaboratorNotInEvaluation",
        Tags = new[] { "CollaboratorService" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<CollaboratorNotInEvaluationDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCollaboratorNotInEvaluation(Guid evaluationId)
        {
            var result = await _collaboratorService.GetAllCollaboratorNotInEvaluationAsync(evaluationId);
            return new OkObjectResult(new JsonResult<IEnumerable<CollaboratorNotInEvaluationDto>>(result));
        }

       
    }
}
