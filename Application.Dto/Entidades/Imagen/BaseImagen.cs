namespace Application.Dto.Entidades.Color
{
    public abstract class BaseImagen
    {
        public string Nombre { get; set; } = string.Empty;
        public string NombreArchivo { get; set; } = string.Empty;
        public string Contenedor { get; set; } = string.Empty;
        public string RutaImagen { get; set; } = string.Empty;
    }
}
