
namespace Infraestructure.Data.Core.EntityConfig
{
    using Domain.Main.Base;
    public abstract class BaseEntityTypeConfiguracion<TEntity, TId> : 
        IEntityTypeConfiguration<TEntity>
        where TEntity : BaseModel<TId>
    {
        public abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            ConfigureEntity(builder);

            builder.Property(p => p.FechaCrea).IsRequired();
            builder.Property(p => p.UsuarioCrea).IsRequired().HasMaxLength(50);
            builder.Property(p => p.FechaEdita);
            builder.Property(p => p.UsuarioEdita).HasMaxLength(50);
            builder.Property(p => p.EsEliminado).HasDefaultValue(false);
        }
    }
}
