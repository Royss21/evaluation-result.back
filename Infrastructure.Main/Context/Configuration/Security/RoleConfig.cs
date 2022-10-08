namespace Infrastructure.Main.Context.Configuration.Security
{
    using Domain.Main.Security;
    using Infrastructure.Main.Context.Base;
    public class RoleConfig : BaseEntityTypeConfig<Role, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Role> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Description)
                .HasMaxLength(200);
        }
    }
}
