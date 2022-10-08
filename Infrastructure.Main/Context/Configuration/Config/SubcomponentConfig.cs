

namespace Infrastructure.Main.Context.Configuration.Config
{
    public class SubcomponentConfig : BaseEntityTypeConfig<Subcomponent, string>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Subcomponent> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .HasMaxLength(200);
        }
    }
}
