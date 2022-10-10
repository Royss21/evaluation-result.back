namespace Infrastructure.Main.Context.Configuration.EvaResult
{
    using Domain.Main.EvaResult;


    public class ComponentStageConfig : BaseEntityTypeConfig<ComponentStage, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ComponentStage> builder)
        {
            builder.Property(p => p.StartDate)
                .IsRequired();

            builder.Property(p => p.EndDate)
                .IsRequired();
        }
    }
}
