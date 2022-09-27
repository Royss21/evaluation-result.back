namespace Infrastructure.Main.Contexto.Configuraciones.Entidades
{
    public class PedidoHistorialConfig : BaseEntityTypeConfiguracion<PedidoHistorial, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<PedidoHistorial> builder)
        {
            builder.Property(e => e.Comentario)
             .HasMaxLength(400);
        }
    }
}
