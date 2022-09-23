namespace Infrastructure.Main.Contexto.Configuraciones.Entidades
{
    public class CotizacionDetalleConfig : BaseEntityTypeConfiguracion<CotizacionDetalle, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<CotizacionDetalle> builder)
        {
            builder.Property(e => e.Descripcion)
                .HasMaxLength(300);

            builder.Property(e => e.NombreBordado)
               .HasMaxLength(100);

            builder.Property(e => e.Comentario)
               .HasMaxLength(400);
        }
    }
}
