namespace Api.Services.Controllers.Config
{
    using Api.Services.Controllers;
    using Application.Dto.Config.ParameterValue;
    using Application.Dto.Pagination;
    using Application.Main.Services.Config.Interfaces;
    using SharedKernell.Wrappers;

    [Route("api/parameter-value")]
    [ApiController]
    public class ParameterValueController : BaseController
    {
        private readonly IParameterValueService _parameterValueService;
        private readonly ILogger<ParameterValueController> _logger;

        public ParameterValueController(IParameterValueService parameterValueService, ILogger<ParameterValueController> logger)
        {
            _parameterValueService = parameterValueService;
            _logger = logger;
        }


        [HttpPost]
        [SwaggerOperation(
        Summary = "Crear Valor de Parametro",
        Description = "crear valor de parametro",
        OperationId = "ParameterValue.Create",
        Tags = new[] { "ParameterValueService" })]
        [ProducesResponseType(typeof(JsonResult<ParameterValueDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(ParameterValueCreateDto request)
        {
            var result = await _parameterValueService.CreateAsync(request);
            return new OkObjectResult(new JsonResult<ParameterValueDto>(result));
        }

        [HttpPut]
        [SwaggerOperation(
        Summary = "Actualizar Valor de Parametro",
        Description = "actualizar valor de parametro",
        OperationId = "ParameterValue.Update",
        Tags = new[] { "ParameterValueService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Udpate(ParameterValueUpdateDto request)
        {
            var result = await _parameterValueService.UpdateAsync(request);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Eliminar Valor de Parametro",
        Description = "eliminar valor de parametro",
        OperationId = "ParameterValue.Delete",
        Tags = new[] { "ParameterValueService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _parameterValueService.DeleteAsync(id);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

        [HttpGet("get-all/parameter-range/{parameterRangeId}")]
        [SwaggerOperation(
        Summary = "Obtener Listado por Valor de Parametro",
        Description = "obtener listado por valor de parametro",
        OperationId = "ParameterValue.GetAllByParameterRange",
        Tags = new[] { "ParameterValueService" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<ParameterValueDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllByParameterRange(Guid parameterRangeId)
        {
            var result = await _parameterValueService.GetAllByParameterRangeAsync(parameterRangeId);
            return new OkObjectResult(new JsonResult<IEnumerable<ParameterValueDto>>(result));
        }

        [HttpGet("paging")]
        [SwaggerOperation(
        Summary = "Lista Paginada Valor de Parametro",
        Description = "lista paginada de valor de parametro",
        OperationId = "ParameterValue.GetAllPaging",
        Tags = new[] { "ParameterValueService" })]
        [ProducesResponseType(typeof(JsonResult<PaginationResultDto<ParameterValueDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPaging([FromQuery] ParameterValueFilterDto filter)
        {
            var result = await _parameterValueService.GetAllPagingAsync(filter);
            return new OkObjectResult(new JsonResult<PaginationResultDto<ParameterValueDto>>(result));
        }

    }
}
