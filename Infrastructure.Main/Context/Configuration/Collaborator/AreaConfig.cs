

namespace Infrastructure.Main.Context.Configuration.Collaborator
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
