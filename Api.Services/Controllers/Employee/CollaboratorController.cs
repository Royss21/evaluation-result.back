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
        [ProducesResponseType(typeof(JsonResult<CollaboratorDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(CollaboratorNotInEvaluationCreateDto request)
        {
            var result = await _collaboratorService.CreateAsync(request);
            return new OkObjectResult(new JsonResult<CollaboratorDto>(result));
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


        [HttpGet("paging")]
        [SwaggerOperation(
        Summary = "Lista Paginada de Colaboradores",
        Description = "Listado Paginado de Colaboradores",
        OperationId = "Collaborator.GetAllPaging",
        Tags = new[] { "CollaboratorService" })]
        [ProducesResponseType(typeof(JsonResult<PaginationResultDto<CollaboratorDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPaging([FromQuery] PagingFilterDto filter)
        {
            var result = await _collaboratorService.GetAllPagingAsync(filter);
            return new OkObjectResult(new JsonResult<PaginationResultDto<CollaboratorDto>>(result));
        }

        [HttpGet("not-in-evaluation/{evaluationid}")]
        [SwaggerOperation(
        Summary = "lista de collaborators que no estan en la evaluacion",
        Description = "listado de collaborators que no estan en la evaluacion",
        OperationId = "Collaborator.GetAllCollaboratorNotInEvaluation",
        Tags = new[] { "CollaboratorService" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<CollaboratorNotInEvaluationDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCollaboratorNotInEvaluation(Guid evaluationid)
        {
            var result = await _collaboratorService.GetAllCollaboratorNotInEvaluationAsync(evaluationid);
            return new OkObjectResult(new JsonResult<IEnumerable<CollaboratorNotInEvaluationDto>>(result));
        }


    }
}
