
namespace Infrastructure.UnitOfWork
{
    using Infrastructure.Main.Contexto;
    using Infrastructure.UnitOfWork.Interfaces;

    public class UnitOfWorkApp : IUnitOfWorkApp, IDisposable
    {
        private readonly DbContextoPrincipal _contextoPrincipal;
        private bool _disposed;
        public IUnitOfWorkRepositorio Repositorio { get; }

        public UnitOfWorkApp(DbContextoPrincipal contextoPrincipal)
        {
            _contextoPrincipal = contextoPrincipal;
            Repositorio = new UnitOfWorkRepository(contextoPrincipal);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task SaveChangesAsync()
        {
            return _contextoPrincipal.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            await _contextoPrincipal.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _contextoPrincipal.SaveChangesAsync();
            await _contextoPrincipal.Database.CommitTransactionAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _contextoPrincipal.Dispose();
            _disposed = true;
        }

        public void RollbackTransaction()
        {
            _contextoPrincipal.Database.RollbackTransaction();
        }
    }
}