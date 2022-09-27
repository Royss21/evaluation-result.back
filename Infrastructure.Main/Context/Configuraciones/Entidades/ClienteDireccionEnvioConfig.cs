namespace Infrastructure.Main.Contexto.Configuraciones.Entidades
{
    public class ClienteDireccionEnvioConfig : BaseEntityTypeConfiguracion<ClienteDireccionEnvio, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ClienteDireccionEnvio> builder)
        {
            builder.Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(e => e.Referencia)
                .HasMaxLength(200);
        }
    }
}
