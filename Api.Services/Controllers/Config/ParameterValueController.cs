namespace Api.Services.Controllers.Config
{
    using Api.Services.Controllers;
    using Application.Dto.Config.ParameterValue;
    using Application.Main.Services.Config.Interfaces;
    using SharedKernell.Wrappers;

    [Route("api/[controller]")]
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

        [HttpGet("GetAllByParameterRange/{parameterRangeId}")]
        [SwaggerOperation(
        Summary = "Obtener Listado por Rango de Parametro",
        Description = "obtener listado por rango de parametro",
        OperationId = "ParameterValue.GetAllByParameterRange",
        Tags = new[] { "ParameterValueService" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<ParameterValueDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllByParameterRange(Guid parameterRangeId)
        {
            var result = await _parameterValueService.GetAllByParameterRangeAsync(parameterRangeId);
            return new OkObjectResult(new JsonResult<IEnumerable<ParameterValueDto>>(result));
        }

    }
}
