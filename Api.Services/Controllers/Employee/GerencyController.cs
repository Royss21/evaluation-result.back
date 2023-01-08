namespace Api.Services.Controllers.Employee
{
    using SharedKernell.Wrappers;
    using Api.Services.Controllers;
    using Application.Dto.Pagination;
    using Application.Dto.Employee.Gerency;
    using Application.Main.Services.Employee.Interfaces;

    [Route("api/gerency")]
    [ApiController]
    public class GerencyController : BaseController
    {
        private readonly IGerencyService _gerencyService;
        private readonly ILogger<GerencyController> _logger;
        public GerencyController(IGerencyService gerencyService, ILogger<GerencyController> logger)
        {
            this._gerencyService = gerencyService;
            this._logger = logger;
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Crear Gerencia",
        Description = "Crear Gerencia",
        OperationId = "GerencyService.Create",
        Tags = new[] { "GerencyService" })]
        [ProducesResponseType(typeof(JsonResult<GerencyDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(GerencyCreateDto request)
        {
            var result = await _gerencyService.CreateAsync(request);
            return new OkObjectResult(new JsonResult<GerencyDto>(result));
        }

        [HttpPut]
        [SwaggerOperation(
        Summary = "Actualiza Gerencia",
        Description = "Actualizar Gerencia",
        OperationId = "GerencyService.Update",
        Tags = new[] { "GerencyService" })]
        [ProducesResponseType(typeof(JsonResult<GerencyDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(GerencyUpdateDto request)
        {
            var result = await _gerencyService.UpdateAsync(request);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

        [HttpGet("paging")]
        [SwaggerOperation(
        Summary = "Lista Paginada de Gerencias",
        Description = "Lista Paginada de Gerencias",
        OperationId = "GerencyService.GetAllPaging",
        Tags = new[] { "GerencyService" })]
        [ProducesResponseType(typeof(JsonResult<PaginationResultDto<GerencyDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPaging([FromQuery] PagingFilterDto filter)
        {
            var result = await _gerencyService.GetAllPagingAsync(filter);
            return new OkObjectResult(new JsonResult<PaginationResultDto<GerencyDto>>(result));
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Obtener Lista de Gerencias",
        Description = "Obtener Lista de Gerencias",
        OperationId = "GerencyService.GetAll",
        Tags = new[] { "GerencyService" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<GerencyDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _gerencyService.GetAllAsync();
            return new OkObjectResult(new JsonResult<IEnumerable<GerencyDto>>(result));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Eliminar Gerencia",
        Description = "Eliminar Gerencia",
        OperationId = "GerencyService.Delete",
        Tags = new[] { "GerencyService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _gerencyService.DeleteAsync(id);
            return new OkObjectResult(new JsonResult<bool>(result));
        }
    }
}
