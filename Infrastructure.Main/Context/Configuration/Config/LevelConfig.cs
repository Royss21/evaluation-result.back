namespace Infrastructure.Main.Context.Configuration.Config
{
    public class LevelConfig : BaseEntityTypeConfig<Level, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Level> builder)
        {
            builder.ToTable(typeof(Level).Name, schema: "Config");
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);


            builder.Property(p => p.Description)
                .HasMaxLength(200);

            builder.HasMany(b => b.Hierarchies)
                .WithOne(b => b.Level);

            builder.HasMany(b => b.Conducts)
                .WithOne(b => b.Level);
        }
    }
}
