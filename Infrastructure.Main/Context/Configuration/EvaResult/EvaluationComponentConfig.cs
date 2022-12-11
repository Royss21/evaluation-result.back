namespace Infrastructure.Main.Context.Configuration.EvaResult
{
    using Domain.Main.EvaResult;
    

    public class EvaluationComponentConfig : BaseEntityTypeConfig<EvaluationComponent, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<EvaluationComponent> builder)
        {
            builder.ToTable(typeof(EvaluationComponent).Name, schema: "EvaResult");
            builder.HasKey(p => p.Id);

            builder.HasOne(b => b.Evaluation)
                .WithMany(b => b.EvaluationComponents);

            builder.HasOne(b => b.Component)
                .WithMany(b => b.EvaluationComponents);

            builder.HasMany(b => b.EvaluationComponentStages)
               .WithOne(b => b.EvaluationComponent);

            builder.HasMany(b => b.ComponentsCollaborator)
               .WithOne(b => b.EvaluationComponent);

            builder.HasMany(b => b.EvaluationLeaders)
               .WithOne(b => b.EvaluationComponent);

            builder.HasOne(b => b.Status)
                   .WithMany(b => b.EvaluationComponents);

        }
    }
}
