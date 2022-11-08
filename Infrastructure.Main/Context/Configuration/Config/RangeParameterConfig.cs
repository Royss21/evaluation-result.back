namespace Infrastructure.Main.Context.Configuration.Config
{
    public class RangeParameterConfig : BaseEntityTypeConfig<RangeParameter, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<RangeParameter> builder)
        {
            builder.ToTable(typeof(RangeParameter).Name, schema: "Config");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .IsRequired(false)
                .HasMaxLength(200);

            builder.HasMany(b => b.ParametersValue)
                .WithOne(b => b.RangeParameter)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
