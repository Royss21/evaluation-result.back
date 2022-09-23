namespace Infrastructure.Main.Contexto.Configuraciones.Autenticacion
{
    public class UsuarioConfig : BaseEntityTypeConfiguracion<Usuario, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(p => p.NombreUsuario)
                .IsRequired()
              .HasMaxLength(100);

            builder.Property(p => p.Contrasenia)
                .IsRequired()
             .HasMaxLength(250);
        }
    }
}

