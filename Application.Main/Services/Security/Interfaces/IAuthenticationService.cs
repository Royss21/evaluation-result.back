
namespace Application.Main.Services.Security.Interfaces
{
    using Application.Dto.Security.Authentication;
    using Microsoft.AspNetCore.Mvc;
    public interface IAuthenticationService
    {
        Task<LoginSesionResDto> ValidateUserAsync(string usuario);
        Task<AccessDto> LoginSesionAsync(LoginSesionReqDto loginSesionReq, Controller controller);
        Task<AccessDto> RefreshTokenAsync(TokenDto tokenReq);
    }
}
