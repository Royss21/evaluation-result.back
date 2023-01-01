

namespace Infrastructure.Main.Context.Configuration.Security
{
    using Infrastructure.Main.Context.Base;
    public class UserEnpointLockedConfig : BaseEntityTypeConfig<UserEndpointLocked, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<UserEndpointLocked> builder)
        {
            builder.ToTable(typeof(UserEndpointLocked).Name, schema: "Security");
            builder.HasOne(p => p.User)
               .WithMany(p => p.UserEndpointsLocked);

            builder.HasOne(p => p.EndpointService)
               .WithMany(p => p.UserEndpointsLocked);
        }
    }
}
