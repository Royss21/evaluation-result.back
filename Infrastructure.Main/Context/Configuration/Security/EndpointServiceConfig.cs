

namespace Infrastructure.Main.Context.Configuration.Security
{
    using Infrastructure.Main.Context.Base;
    public class EndpointServiceConfig : BaseEntityTypeConfig<EndpointService, string>
    {
        public override void ConfigureEntity(EntityTypeBuilder<EndpointService> builder)
        {
            builder.Property(p => p.Entity)
                .HasMaxLength(100);

            builder.Property(p => p.Method)
                .HasMaxLength(100);

            builder.Property(p => p.Controller)
                .HasMaxLength(100);

            builder.Property(p => p.Action)
                .HasMaxLength(100);

            builder.Property(p => p.PathEndpoint)
                .HasMaxLength(100);

        }
    }
}
