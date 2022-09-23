namespace Infrastructure.Main.Contexto.Configuraciones.Autenticacion
{
    public class UsuarioTokenConfig : BaseEntityTypeConfiguracion<UsuarioToken, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<UsuarioToken> builder)
        {
            builder.Property(p => p.Token)
                .IsRequired()
             .HasMaxLength(1000);

            builder.Property(p => p.RefrescarToken)
                .IsRequired()
             .HasMaxLength(150);
        }
    }
}
