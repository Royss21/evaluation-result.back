namespace Application.Dto.Autenticacion.Usuario
{
    public class UsuarioCrearDto : BaseUsuario
    {
        public string Contrasenia { get; set; } = string.Empty;
    }
}
