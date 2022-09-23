namespace Infrastructure.Main.Contexto.Configuraciones.Entidades
{
    public class ColorConfig : BaseEntityTypeConfiguracion<Color, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Color> builder)
        {
            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
