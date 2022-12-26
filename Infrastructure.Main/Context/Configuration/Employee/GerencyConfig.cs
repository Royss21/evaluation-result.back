namespace Infrastructure.Main.Context.Configuration.Employee
{
    public class GerencyConfig : BaseEntityTypeConfig<Gerency, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Gerency> builder)
        {
            builder.ToTable(typeof(Gerency).Name, schema: "Employee");
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(b => b.Areas)
                .WithOne(b => b.Gerency);
        }
    }
}
