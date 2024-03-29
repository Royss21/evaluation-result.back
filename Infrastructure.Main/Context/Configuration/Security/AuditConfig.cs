﻿namespace Infrastructure.Main.Context.Configuration.Security
{
    using Domain.Main.Security;
    using Infrastructure.Main.Context.Base;
    public class AuditConfig : BaseEntityTypeConfig<AuditEntity, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<AuditEntity> builder)
        {
            builder.Property(p => p.KeyValues)
                .HasMaxLength(5000);

            builder.Property(p => p.NewValues)
                .HasMaxLength(100000);

            builder.Property(p => p.OldValues)
                .HasMaxLength(100000);

            builder.Property(p => p.TableName)
                .HasMaxLength(50);
        }
    }
}
