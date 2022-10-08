namespace Infrastructure.Main.Repository.Collaborator
{
    using Infrastructure.Main.Repository.Config.Interfaces;

    public class LevelRepository : BaseRepository<Level, int>, ILevelRepository
    {
        public LevelRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
