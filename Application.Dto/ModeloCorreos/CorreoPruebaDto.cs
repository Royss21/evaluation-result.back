namespace Application.Dto.ModeloCorreos
{
    public class CorreoPruebaDto
    {
        public string NombreUsuario { get; set; } = string.Empty;
        public string NombreCompletos { get; set; } = string.Empty;
        public List<string> Endpoints { get; set; }
    }
}
