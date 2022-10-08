namespace Application.Main.Servicios.Seguridad.Interfaces
{
    using Application.Dto.Seguridad.Endpoint;
    using Application.Dto.Paginacion;
    using Application.Main.PrimeNg;

    public interface IEndpointServicio
    {
        Task<IEnumerable<EndpointDto>> ObtenerTodoAsync();
        Task<PaginacionResultadoDto<EndpointDto>> ObtenerTodoPaginadoAsync(PrimeTable primeTable);
        Task<EndpointDto> ObtenerPorIdAsync(Guid id);
        Task<bool> CrearAsync(EndpointCrearDto request);
        Task<bool> ActualizarAsync(EndpointActualizarDto request);
        Task<bool> EliminarAsync(Guid id);
    }
}
