namespace Application.Main.AutoMapper.Perfiles.Autenticacion
{
    using Application.Dto.Autenticacion.Rol;
    using Domain.Main.Autenticacion;
    public class RolPerfil : Profile
    {
        public RolPerfil()
        {

            CreateMap<Rol, RolDto>();
        }
    }
}
