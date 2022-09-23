
namespace Infrastructure.Main.Contexto.Configuraciones.Auditoria
{
    
    public class AuditoriaConfig : BaseEntityTypeConfiguracion<AuditoriaEntidad, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<AuditoriaEntidad> builder)
        {
            builder.Property(p => p.LlaveValores).HasMaxLength(int.MaxValue);
            builder.Property(p => p.ValoresNuevos).HasMaxLength(int.MaxValue);
            builder.Property(p => p.ValoresAntiguos).HasMaxLength(int.MaxValue);
            builder.Property(p => p.NombreTabla).HasMaxLength(50);
        }
    }
}
