
namespace Application.Main.Services.Security.Interfaces
{
    using Application.Dto.Security;
    using Microsoft.AspNetCore.Mvc;
    public interface IAuthenticationService
    {
        Task<LoginSesionResDto> ValidateUser(string usuario);
        Task<AccessDto> LoginSesion(LoginSesionReqDto loginSesionReq, Controller controller);
        Task<AccessDto> RefreshToken(TokenDto tokenReq);
    }
}
