namespace Infrastructure.Main.Context.Configuration.EvaResult
{
    using Domain.Main.EvaResult;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EvaluationConfig : BaseEntityTypeConfig<Evaluation, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Evaluation> builder)
        {
            
        }
    }
}
