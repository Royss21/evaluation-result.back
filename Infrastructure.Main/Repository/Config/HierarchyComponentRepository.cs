namespace Infrastructure.Main.Repository.Collaborator
{
    using Infrastructure.Main.Repository.Config.Interfaces;

    public class HierarchyComponentRepository : BaseRepository<HierarchyComponent, int>, IHierarchyComponentRepository
    {
        public HierarchyComponentRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
