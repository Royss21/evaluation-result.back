namespace Infrastructure.Main.Context.Configuration.EvaResult
{
    using Domain.Main.EvaResult;
    

    public class PeriodConfig : BaseEntityTypeConfig<Period, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Period> builder)
        {
            builder.Property(p => p.StartDate)
                        .IsRequired();

            builder.Property(p => p.EndDate)
                        .IsRequired();

            builder.HasMany(b => b.Evaluations)
                .WithOne(b => b.Period);
        }
    }
}
