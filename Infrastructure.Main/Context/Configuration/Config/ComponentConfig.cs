namespace Infrastructure.Main.Context.Configuration.Config
{
    public class ComponentConfig : BaseEntityTypeConfig<Component, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Component> builder)
        {
            builder.ToTable(typeof(Component).Name, schema: "Config");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(b => b.HierarchyComponents)
                .WithOne(b => b.Component);
        }
    }
}
