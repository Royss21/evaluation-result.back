namespace Infrastructure.Main.Contexto.Configuraciones.Entidades
{
    public class PedidoConfig : BaseEntityTypeConfiguracion<Pedido, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Pedido> builder)
        {
            builder.Property(e => e.Comentario)
                .IsRequired()
                .HasMaxLength(400);
        }
    }
}
