namespace Infrastructure.Main.Context.Configuration.EvaResult
{
    using Domain.Main.EvaResult;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EvaluationConfig : BaseEntityTypeConfig<Evaluation, string>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Evaluation> builder)
        {
            builder.Property(p => p.StartDate)
                .IsRequired();

            builder.Property(p => p.EndDate)
                .IsRequired();

            builder.Property(p => p.Weight)
                .IsRequired()
                .HasDefaultValue(0);
        }
    }
}
