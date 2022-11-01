namespace Infrastructure.Main.Context.Configuration.Employee
{
    public class HierarchyConfig : BaseEntityTypeConfig<Hierarchy, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Hierarchy> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(b => b.Level)
                .WithMany(b => b.Hierarchies);

            builder.HasMany(b => b.Charges)
                .WithOne(b => b.Hierarchy);

            builder.HasMany(b => b.HierarchyComponents)
                .WithOne(b => b.Hierarchy);
        }
    }
}
