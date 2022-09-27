

namespace Domain.Main.Base
{

    using SharedKernell.BaseEntity;

    public abstract class BaseModel<TId> :BaseEntity<TId>, IBaseModel
    {
        public virtual string CreateUser { get; set; } = string.Empty;
        public virtual DateTimeOffset CreateDate { get; set; }
        public virtual string? EditUser { get; set; }
        public virtual DateTimeOffset? EditDate { get; set; }
        public virtual bool IsDeleted { get; set; }
    }

    public abstract class BaseModelActive<TId> : BaseModel<TId>
    {
        public virtual bool IsActive { get; set; }
    }

    public interface IBaseModel
    {
        string CreateUser { get; set; }
        DateTimeOffset CreateDate { get; set; }
        string? EditUser { get; set; }
        DateTimeOffset? EditDate { get; set; }
        bool IsDeleted { get; set; }
    }
}