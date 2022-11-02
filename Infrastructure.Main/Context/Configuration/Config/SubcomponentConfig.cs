namespace Infrastructure.Main.Context.Configuration.Config
{
    public class SubcomponentConfig : BaseEntityTypeConfig<Subcomponent, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Subcomponent> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .HasMaxLength(200);

            builder.HasMany(b => b.Conducts)
                .WithOne(b => b.Subcomponent);

            builder.HasMany(b => b.SubcomponentValues)
               .WithOne(b => b.Subcomponent);

            builder.HasOne(b => b.Component)
                .WithMany(b => b.Subcomponents);

            builder.HasOne(b => b.Area)
                .WithMany(b => b.Subcomponents);

            builder.HasOne(b => b.Formula)
                .WithMany(b => b.Subcomponents);
        }
    }
}
