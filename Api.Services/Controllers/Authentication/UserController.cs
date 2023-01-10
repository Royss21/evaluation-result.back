namespace Api.Services.Controllers.Autenticacion
{
    using Api.Services.Controllers;
    using Application.Dto.Pagination;
    using Application.Dto.Security.User;
    using Application.Main.Services.Security.Interfaces;
    using SharedKernell.Wrappers;

    [Route("api/user")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Lista de Usuarios",
        Description = "Listado donde se listan las usuarios de la compa;ia",
        OperationId = "Usuario.GetAll",
        Tags = new[] { "UserService" })]
        [ProducesResponseType(typeof(JsonResult<IEnumerable<UserDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userService.GetAllAsync();
            return new OkObjectResult(new JsonResult<IEnumerable<UserDto>>(result));
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Crear Usuario",
        Description = "crear",
        OperationId = "Usuario.Create",
        Tags = new[] { "UserService" })]
        [ProducesResponseType(typeof(JsonResult<UserResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(UserCreateDto request)
        {
            var resultado = await _userService.CreateAsync(request);
            return new OkObjectResult(new JsonResult<UserResponseDto>(resultado));
        }

        [HttpPut]
        [SwaggerOperation(
        Summary = "Actualizar Usuario",
        Description = "Actualizar Usuario",
        OperationId = "UserService.Update",
        Tags = new[] { "UserService" })]
        [ProducesResponseType(typeof(JsonResult<UserDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(UserUpdateDto request)
        {
            var result = await _userService.UpdateAsync(request);
            return new OkObjectResult(new JsonResult<bool>(result));
        }

        [HttpGet("paging")]
        [SwaggerOperation(
        Summary = "Lista Paginada de Usuarios",
        Description = "Lista Paginada de Usuarios",
        OperationId = "UserService.GetAllPaging",
        Tags = new[] { "UserService" })]
        [ProducesResponseType(typeof(JsonResult<PaginationResultDto<UserDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPaging([FromQuery] PagingFilterDto filter)
        {
            var result = await _userService.GetAllPagingAsync(filter);
            return new OkObjectResult(new JsonResult<PaginationResultDto<UserDto>>(result));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Eliminar Usuario",
        Description = "Eliminar Usuario",
        OperationId = "UserService.Delete",
        Tags = new[] { "UserService" })]
        [ProducesResponseType(typeof(JsonResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userService.DeleteAsync(id);
            return new OkObjectResult(new JsonResult<bool>(result));
        }
    }
}
