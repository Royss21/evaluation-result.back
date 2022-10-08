namespace Infrastructure.Main.Context.Configuration.Security
{
    using Domain.Main.Security;
    using Infrastructure.Main.Context.Base;
    public class AuditConfig : BaseEntityTypeConfig<AuditEntity, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<AuditEntity> builder)
        {
            builder.Property(p => p.KeyValues).HasMaxLength(int.MaxValue);
            builder.Property(p => p.NewValues).HasMaxLength(int.MaxValue);
            builder.Property(p => p.OldValues).HasMaxLength(int.MaxValue);
            builder.Property(p => p.TableName).HasMaxLength(50);
        }
    }
}
