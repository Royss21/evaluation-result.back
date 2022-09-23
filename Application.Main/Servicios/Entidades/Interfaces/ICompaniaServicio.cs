namespace Application.Main.Servicios.Entidades.Interfaces
{
    using Application.Dto.Entidades.Compania;
    using Application.Dto.Paginacion;
    using Application.Main.PrimeNg;

    public interface ICompaniaServicio
    {
        Task<IEnumerable<CompaniaDto>> ObtenerTodoAsync();
        Task<PaginacionResultadoDto<CompaniaDto>> ObtenerTodoPaginadoAsync(PrimeTable primeTable);
        Task<CompaniaDto> ObtenerPorIdAsync(Guid id);
        Task<bool> CrearAsync(CompaniaCrearDto request);
        Task<bool> ActualizarAsync(CompaniaActualizarDto request);
        Task<bool> EliminarAsync(Guid id);
    }
}
