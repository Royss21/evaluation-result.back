namespace Infrastructure.Main.Repository.Security
{
    using Domain.Main.Security;
    using Infrastructure.Main.Repository.Security.Interfaces;

    public class AuditRepository : BaseRepository<AuditEntity, int>, IAuditRepository
    {
        public AuditRepository(DbContextMain dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
