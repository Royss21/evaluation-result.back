namespace Application.Main.Servicios.Autenticacion.Interfaces
{
    using Application.Dto.Autenticacion.Usuario;

    public interface IUsuarioServicio
    {
        Task<IEnumerable<UsuarioDto>> ObtenerTodoAsync();
        Task<bool> CrearAsync(UsuarioCrearDto request);
        Task<bool> CrearConCompaniaAsync(UsuarioCompaniaCrearDto request);
    }
}
