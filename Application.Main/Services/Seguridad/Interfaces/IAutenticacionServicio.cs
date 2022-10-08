namespace Application.Main.Services.Seguridad.Interfaces
{
    using Application.Dto.Autenticacion.InicioSesion;
    using Microsoft.AspNetCore.Mvc;

    public interface IAutenticacionServicio
    {
        Task<IniciarSesionResDto> ValidarUsuario(string usuario);
        Task<AccesoDto> IniciarSesion(IniciarSesionReqDto iniciarSesionDto, Controller controller);
        Task<AccesoDto> RefrescarToken(TokenReqDto tokenReq);
    }
}
