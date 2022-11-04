namespace Infrastructure.Main.Context.Configuration.EvaResult
{
    using Domain.Main.EvaResult;


    public class ComponentCollaboratorConfig : BaseEntityTypeConfig<ComponentCollaborator, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ComponentCollaborator> builder)
        {
            builder.ToTable(typeof(ComponentCollaborator).Name, schema: "EvaResult");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

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

            builder.Property(p => p.ExcessSubtotal)
             .IsRequired()
             .HasDefaultValue(0);

            builder.Property(p => p.Total)
               .IsRequired()
               .HasDefaultValue(0);

            builder.Property(p => p.TotalCalibrated)
               .IsRequired()
               .HasDefaultValue(0);

            builder.Property(p => p.Excess)
               .IsRequired()
               .HasDefaultValue(0);

            builder.HasOne(b => b.EvaluationComponent)
                    .WithMany(b => b.ComponentsCollaborator);

            builder.HasOne(b => b.EvaluationCollaborator)
                    .WithMany(b => b.ComponentsCollaborator);

            builder.HasMany(b => b.ComponentCollaboratorDetails)
                    .WithOne(b => b.ComponentCollaborator);

        }
    }
}
