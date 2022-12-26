namespace Infrastructure.Main.Context.Configuration.EvaResult
{
    using Domain.Main.EvaResult;

    public class ComponentCollaboratorConductConfig : BaseEntityTypeConfig<ComponentCollaboratorConduct, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ComponentCollaboratorConduct> builder)
        {
            builder.ToTable(typeof(ComponentCollaboratorConduct).Name, schema: "EvaResult");
            builder.Property(p => p.LevelName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.ConductDescription)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(p => p.ConductPoints)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(p => p.ConductPointsCalibrated)
                .IsRequired()
                .HasDefaultValue(0);

            builder.HasOne(b => b.ComponentCollaboratorDetail)
                .WithMany(b => b.ComponentCollaboratorConducts);
        }
    }
}
