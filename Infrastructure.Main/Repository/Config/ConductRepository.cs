namespace Infrastructure.Main.Repository.Config
{
    using Infrastructure.Main.Repository.Config.Interfaces;

    public class ConductRepository : BaseRepository<Conduct, Guid>, IConductRepository
    {
        public ConductRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
