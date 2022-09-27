namespace Infrastructure.Main.Contexto.Configuraciones.Administrador
{
    public class MenuConfig : BaseEntityTypeConfiguracion<Menu, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Menu> builder)
        {
            builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Url)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(p => p.Icono)
                .HasMaxLength(50);
        }
    }
}
