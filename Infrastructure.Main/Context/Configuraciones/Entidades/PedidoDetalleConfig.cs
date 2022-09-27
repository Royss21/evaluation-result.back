namespace Infrastructure.Main.Contexto.Configuraciones.Entidades
{
    public class PedidoDetalleConfig : BaseEntityTypeConfiguracion<PedidoDetalle, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<PedidoDetalle> builder)
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
