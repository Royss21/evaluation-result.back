namespace Application.Main.Servicios.Entidades.Interfaces
{
    using Application.Dto.Entidades.Categoria;
    using Application.Dto.Paginacion;
    using Application.Main.PrimeNg;

    public interface ICategoriaServicio
    {
        Task<IEnumerable<CategoriaDto>> ObtenerTodoAsync();
        Task<PaginacionResultadoDto<CategoriaDto>> ObtenerTodoPaginadoAsync(PrimeTable primeTable);
        Task<CategoriaDto> ObtenerPorIdAsync(int id);
        Task<bool> CrearAsync(CategoriaCrearDto request);
        Task<bool> ActualizarAsync(CategoriaActualizarDto request);
        Task<bool> EliminarAsync(int id);
    }
}
