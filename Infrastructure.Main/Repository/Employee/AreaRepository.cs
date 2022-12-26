namespace Infrastructure.Main.Repository.Employee
{
    using Infrastructure.Main.Repository.Employee.Interfaces;

    public class AreaRepository : BaseRepository<Area, int>, IAreaRepository
    {
        public AreaRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
