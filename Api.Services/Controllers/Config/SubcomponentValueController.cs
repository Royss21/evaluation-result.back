namespace Api.Services.Controllers.Config
{
    using Api.Services.Controllers;
    using Application.Dto.Config.SubcomponentValue;
    using Application.Main.Services.Config.Interfaces;
    using SharedKernell.Wrappers;

    [Route("api/[controller]")]
    [ApiController]
    public class SubcomponentValueController : BaseController
    {
        private readonly ISubcomponentValueService _subcomponentValueService;
        private readonly ILogger<ParameterValueController> _logger;

        public SubcomponentValueController(ISubcomponentValueService subcomponentValueService, ILogger<ParameterValueController> logger)
        {
            _subcomponentValueService = subcomponentValueService;
            _logger = logger;
        }

        [HttpGet("GetAllBySubcomponent/{subcomponentId}")]
        [SwaggerOperation(
        Summary = "Lista de valores por subcomponente",
        Description = "Listado de valores por subcomponente",
        OperationId = "SubcomponentValue.GetAllBySubcomponent",
        Tags = new[] { "SubcomponentValueService" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<SubcomponentValueDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllBySubcomponent(Guid subcomponentId)
        {
            var result = await _subcomponentValueService.GetAllBySubcomponentAsync(subcomponentId);
            return new OkObjectResult(new JsonResult<IEnumerable<SubcomponentValueDto>>(result));
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Crear Subcomponente valor",
        Description = "crear subcomponente valor",
        OperationId = "SubcomponentValue.Create",
        Tags = new[] { "SubcomponentValueService" })]
        [ProducesResponseType(typeof(JsonResult<SubcomponentValueDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(SubcomponentValueCreateDto Level)
        {
            var result = await _subcomponentValueService.CreateAsync(Level);
            return new OkObjectResult(new JsonResult<SubcomponentValueDto>(result));
        }

        [HttpPut]
        [SwaggerOperation(
        Summary = "Actualizar subcomponente valor",
        Description = "actualizar subcomponente valor",
        OperationId = "SubcomponentValue.Update",
        Tags = new[] { "SubcomponentValueService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Udpate(SubcomponentValueUpdateDto request)
        {
            var result = await _subcomponentValueService.UpdateAsync(request);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Eliminar subcomponente valor",
        Description = "eliminar subcomponente valor",
        OperationId = "SubcomponentValue.Delete",
        Tags = new[] { "SubcomponentValueService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _subcomponentValueService.DeleteAsync(id);
            return new OkObjectResult(new JsonResult<bool>(result));
        }
    }
}
