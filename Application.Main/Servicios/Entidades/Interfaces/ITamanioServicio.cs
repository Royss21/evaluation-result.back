namespace Application.Main.Servicios.Entidades.Interfaces
{
    using Application.Dto.Entidades.Tamanio;
    using Application.Dto.Paginacion;
    using Application.Main.PrimeNg;

    public interface ITamanioServicio
    {
        Task<IEnumerable<TamanioDto>> ObtenerTodoAsync();
        Task<PaginacionResultadoDto<TamanioDto>> ObtenerTodoPaginadoAsync(PrimeTable primeTable);
        Task<TamanioDto> ObtenerPorIdAsync(int id);
        Task<bool> CrearAsync(TamanioCrearDto request);
        Task<bool> ActualizarAsync(TamanioActualizarDto request);
        Task<bool> EliminarAsync(int id);
    }
}
