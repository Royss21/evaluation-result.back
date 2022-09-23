namespace Application.Dto.Autenticacion.Usuario
{
    public class UsuarioDto : BaseUsuario
    {
        public Guid Id { get; set; }
        public Guid CompaniaId { get; set; }
        public bool EsBloqueado { get; set; }
    }
}
