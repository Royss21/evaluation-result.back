namespace Infrastructure.Main.Repository.Config
{
    using Infrastructure.Main.Repository.Config.Interfaces;

    public class ConductRepository : BaseRepository<Conduct, string>, IConductRepository
    {
        public ConductRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
