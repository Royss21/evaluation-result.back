namespace Infrastructure.Main.Context.Configuration.EvaResult
{
    using Domain.Main.EvaResult;

    public class ComponentCollaboratorDetailConfig : BaseEntityTypeConfig<ComponentCollaboratorDetail, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ComponentCollaboratorDetail> builder)
        {
            builder.Property(p => p.SubcomponentName)
             .IsRequired()
             .HasMaxLength(100);

            builder.Property(p => p.WeightRelative)
               .IsRequired()
               .HasDefaultValue(0);

            builder.Property(p => p.PercentMaximun)
              .IsRequired()
              .HasDefaultValue(0);

            builder.Property(p => p.PercentMinimun)
              .IsRequired()
              .HasDefaultValue(0);

            builder.Property(p => p.Result)
              .IsRequired()
              .HasDefaultValue(0);

            builder.Property(p => p.ResultCalibrated)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(p => p.ResultSimil)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(p => p.PointsTotalCalibrated)
                .IsRequired()
                .HasDefaultValue(0);
        }
    }
}
