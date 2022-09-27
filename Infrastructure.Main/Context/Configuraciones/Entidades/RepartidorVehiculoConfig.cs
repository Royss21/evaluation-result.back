namespace Infrastructure.Main.Contexto.Configuraciones.Entidades
{
    public class RepartidorVehiculoConfig : BaseEntityTypeConfiguracion<RepartidorVehiculo, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<RepartidorVehiculo> builder)
        {
            builder.Property(e => e.Modelo)
             .HasMaxLength(20);

            builder.Property(e => e.Color)
             .HasMaxLength(20);

            builder.Property(e => e.NumeroPlaca)
             .HasMaxLength(20);
        }
    }
}
