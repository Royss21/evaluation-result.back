namespace Infrastructure.Main.Context.Configuration.EvaResult
{
    using Domain.Main.EvaResult;
    

    public class EvaluationComponentStageConfig : BaseEntityTypeConfig<EvaluationComponentStage, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<EvaluationComponentStage> builder)
        {
            builder.ToTable(typeof(EvaluationComponentStage).Name, schema: "EvaResult");
            builder.Property(p => p.StartDate)
                .IsRequired();

            builder.Property(p => p.EndDate)
                .IsRequired();

            builder.HasOne(b => b.Evaluation)
                .WithMany(b => b.EvaluationComponentStages);

            builder.HasOne(b => b.Stage)
                .WithMany(b => b.EvaluationStages);

            builder.HasOne(b => b.EvaluationComponent)
                .WithMany(b => b.EvaluationComponentStages);

            builder.HasMany(b => b.ComponentCollaboratorStages)
                .WithOne(b => b.EvaluationComponentStage);
        }
    }
}
