namespace Infrastructure.Main.Context.Configuration.Config
{
    public class StatusConfig : BaseEntityTypeConfig<Status, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable(typeof(Conduct).Name, schema: "Config");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(b => b.ComponentsCollaborator)
                .WithOne(b => b.Status);

            builder.HasMany(b => b.Evaluations)
                .WithOne(b => b.Status);

            builder.HasMany(b => b.EvaluationComponents)
                .WithOne(b => b.Status);

            builder.HasMany(b => b.ComponentCollaboratorComments)
                .WithOne(b => b.Status);
        }
    }
}
