
namespace Domain.Main.Base
{
    using SharedKernell.EntidadBase;
    public abstract class BaseModel<TId> :
        BaseEntity<TId>,
        IBaseModel
    {
        public virtual string UsuarioCrea { get; set; } = string.Empty;
        public virtual DateTimeOffset FechaCrea { get; set; }
        public virtual string? UsuarioEdita { get; set; }
        public virtual DateTimeOffset? FechaEdita { get; set; }
        public virtual bool EsEliminado { get; set; }
    }

    public abstract class BaseModelActivo<TId> : BaseModel<TId>
    {
        public virtual bool EsActivo { get; set; }
    }

    public interface IBaseModel
    {
        string UsuarioCrea { get; set; }
        DateTimeOffset FechaCrea { get; set; }
        string? UsuarioEdita { get; set; }
        DateTimeOffset? FechaEdita { get; set; }
        bool EsEliminado { get; set; }
    }

    public interface IBaseCompania
    {
        Guid CompaniaId { get; set; }
    }

}