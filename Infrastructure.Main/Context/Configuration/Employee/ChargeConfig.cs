namespace Infrastructure.Main.Context.Configuration.Employee
{
    public class ChargeConfig : BaseEntityTypeConfig<Charge, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Charge> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
