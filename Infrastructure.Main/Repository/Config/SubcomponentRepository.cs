namespace Infrastructure.Main.Repository.Config
{
    using Infrastructure.Main.Repository.Config.Interfaces;

    public class SubcomponentRepository : BaseRepository<Subcomponent, Guid>, ISubcomponentRepository
    {
        public SubcomponentRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
