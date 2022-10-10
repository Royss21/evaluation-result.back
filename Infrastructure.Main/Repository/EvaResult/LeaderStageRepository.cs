namespace Infrastructure.Main.Repository.EvaResult
{
    using Infrastructure.Main.Repository.EvaResult.Interfaces;

    public class LeaderStageRepository : BaseRepository<LeaderStage, int>, ILeaderStageRepository
    {
        public LeaderStageRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
