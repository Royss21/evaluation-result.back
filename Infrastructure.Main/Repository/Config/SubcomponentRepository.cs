namespace Infrastructure.Main.Repository.Collaborator
{
    using Infrastructure.Main.Repository.Config.Interfaces;

    public class SubcomponentRepository : BaseRepository<Subcomponent, string>, ISubcomponentRepository
    {
        public SubcomponentRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
