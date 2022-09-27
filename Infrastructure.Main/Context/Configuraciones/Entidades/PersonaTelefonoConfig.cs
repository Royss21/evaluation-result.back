namespace Infrastructure.Main.Contexto.Configuraciones.Entidades
{
    public class PersonaTelefonoConfig : BaseEntityTypeConfiguracion<PersonaTelefono, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<PersonaTelefono> builder)
        {

            builder.Property(e => e.NumeroContacto)
               .IsRequired()
               .HasMaxLength(20);
        }
    }
}
