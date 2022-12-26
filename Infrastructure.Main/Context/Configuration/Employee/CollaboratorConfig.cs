namespace Infrastructure.Main.Context.Configuration.Employee
{

    public class CollaboratorConfig : BaseEntityTypeConfig<Collaborator, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Collaborator> builder)
        {
            builder.ToTable(typeof(Collaborator).Name, schema: "Employee");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.DocumentNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.MiddleName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Code)
                .IsRequired(false)
                .HasMaxLength(20);

            builder.Property(p => p.DateBirthday).IsRequired(false);
            builder.Property(p => p.DateAdmission);
            builder.Property(p => p.DateEgress).IsRequired(false);

            builder.HasOne(b => b.Charge)
                .WithMany(b => b.Collaborators);
        }
    }
}
