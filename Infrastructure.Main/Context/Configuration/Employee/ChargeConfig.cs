namespace Infrastructure.Main.Context.Configuration.Employee
{
    public class ChargeConfig : BaseEntityTypeConfig<Charge, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Charge> builder)
        {
            builder.ToTable(typeof(Charge).Name, schema: "Employee");
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(b => b.Area)
                  .WithMany(b => b.Charges);

            builder.HasOne(b => b.Hierarchy)
                 .WithMany(b => b.Charges);

            builder.HasMany(b => b.Collaborators)
                .WithOne(b => b.Charge);
        }
    }
}
