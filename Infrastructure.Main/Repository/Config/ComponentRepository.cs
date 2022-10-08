namespace Infrastructure.Main.Repository.Collaborator
{
    using Infrastructure.Main.Repository.Config.Interfaces;

    public class ComponentRepository : BaseRepository<Component, int>, IComponentRepository
    {
        public ComponentRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
