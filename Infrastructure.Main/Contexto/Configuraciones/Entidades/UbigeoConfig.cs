namespace Infrastructure.Main.Contexto.Configuraciones.Entidades
{
    public class UbigeoConfig : BaseEntityTypeConfiguracion<Ubigeo, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Ubigeo> builder)
        {
            builder.Property(e => e.Departamento)
            .IsRequired()
           .HasMaxLength(100);

            builder.Property(e => e.Provincia)
            .IsRequired()
           .HasMaxLength(100);

            builder.Property(e => e.Distrito)
            .IsRequired()
           .HasMaxLength(100);

            builder.Property(e => e.CodigoUbigeo)
            .IsRequired()
            .HasMaxLength(8);
        }
    }
}
