namespace Infrastructure.Main.Context.Configuration.Security
{
    using Domain.Main.Security;
    using Infrastructure.Main.Context.Base;
    public class RoleConfig : BaseEntityTypeConfig<Role, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(typeof(Role).Name, schema: "Security");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Description)
                .HasMaxLength(200);

            builder.HasMany(p => p.RolesMenu)
                .WithOne(p => p.Role);

            builder.HasMany(p => p.UserRoles)
                .WithOne(p => p.Role);
        }
    }
}
