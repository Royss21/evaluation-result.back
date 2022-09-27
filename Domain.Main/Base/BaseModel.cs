
using SharedKernell.BaseEntity;

namespace Domain.Main.Base
{

    public abstract class BaseModel<TId> :
        BaseEntity<TId>,
        IBaseModel
    {
        public virtual string CreateUser { get; set; } = string.Empty;
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
        string CreateUser { get; set; }
        DateTimeOffset CreateDate { get; set; }
        string? EditUser { get; set; }
        DateTimeOffset? EditDate { get; set; }
        bool IsDelete { get; set; }
    }

    public interface IBaseCompania
    {
        Guid CompaniaId { get; set; }
    }

}