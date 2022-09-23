namespace Infrastructure.Main.Contexto.Configuraciones.Entidades
{
    public class OperadoraTelefonoConfig : BaseEntityTypeConfiguracion<OperadoraTelefono, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<OperadoraTelefono> builder)
        {
            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Descripcion)
                .HasMaxLength(200);

        }
    }
}
