namespace Application.Main.AutoMapper.Perfiles.Entidades
{
    using Application.Dto.Entidades.Tamanio;

    public class TamanioPerfil : Profile
    {
        public TamanioPerfil()
        {
            CreateMap<TamanioDto, Tamanio>().ReverseMap();
            CreateMap<TamanioCrearDto, Tamanio>().ReverseMap();
            CreateMap<TamanioActualizarDto, Tamanio>().ReverseMap();
        }
    }
}
