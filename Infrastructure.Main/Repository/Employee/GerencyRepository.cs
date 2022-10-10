namespace Infrastructure.Main.Repository.Employee
{
    using Infrastructure.Main.Repository.Employee.Interfaces;

    public class GerencyRepository : BaseRepository<Gerency, int>, IGerencyRepository
    {
        public GerencyRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
