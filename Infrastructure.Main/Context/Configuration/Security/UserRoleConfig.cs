namespace Infrastructure.Main.Context.Configuration.Security
{
    using Domain.Main.Security;
    using Infrastructure.Main.Context.Base;
    public class UserRoleConfig : BaseEntityTypeConfig<UserRole, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasOne(p => p.User)
                .WithMany(p => p.UserRoles);

            builder.HasOne(p => p.Role)
                .WithMany(p => p.UserRoles);
        }
    }
}
