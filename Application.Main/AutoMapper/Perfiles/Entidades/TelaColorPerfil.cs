namespace Application.Main.AutoMapper.Perfiles.Entidades
{
    using Application.Dto.Entidades.TelaColor;

    public class TelaColorPerfil : Profile
    {
        public TelaColorPerfil()
        {
            CreateMap<TelaColorDto, TelaColor>().ReverseMap();
            CreateMap<TelaColorCrearDto, TelaColor>();
            CreateMap<TelaColorActualizarDto, TelaColor>();
        }
    }
}
