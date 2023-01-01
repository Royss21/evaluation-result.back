namespace Api.Services.Controllers.Autenticacion
{
    using Api.Services.Controllers;
    using Application.Dto.Security.User;
    using Application.Main.Services.Security.Interfaces;
    using SharedKernell.Wrappers;

    [Route("api/[controller]")]
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
        [ProducesResponseType(typeof(JsonResult<UserDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(UserCreateDto request)
        {
            var resultado = await _userService.CreateAsync(request);
            return new OkObjectResult(new JsonResult<UserDto>(resultado));
        }
    }
}
