namespace Infrastructure.Main.Context.Configuration.Employee
{
    public class GerencyConfig : BaseEntityTypeConfig<Gerency, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Gerency> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(b => b.Areas)
                .WithOne(b => b.Gerency);
        }
    }
}
