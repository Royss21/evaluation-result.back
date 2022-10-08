namespace Infrastructure.Main.Context.Configuration.Config
{
    public class ConductConfig : BaseEntityTypeConfig<Conduct, string>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Conduct> builder)
        {
            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
