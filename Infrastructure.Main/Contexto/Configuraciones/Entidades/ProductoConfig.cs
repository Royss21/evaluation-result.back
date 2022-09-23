namespace Infrastructure.Main.Contexto.Configuraciones.Entidades
{
    public class ProductoConfig : BaseEntityTypeConfiguracion<Producto, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Producto> builder)
        {
            builder.Property(e => e.Codigo)
              .HasMaxLength(12);

            builder.Property(e => e.CodigoSunat)
             .HasMaxLength(20);

            builder.Property(e => e.Nombre)
             .IsRequired()
             .HasMaxLength(100);

            builder.Property(e => e.Descripcion)
             .HasMaxLength(250);
        }
    }
}
