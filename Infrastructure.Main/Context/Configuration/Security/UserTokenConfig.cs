﻿namespace Infrastructure.Main.Context.Configuration.Security
{
    using Domain.Main.Security;
    using Infrastructure.Main.Context.Base;
    public class UserTokenConfig : BaseEntityTypeConfig<UserToken, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<UserToken> builder)
        {
            builder.Property(p => p.Token)
                .IsRequired()
             .HasMaxLength(1000);

            builder.Property(p => p.RefreshToken)
                .IsRequired()
             .HasMaxLength(250);

            builder.HasOne(p => p.User)
                .WithOne(p => p.UserToken);
        }
    }
}
