namespace Infrastructure.Main.Context.Configuration.Employee
{
    public class IdentityDocumentConfig : BaseEntityTypeConfig<IdentityDocument, int>
    {
        public override void ConfigureEntity(EntityTypeBuilder<IdentityDocument> builder)
        {
            builder.ToTable(typeof(IdentityDocument).Name, schema: "Employee");
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(b => b.Collaborators)
                .WithOne(b => b.IdentityDocument);
        }
    }
}
