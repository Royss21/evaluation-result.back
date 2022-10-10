namespace Infrastructure.Main.Repository.EvaResult
{
    using Infrastructure.Main.Repository.EvaResult.Interfaces;

    public class EvaluationStageRepository : BaseRepository<EvaluationStage, int>, IEvaluationStageRepository
    {
        public EvaluationStageRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
