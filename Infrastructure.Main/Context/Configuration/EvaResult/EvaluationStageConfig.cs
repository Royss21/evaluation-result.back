namespace Infrastructure.Main.Context.Configuration.EvaResult
{
    using Domain.Main.EvaResult;
    

    public class EvaluationStageConfig : BaseEntityTypeConfig<EvaluationStage, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<EvaluationStage> builder)
        {

            builder.Property(p => p.StartDate)
                .IsRequired();

            builder.Property(p => p.EndDate)
                .IsRequired();

            builder.HasOne(b => b.Evaluation)
                .WithMany(b => b.EvaluationStages);

            builder.HasOne(b => b.Stage)
                .WithMany(b => b.EvaluationStages);
        }
    }
}
