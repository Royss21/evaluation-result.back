namespace Infrastructure.Main.Context.Configuration.EvaResult
{
    using Domain.Main.EvaResult;


    public class ComponentCollaboratorCommentConfig : BaseEntityTypeConfig<ComponentCollaboratorComment, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ComponentCollaboratorComment> builder)
        {
            builder.ToTable(typeof(ComponentCollaboratorComment).Name, schema: "EvaResult");

            builder.Property(p => p.Comment)
                .IsRequired()
                .HasMaxLength(2000);

            builder.HasOne(b => b.EvaluationCollaborator)
               .WithMany(b => b.ComponentCollaboratorComments);

            builder.HasOne(b => b.EvaluationComponentStage)
              .WithMany(b => b.ComponentCollaboratorStages);

            builder.HasOne(b => b.Status)
                   .WithMany(b => b.ComponentCollaboratorComments);

        }
    }
}
