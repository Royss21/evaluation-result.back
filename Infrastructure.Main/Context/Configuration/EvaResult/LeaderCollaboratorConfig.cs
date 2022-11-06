namespace Infrastructure.Main.Context.Configuration.EvaResult
{
    using Domain.Main.EvaResult;
    

    public class LeaderCollaboratorConfig : BaseEntityTypeConfig<LeaderCollaborator, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<LeaderCollaborator> builder)
        {
            builder.ToTable(typeof(LeaderCollaborator).Name, schema: "EvaResult");
            builder.HasOne(b => b.LeaderStage)
                .WithMany(b => b.LeaderCollaborators);

            builder.HasOne(b => b.EvaluationCollaborator)
               .WithMany(b => b.LeaderCollaborators)
               .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
