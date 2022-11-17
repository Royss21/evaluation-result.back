namespace Infrastructure.Main.Context.Configuration.Config
{
    public class ParameterValueConfig : BaseEntityTypeConfig<ParameterValue, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ParameterValue> builder)
        {
            builder.ToTable(typeof(ParameterValue).Name, schema: "Config");
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.NameProperty)
                .IsRequired(false)
                .HasMaxLength(50);

            builder.Property(p => p.Value)
                .HasDefaultValue(0)
                .IsRequired();

            builder.HasOne(p => p.ParameterRange)
                .WithMany(b => b.ParametersValue);
        }
    }
}
