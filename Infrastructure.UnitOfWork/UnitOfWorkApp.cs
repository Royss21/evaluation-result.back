
namespace Infrastructure.UnitOfWork
{
    using Infrastructure.Main.Context;
    using Infrastructure.UnitOfWork.Interfaces;

    public class UnitOfWorkApp : IUnitOfWorkApp, IDisposable
    {
        private readonly DbContextMain _context;
        private bool _disposed;
        public IUnitOfWorkRepository Repository { get; }

        public UnitOfWorkApp(DbContextMain context)
        {
            _context = context;
            Repository = new UnitOfWorkRepository(context);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _context.SaveChangesAsync();
            await _context.Database.CommitTransactionAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }

        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }
    }
}