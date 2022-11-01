namespace Infrastructure.Main.Context.Configuration.Config
{
    public class StageConfig : BaseEntityTypeConfig<Stage, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Stage> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(b => b.EvaluationStages)
                .WithOne(b => b.Stage);

            builder.HasMany(b => b.ComponentStages)
                .WithOne(b => b.Stage);

            builder.HasMany(b => b.ComponentCollaboratorStages)
                .WithOne(b => b.Stage);
        }
    }
}
