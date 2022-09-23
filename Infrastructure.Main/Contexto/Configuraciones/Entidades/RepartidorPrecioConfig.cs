namespace Infrastructure.Main.Contexto.Configuraciones.Entidades
{
    public class RepartidorPrecioConfig : BaseEntityTypeConfiguracion<RepartidorPrecio, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<RepartidorPrecio> builder)
        {
            builder.Property(e => e.Comentario)
             .HasMaxLength(250);
        }
    }
}
