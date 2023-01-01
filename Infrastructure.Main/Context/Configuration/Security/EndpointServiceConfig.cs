

namespace Infrastructure.Main.Context.Configuration.Security
{
    using Infrastructure.Main.Context.Base;
    public class EndpointServiceConfig : BaseEntityTypeConfig<EndpointService, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<EndpointService> builder)
        {
            builder.ToTable(typeof(EndpointService).Name, schema: "Security");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

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

            builder.HasMany(p => p.UserEndpointsLocked)
                .WithOne(p => p.EndpointService);
        }
    }
}
