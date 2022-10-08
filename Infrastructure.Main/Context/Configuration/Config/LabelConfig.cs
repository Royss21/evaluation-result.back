namespace Infrastructure.Main.Context.Configuration.Config
{
    public class LabelConfig : BaseEntityTypeConfig<Label, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Label> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);


            builder.Property(p => p.Description)
                .HasMaxLength(200);
        }
    }
}
