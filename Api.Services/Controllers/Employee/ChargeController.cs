namespace Api.Services.Controllers.Employee
{
    using SharedKernell.Wrappers;
    using Application.Dto.Employee.Charge;
    using Application.Main.Services.Employee.Interfaces;

    [Route("api/charge")]
    [ApiController]
    public class ChargeController : BaseController
    {
        private readonly IChargeService _chargeService;
        private readonly ILogger<ChargeController> _logger;

        public ChargeController(IChargeService chargeService, ILogger<ChargeController> logger)
        {
            _chargeService = chargeService;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Lista de Cargos",
        Description = "Listado de Cargos",
        OperationId = "ChargeService.GetAll",
        Tags = new[] { "ChargeService" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<ChargeDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _chargeService.GetAllAsync();
            return new OkObjectResult(new JsonResult<List<ChargeDto>>(result.ToList()));
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Obtener Cargo",
        Description = "Obtener Cargo",
        OperationId = "ChargeService.GetById",
        Tags = new[] { "ChargeService" })]
        [ProducesResponseType(typeof(JsonResult<ChargeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _chargeService.GetByIdAsync(id);
            return new OkObjectResult(new JsonResult<ChargeDto>(result));
        }

        [HttpGet("by-area/{id}")]
        [SwaggerOperation(
        Summary = "Obtener Cargo por Área",
        Description = "Obtener Cargo por Área",
        OperationId = "ChargeService.GetByIdArea",
        Tags = new[] { "ChargeService" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<ChargeDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByFilters(int id)
        {
            var result = await _chargeService.GetByIdAreaAsync(id);
            return new OkObjectResult(new JsonResult<List<ChargeDto>>(result.ToList()));
        }

    }
}
