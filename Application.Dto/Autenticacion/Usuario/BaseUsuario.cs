namespace Application.Dto.Autenticacion.Usuario
{
    public abstract class BaseUsuario
    {
        public Guid PersonaId { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;       
        
    }
}
