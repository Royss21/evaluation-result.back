
namespace Application.Dto.Autenticacion.Usuario
{
    public class UsuarioPersonaTokenDto
    {
        public Guid Id { get; set; }
        public string Contrasenia { get; set; }
        public int TipoHash { get; set; }
        public Guid CompaniaId { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
    }
}
