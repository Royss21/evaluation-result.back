namespace Api.Services.Controllers.Config
{
    using Api.Services.Controllers;
    using Application.Dto.Config.Subcomponent;
    using Application.Dto.Pagination;
    using Application.Main.Services.Config.Interfaces;
    using SharedKernell.Wrappers;

    [Route("api/subcomponent")]
    [ApiController]
    public class SubcomponentController : BaseController
    {
        private readonly ISubcomponentService _subcomponentService;
        private readonly ILogger<ParameterValueController> _logger;

        public SubcomponentController(ISubcomponentService subcomponentService, ILogger<ParameterValueController> logger)
        {
            _subcomponentService = subcomponentService;
            _logger = logger;
        }


        [HttpGet("paging")]
        [SwaggerOperation(
        Summary = "Lista Paginada Subcomponente",
        Description = "lista paginada de subcomponente",
        OperationId = "Subcomponent.GetAllPaging",
        Tags = new[] { "SubcomponentService" })]
        [ProducesResponseType(typeof(JsonResult<PaginationResultDto<SubcomponentDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPaging([FromQuery] SubcomponentFilterDto filter)
        {
            var result = await _subcomponentService.GetAllPagingAsync(filter);
            return new OkObjectResult(new JsonResult<PaginationResultDto<SubcomponentDto>>(result));
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Obtener Subcomponente",
        Description = "obtener subcomponente",
        OperationId = "Subcomponent.GetById",
        Tags = new[] { "SubcomponentService" })]
        [ProducesResponseType(typeof(JsonResult<SubcomponentDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _subcomponentService.GetByIdAsync(id);
            return new OkObjectResult(new JsonResult<SubcomponentDto>(result));
        }


        [HttpPost]
        [SwaggerOperation(
        Summary = "Crear Subcomponente",
        Description = "crear subcomponente",
        OperationId = "Subcomponent.Create",
        Tags = new[] { "SubcomponentService" })]
        [ProducesResponseType(typeof(JsonResult<SubcomponentDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(SubcomponentCreateDto Level)
        {
            var result = await _subcomponentService.CreateAsync(Level);
            return new OkObjectResult(new JsonResult<SubcomponentDto>(result));
        }

        [HttpPut]
        [SwaggerOperation(
        Summary = "Actualizar Subcomponente",
        Description = "actualizar subcomponente",
        OperationId = "Subcomponent.Update",
        Tags = new[] { "SubcomponentService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Udpate(SubcomponentUpdateDto request)
        {
            var result = await _subcomponentService.UpdateAsync(request);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Eliminar Subcomponente",
        Description = "eliminar subcomponente",
        OperationId = "Subcomponent.Delete",
        Tags = new[] { "SubcomponentService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _subcomponentService.DeleteAsync(id);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

    }
}
