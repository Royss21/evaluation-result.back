namespace Infrastructure.Main.Contexto.Configuraciones.Entidades
{
    public class CotizacionConfig : BaseEntityTypeConfiguracion<Cotizacion, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Cotizacion> builder)
        {
            builder.Property(e => e.Comentario)
                .IsRequired()
                .HasMaxLength(400);

        }
    }
}
