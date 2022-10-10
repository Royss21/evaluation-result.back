namespace Infrastructure.Main.Repository.EvaResult
{
    using Infrastructure.Main.Repository.EvaResult.Interfaces;

    public class EvaluationLeaderRepository : BaseRepository<EvaluationLeader, int>, IEvaluationLeaderRepository
    {
        public EvaluationLeaderRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
