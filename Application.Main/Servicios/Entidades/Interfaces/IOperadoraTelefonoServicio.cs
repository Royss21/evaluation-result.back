namespace Application.Main.Servicios.Entidades.Interfaces
{
    using Application.Dto.Entidades.OperadoraTelefono;
    using Application.Dto.Paginacion;
    using Application.Main.PrimeNg;

    public interface IOperadoraTelefonoServicio
    {
        Task<IEnumerable<OperadoraTelefonoDto>> ObtenerTodoAsync();
        Task<PaginacionResultadoDto<OperadoraTelefonoDto>> ObtenerTodoPaginadoAsync(PrimeTable primeTable);
        Task<OperadoraTelefonoDto> ObtenerPorIdAsync(int id);
        Task<bool> CrearAsync(OperadoraTelefonoCrearDto request);
        Task<bool> ActualizarAsync(OperadoraTelefonoActualizarDto request);
        Task<bool> EliminarAsync(int id);
    }
}
