namespace Infrastructure.Main.Context.Configuration.EvaResult
{
    using Domain.Main.EvaResult;
    

    public class EvaluationLeaderConfig : BaseEntityTypeConfig<EvaluationLeader, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<EvaluationLeader> builder)
        {

            builder.HasOne(b => b.EvaluationCollaborator)
               .WithOne(b => b.EvaluationLeader);

            builder.HasOne(b => b.Evaluation)
              .WithMany(b => b.EvaluationLeaders);

            builder.HasOne(b => b.Area)
              .WithMany(b => b.EvaluationLeaders);

            builder.HasMany(b => b.LeaderStages)
              .WithOne(b => b.EvaluationLeader);
        }
    }
}
