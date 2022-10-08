

namespace Infrastructure.Main.Context.Configuration.Config
{
    public class LevelConfig : BaseEntityTypeConfig<Level, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Level> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);


            builder.Property(p => p.Description)
                .HasMaxLength(200);
        }
    }
}
