namespace Application.Security.Entidades
{
    public static class UsuarioActual
    {
        public static Guid Id { get; set; }
        public static Guid RolId { get; set; }
        public static Guid CompaniaId { get; set; }
        public static string ContenedorAzure { get; set; } = string.Empty;
    }
}
