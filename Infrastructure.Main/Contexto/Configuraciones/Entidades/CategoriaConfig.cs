namespace Infrastructure.Main.Contexto.Configuraciones.Entidades
{
    public class CategoriaConfig : BaseEntityTypeConfiguracion<Categoria, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Categoria> builder)
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
