namespace Application.Main.AutoMapper.Perfiles.Entidades
{
    using Application.Dto.Entidades.Tela;

    public class TelaPerfil : Profile
    {
        public TelaPerfil()
        {
            CreateMap<TelaDto, Tela>().ReverseMap();
            CreateMap<TelaPaginadoDto, Tela>().ReverseMap();
            CreateMap<TelaCrearDto, Tela>();
            CreateMap<TelaActualizarDto, Tela>();
        }
    }
}
