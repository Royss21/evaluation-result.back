namespace Api.Services.Controllers.EvaResult
{
    using Api.Services.Controllers;
    using Application.Dto.EvaResult.Period;
    using Application.Dto.Pagination;
    using Application.Main.Services.EvaResult.Interfaces;
    using SharedKernell.Wrappers;

    [Route("api/[controller]")]
    [ApiController]
    public class PeriodController : BaseController
    {
        private readonly IPeriodService _periodService;
        private readonly ILogger<PeriodController> _logger;

        public PeriodController(IPeriodService periodService, ILogger<PeriodController> logger)
        {
            _periodService = periodService;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Lista de Periodos",
        Description = "Listado de Periodos",
        OperationId = "Period.GetAll",
        Tags = new[] { "PeriodService" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<PeriodDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _periodService.GetAllAsync();
            return new OkObjectResult(new JsonResult<List<PeriodDto>>(result.ToList()));
        }

        [HttpGet("paging")]
        [SwaggerOperation(
        Summary = "Lista Paginada Periodos",
        Description = "lista paginada de Periodso",
        OperationId = "Period.GetAllPaging",
        Tags = new[] { "PeriodService" })]
        [ProducesResponseType(typeof(JsonResult<PaginationResultDto<PeriodDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPaging([FromQuery] PrimeTable primeTable)
        {
            var result = await _periodService.GetAllPagingAsync(primeTable);
            return new OkObjectResult(new JsonResult<PaginationResultDto<PeriodDto>>(result));
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Crear Periodo",
        Description = "crear Periodp",
        OperationId = "Period.Create",
        Tags = new[] { "PeriodService" })]
        [ProducesResponseType(typeof(JsonResult<PeriodDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(PeriodCreateDto Period)
        {
            var result = await _periodService.CreateAsync(Period);
            return new OkObjectResult(new JsonResult<PeriodDto>(result));
        }

        [HttpPut]
        [SwaggerOperation(
        Summary = "Actualizar Periodo",
        Description = "actualizar Periodo",
        OperationId = "Period.Create",
        Tags = new[] { "PeriodService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Udpate(PeriodUpdateDto request)
        {
            var result = await _periodService.UpdateAsync(request);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Eliminar Periodo",
        Description = "eliminar Periodo",
        OperationId = "Period.Delete",
        Tags = new[] { "PeriodService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _periodService.DeleteAsync(id);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

    }
}
