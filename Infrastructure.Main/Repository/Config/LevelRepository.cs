namespace Infrastructure.Main.Repository.Config
{
    using Infrastructure.Main.Repository.Config.Interfaces;

    public class LevelRepository : BaseRepository<Level, int>, ILevelRepository
    {
        public LevelRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
