namespace Infrastructure.Main.Context.Configuration.Collaborator
{
    public class GerencyConfig : BaseEntityTypeConfig<Gerency, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Gerency> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
