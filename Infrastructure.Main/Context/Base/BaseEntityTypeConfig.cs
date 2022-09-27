
namespace Infrastructure.Main.Context.Base
{
    using Domain.Main.Base;

    public abstract class BaseEntityTypeConfig<TEntity, TId> : 
        IEntityTypeConfiguration<TEntity>
        where TEntity : BaseModel<TId>
    {
        public abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            ConfigureEntity(builder);

            builder.Property(p => p.CreateDate).IsRequired();
            builder.Property(p => p.CreateUser).IsRequired().HasMaxLength(50);
            builder.Property(p => p.EditDate);
            builder.Property(p => p.EditUser).HasMaxLength(50);
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);
        }
    }
}
