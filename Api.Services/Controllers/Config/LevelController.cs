namespace Api.Services.Controllers.Config
{
    using SharedKernell.Wrappers;
    using Api.Services.Controllers;
    using Application.Dto.Pagination;
    using Application.Dto.Config.Level;
    using Application.Main.Services.Config.Interfaces;

    [Route("api/level")]
    [ApiController]
    public class LevelController : BaseController
    {
        private readonly ILevelService _levelService;
        private readonly ILogger<LevelController> _logger;

        public LevelController(ILevelService levelService, ILogger<LevelController> logger)
        {
            _levelService = levelService;
            _logger = logger;
        }


        [HttpGet("paging")]
        [SwaggerOperation(
        Summary = "Lista Paginada Niveles",
        Description = "lista paginada de Niveles",
        OperationId = "Level.GetAllPaging",
        Tags = new[] { "LevelService" })]
        [ProducesResponseType(typeof(JsonResult<PaginationResultDto<LevelDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPaging([FromQuery] PagingFilterDto filter)
        {
            var result = await _levelService.GetAllPagingAsync(filter);
            return new OkObjectResult(new JsonResult<PaginationResultDto<LevelDto>>(result));
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Crear Nivel",
        Description = "crear Nivel",
        OperationId = "Level.Create",
        Tags = new[] { "LevelService" })]
        [ProducesResponseType(typeof(JsonResult<LevelDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(LevelCreateDto Level)
        {
            var result = await _levelService.CreateAsync(Level);
            return new OkObjectResult(new JsonResult<LevelDto>(result));
        }

        [HttpPut]
        [SwaggerOperation(
        Summary = "Actualizar Nivel",
        Description = "actualizar Nivel",
        OperationId = "Level.Update",
        Tags = new[] { "LevelService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Udpate(LevelUpdateDto request)
        {
            var result = await _levelService.UpdateAsync(request);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Eliminar Nivel",
        Description = "eliminar Nivel",
        OperationId = "Level.Delete",
        Tags = new[] { "LevelService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _levelService.DeleteAsync(id);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Obtener Nivel",
        Description = "obtener Level",
        OperationId = "Level.GetById",
        Tags = new[] { "LevelService" })]
        [ProducesResponseType(typeof(JsonResult<LevelDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _levelService.GetByIdAsync(id);
            return new OkObjectResult(new JsonResult<LevelDto>(result));
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Obtener Lista de Nivel",
        Description = "obtener lista de Level",
        OperationId = "Level.GetAll",
        Tags = new[] { "LevelService" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<LevelDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _levelService.GetAllAsync();
            return new OkObjectResult(new JsonResult<IEnumerable<LevelDto>>(result));
        }

        [HttpGet("{id}/HasDependencyOtherEntities")]
        [SwaggerOperation(
        Summary = "Tiene dependencia en otras entidades",
        Description = "tiene dependencia en otras entidades",
        OperationId = "Level.HasDependencyOtherEntities",
        Tags = new[] { "LevelService" })]
        [ProducesResponseType(typeof(JsonResult<LevelDependencyDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> HasDependencyOtherEntities(int id)
        {
            var result = await _levelService.HasDependencyOtherEntitiesAsync(id);
            return new OkObjectResult(new JsonResult<LevelDependencyDto>(result));
        }

    }
}
