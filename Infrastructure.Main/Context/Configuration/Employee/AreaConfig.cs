namespace Infrastructure.Main.Context.Configuration.Employee
{

    public class AreaConfig : BaseEntityTypeConfig<Area, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Area> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
