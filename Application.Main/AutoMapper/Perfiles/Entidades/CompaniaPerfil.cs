namespace Application.Main.AutoMapper.Perfiles.Entidades
{
    using Application.Dto.Entidades.Compania;

    public class CompaniaPerfil : Profile
    {
        public CompaniaPerfil()
        {
            CreateMap<CompaniaDto, Compania>().ReverseMap();
            CreateMap<CompaniaCrearDto, Compania>().ReverseMap();
            CreateMap<CompaniaActualizarDto, Compania>().ReverseMap();
        }
    }
}
