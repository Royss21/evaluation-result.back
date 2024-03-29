﻿namespace Infrastructure.Main.Context.Configuration.EvaResult
{
    using Domain.Main.EvaResult;
    

    public class LeaderStageConfig : BaseEntityTypeConfig<LeaderStage, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<LeaderStage> builder)
        {
            builder.ToTable(typeof(LeaderStage).Name, schema: "EvaResult");

            builder.HasOne(b => b.EvaluationLeader)
             .WithMany(b => b.LeaderStages)
             .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(b => b.Stage)
                .WithMany(b => b.LeaderStages);

            builder.HasMany(b => b.LeaderCollaborators)
                .WithOne(b => b.LeaderStage)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
