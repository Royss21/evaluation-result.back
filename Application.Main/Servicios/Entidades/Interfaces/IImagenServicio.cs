namespace Application.Main.Servicios.Entidades.Interfaces
{
    using Application.Dto.Entidades.Color;
    using Application.Dto.Paginacion;
    using Application.Main.PrimeNg;

    public interface IImagenServicio
    {
        Task<IEnumerable<ImagenDto>> ObtenerTodoAsync();
        Task<PaginacionResultadoDto<ImagenDto>> ObtenerTodoPaginadoAsync(PrimeTable primeTable);
        Task<int> CrearAsync(ImagenCrearDto request);
        Task<bool> EliminarAsync(int id);
    }
}
