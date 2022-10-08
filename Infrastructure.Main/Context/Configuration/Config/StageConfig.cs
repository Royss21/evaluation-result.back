

namespace Infrastructure.Main.Context.Configuration.Config
{
    public class StageConfig : BaseEntityTypeConfig<Stage, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Stage> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
