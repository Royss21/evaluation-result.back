namespace Infrastructure.Main.Context.Configuration.Config
{
    public class HierarchyComponentConfig : BaseEntityTypeConfig<HierarchyComponent, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<HierarchyComponent> builder)
        {
            builder.Property(p => p.Weight)
                .IsRequired()
                .HasDefaultValue(0);

            builder.HasOne(b => b.Hierarchy)
                    .WithMany(b => b.HierarchyComponents);

            builder.HasOne(b => b.Component)
                    .WithMany(b => b.HierarchyComponents);
        }
    }
}
