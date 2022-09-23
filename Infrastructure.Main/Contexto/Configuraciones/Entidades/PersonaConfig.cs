namespace Infrastructure.Main.Contexto.Configuraciones.Entidades
{
    public class PersonaConfig : BaseEntityTypeConfiguracion<Persona, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Persona> builder)
        {
            builder.Property(e => e.Apellidos)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Nombres)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.NumeroDocumento)
               .IsRequired()
               .HasMaxLength(20);

            builder.Property(e => e.Direccion)
               .IsRequired()
               .HasMaxLength(200);

            builder.Property(e => e.Correo)
               .IsRequired()
               .HasMaxLength(80);

            builder.HasIndex(e => e.Correo)
                .IsUnique();

            //builder.HasOne(p => p.DocumentoIdentidad)
            //        .WithOne(p => p.Persona)
            //        .HasForeignKey<Persona>(d => d.DocumentoIdentidadId);

        }
    }
}
