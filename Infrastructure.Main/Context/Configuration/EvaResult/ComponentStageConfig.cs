namespace Infrastructure.Main.Context.Configuration.EvaResult
{
    using Domain.Main.EvaResult;


    public class ComponentStageConfig : BaseEntityTypeConfig<ComponentStage, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ComponentStage> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.StartDate)
                .IsRequired();

            builder.Property(p => p.EndDate)
                .IsRequired();

            builder.HasOne(b => b.EvaluationComponent)
               .WithMany(b => b.ComponentStages);

            builder.HasOne(b => b.Stage)
              .WithMany(b => b.ComponentStages);
        }
    }
}
