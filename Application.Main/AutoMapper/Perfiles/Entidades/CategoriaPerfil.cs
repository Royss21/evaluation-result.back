namespace Application.Main.AutoMapper.Perfiles.Entidades
{
    using Application.Dto.Entidades.Categoria;

    public class CategoriaPerfil : Profile
    {
        public CategoriaPerfil()
        {
            CreateMap<CategoriaDto, Categoria>().ReverseMap();
            CreateMap<CategoriaCrearDto, Categoria>().ReverseMap();
            CreateMap<CategoriaActualizarDto, Categoria>().ReverseMap();
        }
    }
}
