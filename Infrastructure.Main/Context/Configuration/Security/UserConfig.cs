namespace Infrastructure.Main.Context.Configuration.Security
{
    using Domain.Main.Security;
    using Infrastructure.Main.Context.Base;
    public class UserConfig : BaseEntityTypeConfig<User, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.UserName)
                .IsRequired()
              .HasMaxLength(100);

            builder.Property(p => p.Password)
                .IsRequired()
             .HasMaxLength(250);

            builder.HasMany(p => p.UserRoles)
               .WithOne(p => p.User);

            builder.HasMany(p => p.UserEndpointsLocked)
               .WithOne(p => p.User);
        }
    }
}

