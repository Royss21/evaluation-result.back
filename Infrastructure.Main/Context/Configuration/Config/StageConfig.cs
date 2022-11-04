namespace Infrastructure.Main.Context.Configuration.Config
{
    public class StageConfig : BaseEntityTypeConfig<Stage, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Stage> builder)
        {
            builder.ToTable(typeof(Stage).Name, schema: "Config");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(b => b.EvaluationStages)
                .WithOne(b => b.Stage);

        }
    }
}
