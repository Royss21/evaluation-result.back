namespace Infrastructure.Main.Context.Configuration.Security
{
    using Domain.Main.Security;
    using Infrastructure.Main.Context.Base;
    public class UserConfig : BaseEntityTypeConfig<User, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.NameUser)
                .IsRequired()
              .HasMaxLength(100);

            builder.Property(p => p.Password)
                .IsRequired()
             .HasMaxLength(250);
        }
    }
}

