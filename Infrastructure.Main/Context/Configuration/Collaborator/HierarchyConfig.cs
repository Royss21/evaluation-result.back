namespace Infrastructure.Main.Context.Configuration.Collaborator
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
