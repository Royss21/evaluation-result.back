namespace Infrastructure.Main.Contexto.Configuraciones.Autenticacion
{
    public class RolConfig : BaseEntityTypeConfiguracion<Rol, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Rol> builder)
        {
            builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Descripcion)
                .HasMaxLength(200);
        }
    }
}
