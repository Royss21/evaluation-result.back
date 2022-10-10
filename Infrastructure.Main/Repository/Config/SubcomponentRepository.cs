namespace Infrastructure.Main.Repository.Config
{
    using Infrastructure.Main.Repository.Config.Interfaces;

    public class SubcomponentRepository : BaseRepository<Subcomponent, string>, ISubcomponentRepository
    {
        public SubcomponentRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
