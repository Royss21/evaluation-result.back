namespace Api.Services.Controllers.Security
{
    using SharedKernell.Wrappers;
    using Api.Services.Controllers;
    using Application.Main.Services.Security.Interfaces;
    using Application.Dto.Security.Role;
    using Application.Dto.Pagination;

    [Route("api/role")]
    [ApiController]
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<RoleController> _logger;
        public RoleController(IRoleService roleService, ILogger<RoleController> logger)
        {
            this._roleService = roleService;
            this._logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Lista de Roles",
        Description = "Listado de Roles",
        OperationId = "RoleService.GetAll",
        Tags = new[] { "RoleService" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<RoleDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _roleService.GetAllAsync();
            return new OkObjectResult(new JsonResult<List<RoleDto>>(result.ToList()));
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Crear Rol",
        Description = "Crear Rol",
        OperationId = "RoleService.Create",
        Tags = new[] { "RoleService" })]
        [ProducesResponseType(typeof(JsonResult<RoleDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(RoleCreateDto request)
        {
            var result = await _roleService.CreateAsync(request);
            return new OkObjectResult(new JsonResult<RoleDto>(result));
        }

        [HttpPut]
        [SwaggerOperation(
        Summary = "Actualizar Rol",
        Description = "Actualizar Rol",
        OperationId = "RoleService.Update",
        Tags = new[] { "RoleService" })]
        [ProducesResponseType(typeof(JsonResult<RoleDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(RoleUpdateDto request)
        {
            var result = await _roleService.UpdateAsync(request);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

        [HttpGet("paging")]
        [SwaggerOperation(
        Summary = "Lista Paginada de Roles",
        Description = "Lista Paginada de Roles",
        OperationId = "RoleService.GetAllPaging",
        Tags = new[] { "RoleService" })]
        [ProducesResponseType(typeof(JsonResult<PaginationResultDto<RoleDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPaging([FromQuery] PagingFilterDto filter)
        {
            var result = await _roleService.GetAllPagingAsync(filter);
            return new OkObjectResult(new JsonResult<PaginationResultDto<RoleDto>>(result));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Eliminar Rol",
        Description = "Eliminar Rol",
        OperationId = "RoleService.Delete",
        Tags = new[] { "RoleService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _roleService.DeleteAsync(id);
            return new OkObjectResult(new JsonResult<bool>(result));
        }
    }
}
