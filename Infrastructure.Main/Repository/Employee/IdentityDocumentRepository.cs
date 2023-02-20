namespace Infrastructure.Main.Repository.Employee
{
    using Infrastructure.Main.Repository.Employee.Interfaces;

    public class IdentityDocumentRepository : BaseRepository<IdentityDocument, int>, IIdentityDocumentRepository
    {
        public IdentityDocumentRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
