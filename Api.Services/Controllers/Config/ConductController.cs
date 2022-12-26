namespace Api.Services.Controllers.Config
{
    using Api.Services.Controllers;
    using Application.Dto.Config.Conduct;
    using Application.Main.Services.Config.Interfaces;
    using SharedKernell.Wrappers;

    [Route("api/conduct")]
    [ApiController]
    public class ConductController : BaseController
    {
        private readonly IConductService _conductService;
        private readonly ILogger<ConductController> _logger;

        public ConductController(IConductService conductService, ILogger<ConductController> logger)
        {
            _conductService = conductService;
            _logger = logger;
        }

        [HttpGet("get-all/subcomponent/{subcomponentId}")]
        [SwaggerOperation(
        Summary = "Obtener Conductas por Subcomponente",
        Description = "obtener conductas por subcomponente",
        OperationId = "Conduct.GetAllBySubcomponent",
        Tags = new[] { "ConductService" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<ConductDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllBySubcomponent(Guid subcomponentId)
        {
            var result = await _conductService.GetAllBySubcomponentAsync(subcomponentId);
            return new OkObjectResult(new JsonResult<IEnumerable<ConductDto>>(result));
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Crear Conducta",
        Description = "crear Conducta",
        OperationId = "Conduct.Create",
        Tags = new[] { "ConductService" })]
        [ProducesResponseType(typeof(JsonResult<ConductDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(ConductCreateDto request)
        {
            var result = await _conductService.CreateAsync(request);
            return new OkObjectResult(new JsonResult<ConductDto>(result));
        }

        [HttpPut]
        [SwaggerOperation(
        Summary = "Actualizar Conducta",
        Description = "actualizar Conducta",
        OperationId = "Conduct.Update",
        Tags = new[] { "ConductService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(ConductUpdateDto request)
        {
            var result = await _conductService.UpdateAsync(request);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Eliminar Conducta",
        Description = "eliminar Conducta",
        OperationId = "Conduct.Delete",
        Tags = new[] { "ConductService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _conductService.DeleteAsync(id);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

    }
}
