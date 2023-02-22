namespace Infrastructure.Main.Context.Configuration.Security
{
    using Domain.Main.Security;
    using Infrastructure.Main.Context.Base;
    public class LogConfig : BaseEntityTypeConfig<LogEntity, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<LogEntity> builder)
        {
            builder.ToTable(typeof(LogEntity).Name, schema: "Security");

            builder.Property(p => p.StackTrace)
                .HasMaxLength(5000);

            builder.Property(p => p.Message)
                .HasMaxLength(5000);

            builder.Property(p => p.InnerExceptionMessage)
                .HasMaxLength(100000);

            builder.Property(p => p.FullNameService)
                .HasMaxLength(5000);

            builder.Property(p => p.TypeException)
                .HasMaxLength(500);
        }
    }
}
