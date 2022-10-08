namespace Infrastructure.Main.Repository.Collaborator
{
    using Infrastructure.Main.Repository.Config.Interfaces;

    public class ConductRepository : BaseRepository<Conduct, string>, IConductRepository
    {
        public ConductRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
