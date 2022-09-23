namespace Infrastructure.Main.Contexto.Configuraciones.Entidades
{
    public class ImagenConfig : BaseEntityTypeConfiguracion<Imagen, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Imagen> builder)
        {
            builder.Property(e => e.Nombre)
                .IsRequired()
               .HasMaxLength(200);

            builder.Property(e => e.NombreArchivo)
                 .IsRequired()
               .HasMaxLength(100);

            builder.Property(e => e.Contenedor)
                .IsRequired()
               .HasMaxLength(100);

            builder.Property(e => e.RutaImagen)
                .IsRequired()
               .HasMaxLength(300);
        }
    }
}
