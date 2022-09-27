namespace Infrastructure.Main.Contexto.Configuraciones.Entidades
{
    public class CompaniaConfig : BaseEntityTypeConfiguracion<Compania, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Compania> builder)
        {
            builder.Property(e => e.Correo)
               .IsRequired()
               .HasMaxLength(80);

            builder.HasIndex(e => e.Correo)
                .IsUnique();

            builder.Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(400);

            builder.Property(e => e. Contenedor)
               .HasMaxLength(50);

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Movil)
               .HasMaxLength(20);

            builder.Property(e => e.Telefono)
               .HasMaxLength(20);
        }
    }
}
