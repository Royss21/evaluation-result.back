
namespace Domain.Main.Base
{
    using SharedKernell.EntidadBase;
    public abstract class BaseModelo<TId> :
        EntidadBase<TId>,
        IBaseModelo
    {
        public virtual string UsuarioCrea { get; set; } = string.Empty;
        public virtual DateTimeOffset FechaCrea { get; set; }
        public virtual string? UsuarioEdita { get; set; }
        public virtual DateTimeOffset? FechaEdita { get; set; }
        public virtual bool EsEliminado { get; set; }
    }

    public abstract class BaseModeloActivo<TId> : BaseModelo<TId>
    {
        public virtual bool EsActivo { get; set; }
    }

    public interface IBaseModelo
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