namespace Infrastructure.Main.Repository.Collaborator
{
    using Infrastructure.Main.Repository.Collaborator.Interfaces;

    public class GerencyRepository : BaseRepository<Gerency, int>, IGerencyRepository
    {
        public GerencyRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
