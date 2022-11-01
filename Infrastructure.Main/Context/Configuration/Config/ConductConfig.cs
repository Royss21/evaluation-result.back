namespace Infrastructure.Main.Context.Configuration.Config
{
    public class ConductConfig : BaseEntityTypeConfig<Conduct, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Conduct> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(b => b.Level)
                .WithMany(b => b.Conducts);

            builder.HasOne(b => b.Subcomponent)
                .WithMany(b => b.Conducts);
        }
    }
}
