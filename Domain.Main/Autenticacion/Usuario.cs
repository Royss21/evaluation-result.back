namespace Domain.Main.Autenticacion
{
    public  class Usuario : BaseModeloActivo<Guid>, IBaseCompania
    {
        public Guid PersonaId { get; set; }
        public Guid CompaniaId { get ; set ; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string Contrasenia { get; set; } = string.Empty;
        public int TipoHash { get; set; }
        public bool EsBloqueado { get; set; }

        public Persona Persona { get; set; }
        public Compania Compania { get; set; }
    }
}
