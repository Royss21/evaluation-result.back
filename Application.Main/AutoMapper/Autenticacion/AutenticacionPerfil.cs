namespace Application.Main.AutoMapper.Perfiles.Autenticacion
{
    using Application.Dto.Autenticacion.InicioSesion;
    using Application.Security.Entidades;

    public class AutenticacionPerfil : Profile
    {
        public AutenticacionPerfil()
        {
            CreateMap<AccesoDto, UsuarioTokenApp>().ReverseMap();
        }
    }
}
