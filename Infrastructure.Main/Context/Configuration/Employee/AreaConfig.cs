namespace Infrastructure.Main.Context.Configuration.Employee
{

    public class AreaConfig : BaseEntityTypeConfig<Area, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Area> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(b => b.Gerency)
                .WithMany(b => b.Areas);

            builder.HasMany(b => b.Charges)
                    .WithOne(b => b.Area);

            builder.HasMany(b => b.Subcomponents)
                   .WithOne(b => b.Area);
        }
    }
}
