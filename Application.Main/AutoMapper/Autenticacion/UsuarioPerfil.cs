namespace Application.Main.AutoMapper.Perfiles.Autenticacion
{
    using Application.Dto.Autenticacion.Usuario;
    using Domain.Main.Autenticacion;
    public class UsuarioPerfil : Profile
    {
        public UsuarioPerfil()
        {
            CreateMap<Usuario, UsuarioPersonaTokenDto>()
                .ForMember(x => x.Nombres, m => m.MapFrom(d => d.Persona.Nombres))
                .ForMember(x => x.Apellidos, m => m.MapFrom(d => d.Persona.Apellidos))
                .ForMember(x => x.NombreUsuario, m => m.MapFrom(d => d.NombreUsuario))
                .ForMember(x => x.Id, m => m.MapFrom(d => d.Id))
                .ForMember(x => x.CompaniaId, m => m.MapFrom(d => d.CompaniaId))
                .ForMember(x => x.Contrasenia, m => m.MapFrom(d => d.Contrasenia))
                .ForMember(x => x.TipoHash, m => m.MapFrom(d => d.TipoHash));

            CreateMap<UsuarioCrearDto, Usuario>();
            CreateMap<UsuarioCompaniaCrearDto, Usuario>();
            CreateMap<Usuario, UsuarioDto>();
        }
    }
}
