namespace Infrastructure.Main.Repository.Config
{
    using Infrastructure.Main.Repository.Config.Interfaces;

    public class StageRepository : BaseRepository<Stage, int>, IStageRepository
    {
        public StageRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
