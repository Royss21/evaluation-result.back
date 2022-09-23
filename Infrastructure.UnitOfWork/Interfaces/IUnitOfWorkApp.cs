using SharedKernell.Nucleo;

namespace Infrastructure.UnitOfWork.Interfaces
{
    public interface IUnitOfWorkApp : IUnitOfWork
    {
         IUnitOfWorkRepositorio Repositorio { get; }
    }
}
