namespace Application.Main.Servicios.Entidades.Interfaces
{
    using Application.Dto.Entidades.MarcaVehiculo;
    using Application.Dto.Paginacion;
    using Application.Main.PrimeNg;

    public interface IMarcaVehiculoServicio
    {
        Task<IEnumerable<MarcaVehiculoDto>> ObtenerTodoAsync();
        Task<PaginacionResultadoDto<MarcaVehiculoDto>> ObtenerTodoPaginadoAsync(PrimeTable primeTable);
        Task<MarcaVehiculoDto> ObtenerPorIdAsync(int id);
        Task<bool> CrearAsync(MarcaVehiculoCrearDto request);
        Task<bool> ActualizarAsync(MarcaVehiculoActualizarDto request);
        Task<bool> EliminarAsync(int id);
    }
}
