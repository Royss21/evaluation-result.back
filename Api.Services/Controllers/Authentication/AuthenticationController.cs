namespace Api.Services.Controllers.Authentication
{
    using Application.Dto.Security.Authentication;
    using Application.Main.Services.Security.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using SharedKernell.Wrappers;

    [Route("api/authentication")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {

        private readonly ILogger<AuthenticationController> _logger;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService, ILogger<AuthenticationController> logger)
        {

            _logger = logger;
            _authenticationService = authenticationService;
        }

        [HttpGet("validate-user/{userName}")]
        [SwaggerOperation(
        Summary = "Validar nombbre de usuario",
        Description = "Servicio donde se valida el nombre del usuario si existe o no",
        OperationId = "Authentication.ValidateUser",
        Tags = new[] { "AuthenticationService" })]
        [ProducesResponseType(typeof(JsonResult<LoginSesionResDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ValidateUser(string userName)
        {
            var resultado = await _authenticationService.ValidateUserAsync(userName);
            return new OkObjectResult(new JsonResult<LoginSesionResDto>(resultado));
        }

        [HttpPost("login-sesion")]
        [SwaggerOperation(
        Summary = "Validar nombbre de usuario",
        Description = "Servicio donde se valida el nombre del usuario si existe o no",
        OperationId = "Authentication.LoginSesion",
        Tags = new[] { "AuthenticationService" })]
        [ProducesResponseType(typeof(JsonResult<AccessDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> LoginSesion(LoginSesionReqDto loginSesionReqDto)
        {
            var resultado = await _authenticationService.LoginSesionAsync(loginSesionReqDto, this);
            return new OkObjectResult(new JsonResult<AccessDto>(resultado));
        }

        [HttpPost("login-sesion-collaborator/{id}")]
        [SwaggerOperation(
        Summary = "iniciar sesion",
        Description = "Inicio de sesion",
        OperationId = "Authentication.LoginSesionCollaborator",
        Tags = new[] { "AuthenticationService" })]
        [ProducesResponseType(typeof(JsonResult<AccessCollaboratorDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> LoginSesionCollaborator(Guid id)
        {
            var resultado = await _authenticationService.LoginSessionCollaboratorAsync(id);
            return new OkObjectResult(new JsonResult<AccessCollaboratorDto>(resultado));
        }

        [HttpPost("refresh-token")]
        [SwaggerOperation(
        Summary = "Validar nombbre de usuario",
        Description = "Servicio donde se valida el nombre del usuario si existe o no",
        OperationId = "Authentication.RefreshToken",
        Tags = new[] { "AuthenticationService" })]
        [ProducesResponseType(typeof(JsonResult<AccessDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> RefreshToken(TokenDto tokenDto)
        {
            var resultado = await _authenticationService.RefreshTokenAsync(tokenDto);
            return new OkObjectResult(new JsonResult<AccessDto>(resultado));
        }

    }
}
