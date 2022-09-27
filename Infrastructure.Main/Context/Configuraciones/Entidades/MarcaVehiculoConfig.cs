namespace Infrastructure.Main.Contexto.Configuraciones.Entidades
{
    public class MarcaVehiculoConfig : BaseEntityTypeConfiguracion<MarcaVehiculo, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<MarcaVehiculo> builder)
        {
            builder.Property(e => e.Nombre)
                .IsRequired()
               .HasMaxLength(50);
        }
    }
}
