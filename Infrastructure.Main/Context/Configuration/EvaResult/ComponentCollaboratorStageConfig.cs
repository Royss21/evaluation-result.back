namespace Infrastructure.Main.Context.Configuration.EvaResult
{
    using Domain.Main.EvaResult;


    public class ComponentCollaboratorStageConfig : BaseEntityTypeConfig<ComponentCollaboratorStage, string>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ComponentCollaboratorStage> builder)
        {
            builder.Property(p => p.Comment)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
