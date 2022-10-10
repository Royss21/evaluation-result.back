namespace Infrastructure.Main.Context.Configuration.Employee
{
    public class HierarchyConfig : BaseEntityTypeConfig<Hierarchy, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Hierarchy> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
