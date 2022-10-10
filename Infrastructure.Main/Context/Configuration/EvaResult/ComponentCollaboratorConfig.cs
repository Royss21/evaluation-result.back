namespace Infrastructure.Main.Context.Configuration.EvaResult
{
    using Domain.Main.EvaResult;


    public class ComponentCollaboratorConfig : BaseEntityTypeConfig<ComponentCollaborator, string>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ComponentCollaborator> builder)
        {
            builder.Property(p => p.HierarchyName)
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(p => p.ComponentName)
              .IsRequired()
              .HasMaxLength(100);

            builder.Property(p => p.WeightHierarchy)
               .IsRequired()
               .HasDefaultValue(0);

            builder.Property(p => p.SubTotal)
               .IsRequired()
               .HasDefaultValue(0);

            builder.Property(p => p.Total)
               .IsRequired()
               .HasDefaultValue(0);

            builder.Property(p => p.TotalCalibrated)
               .IsRequired()
               .HasDefaultValue(0);

            builder.Property(p => p.Surplus)
               .IsRequired()
               .HasDefaultValue(0);

            builder.Property(p => p.Comment)
               .IsRequired()
               .HasMaxLength(300);

            builder.Property(p => p.CommentCollaborator)
               .IsRequired()
               .HasMaxLength(300);

        }
    }
}
