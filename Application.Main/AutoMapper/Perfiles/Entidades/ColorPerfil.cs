namespace Application.Main.AutoMapper.Perfiles.Entidades
{
    using Application.Dto.Entidades.Color;

    public class ColorPerfil : Profile
    {
        public ColorPerfil()
        {
            CreateMap<ColorDto, Color>().ReverseMap();
            CreateMap<ColorCrearDto, Color>();
            CreateMap<ColorActualizarDto, Color>();
        }
    }
}
