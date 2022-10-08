

namespace Infrastructure.Main.Context.Configuration.Config
{

    public class ComponentConfig : BaseEntityTypeConfig<Component, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Component> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
