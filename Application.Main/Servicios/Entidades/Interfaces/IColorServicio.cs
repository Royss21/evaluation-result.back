namespace Application.Main.Servicios.Entidades.Interfaces
{
    using Application.Dto.Entidades.Color;
    using Application.Dto.Paginacion;
    using Application.Main.PrimeNg;

    public interface IColorServicio
    {
        Task<IEnumerable<ColorDto>> ObtenerTodoAsync();
        Task<PaginacionResultadoDto<ColorDto>> ObtenerTodoPaginadoAsync(PrimeTable primeTable);
        Task<ColorDto> ObtenerPorIdAsync(int id);
        Task<bool> CrearAsync(ColorCrearDto request);
        Task<bool> ActualizarAsync(ColorActualizarDto request);
        Task<bool> EliminarAsync(int id);
    }
}
