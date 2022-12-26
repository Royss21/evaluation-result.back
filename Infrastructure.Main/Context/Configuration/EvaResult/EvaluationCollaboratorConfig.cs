namespace Infrastructure.Main.Context.Configuration.EvaResult
{
    using Domain.Main.EvaResult;
    

    public class EvaluationCollaboratorConfig : BaseEntityTypeConfig<EvaluationCollaborator, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<EvaluationCollaborator> builder)
        {
            builder.ToTable(typeof(EvaluationCollaborator).Name, schema: "EvaResult");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(e => e.Evaluation)
                .WithMany(c => c.EvaluationCollaborators);

            builder.HasOne(e => e.Collaborator)
                .WithMany(c => c.EvaluationCollaborators);

            builder.HasMany(e => e.EvaluationLeaders)
                .WithOne(c => c.EvaluationCollaborator)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(e => e.LeaderCollaborators)
                .WithOne(c => c.EvaluationCollaborator)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(e => e.ComponentsCollaborator)
                .WithOne(c => c.EvaluationCollaborator)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(e => e.ComponentCollaboratorComments)
                .WithOne(c => c.EvaluationCollaborator)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
