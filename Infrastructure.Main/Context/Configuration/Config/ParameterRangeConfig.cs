namespace Infrastructure.Main.Context.Configuration.Config
{
    public class ParameterRangeConfig : BaseEntityTypeConfig<ParameterRange, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ParameterRange> builder)
        {
            builder.ToTable(typeof(ParameterRange).Name, schema: "Config");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .IsRequired(false)
                .HasMaxLength(200);

            builder.HasMany(b => b.ParametersValue)
                .WithOne(b => b.ParameterRange)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
