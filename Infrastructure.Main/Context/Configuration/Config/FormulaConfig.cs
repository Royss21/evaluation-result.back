namespace Infrastructure.Main.Context.Configuration.Config
{
    public class FormulaConfig : BaseEntityTypeConfig<Formula, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Formula> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Description)
                        .HasMaxLength(250);

            builder.Property(p => p.Name)
                        .HasMaxLength(100)
                        .IsRequired();

            builder.Property(p => p.FormulaReal)
                        .HasMaxLength(500)
                        .IsRequired();

            builder.Property(p => p.FormulaQuery)
                        .HasMaxLength(500)
                        .IsRequired();

            builder.HasMany(c => c.Subcomponents)
                .WithOne(c => c.Formula);
        }
    }
}
