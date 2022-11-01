namespace Infrastructure.Main.Context.Configuration.EvaResult
{
    using Domain.Main.EvaResult;


    public class ComponentCollaboratorStageConfig : BaseEntityTypeConfig<ComponentCollaboratorStage, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ComponentCollaboratorStage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Comment)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(b => b.ComponentCollaborator)
               .WithMany(b => b.ComponentCollaboratorStages);

            builder.HasOne(b => b.Stage)
               .WithMany(b => b.ComponentCollaboratorStages);
        }
    }
}
