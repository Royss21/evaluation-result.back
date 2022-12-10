namespace Api.Services.Controllers.Employee
{
    using Api.Services.Controllers;
    using Application.Dto.Employee.Collaborator;
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
