namespace Infrastructure.Main.Context.Configuration.EvaResult
{
    using Domain.Main.EvaResult;

    public class ComponentCollaboratorDetailConfig : BaseEntityTypeConfig<ComponentCollaboratorDetail, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ComponentCollaboratorDetail> builder)
        {
            builder.ToTable(typeof(ComponentCollaboratorDetail).Name, schema: "EvaResult");
            builder.Property(p => p.SubcomponentName)
             .IsRequired()
             .HasMaxLength(100);

            builder.Property(p => p.WeightRelative)
               .IsRequired()
               .HasDefaultValue(0);

            builder.Property(p => p.MaximunPercentage)
              .IsRequired()
              .HasDefaultValue(0);

            builder.Property(p => p.MinimunPercentage)
              .IsRequired()
              .HasDefaultValue(0);

            builder.Property(p => p.Result)
              .IsRequired()
              .HasDefaultValue(0);


            builder.Property(p => p.Result)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(p => p.Compliance)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(p => p.Points)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(p => p.PointsCalibrated)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(p => p.FormulaName)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.FormulaQuery)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.FormulaValues)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne(b => b.ComponentCollaborator)
                .WithMany(b => b.ComponentCollaboratorDetails);

            builder.HasMany(b => b.ComponentCollaboratorConducts)
               .WithOne(b => b.ComponentCollaboratorDetail)
               .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
