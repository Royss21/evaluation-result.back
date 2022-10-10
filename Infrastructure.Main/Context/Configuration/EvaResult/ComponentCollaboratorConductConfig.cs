namespace Infrastructure.Main.Context.Configuration.EvaResult
{
    using Domain.Main.EvaResult;

    public class ComponentCollaboratorConductConfig : BaseEntityTypeConfig<ComponentCollaboratorConduct, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ComponentCollaboratorConduct> builder)
        {
            builder.Property(p => p.LevelName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Points)
                .IsRequired()
                .HasDefaultValue(0);
        }
    }
}
