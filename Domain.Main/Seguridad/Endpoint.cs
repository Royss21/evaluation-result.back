namespace Domain.Main.Seguridad
{
    public class Endpoint : BaseModelo<Guid>
    {
        public string Entidad { get; set; } = string.Empty;
        public string Metodo { get; set; } = string.Empty;
        public string NombreControlador { get; set; } = string.Empty;
        public string NombreAccion { get; set; } = string.Empty;
        public string RutaEndpoint { get; set; } = string.Empty;
    }
}
