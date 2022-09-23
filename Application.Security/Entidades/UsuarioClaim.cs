namespace Application.Security.Entidades
{
    public class UsuarioClaim
    {
        public Guid Id { get; set; }
        public string NombreCompleto { get; set; }
        public string NombreUsuario { get; set; }
        public Guid RolId { get; set; }
        public Guid CompaniaId { get; set; }
    }
}