namespace Infrastructure.Main.Context.Configuration.Config
{
    public class LabelDetailConfig : BaseEntityTypeConfig<LabelDetail, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<LabelDetail> builder)
        {
            builder.ToTable(typeof(LabelDetail).Name, schema: "Config");
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .HasMaxLength(200);

            builder.Property(p => p.Icon)
               .HasMaxLength(50);

            builder.Property(p => p.MaximunValue)
               .IsRequired()
               .HasDefaultValue(0);

            builder.Property(p => p.MinimunValue)
               .IsRequired()
               .HasDefaultValue(0);

            builder.Property(p => p.RealValue)
               .IsRequired()
               .HasDefaultValue(0);

            builder.HasOne(b => b.Label)
                .WithMany(b => b.LabelDetails);
        }
    }
}
