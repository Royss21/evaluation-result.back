namespace Api.Services.Controllers.Config
{
    using Api.Services.Controllers;
    using Application.Dto.Config.Formula;
    using Application.Dto.Pagination;
    using Application.Main.Services.Config.Interfaces;
    using SharedKernell.Wrappers;

    [Route("api/formula")]
    [ApiController]
    public class FormulaController : BaseController
    {
        private readonly IFormulaService _formulaService;
        private readonly ILogger<FormulaController> _logger;

        public FormulaController(IFormulaService formulaService, ILogger<FormulaController> logger)
        {
            _formulaService = formulaService;
            _logger = logger;
        }


        [HttpGet("paging")]
        [SwaggerOperation(
        Summary = "Lista Paginada Formulas",
        Description = "lista paginada de Formulas",
        OperationId = "Formula.GetAllPaging",
        Tags = new[] { "FormulaService" })]
        [ProducesResponseType(typeof(JsonResult<PaginationResultDto<FormulaDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPaging([FromQuery] PagingFilterDto filter)
        {
            var result = await _formulaService.GetAllPagingAsync(filter);
            return new OkObjectResult(new JsonResult<PaginationResultDto<FormulaDto>>(result));
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Crear Formula",
        Description = "crear Formula",
        OperationId = "Formula.Create",
        Tags = new[] { "FormulaService" })]
        [ProducesResponseType(typeof(JsonResult<FormulaDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(FormulaCreateDto Formula)
        {
            var result = await _formulaService.CreateAsync(Formula);
            return new OkObjectResult(new JsonResult<FormulaDto>(result));
        }

        [HttpPut]
        [SwaggerOperation(
        Summary = "Actualizar Formula",
        Description = "actualizar Formula",
        OperationId = "Formula.Update",
        Tags = new[] { "FormulaService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Udpate(FormulaUpdateDto request)
        {
            var result = await _formulaService.UpdateAsync(request);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Eliminar Formula",
        Description = "eliminar Formula",
        OperationId = "Formula.Delete",
        Tags = new[] { "FormulaService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _formulaService.DeleteAsync(id);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Obtener Formula",
        Description = "obtener formula",
        OperationId = "Formula.GetById",
        Tags = new[] { "FormulaService" })]
        [ProducesResponseType(typeof(JsonResult<FormulaDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _formulaService.GetByIdAsync(id);
            return new OkObjectResult(new JsonResult<FormulaDto>(result));
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Obtener Lista de Formula",
        Description = "obtener lista de Formula",
        OperationId = "Formula.GetAll",
        Tags = new[] { "FormulaService" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<FormulaDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _formulaService.GetAllAsync();
            return new OkObjectResult(new JsonResult<IEnumerable<FormulaDto>>(result));
        }

        [HttpGet("validate-assigned/{id}")]
        [SwaggerOperation(
        Summary = "Validar si la fórmula está referenciada a un objetivo corporativo",
        Description = "Validar si la fórmula está referenciada a un objetivo corporativo",
        OperationId = "Formula.ExistInObjectiveCorporative",
        Tags = new[] { "FormulaService" })]
        [ProducesResponseType(typeof(JsonResult<JsonResult<bool>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ExistInObjectiveCorporative(Guid id)
        {
            var result = await _formulaService.ExistInObjectiveCorporative(id);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

    }
}
