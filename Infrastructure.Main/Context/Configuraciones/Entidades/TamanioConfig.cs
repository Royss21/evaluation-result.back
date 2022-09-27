namespace Infrastructure.Main.Contexto.Configuraciones.Entidades
{
    public class TamanioConfig : BaseEntityTypeConfiguracion<Tamanio, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Tamanio> builder)
        {
            builder.Property(e => e.Nombre)
              .IsRequired()
             .HasMaxLength(50);

            builder.Property(e => e.Codigo)
              .IsRequired()
            .HasMaxLength(15);
        }
    }
}
