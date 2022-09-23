namespace Application.Main.Servicios.Entidades.Interfaces
{
    using Application.Dto.Entidades.Tela;
    using Application.Dto.Paginacion;
    using Application.Main.PrimeNg;

    public interface ITelaServicio
    {
        Task<IEnumerable<TelaDto>> ObtenerTodoAsync();
        Task<PaginacionResultadoDto<TelaPaginadoDto>> ObtenerTodoPaginadoAsync(PrimeTable primeTable);
        Task<TelaDto> ObtenerPorIdAsync(int id);
        Task<bool> CrearAsync(TelaCrearDto request);
        Task<bool> ActualizarAsync(TelaActualizarDto request);
        Task<bool> EliminarAsync(int id);
    }
}
