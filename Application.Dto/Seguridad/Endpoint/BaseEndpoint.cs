namespace Application.Dto.Seguridad.Endpoint
{
    public abstract class BaseEndpoint
    {
        public string Entidad { get; set; } = string.Empty;
        public string Metodo { get; set; } = string.Empty;
        public string NombreControlador { get; set; } = string.Empty;
        public string NombreAccion { get; set; } = string.Empty;
        public string RutaEndpoint { get; set; } = string.Empty;
    }
}
