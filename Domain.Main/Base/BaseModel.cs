

namespace Domain.Main.Base
{

    using SharedKernell.BaseEntity;

    public abstract class BaseModel<TId> :BaseEntity<TId>, IBaseModel
    {
        public virtual string CreateUser { get; set; } = string.Empty;
        public virtual DateTime CreateDate { get; set; }
        public virtual string? EditUser { get; set; }
        public virtual DateTime? EditDate { get; set; }
        public virtual bool IsDeleted { get; set; }
    }

    public abstract class BaseModelActive<TId> : BaseModel<TId>
    {
        public virtual bool IsActive { get; set; }
    }

    public interface IBaseModel
    {
        string CreateUser { get; set; }
        DateTime CreateDate { get; set; }
        string? EditUser { get; set; }
        DateTime? EditDate { get; set; }
        bool IsDeleted { get; set; }
    }
}