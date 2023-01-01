namespace Infrastructure.Main.Context.Configuration.Security
{
    using Domain.Main.Security;
    using Infrastructure.Main.Context.Base;
    public class RoleMenuConfig : BaseEntityTypeConfig<RoleMenu, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<RoleMenu> builder)
        {
            builder.ToTable(typeof(RoleMenu).Name, schema: "Security");

            builder.HasOne(p => p.Role)
                .WithMany(p => p.RolesMenu);

            builder.HasOne(p => p.Menu)
                .WithMany(p => p.RolesMenu);
        }
    }
}
