
namespace Infrastructure.UnitOfWork.Interfaces
{
    using SharedKernell.Core;
    public interface IUnitOfWorkApp : IUnitOfWork
    {
         IUnitOfWorkRepository Repository { get; }
    }
}
