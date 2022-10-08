namespace Infrastructure.Main.Context.Configuration.Security
{
    using Domain.Main.Security;
    using Infrastructure.Main.Context.Base;
    public class UserRoleConfig : BaseEntityTypeConfig<UserRole, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<UserRole> builder)
        {

        }
    }
}
