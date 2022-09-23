namespace Infrastructure.Main.Contexto.Configuraciones.Entidades
{
    public class TipoEntidadEstadoConfig : BaseEntityTypeConfiguracion<TipoEntidadEstado, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<TipoEntidadEstado> builder)
        {
            builder.Property(e => e.Nombre)
             .IsRequired()
            .HasMaxLength(50);
        }
    }
}
