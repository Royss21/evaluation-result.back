namespace Infrastructure.Main.Context.Configuration.Employee
{

    public class CollaboratorConfig : BaseEntityTypeConfig<Collaborator, string>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Collaborator> builder)
        {
            builder.Property(p => p.DocumentNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.FullName)
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
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.DateBirthday);
            builder.Property(p => p.DateAdmission);
            builder.Property(p => p.DateEgress);
        }
    }
}
