namespace Infrastructure.Main.Context.Configuration.Config
{
    public class SubcomponentValueConfig : BaseEntityTypeConfig<SubcomponentValue, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<SubcomponentValue> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.MinimunPercentage)
               .IsRequired()
               .HasDefaultValue(0);

            builder.Property(p => p.MaximunPercentage)
               .IsRequired()
               .HasDefaultValue(0);

            builder.Property(p => p.RelativeWeight)
               .IsRequired()
               .HasDefaultValue(0);

            builder.HasOne(b => b.Subcomponent)
                .WithOne(b => b.SubcomponentValue);
        }
    }
}
