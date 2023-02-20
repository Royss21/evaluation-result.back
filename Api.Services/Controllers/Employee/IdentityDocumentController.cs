namespace Api.Services.Controllers.Employee
{
    using Api.Services.Controllers;
    using Application.Dto.Employee.IdentityDocument;
    using Application.Main.Services.Employee.Interfaces;
    using SharedKernell.Wrappers;

    [Route("api/identity-document")]
    [ApiController]
    public class IdentityDocumentController : BaseController
    {
        private readonly IIdentityDocumentService _service;
        private readonly ILogger<IdentityDocumentController> _logger;

        public IdentityDocumentController(IIdentityDocumentService service, ILogger<IdentityDocumentController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Lista de Documentos de identidad",
        Description = "Listado de Documentos de identidad",
        OperationId = "IdentityDocument.GetAll",
        Tags = new[] { "IdentityDocumentService" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<IdentityDocumentDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return new OkObjectResult(new JsonResult<List<IdentityDocumentDto>>(result.ToList()));
        }
    }
}
