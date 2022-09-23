
namespace Domain.Main.Auditoria
{
    using SharedKernell.Helpers;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System.Text.Json;
    public class AuditoriaEntrada 
    {
        public AuditoriaEntrada(EntityEntry entidadEntrada)
        {
            EntidadEntrada = entidadEntrada;
        }

        public EntityEntry EntidadEntrada { get; }
        public string NombreTabla { get; set; }
        public Dictionary<string, object> LlaveValores { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> ValoresAntiguos { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> ValoresNuevos { get; } = new Dictionary<string, object>();
        public List<PropertyEntry> PropiedadesTemporales { get; } = new List<PropertyEntry>();
        public bool TienePropiedadesTemporales => PropiedadesTemporales.Any();

        public AuditoriaEntidad MapAuditoria(string usuario)
        {
            var auditoria = new AuditoriaEntidad
            {
                NombreTabla = NombreTabla,
                FechaCrea = DateTime.Now.ObtenerFechaPeru(),
                LlaveValores = JsonSerializer.Serialize(LlaveValores),
                ValoresAntiguos = !ValoresAntiguos.Any() ? "" : JsonSerializer.Serialize(ValoresAntiguos),
                ValoresNuevos = !ValoresNuevos.Any() ? "" : JsonSerializer.Serialize(ValoresNuevos),
                UsuarioCrea = usuario
            };

            return auditoria;
        }
    }
}
