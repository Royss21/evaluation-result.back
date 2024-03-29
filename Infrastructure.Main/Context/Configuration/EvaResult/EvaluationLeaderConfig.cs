﻿namespace Infrastructure.Main.Context.Configuration.EvaResult
{
    using Domain.Main.EvaResult;
    

    public class EvaluationLeaderConfig : BaseEntityTypeConfig<EvaluationLeader, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<EvaluationLeader> builder)
        {
            builder.ToTable(typeof(EvaluationLeader).Name, schema: "EvaResult");
            builder.HasOne(b => b.EvaluationCollaborator)
               .WithMany(b => b.EvaluationLeaders);

            builder.HasOne(b => b.Evaluation)
              .WithMany(b => b.EvaluationLeaders);

            builder.HasMany(b => b.LeaderStages)
              .WithOne(b => b.EvaluationLeader)
              .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(b => b.EvaluationComponent)
              .WithMany(b => b.EvaluationLeaders);
        }
    }
}
