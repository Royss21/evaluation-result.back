namespace Application.Dto.Entidades.Persona
{
    public abstract class BasePersona
    {
        public string Apellidos { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string NumeroDocumento { get; set; } = string.Empty;
        public int DocumentoIdentidadId { get; set; }
        public string Direccion { get; set; } = string.Empty;
        public DateTimeOffset? FechaNacimiento { get; set; }
        public string Correo { get; set; } = string.Empty;
        public int UbigeoId { get; set; }
    }
}
