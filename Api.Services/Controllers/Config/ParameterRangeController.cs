﻿namespace Api.Services.Controllers.Config
{
    using Api.Services.Controllers;
    using Application.Dto.Config.ParameterRange;
    using Application.Dto.Pagination;
    using Application.Main.Services.Config.Interfaces;
    using SharedKernell.Wrappers;

    [Route("api/parameter-range")]
    [ApiController]
    public class ParameterRangeController : BaseController
    {
        private readonly IParameterRangeService _parameterRangeService;
        private readonly ILogger<ParameterValueController> _logger;

        public ParameterRangeController(IParameterRangeService parameterRangeService, ILogger<ParameterValueController> logger)
        {
            _parameterRangeService = parameterRangeService;
            _logger = logger;
        }


        [HttpGet("paging")]
        [SwaggerOperation(
        Summary = "Lista Paginada Rango de Parametro",
        Description = "lista paginada de rango de parametro",
        OperationId = "ParameterRange.GetAllPaging",
        Tags = new[] { "ParameterRangeService" })]
        [ProducesResponseType(typeof(JsonResult<PaginationResultDto<ParameterRangeDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPaging([FromQuery] PagingFilterDto filter)
        {
            var result = await _parameterRangeService.GetAllPagingAsync(filter);
            return new OkObjectResult(new JsonResult<PaginationResultDto<ParameterRangeDto>>(result));
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Obtener Rango de Parametro",
        Description = "obtener rango de parametro",
        OperationId = "ParameterRange.GetById",
        Tags = new[] { "ParameterRangeService" })]
        [ProducesResponseType(typeof(JsonResult<ParameterRangeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _parameterRangeService.GetByIdAsync(id);
            return new OkObjectResult(new JsonResult<ParameterRangeDto>(result));
        }


        [HttpPost]
        [SwaggerOperation(
        Summary = "Crear Rango de Parametro",
        Description = "crear rango de parametro",
        OperationId = "ParameterRange.Create",
        Tags = new[] { "ParameterRangeService" })]
        [ProducesResponseType(typeof(JsonResult<ParameterRangeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(ParameterRangeCreateDto Level)
        {
            var result = await _parameterRangeService.CreateAsync(Level);
            return new OkObjectResult(new JsonResult<ParameterRangeDto>(result));
        }

        [HttpPut]
        [SwaggerOperation(
        Summary = "Actualizar Rango de Parametro",
        Description = "actualizar rango de parametro",
        OperationId = "ParameterRange.Update",
        Tags = new[] { "ParameterRangeService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Udpate(ParameterRangeUpdateDto request)
        {
            var result = await _parameterRangeService.UpdateAsync(request);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Eliminar Rango de Parametro",
        Description = "eliminar rango de parametro",
        OperationId = "ParameterRange.Delete",
        Tags = new[] { "ParameterRangeService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _parameterRangeService.DeleteAsync(id);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

        [HttpGet("get-all-values")]
        [SwaggerOperation(
        Summary = "Obtener Rango de Parametro con sus valores",
        Description = "obtener rango de parametro con sus valores",
        OperationId = "ParameterRange.GetAllWithValues",
        Tags = new[] { "ParameterRangeService" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<ParameterRangeWithValuesDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllWithValues()
        {
            var result = await _parameterRangeService.GetAllWithValuesAsync();
            return new OkObjectResult(new JsonResult<IEnumerable<ParameterRangeWithValuesDto>>(result));
        }
    }
}
