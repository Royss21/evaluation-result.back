namespace Infrastructure.Main.Context.Configuration.Security
{
    using Domain.Main.Security;
    using Infrastructure.Main.Context.Base;
    public class MenuConfig : BaseEntityTypeConfig<Menu, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Menu> builder)
        {
            //builder.Property(p => p.Name)
            //    .IsRequired()
            //    .HasMaxLength(100);

            //builder.Property(p => p.Url)
            //    .IsRequired()
            //    .HasMaxLength(300);

            //builder.Property(p => p.Icon)
            //    .HasMaxLength(50);
        }
    }
}
