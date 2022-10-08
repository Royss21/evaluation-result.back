namespace Infrastructure.Main.Repository.Collaborator
{
    using Infrastructure.Main.Repository.Collaborator.Interfaces;

    public class HierarchyRepository : BaseRepository<Hierarchy, int>, IHierarchyRepository
    {
        public HierarchyRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
