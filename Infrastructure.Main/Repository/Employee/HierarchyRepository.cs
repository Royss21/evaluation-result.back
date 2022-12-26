namespace Infrastructure.Main.Repository.Employee
{
    using Infrastructure.Main.Repository.Employee.Interfaces;

    public class HierarchyRepository : BaseRepository<Hierarchy, int>, IHierarchyRepository
    {
        public HierarchyRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
