namespace Api.Services.Controllers.Employee
{
    using SharedKernell.Wrappers;
    using Application.Dto.Employee.Charge;
    using Application.Main.Services.Employee.Interfaces;
    using Application.Dto.Pagination;

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

        [HttpPost]
        [SwaggerOperation(
        Summary = "Crear Cargo",
        Description = "Crear Cargo",
        OperationId = "ChargeService.Create",
        Tags = new[] { "ChargeService" })]
        [ProducesResponseType(typeof(JsonResult<ChargeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(ChargeCreateDto request)
        {
            var result = await _chargeService.CreateAsync(request);
            return new OkObjectResult(new JsonResult<ChargeDto>(result));
        }

        [HttpPut]
        [SwaggerOperation(
        Summary = "Actualizar Cargo",
        Description = "Actualizar Cargo",
        OperationId = "ChargeService.Update",
        Tags = new[] { "ChargeService" })]
        [ProducesResponseType(typeof(JsonResult<ChargeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(ChargeUpdateDto request)
        {
            var result = await _chargeService.UpdateAsync(request);
            return new OkObjectResult(new JsonResult<bool>(result));
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

        [HttpGet("paging")]
        [SwaggerOperation(
        Summary = "Lista Paginada de Cargos",
        Description = "lista paginada de Cargos",
        OperationId = "ChargeService.GetAllPaging",
        Tags = new[] { "ChargeService" })]
        [ProducesResponseType(typeof(JsonResult<PaginationResultDto<ChargeDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPaging([FromQuery] PagingFilterDto primeTable)
        {
            var result = await _chargeService.GetAllPagingAsync(primeTable);
            return new OkObjectResult(new JsonResult<PaginationResultDto<ChargeDto>>(result));
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

        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Eliminar Área",
        Description = "Eliminar Área",
        OperationId = "ChargeService.Delete",
        Tags = new[] { "ChargeService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _chargeService.DeleteAsync(id);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

    }
}
