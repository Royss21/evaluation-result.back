namespace Infrastructure.Main.Context.Configuration.Config
{
    public class SubcomponentValueConfig : BaseEntityTypeConfig<SubcomponentValue, string>
    {
        public override void ConfigureEntity(EntityTypeBuilder<SubcomponentValue> builder)
        {
            builder.Property(p => p.MinimunPercentage)
               .IsRequired()
               .HasDefaultValue(0);

            builder.Property(p => p.MaximunPercentage)
               .IsRequired()
               .HasDefaultValue(0);

            builder.Property(p => p.RelativeWeight)
               .IsRequired()
               .HasDefaultValue(0);
        }
    }
}
