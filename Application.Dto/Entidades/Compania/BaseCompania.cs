namespace Application.Dto.Entidades.Compania
{
    public abstract class BaseCompania
    {
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Movil { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Contenedor { get; set; } = string.Empty;
        public int UbigeoId { get; set; }
    }
}
