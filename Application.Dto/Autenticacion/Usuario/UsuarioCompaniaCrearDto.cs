namespace Application.Dto.Autenticacion.Usuario
{
    public class UsuarioCompaniaCrearDto : BaseUsuario
    {
        public string Contrasenia { get; set; } = string.Empty;
        public Guid CompaniaId { get; set; }
    }
}
