
namespace Domain.Main.Auditoria
{
    public class AuditoriaEntidad : BaseModel<int>
    {
        public string NombreTabla { get; set; } = string.Empty;
        public string LlaveValores { get; set; } = string.Empty;
        public string ValoresAntiguos { get; set; } = string.Empty;
        public string ValoresNuevos { get; set; } = string.Empty;
    }
}
