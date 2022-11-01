namespace Infrastructure.Main.Context.Configuration.EvaResult
{
    using Domain.Main.EvaResult;
    

    public class LeaderStageConfig : BaseEntityTypeConfig<LeaderStage, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<LeaderStage> builder)
        {
            builder.HasOne(b => b.EvaluationLeader)
             .WithMany(b => b.LeaderStages);

            builder.HasOne(b => b.Stage)
                .WithMany(b => b.LeaderStages);

            builder.HasMany(b => b.LeaderCollaborators)
                .WithOne(b => b.LeaderStage);
        }
    }
}
