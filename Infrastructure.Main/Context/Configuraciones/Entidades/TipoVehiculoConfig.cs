namespace Infrastructure.Main.Contexto.Configuraciones.Entidades
{
    public class TipoVehiculoConfig : BaseEntityTypeConfiguracion<TipoVehiculo, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<TipoVehiculo> builder)
        {
            builder.Property(e => e.Nombre)
             .IsRequired()
            .HasMaxLength(50);
        }
    }
}
