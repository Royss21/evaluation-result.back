namespace Application.Main.Servicios.Entidades.Interfaces
{
    using Application.Dto.Entidades.TipoVehiculo;
    using Application.Dto.Paginacion;
    using Application.Main.PrimeNg;

    public interface ITipoVehiculoServicio
    {
        Task<IEnumerable<TipoVehiculoDto>> ObtenerTodoAsync();
        Task<PaginacionResultadoDto<TipoVehiculoDto>> ObtenerTodoPaginadoAsync(PrimeTable primeTable);
        Task<TipoVehiculoDto> ObtenerPorIdAsync(int id);
        Task<bool> CrearAsync(TipoVehiculoCrearDto request);
        Task<bool> ActualizarAsync(TipoVehiculoActualizarDto request);
        Task<bool> EliminarAsync(int id);
    }
}
