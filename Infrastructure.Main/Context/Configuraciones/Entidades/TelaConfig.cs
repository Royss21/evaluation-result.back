namespace Infrastructure.Main.Contexto.Configuraciones.Entidades
{
    public class TelaConfig : BaseEntityTypeConfiguracion<Tela, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Tela> builder)
        {
            builder.Property(e => e.Nombre)
              .IsRequired()
             .HasMaxLength(50);
        }
    }
}
